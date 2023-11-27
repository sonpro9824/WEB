﻿using FontAwesome.Sharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;
using FontStyle = System.Drawing.FontStyle;
using Point = System.Drawing.Point;

namespace WEB
{
    //public delegate void (object sender, EventArgs e);
    public partial class Form4 : Form
    {
        TabPage tabPage1;
        ChuyenTab chuyen;
        Webcom webcom = new Webcom();
        /*public static ArrayList buttons = new ArrayList();
        public static ArrayList buttons1 = new ArrayList();*/
        public ArrayList Weblist = new ArrayList();
        public Taotab Sender;
        public RemoveCurrentTab ReceiverRemove;
        public Refresh swap;
        public Form4(Taotab receiver, ref TabPage tabPage, ChuyenTab chuyen, RemoveCurrentTab remove, Refresh createNewForm)
        {
            InitializeComponent();
            Sender = receiver;
            tabPage1 = tabPage;
            this.chuyen = chuyen;
            ReceiverRemove = remove;
            swap = createNewForm;
        }
        /// <summary>
        /// Click chuot trai thi truy cap ngay tren tab hien tai, chuot phai thi hien menustrip voi 2 option la truy cap va xoa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Label_Click(object sender, MouseEventArgs e)
        {
       
           if (sender is Label Clicked_Label)
            {
                int labelindex = (int)Clicked_Label.Tag;
                string labelname = Clicked_Label.Text;
                int index = ((Webcom)Weblist[labelindex]).Count;
                Webcom temp = ((Webcom)Weblist[labelindex]);
                webcom = temp;
                if (e.Button == MouseButtons.Left)
                {
                    
                     //HisoryList.historyControl.Noibot(ref temp);
                     HisoryList.historyControl.TachHistory(ref temp);
                     //temp.//DateTime = DateTime.Now;
                     ReceiverRemove();
                     //Sender(ref temp);      
                     //chuyen(tabPage1);
                     swap(ref temp);
                }
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenuStrip contextMenu = new ContextMenuStrip();
                    System.Drawing.Point point = new System.Drawing.Point(e.Location.X, e.Location.Y);
                    contextMenu.Items.Add("Access in a new tab");
                    contextMenu.Items.Add("Delete");
                    contextMenu.Show(Clicked_Label, point);
                    contextMenu.ItemClicked += ContextMenu_ItemClicked;
                }
            }

        }

        private void ContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.ToString() == "Access in a new tab")
            {
                //System.Windows.MessageBox.Show("Accessed!");
                HisoryList.historyControl.TachHistory(ref webcom);
                //webcom.//DateTime = DateTime.Now;
                Sender(ref webcom);
                chuyen(tabPage1);
            }
            if (e.ClickedItem.ToString() == "Delete")
            {
                //System.Windows.MessageBox.Show("Deleted!");
                HisoryList.historyControl.TachHistory(ref webcom);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = "History list";
            //int height = 80;
            int count = 0;
            //List<Label> list = new List<Label>();

            HisoryList.historyControl.Sort_Date();
           /* for (var i = HisoryList.historyControl.Head; i != null; i = i.NextforHistory1)
            {
                System.Windows.Forms.MessageBox.Show(i.Title+ "\n" + i.DateTime1.ToString());
            }*/
            /* string textoutput = string.Empty;
             for (var i = HisoryList.historyControl.Head; i != null; i = i.NextforHistory1)
             {
                 textoutput += i.Title + "\n";
             }
             System.Windows.MessageBox.Show(textoutput);*/
            DateTime time = HisoryList.historyControl.Head.DateTime1;
            int xG = 10;
            int yG = 50;
            Webcom i = HisoryList.historyControl.Head;
            while (i != null)
            {
                GroupBox group = new GroupBox();
                group.Location = new System.Drawing.Point(xG, yG);
                group.Text = time.ToString("dd/MM/yyyy");

                int x = 10;
                int y = 20;


                while (i != null && i.DateTime1.Year == time.Year && i.DateTime1.Month==time.Month && i.DateTime1.Day == time.Day)
                {
                    //System.Windows.MessageBox.Show("Im here!!");
                    webcom = (Webcom)i;
                    Label label = new Label
                    {
                        Tag = count
                    };
                    count++;
                    Weblist.Add(i);
                    label.Text = i.Title + " ---- Page: " + i.Count.ToString() + "\nAcess Time: " + i.Datatime2.ToString("  HH:mm:ss" + "\n---------------------------------------");

                    label.AutoSize = true;
                    label.Location = new System.Drawing.Point(x, y);
                    label.Visible = true;
                    label.Font = new Font("Calibri", 12, FontStyle.Regular);

                    label.MouseUp += Label_Click;
                    group.Controls.Add(label);
                    y += 70;

                    i = i.NextforHistory1;
                }
                group.AutoSize = true;

                this.Controls.Add(group);
                yG = group.Bottom + 20;
                if (i != null)
                    time = i.DateTime1;
            }


            //for (var i = HisoryList.historyControl.Head; i != null; i = i.NextforHistory1)
            //{
            //    webcom = (Webcom)i;
            //    Label label = new Label
            //    {
            //        Tag = count
            //    };
            //    Weblist.Add(i);
            //    label.Text = i.Title + " ---- Page: " + i.Count.ToString() + "\nAcess Time: " + i.DateTime1.ToString("dd/MM/yyyy") + i.Datatime2.ToString("  HH:mm:ss" +"\n---------------------------------------");
            //    //label1.Text = i.Count.ToString();
            //    label.AutoSize = true;
            //    label.Location = new System.Drawing.Point(0, height);
            //    label.Visible = true;

            //    label.Font = new Font("Calibri", 12, FontStyle.Regular);
            //    this.Controls.Add(label);
            //    this.Controls.Add(label1);

            //    height += 70;
            //    label.MouseUp += Label_Click;
            //    count++;
            //    //list.Add(label);
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //CreateNewForm(ref tabPage1);
            Weblist.Clear();
            foreach (Control control in this.Controls)
            {
                control.Enabled = false;
                control.Visible = false;
            }
            label1.Visible = true;
            label1.Enabled = true;
            Form4_Load(sender,e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
