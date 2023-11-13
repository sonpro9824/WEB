using FontAwesome.Sharp;
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

namespace WEB
{
    //public delegate void (object sender, EventArgs e);
    public partial class Form4 : Form
    {
        TabPage tabPage1;
        ChuyenTab chuyen;
        Webcom webcom = new Webcom();
        public static ArrayList buttons = new ArrayList();
        public static ArrayList buttons1 = new ArrayList();
        public static ArrayList Weblist = new ArrayList();
        public Taotab Sender;
        public Form4(Taotab receiver, TabPage tabPage, ChuyenTab chuyen)
        {
            InitializeComponent();
            Sender = receiver;
            tabPage1 = tabPage;
            this.chuyen = chuyen;
        }
        protected void Label_Click(object sender, EventArgs e)
        {
           /* Label label = (Label)sender;
            
            // Thực hiện các xử lý dựa trên thông tin về button
            //MessageBox.Show($"Button {buttonName} (Index {buttonIndex}) was clicked.");
            Sender((Webcom)Weblist[buttonIndex]);
            messageBox.ShowCustomMessageBox();*/
           if (sender is Label Clicked_Label)
            {
                int labelindex = (int)Clicked_Label.Tag;
                string labelname = Clicked_Label.Text;
                System.Windows.MessageBox.Show(((Webcom)Weblist[labelindex]).BookMark.ToString());


                /* Webcom temp = ((Webcom)Weblist[labelindex]).Next;
                 ((Webcom)Weblist[labelindex - 1]).Next = temp;
                 HisoryList.historyControl.Tail = ((Webcom)Weblist[labelindex]);
                 HisoryList.historyControl.Tail.Next = null;*/


                int index = ((Webcom)Weblist[labelindex]).Count;
                Webcom temp = ((Webcom)Weblist[labelindex]);
                //HisoryList.historyControl.Noibot(ref temp);

                Sender(ref temp);
                HisoryList.historyControl.DeleteHistory(ref temp);
               // Pagenumber.count--;
                chuyen(tabPage1);
                //System.Windows.Forms.MessageBox.Show("Label name:  "+ labelname + " clicked");
            }
            
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = "History list";
            int height = 50;
            int count = 0;
            //List<Label> list = new List<Label>();
            for (var i = HisoryList.historyControl.Head; i != null; i = i.NextforHistory1)
            {
                webcom = (Webcom)i;
                Label label = new Label
                {
                     Tag = count
                };
              /*  Button button = new Button
                {
                     Tag = count
                };
                Button button1 = new Button
                {
                     Tag = count
                };*/
                Label label1 = new Label
                {
                    Tag = count
                };
              /*  buttons.Add(button);
                buttons1.Add(button1);*/
                Weblist.Add(i);
             /*   button.Height += 5;
                button1.Height += 5;
                button.Text = "Acess";
                button1.Text = "Delete";*/
                label.Text = i.Title + " ---- Page: " + i.Count.ToString();
                //label1.Text = i.Count.ToString();
                label.AutoSize = true;
                label.Location = new System.Drawing.Point(0, height);
                //label1.Location = new System.Drawing.Point(label.Width+10, height);
            /*    button.Location = new System.Drawing.Point(label.Width + 300 , label.Location.Y);
                button1.Location = new System.Drawing.Point(label.Width + button.Width + 300, label.Location.Y);*/
               /* button.Visible = true;
                button1.Visible = true;*/
                label.Visible = true;
                label1.Visible = true;
                this.Controls.Add(label);
              /*  this.Controls.Add(button);
                this.Controls.Add(button1);*/
                this.Controls.Add(label1);
                height += 50;
                //list.Add(label);
                label.Click += Label_Click;
               /* button.Click += Button_Click;
                button1.Click += Button1_Click;*/

                //System.Windows.MessageBox.Show("Im in loop!. Index: " + i.Count.ToString());
                count++;
            }
            //System.Windows.MessageBox.Show("Im out of loop!");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        /*private void addFav()
        {

            Webcom webcom1 = new Webcom();
            webcom1.Title = label1.Text;
            webcom1.Label_text1 = label2.Text;
            //MessageBox.Show(webcom1.Title);
            webcom1.Label_text2 = label3.Text;
            webcom1.Label_text3 = label4.Text;
            webcom1.Label_text4 = label5.Text;
            webcom1.Label_text5 = label6.Text;
            webcom1.Count = Convert.ToInt32(label7.Text);
            webcom1.BookMark = Webcom.BookMark;
            checkBookMark(webcom1);
            Fav.fav.AddHistory(webcom1);
        }*/

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                int buttonIndex = (int)clickedButton.Tag;
                string buttonName = clickedButton.Name;
                // Thực hiện các xử lý dựa trên thông tin về button
                //MessageBox.Show($"Button {buttonName} (Index {buttonIndex}) was clicked.");
                //Sender((Webcom)Weblist[buttonIndex]);
            }
        }
    }
}
