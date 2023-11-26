using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace WEB
{
    public delegate void Resizeform();
    public partial class Form2 : Form
    {
        private Timer resizeTimer1 = new Timer();
        private Timer resizeTimer2;
        private bool resize1 = false;
        private bool resize2 = false;
        Webcom Webcom = new Webcom();
        Stack back = new Stack();
        Stack next = new Stack();
        internal Webcom Webcom1 { get => Webcom; set => Webcom = value; }
        TruyenData truyenDataform2;
        /// <summary>
        /// push title va number
        /// </summary>
        private void GanLabel(ref Webcom webcom)
        {
            webcom.Label_text1 = label2.Text;
            webcom.Label_text2 = label3.Text;
            webcom.Label_text3 = label4.Text;
            webcom.Label_text4 = label5.Text;
            webcom.Label_text5 = label6.Text;
            
        }
        /// <summary>
        /// Them 1 vung nho duoc Webcom tro toi vao list lich su duyet web
        /// </summary>
        public void AddHistory()
        {
            //Webcom.Datatime2 = DateTime.Now;
            Webcom.DateTime1 = dateTimePicker1.Value;
            Webcom.Datatime2 = DateTime.Now;

            HisoryList.historyControl.AddHistory(ref Webcom);
        }
        /// <summary>
        /// Gan cac label hien tai tren form 2 vao phan tu web
        /// </summary>
        /// <param name="webcom"></param>
        public void HoantraLabel(ref Webcom webcom)
        {
            label2.Text = webcom.Label_text1;
            label3.Text = webcom.Label_text2;
            label4.Text = webcom.Label_text3;
            label5.Text = webcom.Label_text4;
            label6.Text = webcom.Label_text5;
            //dateTimePicker1.Value = webcom.DateTime1;
        }
        /// <summary>
        /// Push trang hien tai dang duoc quan ly boi Webcom vao revious
        /// </summary>
        private void pushBack()
        {  
            back.Push(ref Webcom);
        }
        /// <summary>
        /// Tao doi tuong moi, cho Webcom tro toi, mac dinh bookmark se luon la false
        /// </summary>
        public void Sangtrang()
        {
            Webcom webcon = new Webcom();
            GanLabel(ref webcon);
            webcon.Title = label1.Text;
            webcon.BookMark = false;
            webcon.Count = Convert.ToInt32(label7.Text);
            Webcom = webcon;
        }
        private void pushNext()
        {
            Webcom webcom = new Webcom();
            webcom.Count = Pagenumber.count;
            webcom.Title = label1.Text;
            webcom.BookMark = Webcom.BookMark;
            GanLabel(ref webcom);
            //label7.Text += webcom.Count.ToString();
            next.Push(ref webcom);
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
       /* public Form2()
        {
            InitializeComponent();
            Form1 form1 = new Form1();
            form1.resizef2 += resizeform2_1;
            //form1.resizef2 += resizeform2_2;
        }*/
        private void resizeform2_2()
        {

        }
        private void resizeform2_1()
        {
            //MessageBox.Show("ddd");
            resizeTimer1.Start();
            if (resize1 == false)
            {
                
                if (button_bookmark.Location.X < 810)
                {
                    button_bookmark.Location = new Point(button_bookmark.Location.X+5, button_bookmark.Location.Y);
                }
                    
                if (button_bookmark.Location.X >= 810)
                {
                    resize1 = true;
                    resizeTimer1.Stop();
                }
            }
            else
            {
                if (button_bookmark.Width > 700)
                    button_bookmark.Location = new Point(button_bookmark.Location.X -5, button_bookmark.Location.Y);
                if (button_bookmark.Location.X <= 700)
                {
                    resize1 = false;
                    resizeTimer1.Stop();
                }
            }

        }
        public Form2(TruyenData truyenData, ref Webcom webcom, ref Resizeform receiver)
        {
            
            InitializeComponent();
            Resizeform resizeform = new Resizeform(resizeform2_1);
            receiver = resizeform;
            button_bookmark.IconColor = Color.Black;

            Webcom = webcom;
          
            label1.Text = Webcom.Title;
            CreaterandomOption();
            label7.Text = Webcom.Count.ToString();
            HoantraLabel(ref webcom);
            CheckBookmark();
            truyenDataform2 = truyenData;
            AddHistory();
            CheckBackButton();
            CheckNextButton();
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
        private void Form2_Load(object sender, EventArgs e)
        {
            //button_bookmark.BackColor = Color.White;
            truyenDataform2(label1.Text);
            //Webcom webcom = Webcom;
            //HoantraLabel(ref Webcom);
            if (Webcom.Title != "Title: Welcome home!")
                Displayoption();
            else Hideoption();
            //MessageBox.Show("Tao ne");
            //AddHistory();
        }
        private void button_bookmark_Click(object sender, EventArgs e)
        {
            if (button_bookmark.IconColor == Color.Black)
            {
                button_bookmark.IconColor = Color.Yellow;
            }
            else
                button_bookmark.IconColor = Color.Black;
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
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
                textBox1.Text = textBox1.Text.TrimStart();
                pushBack();
                CreaterandomOption();
                Displayoption();
                label1.Text = string.Empty;
                label1.Text = "Finding resutl for: " + textBox1.Text;
                truyenDataform2(label1.Text);
                textBox1.Text = string.Empty;
                Pagenumber.count++;
                label7.Text = Pagenumber.count.ToString();
                Sangtrang();
                AddHistory();
                CheckBookmark();
                EmptyNext();
                CheckBackButton();
                CheckNextButton();
            }
        }
        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            pushBack();
            Pagenumber.count++;
            //textBox1.Text = label2.Text;
            label1.Text = "Title: " + label2.Text;
            truyenDataform2(label1.Text);
            //Webcom.Count = Pagenumber.count;
            CreaterandomOption();
            label7.Text = Pagenumber.count.ToString();
            Sangtrang();
            AddHistory();
            CheckBookmark();
            EmptyNext();
            CheckBackButton();
            CheckNextButton();
            //addFav();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {
            pushBack();
            Pagenumber.count++;
            //textBox1.Text = label6.Text;
            label1.Text = "Title: " + label6.Text;
            truyenDataform2(label1.Text);
            CreaterandomOption();
            //Webcom.Count = Pagenumber.count;
            label7.Text = Pagenumber.count.ToString();
            Sangtrang();
            AddHistory();
            CheckBookmark();
            EmptyNext();
            CheckBackButton();
            CheckNextButton();
            //addFav();
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {
            pushBack();
            Pagenumber.count++;
            //textBox1.Text = label3.Text;
            label1.Text = "Title: " + label3.Text;
            truyenDataform2(label1.Text);
            CreaterandomOption();
            //Webcom.Count = Pagenumber.count;
            label7.Text = Pagenumber.count.ToString();
            Sangtrang();
            AddHistory();
            CheckBookmark();
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
            truyenDataform2(label1.Text);
            CreaterandomOption();
            //Webcom.Count = Pagenumber.count;
            label7.Text = Pagenumber.count.ToString();
            Sangtrang();
            AddHistory();
            CheckBookmark();
            EmptyNext();
            CheckBackButton();
            CheckNextButton();
            //addFav();
        }
        private void label5_Click(object sender, EventArgs e)
        {
            pushBack();
            Pagenumber.count++;
            //textBox1.Text = label5.Text;
            label1.Text = "Title: " + label5.Text;
            truyenDataform2(label1.Text);
            CreaterandomOption();
            //Webcom.Count = Pagenumber.count;
            label7.Text = Pagenumber.count.ToString();
            Sangtrang();
            AddHistory();
            CheckBookmark();
            EmptyNext();
            CheckBackButton();
            CheckNextButton();
            //addFav();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button_reload_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }
        private void button_back_Click(object sender, EventArgs e)
        {
            if (back.isEmpty())
            {
                MessageBox.Show("Back is empty", "Warning!");
                return;
            }
            next.Push(ref Webcom);
            // day vo next

            Webcom web = null;
            back.Pop(ref web);
            label1.Text = web.Title;
            truyenDataform2(label1.Text);
            label7.Text = web.Count.ToString();
            HoantraLabel(ref web);
            Webcom = web;
            //Webcom.DateTime = DateTime.Now;
            CheckBookmark();
            HisoryList.historyControl.TachHistory(ref Webcom);
            AddHistory();
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
            truyenDataform2(label1.Text);
            label7.Text = web.Count.ToString();
            Webcom = web;
            //Webcom.DateTime = DateTime.Now;
            CheckBookmark();
            HisoryList.historyControl.TachHistory(ref Webcom);
            AddHistory();
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
        private void EmptyNext()
        {
            while (!next.isEmpty())
            {
                next.Head = next.Head.NextforStack1;
            }
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Gan true / false va tac dong toi lich su cung nhu favorite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_bookmark_Click_1(object sender, EventArgs e)
        {
            if (button_bookmark.IconColor==Color.Black)
            {
                //button_bookmark.BackColor = Color.Yellow;
                Webcom.BookMark = true;
                FavControl.FavList.AddFav(ref Webcom);
                CheckBookmark();
            }
            else
            {
                //button_bookmark.BackColor=Color.White;
                Webcom.BookMark = false;
                FavControl.FavList.RemoveFav(ref Webcom);
                CheckBookmark();
            }
            //MessageBox.Show(Webcom.BookMark.ToString());
        }
        /// <summary>
        /// Dung de doi mau bookmark 
        /// </summary>
        private void CheckBookmark()
        {
            if (Webcom.BookMark == true)
            {
                button_bookmark.IconColor = Color.Yellow;
            }
            else 
            { 
                button_bookmark.IconColor = Color.Black;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            CheckBookmark();
            CreaterandomOption();
            GanLabel(ref Webcom);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Webcom.DateTime1 = dateTimePicker1.Value;
        }
    }
  
}
