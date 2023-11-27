using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB
{
    public class Webcom
    {
        private int count = 0;
        private string title = "Title: Welcome home!";
        private string label_text1 = "Option 1";
        private string label_text2 = "Option 2";
        private string label_text3 = "Option 3";
        private string label_text4 = "Option 4";
        private string label_text5 = "Option 5";
        private Webcom NextforHistory = null;
        private Webcom NextforStack = null;
        private Webcom NextforFav = null;
        private bool bookMark = false;
        private string tenThuMuc = string.Empty;
     
        private DateTime datatime2 = DateTime.Now;
       
        private DateTime dateTime = DateTime.Now;

        public Webcom()
        {

        }

        public Webcom(int count, string title, string label_text1, string label_text2, string label_text3, string label_text4, string label_text5, Webcom nextforHistory, Webcom nextforStack, Webcom nextforFav, bool bookMark, DateTime dateTime)
        {
            this.count = count;
            this.title = title;
            this.label_text1 = label_text1;
            this.label_text2 = label_text2;
            this.label_text3 = label_text3;
            this.label_text4 = label_text4;
            this.label_text5 = label_text5;
            NextforHistory = nextforHistory;
            NextforStack = nextforStack;
            NextforFav = nextforFav;
            this.bookMark = bookMark;
            this.DateTime1 = dateTime;
        }

        public string Label_text1 { get => label_text1; set => label_text1 = value; }
        public string Label_text2 { get => label_text2; set => label_text2 = value; }
        public string Label_text3 { get => label_text3; set => label_text3 = value; }
        public string Label_text4 { get => label_text4; set => label_text4 = value; }
        public string Label_text5 { get => label_text5; set => label_text5 = value; }
        public int Count { get => count; set => count = value; }
        public string Title { get => title; set => title = value; }
      
        public bool BookMark { get => bookMark; set => bookMark = value; }
       
        public Webcom NextforStack1 { get => NextforStack; set => NextforStack = value; }
        public Webcom NextforHistory1 { get => NextforHistory; set => NextforHistory = value; }
        //public DateTime DateTime { get => DateTime1; set => DateTime1 = value; }
        public Webcom NextforFav1 { get => NextforFav; set => NextforFav = value; }
        /// <summary>
        /// Quan ly ngay, thang, nam
        /// </summary>
        public DateTime DateTime1 { get => dateTime; set => dateTime = value; }
        /// <summary>
        /// Quan ly gio phut giay
        /// </summary>
        public DateTime Datatime2 { get => datatime2; set => datatime2 = value; }
        public string TenThuMuc { get => tenThuMuc; set => tenThuMuc = value; }
    }
    class Stack
    {
        private Webcom head = null;
        internal Webcom Head { get => head; set => head = value; }
        public Stack() { }
        /// <summary>
        /// Day vao 1 phan tu
        /// </summary>
        /// <param name="webcomponent"></param>
        public void Push(ref Webcom webcomponent)
        {
            if (Head == null)
            {
                Head = webcomponent;
                return;
            }
            webcomponent.NextforStack1 = Head;
            Head = webcomponent;
            return;
        }
        /// <summary>
        /// Tra ve phan tu top
        /// </summary>
        /// <returns></returns>
        public void Pop(ref Webcom webcom)
        {
            if (Head == null)
            {
                return;
            }
            webcom = Head;
            Head = Head.NextforStack1;
            //return webcomponent;
        }
        /// <summary>
        /// Stack co rong khong?
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            if (Head == null)
            {
                return true;
            }
            return false;
        }
    }
}
