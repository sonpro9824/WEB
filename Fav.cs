using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB
{

    internal class Fav
    {
        private Webcom head = null;
        private Webcom tail = null;

        public Webcom Head { get => head; set => head = value; }
        public Webcom Tail { get => tail; set => tail = value; }
        public void AddFav(ref Webcom webcom)
        {
            if (head == null)
            {
                head = webcom;
                tail = webcom;
                return;
            }
            tail.NextforFav1 = webcom;
            tail = webcom;
            tail.NextforFav1 = null;
        }
        public void RemoveFav(ref Webcom webcom)
        {
            if (head == webcom)
            {
                head = head.NextforFav1;
                webcom.NextforFav1 = null;
                return;
            }
            for (var i = head; i != null; i = i.NextforFav1)
            {
                if (i.NextforFav1 == webcom)
                {
                    webcom.BookMark = false;
                    i.NextforFav1 = webcom.NextforFav1;
                    webcom.NextforFav1 = null;
                }
            }
        }
        public void Sort_Name()
        {
            if (Head == null || head.NextforFav1 == null) return;
            Webcom i = new Webcom();
            Webcom prei = new Webcom();

            i = head;
            prei = i;
            Webcom result = new Webcom();
            Webcom presult = new Webcom();
            FindMaxDate(ref i, ref presult, ref result);
            if (result != head)
            {
                Webcom temp = result.NextforFav1;
                presult.NextforFav1 = head;
                result.NextforFav1 = head.NextforFav1;
                head.NextforFav1 = temp;
                if (result == tail)
                {
                    tail = head;
                }
            }
            head = result;
            i = head.NextforFav1;
            prei = head;
            while (i != null)
            {

                FindMaxDate(ref i, ref presult, ref result);
                //MessageBox.Show(result.DateTime1.ToShortDateString());
                if (result != i)
                {
                    Webcom temp = result.NextforFav1;
                    presult.NextforFav1 = i;
                    result.NextforFav1 = i.NextforFav1;
                    i.NextforFav1 = temp;
                    prei.NextforFav1 = result;
                    //i = result;
                    if (result == tail)
                    {
                        tail = i;
                    }
                }
                i = result.NextforFav1;
                prei = result;
            }
        }
        public void FindMaxDate(ref Webcom current, ref Webcom Presult, ref Webcom Result)
        {
            Result = current;
            Presult = current;

            Webcom i = current.NextforFav1;
            Webcom temp = current;
            while (i != null)
            {

                if (String.Compare(Result.TenThuMuc,i.TenThuMuc ) > 0)
                {
                    Presult = temp;
                    Result = i;
                }
                else if (String.Compare(Result.TenThuMuc, i.TenThuMuc) == 0 && String.Compare(Result.TenThuMuc, i.TenThuMuc) > 0)
                {
                    Presult = temp;
                    Result = i;
                }
                temp = i;
                i = i.NextforFav1;
            }
        }
    }
    class FavControl
    {
        public static Fav FavList = new Fav();
    }
}
