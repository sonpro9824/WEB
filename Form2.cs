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
    public partial class Form2 : Form
    {
        Webcom Webcom = new Webcom();

        internal Webcom Webcom1 { get => Webcom; set => Webcom = value; }

        public Form2()
        {
            InitializeComponent();
            label1.Text = Webcom.Title;
            label2.Text = Webcom.Label_text1;
            label3.Text = Webcom.Label_text2;
            label4.Text = Webcom.Label_text3;
            label5.Text = Webcom.Label_text4;
        }
        /// <summary>
        /// An di cac option
        /// </summary>
        private void Hideoption()
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
        }
        /// <summary>
        /// Hien ra cac option
        /// </summary>
        private void Displayoption()
        {
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
        }
    
        /// <summary>
        /// An title
        /// </summary>
        private void HideTitle()
        {
            label1.Visible = false;
        }
        /// <summary>
        /// Hien title
        /// </summary>
        private void DisplayTitle()
        {
            label1.Visible = true;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            button_bookmark.BackColor = Color.White;
            label7.Text = Webcom1.Count.ToString();
            Hideoption();
        }
        private void button_bookmark_Click(object sender, EventArgs e)
        {
            if (button_bookmark.BackColor == Color.White)
            {
                button_bookmark.BackColor = Color.Yellow;
            }
            else
                button_bookmark.BackColor = Color.White;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Displayoption();
                HideTitle();
            }
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            textBox1.Text = label2.Text;
        }
    }
}
