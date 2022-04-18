using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ivanov_WF_PhoneBook
{
    public delegate void AddDelegate(string name, string phone, string address, 
                                     string category, string description, string photo);

    public partial class Add : Form
    {
        public event AddDelegate PerformAddContact;

        public Add()
        {
            InitializeComponent();
            pictureBox1.Select();

            //записываем в метку picturebox'a его стартовую картинку
            pictureBox1.Tag = pictureBox1.Image;    
        }

        //добавить фото
        private void imageButton_Click(object sender, EventArgs e)
        {
            CheckFieldsEmpty();
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Photo";
                    openFileDialog.Filter = "All pictures (*.jpeg; *.jpg; *.bmp)|*.jpeg;*.jpg;*.bmp";
                    openFileDialog.FilterIndex = 0;
                    openFileDialog.CheckFileExists = true;
                    openFileDialog.Multiselect = false;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Load(openFileDialog.FileName);

                        //записываем в метку загруженной картинки её файловый путь
                        pictureBox1.Image.Tag = openFileDialog.FileName; 
                    }
                }
            }
            catch
            {
                MessageBox.Show("Unable to open file!");
            }         
        }

        //подтвердить добавление
        private void addButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == " Name" || phoneTextBox.Text == " Phone" || addressTextBox.Text == " Address" || categoryComboBox.Text == " Category" || descrTextBox.Text == "Description")
                MessageBox.Show("All fields are required");
            else
            {
                PerformAddContact?.Invoke(nameTextBox.Text, phoneTextBox.Text, addressTextBox.Text, 
                                          categoryComboBox.Text, descrTextBox.Text, (string)pictureBox1.Image.Tag);
                this.Close();
            }
        }

        //очистить форму
        private void clearButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = " Name";
            nameTextBox.ForeColor = Color.DarkGray;
            phoneTextBox.Text = " Phone";
            phoneTextBox.ForeColor = Color.DarkGray;
            addressTextBox.Text = " Address";
            addressTextBox.ForeColor = Color.DarkGray;
            this.categoryComboBox.DropDownStyle = ComboBoxStyle.Simple;
            categoryComboBox.Text = " Category";
            categoryComboBox.ForeColor = Color.DarkGray;
            descrTextBox.Text = "Description";
            descrTextBox.ForeColor = Color.DarkGray;

            //помещаем из метки picturebox'a стартовую картинку в поле изображения
            pictureBox1.Image = (Image)pictureBox1.Tag;
        }

        //при нажатии в пустом месте формы, проверить поля на заполнение
        private void AddForm_Click(object sender, EventArgs e)
        {
            CheckFieldsEmpty();
        }

        private void nameTextBox_Click(object sender, EventArgs e)
        {
            CheckFieldsEmpty();
            if (nameTextBox.Text == " Name")
            {
                nameTextBox.Text = "";
                nameTextBox.ForeColor = Color.Black;
            }    
        }

        private void phoneTextBox_Click(object sender, EventArgs e)
        {
            CheckFieldsEmpty();
            if (phoneTextBox.Text == " Phone")
            {
                phoneTextBox.Text = "";
                phoneTextBox.ForeColor = Color.Black;
            }           
        }

        private void addressTextBox_Click(object sender, EventArgs e)
        {
            CheckFieldsEmpty();
            if (addressTextBox.Text == " Address")
            {
                addressTextBox.Text = "";
                addressTextBox.ForeColor = Color.Black;
            }
        }

        private void categoryComboBox_Click(object sender, EventArgs e)
        {
            this.categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryComboBox.SelectedIndex = 0;
        }

        private void descrTextBox_Click(object sender, EventArgs e)
        {
            CheckFieldsEmpty();
            if (descrTextBox.Text == "Description")
            {
                descrTextBox.Text = "";
                descrTextBox.ForeColor = Color.Black;
            }
        }

        //если поля пустые, то заполнить их названиями серого цвета
        private void CheckFieldsEmpty()
        {
            if (nameTextBox.Text == "")
            {
                nameTextBox.Text = " Name";
                nameTextBox.ForeColor = Color.DarkGray;
            }
            if (phoneTextBox.Text == "")
            {
                phoneTextBox.Text = " Phone";
                phoneTextBox.ForeColor = Color.DarkGray;
            }
            if (addressTextBox.Text == "")
            {
                addressTextBox.Text = " Address";
                addressTextBox.ForeColor = Color.DarkGray;
            }
            if (categoryComboBox.Text == "")
            {
                categoryComboBox.Text = " Category";
                categoryComboBox.ForeColor = Color.DarkGray;
            }
            if (descrTextBox.Text == "")
            {
                descrTextBox.Text = "Description";
                descrTextBox.ForeColor = Color.DarkGray;
            }
        }
    }
}
