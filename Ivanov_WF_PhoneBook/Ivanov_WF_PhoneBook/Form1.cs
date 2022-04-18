using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

/*
    Разработать программу-телефонный справочник, которая имеет следующие функции:
    - добавление контакта в отдельном окне
    - редактирование контакта в отдельном окне
    - просмотр контакта в отдельном окне
    - удаление контакта
    - при добавлении и редактировании контакта пользователь может добавить фото
    - поля контакта: ФИО, телефон, адрес, описание, фото, категория контакта
    - при выходе из программы все контакты сохраняются, при входе они загружаются
*/

/*
    CREATE TABLE Contacts
    (
	    [id]		  [int]		IDENTITY primary key,
	    [name]		  [varchar] (80)  NULL,
	    [phone]		  [varchar] (15)  NULL,
	    [address]	  [varchar] (200) NULL,
	    [category]	  [varchar] (10)  NULL,
	    [description] [varchar] (300) NULL,
	    [photo]       [image]         NULL,
	    [width]		  [int]			  NULL,
	    [height]	  [int]			  NULL
    )
*/

namespace Ivanov_WF_PhoneBook
{
    public partial class Form1 : Form
    {
        int w, h;
        int currentID = 0;

        SqlConnection cn;

        public Form1()
        {
            InitializeComponent();
            SetListViewParameters();
            cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["Ivanov_WF_PhoneBook.Properties.Settings.Ivanov_PhoneBook_ConnectionString"].ConnectionString;
        }

        //задать параметры ListView
        public void SetListViewParameters()
        {
            //изменение режима отображения listView
            listView1.View = View.Details;

            //создание столбцов
            listView1.Columns.Add("ID", 70, HorizontalAlignment.Left);
            listView1.Columns.Add("Name", 300, HorizontalAlignment.Left);
            listView1.Columns.Add("Phone", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Address", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Description", 200, HorizontalAlignment.Left);

            //создание групп
            listView1.Groups.Add("listViewGroup1", "Family");
            listView1.Groups.Add("listViewGroup2", "Friends");
            listView1.Groups.Add("listViewGroup3", "Business");           
        }

        //--------------------------------------------------------------------------------------------------
        //ADD
        private void addButton_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.Owner = this;
            add.PerformAddContact += AddContactToListView;
            DialogResult res = add.ShowDialog();
        }

        private void AddContactToListView(string _name, string _phone, string _address, 
                                          string _category, string _description, string _photo)
        {            
            //добавление данных в ListView
            ListViewItem item = new ListViewItem($"{++currentID}");
            if (_photo != null)
                item.Tag = true;
            else
                item.Tag = false;
            item.Checked = false;
            item.SubItems.Add(_name);
            item.SubItems.Add(_phone);
            item.SubItems.Add(_address);
            item.SubItems.Add(_description);
            if (_category == " Family")
                item.Group = listView1.Groups[0];
            else if (_category == " Friends")
                item.Group = listView1.Groups[1];
            else if (_category == " Business")
                item.Group = listView1.Groups[2];
            listView1.Items.Add(item);

            //добавляем данные в БД
            AddData(_name, _phone, _address, _category, _description, _photo);          
        }

        int bytes;

        public void AddData(string n, string p, string a, string c, string d, string ph)
        {
            if (ph != null)
            {
                Bitmap bmp = new Bitmap(ph);
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                bytes = bmpData.Stride * bmp.Height;
                byte[] rgbValues = new byte[bytes];
                Marshal.Copy(ptr, rgbValues, 0, bytes);
                bmp.UnlockBits(bmpData);
                cn.Open();
                string command = $"insert into contacts(name, phone, address, category, description, photo, width, height)" +
                                 $"values ('{n}', '{p}', '{a}', '{c}', '{d}', @photo, '{bmp.Width}', '{bmp.Height}')";
                SqlCommand cmd = new SqlCommand(command, cn);
                SqlParameter param = new SqlParameter("@photo", SqlDbType.Image, rgbValues.Length);
                param.Value = rgbValues;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            else
            {
                cn.Open();
                string command = $"insert into contacts(name, phone, address, category, description)" +
                                 $"values ('{n}', '{p}', '{a}', '{c}', '{d}')";
                SqlCommand cmd = new SqlCommand(command, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }           
        }

        //--------------------------------------------------------------------------------------------------
        //EDIT
        private void editButton_Click(object sender, EventArgs e)
        {
            Edit edit = new Edit();
            edit.Owner = this;
            edit.PerformEditContact += EditContact;
            DialogResult res = edit.ShowDialog();
        }

        private void EditContact(string _name, string _phone, string _address,
                                 string _category, string _description, string _photo)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                string _id = listView1.SelectedItems[0].SubItems[0].Text;
                EditData(_id, _name, _phone, _address, _category, _description, _photo);
            }
            else
                MessageBox.Show("Select some id for edit contact");
        }

