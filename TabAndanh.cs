using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WEB
{
    public delegate void ReceiverDoitenTab(string text);
    public partial class TabAndanh : Form
    {
        Stack back = new Stack();
        Stack next = new Stack();
        Webcom g_Webcom = new Webcom();
        ReceiverDoitenTab receiverDoiten;
        public TabAndanh(ReceiverDoitenTab receiver, ref Webcom webcom)
        {
            InitializeComponent();
            button_bookmark.Enabled = false;
            receiverDoiten = receiver;
            g_Webcom = webcom;
        }
        private void GanLabel(ref Webcom webcom)
        {
            webcom.Label_text1 = label2.Text;
            webcom.Label_text2 = label3.Text;
            webcom.Label_text3 = label4.Text;
            webcom.Label_text4 = label5.Text;
            webcom.Label_text5 = label6.Text;

        }
        public void HoantraLabel(ref Webcom webcom)
        {
            label2.Text = webcom.Label_text1;
            label3.Text = webcom.Label_text2;
            label4.Text = webcom.Label_text3;
            label5.Text = webcom.Label_text4;
            label6.Text = webcom.Label_text5;
        }
        /// <summary>
        /// An di cac option
        /// </summary>
        public void Hideoption()
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
        public void Displayoption()
        {
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
        }
        private void pushBack()
        {
            back.Push(ref g_Webcom);
        }
        private string Createrandom()
        {
            Random random = new Random();
            int n = random.Next(10) + 1;
            Randomstring result = new Randomstring();
            return result.GenerateRandomString(n);
        }
        /// <summary>
        /// Thay doi cac option tren label, khong anh huong den Webcom
        /// </summary>
        private void CreaterandomOption()
        {
            label2.Text = Createrandom();
            label3.Text = Createrandom();
            label4.Text = Createrandom();
            label5.Text = Createrandom();
            label6.Text = Createrandom();
        }
        public void Sangtrang()
        {
            Webcom webcon = new Webcom();
            GanLabel(ref webcon);
            webcon.Title = label1.Text;
            /*webcon.BookMark = false;
            webcon.Count = Convert.ToInt32(label7.Text);*/
            g_Webcom = webcon;
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            receiverDoiten(g_Webcom.Title);
            if (g_Webcom.Title == "Title: Welcome home!")
            {
                Hideoption();
            }
            else
            {
                Displayoption();
            }
            CheckBackButton();
            CheckNextButton();
        }
        public void CheckBackButton()
        {
            if (back.isEmpty())
            {
                button_back.Enabled = false;
            }
            else
            {
                button_back.Enabled = true;
            }
        }
        public void CheckNextButton()
        {
            if (next.isEmpty())
            {
                button_next.Enabled = false;
            }
            else
            {
                button_next.Enabled = true;
            }
        }

        private void EmptyNext()
        {
            while (!next.isEmpty())
            {
                next.Head = next.Head.NextforStack1;
            }
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            pushBack();
            Pagenumber.count++;
            //textBox1.Text = label2.Text;
            label1.Text = "Title: " + label2.Text;
            receiverDoiten(label1.Text);
            //Webcom.Count = Pagenumber.count;
            CreaterandomOption();
            label7.Text = Pagenumber.count.ToString();
            Sangtrang();
            /*AddHistory();
            CheckBookmark();*/
            EmptyNext();
            CheckBackButton();
            CheckNextButton();
            //addFav();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            pushBack();
            Pagenumber.count++;
            //textBox1.Text = label3.Text;
            label1.Text = "Title: " + label3.Text;
            receiverDoiten(label1.Text);
            CreaterandomOption();
            //Webcom.Count = Pagenumber.count;
            label7.Text = Pagenumber.count.ToString();
            Sangtrang();
            /*AddHistory();
            CheckBookmark();*/
            EmptyNext();
            CheckBackButton();
            CheckNextButton();
            //addFav();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            pushBack();
            Pagenumber.count++;
            //textBox1.Text = label4.Text;
            label1.Text = "Title: " + label4.Text;
            receiverDoiten(label1.Text);
            CreaterandomOption();
            //Webcom.Count = Pagenumber.count;
            label7.Text = Pagenumber.count.ToString();
            Sangtrang();
           /* AddHistory();
            CheckBookmark();*/
            EmptyNext();
            CheckBackButton();
            CheckNextButton();
            //addFav();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            pushBack();
            //Pagenumber.count++;
            //textBox1.Text = label5.Text;
            label1.Text = "Title: " + label5.Text;
            receiverDoiten(label1.Text);
            CreaterandomOption();
            //Webcom.Count = Pagenumber.count;
            //label7.Text = Pagenumber.count.ToString();
            Sangtrang();
           /* AddHistory();
            CheckBookmark();*/
            EmptyNext();
            CheckBackButton();
            CheckNextButton();
            //addFav();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            pushBack();
            //Pagenumber.count++;
            //textBox1.Text = label6.Text;
            label1.Text = "Title: " + label6.Text;
            receiverDoiten(label1.Text);
            CreaterandomOption();
            //Webcom.Count = Pagenumber.count;
            //label7.Text = Pagenumber.count.ToString();
            Sangtrang();
          /*  AddHistory();
            CheckBookmark();*/
            EmptyNext();
            CheckBackButton();
            CheckNextButton();
            //addFav();
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("Hello");
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "\r\n")
                {
                    textBox1.Text = string.Empty;
                }
                if (textBox1.Text == string.Empty)
                {
                    //MessageBox.Show("asdsd");
                    return;
                }
                //MessageBox.Show("Hello");
                textBox1.Text = textBox1.Text.TrimStart();
                pushBack();
                CreaterandomOption();
                Displayoption();
                label1.Text = string.Empty;
                label1.Text = "Finding resutl for: " + textBox1.Text;
                //getTitle(label1.Text);
                receiverDoiten(label1.Text);
                textBox1.Text = string.Empty;
                //label1.Text = string.Empty;
                //Pagenumber.count++;
                //Webcom.Count = Pagenumber.count;
                //label7.Text = Pagenumber.count.ToString();
                Sangtrang();
                //AddHistory();
                //CheckBookmark();
                EmptyNext();
                CheckBackButton();
                CheckNextButton();
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            if (back.isEmpty())
            {
                MessageBox.Show("Back is empty", "Warning!");
                return;
            }
            next.Push(ref g_Webcom);
            // day vo next

            Webcom web = null;
            back.Pop(ref web);
            label1.Text = web.Title;
            receiverDoiten(label1.Text);
            label7.Text = web.Count.ToString();
            HoantraLabel(ref web);
            g_Webcom = web;
            g_Webcom.DateTime = DateTime.Now;
            //CheckBookmark();
            //HisoryList.historyControl.TachHistory(ref g_Webcom);
            //AddHistory();
            if (label1.Text == "Title: Welcome home!")
            {
                Hideoption();
            }
            else
            {
                Displayoption();
            }
            CheckBackButton();
            CheckNextButton();
            // lui ve
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if (next.isEmpty())
            {
                MessageBox.Show("Next is empty", "Warning!");
                return;
            }
            pushBack();
            Webcom web = null;
            next.Pop(ref web);
            HoantraLabel(ref web);
            label1.Text = web.Title;
            receiverDoiten(label1.Text);
            label7.Text = web.Count.ToString();
            g_Webcom = web;
            g_Webcom.DateTime = DateTime.Now;
           // CheckBookmark();
           /* HisoryList.historyControl.TachHistory(ref Webcom);
            AddHistory();*/
            //MessageBox.Show(label1.Text);
            if (label1.Text == "Title: Welcome home!")
            {
                MessageBox.Show(label1.Text);
                Hideoption();
            }
            else
            {
                Displayoption();
            }
            CheckBackButton();
            CheckNextButton();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            //CheckBookmark();
            CreaterandomOption();
            GanLabel(ref g_Webcom);
        }
    }
}
