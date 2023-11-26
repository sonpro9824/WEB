using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows;

namespace WEB
{
    internal class HistoryControl
    {
        private Webcom head = null;
        private Webcom tail = null;
        
        internal Webcom Head { get => head; set => head = value; }
        internal Webcom Tail { get => tail; set => tail = value; }
        public void FindMaxDate(ref Webcom current, ref Webcom Presult, ref Webcom Result)
        {
            Result = current;
            Presult = current;

            Webcom i = current.NextforHistory1;
            Webcom temp = current;
            while (i!=null)
            {

                if (DateTime.Compare(i.DateTime1, Result.DateTime1) > 0)
                {
                    Presult = temp;
                    Result = i;
                }
                temp = i;
                i = i.NextforHistory1;
            }
        }
        public void Sort_Date()
        {
            if (Head == null || head.NextforHistory1 == null) return;
            /*bool swapp;

            do
            {
                swapp = false;
                Webcom curr = Head;
                Webcom pre = null;
                Webcom next = Head.NextforHistory1;
                while (next != null)
                {
                    if (curr.DateTime1 > next.DateTime1)
                    {
                        if (pre == null)
                        {
                            Head = next;

                        }
                        else
                        {
                            pre.NextforHistory1 = next;
                        }
                        curr.NextforHistory1 = next.NextforHistory1;
                        next.NextforHistory1 = curr;
                        swapp = true;
                    }
                    pre = curr;
                    curr = curr.NextforHistory1;
                    next = curr.NextforHistory1;
                }


            } while (swapp);*/
            // Chuyen danh sach lk sang mang dac
            /*  Webcom[] array = new Webcom[1000];
              int count = 0;
              for (var i = HisoryList.historyControl.head; i != null; i = i.NextforHistory1)
              {
                  array[count] = new Webcom();
                  array[count] = i;
                  count++;
              }

              for (int i = 0; i < count - 1; i++)
              {
                  for (int j = i + 1; j < count; j++)
                  {
                      //MessageBox.Show(j.ToString() + " " + array[j].DateTime1);
                      if (DateTime.Compare(array[i].DateTime1, array[j].DateTime1) <= 0)
                      {
                          Webcom temp = array[i];
                          array[i] = array[j];
                          array[j] = temp;
                      }
                  }
              }
              System.Windows.Forms.MessageBox.Show("Test");
              for (int i = 0; i < count; i++)
              {
                  if (array[i + 1] != null)
                  {
                      array[i].NextforHistory1 = array[i + 1].NextforHistory1;
                  }

              }
              head = array[0];
              tail = array[count - 1];
              tail.NextforHistory1 = null;*/
            /* Webcom temphead = head;
             Webcom temptail = null;
             for (var i = head.NextforHistory1; i!=null; i = i .NextforHistory1 )
             {
                 for (var j = temphead; j!=null; j = j.NextforHistory1)
                 {
                     if (DateTime.Compare(i.DateTime1,j.DateTime1)>=0)
                     {

                     }
                 }
             }*/
            Webcom i = new Webcom();
            Webcom prei = new Webcom();
            
            i = head;
            prei = i;
            Webcom result = new Webcom();
            Webcom presult = new Webcom();
            FindMaxDate(ref i, ref presult, ref result);
            if (result!=head)
            {
                Webcom temp = result.NextforHistory1;
                presult.NextforHistory1 = head;
                result.NextforHistory1 = head.NextforHistory1;
                head.NextforHistory1 = temp; 
            }
            head = result;
            i = head.NextforHistory1;
            prei = head;
            while (i != null)
            {

                FindMaxDate(ref i, ref presult, ref result);
                //MessageBox.Show(result.DateTime1.ToShortDateString());
                if (result != i)
                {
                    Webcom temp = result.NextforHistory1;
                    presult.NextforHistory1 = i;
                    result.NextforHistory1 = i.NextforHistory1;
                    i.NextforHistory1 = temp;
                    prei.NextforHistory1 = result;
                    //i = result;
                    if (i == head)
                    {
                        head = result;
                    }
                }
                i = result.NextforHistory1;
                prei = result;
            }
            //MessageBox.Show("Head datetime = " + head.DateTime1.ToShortDateString());
        }
        public void AddHistory(ref Webcom webcom)
        {
            if (Head == null)
            {
                Head = webcom;
                Tail = webcom;
                return;
            }
            Tail.NextforHistory1 = webcom;
            Tail = webcom;
            tail.NextforHistory1 = null;
         /*   if (!HasHistory.hashHistory.ContainsKey(webcom.Count))
            {
                HasHistory.hashHistory.Add(webcom.Count, webcom);
            }
            return;*/
        }
        /// <summary>
        /// Nhan vao t tham so ref, tach tham so nay ra khoi list hisory
        /// </summary>
        /// <param name="WeBcom"></param>
        public void TachHistory(ref Webcom WeBcom)
        {
            if (Head == null)
                return;
            if (WeBcom == head)
            {
                head = head.NextforHistory1;
                WeBcom.NextforHistory1 = null;
            }
           for (var i = head; i!=null; i=i.NextforHistory1)
           {
                if (i.NextforHistory1 == WeBcom)
                {
                    i.NextforHistory1 = WeBcom.NextforHistory1;
                    WeBcom.NextforHistory1 = null;
                    //WeBcom.NextforHistory1 = null;
                   /* tail.Next = WeBcom;
                    tail = WeBcom;
                    tail.Next = null;*/
                    return;
                }
           }
        }
      /*  public void Noibot(ref Webcom webcom)
        {
            if (webcom == head)
            {
                head = head.Next;
                tail.Next = webcom;
                tail = webcom;
                tail.Next = null;
                return;
            }
            if (webcom == tail)
                return;
            for (var web = head; web!=null; web=web.Next)
            {
                if (web.Next == webcom)
                {
                    Webcom temp = web.Next;
                    web.Next = temp.Next;
                    tail.Next = temp;
                    tail = temp;
                    tail.Next = null;
                    return;
                }
            }
        }*/
    }
    class HisoryList
    {
        public static HistoryControl historyControl = new HistoryControl();
       
    }
    /*class HasHistory
    {
        public static Hashtable hashHistory = new Hashtable();
        /// <summary>
        /// Doi cho Webcom vua moi duoc truy cap tu lich su, nhan nut back/ next len dau history list
        /// </summary>
        /// <param name="pagenumber"></param>
        public static void Noibot(int pagenumber)
        {
            if (hashHistory[pagenumber] == HisoryList.historyControl.Tail || hashHistory[pagenumber] == HisoryList.historyControl.Head)
            {
                return;
            }
            ((Webcom)hashHistory[pagenumber - 1]).Next = ((Webcom)hashHistory[pagenumber]).Next;
            HisoryList.historyControl.Tail = ((Webcom)hashHistory[pagenumber]);
            ((Webcom)hashHistory[pagenumber]).Next = null;
        }
    }*/
}
