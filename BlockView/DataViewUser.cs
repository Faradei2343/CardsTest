using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockView
{
    public partial class DataViewUser : Form
    {
        public DataViewUser()
        {
            InitializeComponent();
        }

        private void DataViewUser_Load(object sender, EventArgs e)
        {
            textBox1.Text = TestQuery.dtCurrentUser.Rows[0].ItemArray[0].ToString();
            textBox2.Text = TestQuery.dtCurrentUser.Rows[0].ItemArray[1].ToString();
        }

        private void DataViewUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[0].Show();
        }
    }
}
