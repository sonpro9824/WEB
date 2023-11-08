using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WEB
{
    public partial class Form2 : Form
    {
        Webcom Webcom = new Webcom();
        Stack back = new Stack();
        Stack next = new Stack();
        internal Webcom Webcom1 { get => Webcom; set => Webcom = value; }
        TruyenData truyenDataform2;
        /// <summary>
        /// Tao doi tuong moi de luu trang web hien tai, Webcom se tro toi doi tuong do 
        /// </summary>
        private void UpdateData()
        {
            Webcom webcom = new Webcom();
            webcom.Title = textBox1.Text;
            webcom.Label_text1 = label2.Text;
            webcom.Label_text2 = label3.Text;
            webcom.Label_text3 = label4.Text;
            webcom.Label_text4 = label5.Text;
            webcom.Label_text5 = label6.Text;
            webcom.Count = Convert.ToInt32(label7.Text);
            Webcom = webcom;
        }
        /// <summary>
        /// push title va number
        /// </summary>
        private void GanLabel(ref Webcom webcom)
        {
            Webcom.Label_text1 = label2.Text;
            Webcom.Label_text2 = label3.Text;
            Webcom.Label_text3 = label4.Text;
            Webcom.Label_text4 = label5.Text;
            Webcom.Label_text5 = label6.Text;
            Webcom.BookMark = Webcom.BookMark;
            Webcom.Title = textBox1.Text;
            Webcom.Count = Convert.ToInt32(label7.Text);
        }
        private void HoantraLabel()
        {
            label1.Text = Webcom.Title;
            label2.Text = Webcom.Label_text1;
            label3.Text = Webcom.Label_text2;
            label4.Text = Webcom.Label_text3;
            label5.Text = Webcom.Label_text4;
            label6.Text = Webcom.Label_text5;
            Webcom.BookMark = Webcom.BookMark;
            label7.Text = Webcom.Count.ToString();
        }
        /* private void pushBack()
         {
             Webcom webcom = new Webcom();
             webcom.Count = Convert.ToInt32(label7.Text);
             webcom.Title = label1.Text;
             GanLabel(ref webcom);
             //label7.Text += webcom.Count.ToString();
             back.Push(webcom);



             Webcom webcom1 = new Webcom();
             webcom1.Title = webcom.Title;
             webcom1.Label_text1 = webcom.Label_text1;
             webcom1.Label_text2 = webcom.Label_text2;
             webcom1.Label_text3 = webcom.Label_text3;
             webcom1.Label_text4 = webcom.Label_text4;
             webcom1.Label_text5 = webcom.Label_text5;
             webcom1.Count = webcom.Count;
             HisoryList.historyControl.AddHistory(webcom1);
         }*/

        private void checkBookMark()
        {
            if(Webcom.BookMark==true)
            {
                button_bookmark.BackColor = Color.Yellow;
            }
            else
            {
                button_bookmark.BackColor = Color.White;
            }
        }

       /* private void addHis()
        {
            // add lich su
            Webcom webcom1 = new Webcom();
            webcom1.Title = label1.Text;
            webcom1.Label_text1 = label2.Text;
            //MessageBox.Show(webcom1.Title);
            webcom1.Label_text2 = label3.Text;
            webcom1.Label_text3 = label4.Text   ;
            webcom1.Label_text4 = label5.Text;
            webcom1.Label_text5 = label6.Text;
            webcom1.Count = Convert.ToInt32(label7.Text);
            HisoryList.historyControl.AddHistory(webcom1);
        }
        private void addFav()
        {
            // add lich su
            Webcom webcom1 = new Webcom();
            webcom1.Title = label1.Text;
            webcom1.Label_text1 = label2.Text;
            //MessageBox.Show(webcom1.Title);
            webcom1.Label_text2 = label3.Text;
            webcom1.Label_text3 = label4.Text;
            webcom1.Label_text4 = label5.Text;
            webcom1.Label_text5 = label6.Text;
            webcom1.Count = Convert.ToInt32(label7.Text);
            Fav.fav.AddHistory(webcom1);
        }*/
        private void addHis()
        {
            HisoryList.historyControl.AddHistory(Webcom);
        }
        private void addFav()
        {
           Fav.fav.AddHistory(Webcom);
        }
        private void pushBack()
        {
            /*Webcom webcom = new Webcom();
            webcom.Count = Convert.ToInt32(label7.Text);
            webcom.Title = label1.Text;
            webcom.BookMark = Webcom.BookMark;
            GanLabel(ref webcom);
            //label7.Text += webcom.Count.ToString();*/
            UpdateData();
            back.Push(Webcom);
        }
        private void pushNext()
        {
            Webcom webcom = new Webcom();
            webcom.Count = Pagenumber.count;
            webcom.Title = label1.Text;
            GanLabel(ref webcom);
            //label7.Text += webcom.Count.ToString();
            next.Push(webcom);
        }
        private string Createrandom()
        {
            Random random = new Random();
            int n = random.Next(10) + 1;
            Randomstring result = new Randomstring();
            return result.GenerateRandomString(n);
        }
        private void CreaterandomOption()
        {
            label2.Text = Createrandom();
            label3.Text = Createrandom();
            label4.Text = Createrandom();
            label5.Text = Createrandom();
            label6.Text = Createrandom();
        }
        public Form2(TruyenData truyenData)
        {
            
            InitializeComponent();
            label1.Text = "Web title: " + Webcom.Title;
            CreaterandomOption();
            label7.Text = Pagenumber.count.ToString();
            truyenDataform2 = truyenData;

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
        private void Form2_Load(object sender, EventArgs e)
        {
            button_bookmark.BackColor = Color.White;
            truyenDataform2(label1.Text);
            //addHis();
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
                //UpdateData();
                pushBack();
                CreaterandomOption();
                Displayoption();
                Webcom.BookMark = false;
                label1.Text = string.Empty;
                label1.Text = "Finding resutl for: " + textBox1.Text;
                //getTitle(label1.Text);
                truyenDataform2(label1.Text);
                textBox1.Text = string.Empty;
                //label1.Text = string.Empty;
                Pagenumber.count++;
                Webcom.Count = Pagenumber.count;
                label7.Text = Pagenumber.count.ToString();
                EmptyNext();
                addHis();
            }
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            pushBack();
            //UpdateData();
            Webcom.BookMark = false;
            Pagenumber.count++;
            //textBox1.Text = label2.Text;
            label1.Text = "Title: " + label2.Text;
            truyenDataform2(label1.Text);
            Webcom.Count = Pagenumber.count;
            CreaterandomOption();
            label7.Text = Pagenumber.count.ToString();
            EmptyNext();
            addHis() ;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {
            pushBack();
            Webcom.BookMark = false;
            Pagenumber.count++;
            //textBox1.Text = label6.Text;
            label1.Text = "Title: " + label6.Text;
            truyenDataform2(label6.Text);
            CreaterandomOption();
            Webcom.Count = Pagenumber.count;
            label7.Text = Pagenumber.count.ToString();
            EmptyNext();
            addHis() ;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {
            pushBack();
            //UpdateData();
            Webcom.BookMark = false;
            Pagenumber.count++;
            //textBox1.Text = label3.Text;
            label1.Text = "Title: " + label3.Text;
            truyenDataform2(label1.Text);
            CreaterandomOption();
            Webcom.Count = Pagenumber.count;
            label7.Text = Pagenumber.count.ToString();
            EmptyNext();
            addHis() ;
        }
        private void label4_Click(object sender, EventArgs e)
        {
            pushBack();
            //UpdateData();
            Webcom.BookMark = false;
            Pagenumber.count++;
            //textBox1.Text = label4.Text;
            label1.Text = "Title: " + label4.Text;
            truyenDataform2(label4.Text);
            CreaterandomOption();
            Webcom.Count = Pagenumber.count;
            label7.Text = Pagenumber.count.ToString();
            EmptyNext();
            addHis() ;
        }
        private void label5_Click(object sender, EventArgs e)
        {
            pushBack();
            //UpdateData();
            Webcom.BookMark = false;
            Pagenumber.count++;
            //textBox1.Text = label5.Text;
            label1.Text = "Title: " + label5.Text;
            truyenDataform2(label1.Text);
            CreaterandomOption();
            Webcom.Count = Pagenumber.count;
            label7.Text = Pagenumber.count.ToString();
            EmptyNext();
            addHis() ;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button_reload_Click(object sender, EventArgs e)
        {

        }
        private void button_bookmark_Click_1(object sender, EventArgs e)
        {
            if(button_bookmark.BackColor == Color.White)
            {
                button_bookmark.BackColor = Color.Yellow;
                Webcom.BookMark = true;
                addFav();
            }
            else
            {
                button_bookmark.BackColor = Color.White;
                Webcom.BookMark = false;

            }
          
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
            //MessageBox.Show("Tao ne");
          /*  Webcom webcom = new Webcom();
            webcom.Count = Convert.ToInt32(label7.Text);
            webcom.Title = label1.Text;
            GanLabel(ref webcom);
            //label7.Text += webcom.Count.ToString();*/
            UpdateData();
            next.Push(Webcom);
            // day vo next
            Webcom = back.Pop();
            label1.Text = Webcom.Title;
            truyenDataform2(label1.Text);
            label7.Text = Webcom.Count.ToString();
            HoantraLabel();
            if (label1.Text == "Web title: Welcome home!")
            {
                Hideoption();
            }
            else
            {
                Displayoption();
            }
            checkBookMark();
            // lui ve
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if (next.isEmpty())
            {
                MessageBox.Show("Next is empty", "Warning!");
                return;
            }
            /*Webcom webcom = new Webcom();
            webcom.Count = Convert.ToInt32(label7.Text);
            webcom.Title = label1.Text;  
            GanLabel(ref webcom);
            //label7.Text += webcom.Count.ToString();*/
            UpdateData();
            back.Push(Webcom);
            Webcom = next.Pop();
            HoantraLabel();
            //.Text = web.Title;
            truyenDataform2(label1.Text);
            //label7.Text = web.Count.ToString();
            if (label1.Text == "Web title: Welcome home!")
            {
                Hideoption();
            }
            else
            {
                Displayoption();
            }
            checkBookMark();
        }
        private void EmptyNext()
        {
            while (!next.isEmpty())
            {
                next.Pop();
            }
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
  
}
