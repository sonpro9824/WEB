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
    public partial class Form1 : Form
    {
        //private int n = 1;
        string tabpagename = "";
 
        public void SetNameTabpage(string name)
        {
            tabControl1.SelectedTab.Tag = name;
        }
       
        public Form1()
        {
            InitializeComponent();
            Webcom webcom = new Webcom();
            Addtab(ref webcom);
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
           
            Form2 form2 = new Form2(TabName,ref webcom);
            form2.Text = form2.Webcom1.Title;
            TabPage tabPage = new TabPage { Text = webcom.Title};
            tabControl1.TabPages.Add(tabPage);
            //MessageBox.Show(webcom.Label_text1);
            //n++;
            tabPage.BorderStyle = BorderStyle.Fixed3D;
            form2.TopLevel = false;
            form2.Parent = tabPage;
            if (webcom.Title != "Title: Welcome home!")
                form2.Displayoption();
            else form2.Hideoption();
            form2.HoantraLabel(ref webcom);
            form2.Show();
            form2.Dock = DockStyle.Fill;
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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count!=0)
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            else
            {
                return;
            }
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            
            TabPage tabPage = new TabPage { Text = "History" };
            Form4 form4 = new Form4(Addtab, tabPage, Chuyentab);
            tabPage.BorderStyle = BorderStyle.Fixed3D;
            tabControl1.TabPages.Add(tabPage);
            form4.TopLevel = false;
            form4.Parent = tabPage;
            form4.Show();
            form4.Dock = DockStyle.Fill;
            //form4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            TabPage tabPage = new TabPage { Text = "Favorite list" };
            Form5 form5 = new Form5(Addtab, tabPage, Chuyentab);
            tabPage.BorderStyle = BorderStyle.Fixed3D;
            tabControl1.TabPages.Add(tabPage);
            form5.TopLevel = false;
            form5.Parent = tabPage;
            form5.Show();
            form5.Dock = DockStyle.Fill;
        }
    }
}
