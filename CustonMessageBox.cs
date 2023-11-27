using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WEB
{
    public class CustomMessageBox : Form
    {
        public CustomMessageBox()
        {
            // Tạo nút "Access"
            Button accessButton = new Button();
            accessButton.Text = "Access";
            accessButton.Height += 5;
            accessButton.Click += (sender, e) =>
            {
                // Xử lý khi nút "Access" được nhấn
                MessageBox.Show("Access button clicked");
                this.Close();
            };
            accessButton.Location = new System.Drawing.Point(282/2-80, 254/2);
            // Tạo nút "Delete"
            Button deleteButton = new Button();
            deleteButton.Text = "Delete";
            deleteButton.Height += 5;
            deleteButton.Click += (sender, e) =>
            {
                // Xử lý khi nút "Delete" được nhấn
                MessageBox.Show("Delete button clicked");
                this.Close();
            };
            deleteButton.Location = new System.Drawing.Point(282/2+30, 254/2);
            // Thêm các nút vào form
            this.Controls.Add(accessButton);
            this.Controls.Add(deleteButton);
        }
        public void ShowCustomMessageBox()
        {
            CustomMessageBox customMessageBox = new CustomMessageBox();
            customMessageBox.ShowDialog();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CustomMessageBox
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Name = "CustomMessageBox";
            this.Load += new System.EventHandler(this.CustomMessageBox_Load);
            this.ResumeLayout(false);

        }

        private void CustomMessageBox_Load(object sender, EventArgs e)
        {

        }
    }

    // Sử dụng form tùy chỉnh
   

}
