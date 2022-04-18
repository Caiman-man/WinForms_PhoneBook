using System.Drawing;
using System.Windows.Forms;

namespace Ivanov_WF_PhoneBook
{
    public partial class Show : Form
    {
        public Show(string name, string phone, string address,
                    string category, string description, Bitmap photo)
        {
            InitializeComponent();
            nameTextBox.Text = name;
            phoneTextBox.Text = phone;
            addressTextBox.Text = address;
            categoryComboBox.Text = category;
            descrTextBox.Text = description;
            if (photo != null)
                pictureBox1.Image = photo;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
