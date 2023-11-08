using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB
{
    internal class HistoryControl
    {
        private Webcom head = null;
        private Webcom tail = null;

        internal Webcom Head { get => head; set => head = value; }
        internal Webcom Tail { get => tail; set => tail = value; }

        public void AddHistory(Webcom webcom)
        {
            if (Head == null)
            {
                Head = webcom;
                Tail = webcom;
                return;
            }
            Tail.Next = webcom;
            Tail = webcom;
            return;
        }
        public void DeleteHistory(Webcom WeBcom)
        {
            if (Head == null)
                return;
            if (WeBcom == head)
            {
                head = head.Next;
                WeBcom = null;
            }
           Webcom i = Head;
           for (i = head; i.Next!=WeBcom; i=i.Next)
           {
                
           }
            i.Next = WeBcom.Next;
            WeBcom = null;
        }
    }
    class HisoryList
    {
        public static HistoryControl historyControl = new HistoryControl();
    }
}
