using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WEB
{
    public delegate void TruyenData(string text);
    public delegate void Taotab(ref Webcom webcom);
    public delegate void ChuyenTab(TabPage tabPage);
    public delegate void RemoveCurrentTab();
    public delegate void Refresh(ref Webcom webcom);
    public delegate void menu();
    public partial class Form1 : Form
    {
        Resizeform receiver;
       //public event menu resizef2;
        //private int n = 1;
        //string tabpagename = "";
        private Timer resizeTimer;
        private bool resize = false;
        public void SetNameTabpage(string name)
        {
            tabControl1.SelectedTab.Tag = name;
        }
       
        public Form1()
        {
            InitializeComponent();
            Webcom webcom = new Webcom();
            Addtab(ref webcom);
            ResizeTimer = new Timer();
            ResizeTimer.Interval = 10;
            ResizeTimer.Tick += iconButton5_Click;
            ResizeTimer.Start();
        }

        
        /// <summary>
        /// Xoa form con hien tai va thay bang form 2
        /// </summary>
        /// <param name="webcom"></param>
        public void ChenTab(ref Webcom webcom)
        {
            tabControl1.SelectedTab.Controls.Clear();
            Form2 form2 = new Form2(TabName, ref webcom, ref receiver);
            form2.Text = form2.Webcom1.Title;
            tabControl1.SelectedTab.Text = webcom.Title;
            form2.TopLevel = false;
            form2.Parent = tabControl1.SelectedTab;
            if (webcom.Title != "Title: Welcome home!")
                form2.Displayoption();
            else form2.Hideoption();
            form2.HoantraLabel(ref webcom);
            form2.Dock = DockStyle.Fill;
            form2.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void TabName(string tabname)
        {
            tabControl1.SelectedTab.Text = tabname;
        }
        private void Addtab(ref Webcom webcom)
        {
           
            Form2 form2 = new Form2(TabName,ref webcom, ref receiver);
            form2.Text = form2.Webcom1.Title;
            TabPage tabPage = new TabPage { Text = webcom.Title};
            tabControl1.TabPages.Add(tabPage);
            ChuyenTab chuyenTab = new ChuyenTab(Chuyentab);
            chuyenTab(tabPage);
            //MessageBox.Show(webcom.Label_text1);
            //n++;
            tabPage.BorderStyle = BorderStyle.Fixed3D;
            form2.TopLevel = false;
            form2.Parent = tabPage;
            if (webcom.Title != "Title: Welcome home!")
                form2.Displayoption();
            else form2.Hideoption();
            form2.HoantraLabel(ref webcom);
            form2.Dock = DockStyle.Fill;
            form2.Show();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Pagenumber.count++;
            Webcom webcom = new Webcom();
            webcom.Count = Pagenumber.count;
            Addtab(ref webcom);
        }
        public void Chuyentab(TabPage tab)
        {
            tabControl1.SelectedTab = tab;
        }
        public void RemoveTab()
        {
            if (tabControl1.TabPages.Count != 0)
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            else
            {
                MessageBox.Show("Out of tab!");
                return;
            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            RemoveTab();
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            
            TabPage tabPage = new TabPage { Text = "History" };
            CreateForm4(ref tabPage);
            //form4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        }
        /// <summary>
        /// Tao form 4
        /// </summary>
        /// <param name="tabPage"></param>
        public void CreateForm4(ref TabPage tabPage)
        {
            Refresh chuyenTab = new Refresh(ChenTab);
            Form4 form4 = new Form4(Addtab, ref tabPage, Chuyentab, RemoveTab, ChenTab);
            tabPage.BorderStyle = BorderStyle.Fixed3D;
            tabControl1.TabPages.Add(tabPage);
            form4.TopLevel = false;
            form4.Parent = tabPage;
            form4.Show();
            form4.Dock = DockStyle.Fill;
         
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Favorite chuc nang
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iconButton4_Click(object sender, EventArgs e)
        {
            TabPage tabPage = new TabPage { Text = "Favorite list" };
            Form5 form5 = new Form5(Addtab, tabPage, Chuyentab, ChenTab);
            tabPage.BorderStyle = BorderStyle.Fixed3D;
            tabControl1.TabPages.Add(tabPage);
            form5.TopLevel = false;
            form5.Parent = tabPage;
            form5.Show();
            form5.Dock = DockStyle.Fill;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
     
        }

        private void tabControl1_DragDrop(object sender, DragEventArgs e)
        {
            TabPage draggedTab = (TabPage)e.Data.GetData(typeof(TabPage));
            int newIndex = GetHoverTabIndex(tabControl1.PointToClient(new Point(e.X, e.Y)));

            if (newIndex >= 0)
            {
                tabControl1.TabPages.Remove(draggedTab);
                tabControl1.TabPages.Insert(newIndex, draggedTab);
                tabControl1.SelectedTab = draggedTab;
            }
        }
        private Point point;

        public Timer ResizeTimer { get => resizeTimer; set => resizeTimer = value; }
        public bool Resize1 { get => resize; set => resize = value; }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }
        private void tabControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    Rectangle rect = tabControl1.GetTabRect(i);
                    if (rect.Contains(point))
                    {
                        TabPage selectedTab = tabControl1.TabPages[i];
                        tabControl1.DoDragDrop(selectedTab, DragDropEffects.All);
                    }
                }
            }
        }


        private void tabControl1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void tabControl1_DragOver(object sender, DragEventArgs e)
        {
            Point clientPoint = tabControl1.PointToClient(new Point(e.X, e.Y));
            int hoverIndex = GetHoverTabIndex(clientPoint);

            if (hoverIndex >= 0 && hoverIndex < tabControl1.TabPages.Count)
            {
                tabControl1.SelectedIndex = hoverIndex;
            }
        }
        private int GetHoverTabIndex(Point point)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                Rectangle rect = tabControl1.GetTabRect(i);
                if (rect.Contains(point))
                {
                    return i;
                }
            }
            return -1;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            
            //resizef2?.Invoke();
            ResizeTimer.Start();
            if(Resize1 == false)
            {
                //tabControl1.Size = new Size(885, 500);
                if (tabControl1.Width < 880)
                    tabControl1.Width += 5;
                if(tabControl1.Width >=880)
                {
                    Resize1 = true;
                    ResizeTimer.Stop();
                }
            }
            else
            {
                if(tabControl1.Width>770)
                    tabControl1.Width -= 5;
                if(tabControl1.Width <=770)
                {
                    Resize1 = false;
                    ResizeTimer.Stop();
                }
            }
            //receiver();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            ResizeTimer.Start();
            if (Resize1 == false)
            {
                //tabControl1.Size = new Size(885, 500);
                if (tabControl1.Width < 880)
                    tabControl1.Width += 5;
                if (tabControl1.Width >= 880)
                {
                    Resize1 = true;
                    ResizeTimer.Stop();
                }
            }
            else
            {
                if (tabControl1.Width > 770)
                    tabControl1.Width -= 5;
                if (tabControl1.Width <= 770)
                {
                    Resize1 = false;
                    ResizeTimer.Stop();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Pagenumber.count++;
            Webcom webcom = new Webcom();
            webcom.Count = Pagenumber.count;
            Addtab(ref webcom);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            TabPage tabPage = new TabPage { Text = "History" };
            CreateForm4(ref tabPage);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            TabPage tabPage = new TabPage { Text = "Favorite list" };
            Form5 form5 = new Form5(Addtab, tabPage, Chuyentab, ChenTab);
            tabPage.BorderStyle = BorderStyle.Fixed3D;
            tabControl1.TabPages.Add(tabPage);
            form5.TopLevel = false;
            form5.Parent = tabPage;
            form5.Show();
            form5.Dock = DockStyle.Fill;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            RemoveTab();
        }

        private void iconDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
        /*    TabControl tabControl2 = new TabControl();
            TabPage tabPage = new TabPage();
            Form6 TabAndanh = new Form6();
            tabPage.BorderStyle = BorderStyle.Fixed3D;
            tabControl2.TabPages.Add(tabPage);
            tabPage.Dock = DockStyle.Fill;
            TabAndanh.TopLevel = false;
            TabAndanh.Parent = tabPage;
            tabControl2.Show();
            tabControl2.
            TabAndanh.Show();*/
            ControlAndanh controlAndanh = new ControlAndanh();
            
            controlAndanh.Show();
            //this.Visible = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
