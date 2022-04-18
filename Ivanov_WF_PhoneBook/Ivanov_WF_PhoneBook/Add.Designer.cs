
namespace Ivanov_WF_PhoneBook
{
    partial class Add
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add));
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.descrTextBox = new System.Windows.Forms.TextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new Ivanov_WF_PhoneBook.CustomButton();
            this.clearButton = new Ivanov_WF_PhoneBook.CustomButton();
            this.addButton = new Ivanov_WF_PhoneBook.CustomButton();
            this.imageButton = new Ivanov_WF_PhoneBook.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.nameTextBox.Location = new System.Drawing.Point(179, 16);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(307, 31);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.Text = " Name";
            this.nameTextBox.Click += new System.EventHandler(this.nameTextBox_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 175);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.phoneTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.phoneTextBox.Location = new System.Drawing.Point(179, 53);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(307, 31);
            this.phoneTextBox.TabIndex = 3;
            this.phoneTextBox.Text = " Phone";
            this.phoneTextBox.Click += new System.EventHandler(this.phoneTextBox_Click);
            // 
            // addressTextBox
            // 
            this.addressTextBox.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.addressTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.addressTextBox.Location = new System.Drawing.Point(179, 90);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(307, 31);
            this.addressTextBox.TabIndex = 4;
            this.addressTextBox.Text = " Address";
            this.addressTextBox.Click += new System.EventHandler(this.addressTextBox_Click);
            // 
            // descrTextBox
            // 
            this.descrTextBox.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.descrTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.descrTextBox.Location = new System.Drawing.Point(179, 173);
            this.descrTextBox.Multiline = true;
            this.descrTextBox.Name = "descrTextBox";
            this.descrTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descrTextBox.Size = new System.Drawing.Size(307, 65);
            this.descrTextBox.TabIndex = 5;
            this.descrTextBox.Text = "Description";
            this.descrTextBox.Click += new System.EventHandler(this.descrTextBox_Click);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.categoryComboBox.ForeColor = System.Drawing.Color.DarkGray;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Items.AddRange(new object[] {
            " Family",
            " Friends",
            " Business"});
            this.categoryComboBox.Location = new System.Drawing.Point(179, 127);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(307, 31);
            this.categoryComboBox.TabIndex = 6;
            this.categoryComboBox.Text = " Category";
            this.categoryComboBox.Click += new System.EventHandler(this.categoryComboBox_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(128)))), ((int)(((byte)(241)))));
            this.cancelButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(128)))), ((int)(((byte)(241)))));
            this.cancelButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.cancelButton.BorderRadius = 15;
            this.cancelButton.BorderSize = 0;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(337, 252);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(145, 32);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextColor = System.Drawing.Color.White;
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(128)))), ((int)(((byte)(241)))));
            this.clearButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(128)))), ((int)(((byte)(241)))));
            this.clearButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.clearButton.BorderRadius = 15;
            this.clearButton.BorderSize = 0;
            this.clearButton.FlatAppearance.BorderSize = 0;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.clearButton.ForeColor = System.Drawing.Color.White;
            this.clearButton.Location = new System.Drawing.Point(179, 252);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(145, 32);
            this.clearButton.TabIndex = 11;
            this.clearButton.Text = "Clear";
            this.clearButton.TextColor = System.Drawing.Color.White;
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(128)))), ((int)(((byte)(241)))));
            this.addButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(128)))), ((int)(((byte)(241)))));
            this.addButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.addButton.BorderRadius = 15;
            this.addButton.BorderSize = 0;
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Location = new System.Drawing.Point(16, 252);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(145, 32);
            this.addButton.TabIndex = 12;
            this.addButton.Text = "Add";
            this.addButton.TextColor = System.Drawing.Color.White;
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // imageButton
            // 
            this.imageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(128)))), ((int)(((byte)(241)))));
            this.imageButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(128)))), ((int)(((byte)(241)))));
            this.imageButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.imageButton.BorderRadius = 15;
            this.imageButton.BorderSize = 0;
            this.imageButton.FlatAppearance.BorderSize = 0;
            this.imageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageButton.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.imageButton.ForeColor = System.Drawing.Color.White;
            this.imageButton.Location = new System.Drawing.Point(16, 208);
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(145, 32);
            this.imageButton.TabIndex = 13;
            this.imageButton.Text = "Image";
            this.imageButton.TextColor = System.Drawing.Color.White;
            this.imageButton.UseVisualStyleBackColor = false;
            this.imageButton.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(499, 301);
            this.Controls.Add(this.imageButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.descrTextBox);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.nameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(515, 340);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(515, 340);
            this.Name = "Add";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add";
            this.TopMost = true;
            this.Click += new System.EventHandler(this.AddForm_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox descrTextBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private CustomButton cancelButton;
        private CustomButton clearButton;
        private CustomButton addButton;
        private CustomButton imageButton;
    }
}