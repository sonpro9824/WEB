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
    public delegate void DoiTen(string text);
    public partial class ControlAndanh : Form
    {
        public ControlAndanh()
        {
            InitializeComponent();
            Webcom webcom = new Webcom();
            Addtab(ref webcom);
           
        }
        public void ChuyenTab(TabPage tab)
        {
            tabControl1.SelectedTab = tab;
        }
        public void Addtab(ref Webcom webcom)
        {
            string firsttitle = webcom.Title;
            TabPage tabPage = new TabPage();
            tabControl1.TabPages.Add(tabPage);
            ChuyenTab(tabPage);
            TabAndanh tabAndanh = new TabAndanh(DoitenTab, ref webcom);
            tabAndanh.TopLevel = false;
            tabAndanh.Parent = tabPage;
            tabAndanh.Show();
            tabPage.BorderStyle = BorderStyle.Fixed3D;
        }
        private void iconButton7_Click(object sender, EventArgs e)
        {
            Webcom webcom = new Webcom();
            Addtab(ref webcom);
        }
        public void DoitenTab(string text)
        {
            tabControl1.SelectedTab.Text = text;
        }
        private void ControlAndanh_Load(object sender, EventArgs e)
        {
           
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count != 0)
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            else
            {
                MessageBox.Show("Out of tab!");
                return;
            }
        }
    }
}
