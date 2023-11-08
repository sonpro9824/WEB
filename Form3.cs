using System;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string output = "";
            int height = 0;
            for (var i = HisoryList.historyControl.Head; i!=null; i = i.Next)
            {
               // output += i.Title + "\n";
               Label label = new Label();
                //MessageBox.Show(i.Title);
                label.Text = i.Title + "       Page: " + i.Count.ToString();
                label.Location = new System.Drawing.Point(0, height);
                label.AutoSize = true;
                this.Controls.Add(label);   
                height += 50;
                
            }
            //MessageBox.Show(output);
        }
    }
}
