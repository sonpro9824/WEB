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
    public delegate void TruyenData(string text);
    public partial class Form1 : Form
    {
        private int n = 1;
        string tabpagename = "";
 
        public void SetNameTabpage(string name)
        {
            tabControl1.SelectedTab.Tag = name;
        }
        public Form1()
        {
            InitializeComponent();
            Addtab();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void TabName(string tabname)
        {
            tabControl1.SelectedTab.Text = tabname;
        }
        private void Addtab()
        {
            Form2 form2 = new Form2(TabName);
            form2.Text = form2.Webcom1.Title;
            TabPage tabPage = new TabPage { Text = "Tab" + n.ToString() };
            n++;
            tabPage.BorderStyle = BorderStyle.Fixed3D;
            tabControl1.TabPages.Add(tabPage);
            form2.TopLevel = false;
            form2.Parent = tabPage;       
            form2.Show();
            form2.Dock = DockStyle.Fill;

        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            Addtab();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Text = "History";
            TabPage tabPage = new TabPage { Text = "History" };
            tabPage.BorderStyle = BorderStyle.Fixed3D;
            tabControl1.TabPages.Add(tabPage);
            form3.TopLevel = false;
            form3.Parent = tabPage;
            form3.Show();
            form3.Dock = DockStyle.Fill;
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Text = "Favorite";
            form4.ShowDialog();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text != "History")
                return;
            Form3 form3 = new Form3();
            form3.Text = "History";
            //tabControl1.TabPages.Add(tabPage);
            //this.tabControl1.SelectedTab = new TabPage();
            form3.TopLevel = false;
            form3.Parent = tabControl1.SelectedTab;
            form3.Show();
            form3.Dock = DockStyle.Fill;
        }

        private void iconButton4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
