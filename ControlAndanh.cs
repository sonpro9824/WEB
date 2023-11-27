using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WEB
{
    public delegate void DoiTen(string text);
    public partial class ControlAndanh : Form
    {
        private Timer resizeTimerInc;
        private bool resizeInc = false;

        public Timer ResizeTimerInc { get => resizeTimerInc; set => resizeTimerInc = value; }
        public bool ResizeInc { get => resizeInc; set => resizeInc = value; }

        public ControlAndanh()
        {
            InitializeComponent();
            Webcom webcom = new Webcom();
            Addtab(ref webcom);
            
           
        }
        public void ChuyenTab(TabPage tab)
        {
            tabControlInc.SelectedTab = tab;
        }
        public void Addtab(ref Webcom webcom)
        {
            string firsttitle = webcom.Title;
            TabPage tabPage = new TabPage();
            tabControlInc.TabPages.Add(tabPage);
            ChuyenTab(tabPage);
            TabAndanh tabAndanh = new TabAndanh(DoitenTab, ref webcom);
            tabAndanh.TopLevel = false;
            tabAndanh.Parent = tabPage;
            tabAndanh.Show();
            tabPage.BorderStyle = BorderStyle.Fixed3D;
        }
        private void iconButton7_Click(object sender, EventArgs e)
        {
            Webcom webcom = new Webcom();
            Addtab(ref webcom);
        }
        public void DoitenTab(string text)
        {
            tabControlInc.SelectedTab.Text = text;
        }
        private void ControlAndanh_Load(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            if (tabControlInc.TabPages.Count != 0)
                tabControlInc.TabPages.Remove(tabControlInc.SelectedTab);
            else
            {
                //MessageBox.Show("Out of tab!");
                return;
            }
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {

            try
            {
                resizeTimerInc.Start();
                if (ResizeInc == false)
                {
                    //tabControl1.Size = new Size(885, 500);
                    if (tabControlInc.Width < 880)
                        tabControlInc.Width += 5;
                    if (tabControlInc.Width >= 880)
                    {
                        ResizeInc = true;
                        ResizeTimerInc.Stop();
                    }
                }
                else
                {
                    if (tabControlInc.Width > 770)
                        tabControlInc.Width -= 5;
                    if (tabControlInc.Width <= 770)
                    {
                        ResizeInc = false;
                        ResizeTimerInc.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");
            }
            
        }

        
    }
}
