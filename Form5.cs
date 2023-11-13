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
    public partial class Form5 : Form
    {
        public Taotab sender;
        public ChuyenTab chuyen;
        TabPage tabPage1;
        public Form5(Taotab receiver, TabPage tabPage, ChuyenTab chuyen)
        {
            InitializeComponent();
            sender = receiver;
            this.tabPage1 = tabPage;
            this.chuyen = chuyen;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