        public void EditData(string id, string n, string p, string a, string c, string d, string ph)
        {
            if (ph != null)
            {
                Bitmap bmp = new Bitmap(ph);
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                bytes = bmpData.Stride * bmp.Height;
                byte[] rgbValues = new byte[bytes];
                Marshal.Copy(ptr, rgbValues, 0, bytes);
                bmp.UnlockBits(bmpData);

                cn.Open();
                string command = $"update contacts set name = @name, phone = @phone, address = @address, category = @category, description = @description, photo = @photo, width = @width, height = @height where id = @id";
                SqlCommand cmd = new SqlCommand(command, cn);

                SqlParameter param1 = new SqlParameter("@name", SqlDbType.VarChar, 80);
                param1.Value = n;
                cmd.Parameters.Add(param1);
                SqlParameter param2 = new SqlParameter("@phone", SqlDbType.VarChar, 15);
                param2.Value = p;
                cmd.Parameters.Add(param2);
                SqlParameter param3 = new SqlParameter("@address", SqlDbType.VarChar, 200);
                param3.Value = a;
                cmd.Parameters.Add(param3);
                SqlParameter param4 = new SqlParameter("@category", SqlDbType.VarChar, 10);
                param4.Value = c;
                cmd.Parameters.Add(param4);
                SqlParameter param5 = new SqlParameter("@description", SqlDbType.VarChar, 300);
                param5.Value = d;
                cmd.Parameters.Add(param5);
                SqlParameter param6 = new SqlParameter("@photo", SqlDbType.Image, rgbValues.Length);
                param6.Value = rgbValues;
                cmd.Parameters.Add(param6);
                SqlParameter param7 = new SqlParameter("@width", SqlDbType.Int);
                param7.Value = bmp.Width;
                cmd.Parameters.Add(param7);
                SqlParameter param8 = new SqlParameter("@height", SqlDbType.Int);
                param8.Value = bmp.Height;
                cmd.Parameters.Add(param8);
                SqlParameter param9 = new SqlParameter("@id", SqlDbType.Int);
                param9.Value = id;
                cmd.Parameters.Add(param9);

                cmd.ExecuteNonQuery();
                cn.Close();             
            }
            else
            {
                cn.Open();
                string command = $"update contacts set name = @name, phone = @phone, address = @address, category = @category, description = @description where id = @id";
                SqlCommand cmd = new SqlCommand(command, cn);

                SqlParameter param1 = new SqlParameter("@name", SqlDbType.VarChar, 80);
                param1.Value = n;
                cmd.Parameters.Add(param1);
                SqlParameter param2 = new SqlParameter("@phone", SqlDbType.VarChar, 15);
                param2.Value = p;
                cmd.Parameters.Add(param2);
                SqlParameter param3 = new SqlParameter("@address", SqlDbType.VarChar, 200);
                param3.Value = a;
                cmd.Parameters.Add(param3);
                SqlParameter param4 = new SqlParameter("@category", SqlDbType.VarChar, 10);
                param4.Value = c;
                cmd.Parameters.Add(param4);
                SqlParameter param5 = new SqlParameter("@description", SqlDbType.VarChar, 300);
                param5.Value = d;
                cmd.Parameters.Add(param5);
                SqlParameter param6 = new SqlParameter("@id", SqlDbType.Int);
                param6.Value = id;
                cmd.Parameters.Add(param6);

                cmd.ExecuteNonQuery();
                cn.Close();
            }

            //удалить строку в listView1
            foreach (ListViewItem i in listView1.SelectedItems)
            {
                listView1.Items.Remove(i);
            }

            //создать новую строку в listView1
            ListViewItem item = new ListViewItem($"{id}");
            if (ph != null)
                item.Tag = true;
            else
                item.Tag = false;
            item.Checked = false;
            item.SubItems.Add(n);
            item.SubItems.Add(p);
            item.SubItems.Add(a);
            item.SubItems.Add(d);
            if (c == " Family")
                item.Group = listView1.Groups[0];
            else if (c == " Friends")
                item.Group = listView1.Groups[1];
            else if (c == " Business")
                item.Group = listView1.Groups[2];
            listView1.Items.Add(item);
        }

