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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WEB
{
    public partial class Form5 : Form
    {

        public Taotab Sender;
        public ChuyenTab chuyen;
        TabPage tabPage1;
        //public ArrayList FavList = new ArrayList();
        public Refresh refresh;
        public ArrayList WebFavList = new ArrayList();
        Webcom webcom = new Webcom();
        int lbindex = default;
        public Form5(Taotab receiver, TabPage tabPage, ChuyenTab chuyen, Refresh SwapTab)
        {
            InitializeComponent();
            Sender = receiver;
            this.tabPage1 = tabPage;
            this.chuyen = chuyen;
            refresh = SwapTab;
            label1.Tag = -1;
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            FavControl.FavList.Sort_Name();
            int count = 0;
            string name = FavControl.FavList.Head.TenThuMuc;
            int xG = 10;
            int yG = 50;
            Webcom i = FavControl.FavList.Head;
            while (i != null)
            {
                GroupBox group = new GroupBox();
                group.Location = new System.Drawing.Point(xG, yG);
                group.Text = name;
                group.Font = new Font("Calibri", 14, FontStyle.Bold);
                int x = 10;
                int y = 40;

                while(i != null && i.TenThuMuc == name)
                {
                    WebFavList.Add(i);
                    Label label = new Label()
                    {
                        Tag = count
                    };
                    count++;
                    label.Text = ((Webcom)i).Title + " --- Page number : " + i.Count.ToString() + "\nDate Time: " + ((Webcom)i).DateTime1.ToString("dd/MM/yyyy"); //+  ((Webcom)i).Datatime2.ToString(" HH:mm:ss");
                    if (((Webcom)i).BookMark == true)
                    {
                        label.BackColor = Color.Yellow;
                    }
                    else
                    {
                        label.BackColor = Color.White;
                    }
                    //WebFavList.Add(i);
                    label.AutoSize = true;
                    label.Location = new System.Drawing.Point(x,y);
                    label.Visible = true;
                    label.Font = new Font("Calibri", 12, FontStyle.Regular);
                    
                    label.MouseUp += Label_Click;
                    group.Controls.Add(label);
                    y += 70;
                    i = i.NextforFav1;
                }
                group.AutoSize = true;

                this.Controls.Add(group);
                yG = group.Bottom + 20;
                if (i != null)
                    name = i.TenThuMuc;
            }


            //int height = 80;
            //int count = 0;
            //for (var i = FavControl.FavList.Head; i!=null; i=i.NextforFav1)
            //{
            //    //MessageBox.Show("Heloo");
            //    WebFavList.Add(i);
            //    Label label = new Label()
            //    {
            //        Tag = count
            //    };
            //    label.Text = ((Webcom)i).Title + " --- Page number : " + i.Count.ToString() + "\nDate Time: " + ((Webcom)i).DateTime1.ToString("dd/MM/yyyy"); //+  ((Webcom)i).Datatime2.ToString(" HH:mm:ss");
            //    if (((Webcom)i).BookMark == true)
            //    {
            //        label.BackColor = Color.Yellow;
            //    }
            //    else
            //    {
            //        label.BackColor = Color.White;
            //    }
            //    //WebFavList.Add(i);
            //    label.AutoSize = true;
            //    label.Location = new System.Drawing.Point(0, height);
            //    height += 50;
            //    label.Visible = true;
            //    this.Controls.Add(label);
            //    label.MouseUp += Label_Click;
            //    count++;
            //}
        }
       
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
                      //temp.DateTime = DateTime.Now;
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
                    contextMenu.Items.Add("Mark this Web");
                    if (temp.BookMark==true)
                    {
                        contextMenu.Items[2].Enabled = false;
                    }
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
                //webcom.DateTime = DateTime.Now;
                Sender(ref webcom);
                chuyen(tabPage1);
            }
            if (e.ClickedItem.ToString() == "Delete this book mark")
            {
                //System.Windows.MessageBox.Show("Deleted!");
                    webcom.BookMark = false;
              
                    foreach (Control control in this.Controls)
                    {
                        if (control is Label)
                        {
                            Label lb = control as Label;
                            if (Convert.ToInt32(lb.Tag) == lbindex)
                            {                            
                                lb.BackColor = Color.White;
                            }
                        }
                    }
                    FavControl.FavList.RemoveFav(ref webcom);
                
            }
            if (e.ClickedItem.ToString() == "Mark this Web")
            {
                webcom.BookMark = true;
                foreach (Control control in this.Controls)
                {
                    if (control is Label)
                    {
                        Label lb = control as Label;
                        if (Convert.ToInt32(lb.Tag) == lbindex)
                        {
                            lb.BackColor = Color.Yellow;
                        }
                    }
                }
                FavControl.FavList.AddFav(ref webcom);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            //CreateNewForm(ref tabPage1);
            WebFavList.Clear();
            foreach (Control control in this.Controls)
            {
                control.Enabled = false;
                control.Visible = false;
            }
            label1.Visible = true;
            label1.Enabled = true;
            
            Form5_Load(sender, e);
        }
    }
}
