using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dor
{
    public partial class Form5 : Form
    {

        //TRANSAKSI
        private string categoryname;
        public Form5(string categoryName)
        {
            InitializeComponent();
            this.categoryname = categoryName;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
