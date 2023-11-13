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
            for (var i=head; i!=null; i=i.NextforFav1)
            {
                if (i.NextforFav1 == webcom)
                {
                    webcom.BookMark = false;
                    i.NextforFav1 = webcom.NextforFav1;
                    webcom.NextforFav1 = null;
                }
            }
        }
    }
    class FavControl
    {
        public static Fav FavList = new Fav();
    }
}
