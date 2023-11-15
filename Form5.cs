using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WEB
{
    public partial class Form5 : Form
    {
        public Taotab Sender;
        public ChuyenTab chuyen;
        TabPage tabPage1;
        public static ArrayList FavList = new ArrayList();
        public Refresh refresh;
        public ArrayList WebFavList = new ArrayList();
        Webcom webcom = new Webcom();
        public Form5(Taotab receiver, TabPage tabPage, ChuyenTab chuyen, Refresh SwapTab)
        {
            InitializeComponent();
            Sender = receiver;
            this.tabPage1 = tabPage;
            this.chuyen = chuyen;
            refresh = SwapTab;
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            int height = 80;
            int count = 0;
            for (var i = FavControl.FavList.Head; i!=null; i=i.NextforFav1)
            {
                //MessageBox.Show("Heloo");
                FavList.Add(i);
                Label label = new Label()
                {
                    Tag = count
                };
                label.Text = ((Webcom)i).Title + " --- Page number : " + i.Count.ToString()+ "\nDate Time: " + ((Webcom)i).DateTime.ToString();
                if (((Webcom)i).BookMark == true)
                {
                    label.BackColor = Color.Yellow;
                }
                else
                {
                    label.BackColor = Color.White;
                }
                WebFavList.Add(i);
                label.AutoSize = true;
                label.Location = new System.Drawing.Point(0, height);
                height += 50;
                label.Visible = true;
                this.Controls.Add(label);
                label.MouseUp += Label_Click;
                count++;
            }
        }
        int lbindex = default;
        private void Label_Click(object sender, MouseEventArgs e)
        {
            if (sender is Label Clicked_Label)
            {
                int labelindex = (int)Clicked_Label.Tag;
                lbindex = labelindex;
                string labelname = Clicked_Label.Text;
                int index = ((Webcom)WebFavList[labelindex]).Count;
                Webcom temp = ((Webcom)WebFavList[labelindex]);
                webcom = temp;
                if (e.Button == MouseButtons.Left)
                {

                      HisoryList.historyControl.TachHistory(ref temp);
                      temp.DateTime = DateTime.Now;
                      //ReceiverRemove();
                      //Sender(ref temp);      
                      //chuyen(tabPage1);
                      refresh(ref temp);
                }
                if (e.Button == MouseButtons.Right)
                {
                     ContextMenuStrip contextMenu = new ContextMenuStrip();
                     System.Drawing.Point point = new System.Drawing.Point(e.Location.X, e.Location.Y);
                     contextMenu.Items.Add("Access in a new tab");
                     contextMenu.Items.Add("Delete this book mark");
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
                webcom.DateTime = DateTime.Now;
                Sender(ref webcom);
                chuyen(tabPage1);
            }
            if (e.ClickedItem.ToString() == "Delete this book mark")
            {
                //System.Windows.MessageBox.Show("Deleted!");
                webcom.BookMark = false;
                if (webcom.BookMark == true)
                {
                    foreach (Control control in tabPage1.Controls)
                    {
                        if (control is Label)
                        {
                            MessageBox.Show("Heloo");
                            Label lb = control as Label;
                            if (Convert.ToInt32(lb.Tag) == lbindex)
                            {
                                lb.BackColor = Color.White;
                            }
                        }
                    }
                }
                /*else
                {
                    ((Label)sender).BackColor = Color.White;
                }*/
                FavControl.FavList.RemoveFav(ref webcom);
            }
        }
    }
}