        //--------------------------------------------------------------------------------------------------
        //SHOW
        private void showButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                string id = listView1.SelectedItems[0].SubItems[0].Text;
                string name = listView1.SelectedItems[0].SubItems[1].Text;
                string phone = listView1.SelectedItems[0].SubItems[2].Text;
                string address = listView1.SelectedItems[0].SubItems[3].Text;
                string category = listView1.SelectedItems[0].Group.Header;
                string description = listView1.SelectedItems[0].SubItems[4].Text;

                //если фото существует, то показать окно с фото
                if ((bool)listView1.SelectedItems[0].Tag == true)
                {
                    Bitmap photo = GetPhoto(id);
                    Show show = new Show(name, phone, address, category, description, photo);
                    show.Owner = this;
                    show.Show();
                }
                else
                {
                    Show show = new Show(name, phone, address, category, description, null);
                    show.Owner = this;
                    show.Show();
                }
            }
            else
                MessageBox.Show("Select some id for show contact");
        }

        public Bitmap GetPhoto(string id)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = $"select id, name, phone, address, category, description, photo, width, height from contacts " +
                              $"where id = {id}";
            byte[] rgbValues = null;
            long l = 0;

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);          
            while (dr.Read())
            {
                long length = dr.GetBytes(6, 0, null, 0, 0);
                rgbValues = new byte[length];
                l = dr.GetBytes(6, 0, rgbValues, 0, (int)length);       
            }
            cn.Close();

            //приходится еще раз открывать поток, что бы считать размеры изображения
            cn.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = cn;
            cmd2.CommandText = $"select id, name, phone, address, category, description, photo, width, height from contacts " +
                               $"where id = {id}";
            SqlDataReader dr2 = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr2.Read())
            {
                w = Convert.ToInt32(dr2["width"]);
                h = Convert.ToInt32(dr2["height"]);
            }
            cn.Close();

            Bitmap bmp = new Bitmap(w, h, PixelFormat.Format24bppRgb);
            Rectangle rect = new Rectangle(0, 0, w, h);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);

            IntPtr ptr = bmpData.Scan0;
            Marshal.Copy(rgbValues, 0, ptr, (int)l);
            bmp.UnlockBits(bmpData);
            return bmp;
        }

        //--------------------------------------------------------------------------------------------------
        //DELETE
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                cn.Open();
                string id = listView1.SelectedItems[0].SubItems[0].Text;
                string name = listView1.SelectedItems[0].SubItems[1].Text;
                string command = $"delete from contacts where id = {id}";
                SqlCommand cmd = new SqlCommand(command, cn);
                cmd.ExecuteNonQuery();
                cn.Close();

                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    listView1.Items.Remove(item);
                }
                //MessageBox.Show($"{name} was successfully deleted!");
            }
            else
                MessageBox.Show("Select some id for delete contact");
        }

        //загрузка данных при старте
        private void Form1_Load(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "select * from contacts";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(Convert.ToString(dr.GetInt32(0)));
                item.SubItems.Add(dr.GetString(1));
                item.SubItems.Add(dr.GetString(2));
                item.SubItems.Add(dr.GetString(3));
                item.SubItems.Add(dr.GetString(5));

                if (dr.GetString(4) == " Family")
                    item.Group = listView1.Groups[0];
                else if (dr.GetString(4) == " Friends")
                    item.Group = listView1.Groups[1];
                else if (dr.GetString(4) == " Business")
                    item.Group = listView1.Groups[2];

                if (!dr.IsDBNull(6))
                    item.Tag = true;
                else
                    item.Tag = false;

                listView1.Items.Add(item);
            }
            cn.Close();

            //посчитать текущий ID
            foreach (ListViewItem i in listView1.Items)
            {
                if (Convert.ToInt32(i.Text) > currentID)
                    currentID = Convert.ToInt32(i.Text);
            }
        }

        //exit
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //navicon
        private void navicon_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 203)
            {
                panel1.Width = 51;
                label1.Visible = false;
                navicon.Dock = DockStyle.Top;
                navicon.BackgroundImageLayout = ImageLayout.Tile;
                foreach (Button b in panel1.Controls.OfType<Button>())
                {
                    b.Text = "";
                    b.ImageAlign = ContentAlignment.MiddleLeft;
                    b.Padding = new Padding(10, 0, 0, 0);
                }
            }
            else
            {
                panel1.Width = 203;
                label1.Visible = true;
                navicon.Dock = DockStyle.None;
                foreach (Button b in panel1.Controls.OfType<Button>())
                {
                    b.Text = "      " + b.Tag.ToString();
                    b.ImageAlign = ContentAlignment.MiddleLeft;
                    b.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }
    }
}
