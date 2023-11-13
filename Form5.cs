using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WEB
{
    public partial class Form5 : Form
    {
        public Taotab sender;
        public ChuyenTab chuyen;
        TabPage tabPage1;
        public static ArrayList FavList = new ArrayList();
        public Form5(Taotab receiver, TabPage tabPage, ChuyenTab chuyen)
        {
            InitializeComponent();
            sender = receiver;
            this.tabPage1 = tabPage;
            this.chuyen = chuyen;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            int height = 50;
            int count = 0;
            for (var i = FavControl.FavList.Head; i!=null; i=i.NextforFav1)
            {
                MessageBox.Show("Heloo");
                FavList.Add(i);
                Label label = new Label();
                label.Text = ((Webcom)i).Title + " --- Page number : " + i.Count.ToString()+ "\nDate Time: " + ((Webcom)i).DateTime.ToString();
                label.AutoSize = true;
                label.Location = new System.Drawing.Point(0, height);
                height += 50;
                label.Visible = true;
                this.Controls.Add(label);
                count++;
            }
        }
    }
}
