﻿using System;
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

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
