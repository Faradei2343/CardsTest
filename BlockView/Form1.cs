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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DBConnection.ConnectDB();
            TestQuery.TestSelectForCards();
            FillCards();
        }

        private void FillCards()
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < TestQuery.dtUsers.Rows.Count; i++)
            {
                var pn = new Panel();
                pn.Size = new Size(500, 130);
                pn.BorderStyle = BorderStyle.FixedSingle;
                flowLayoutPanel1.Controls.Add(pn);
                var lbFio = new Label();
                lbFio.Text = "ФИО: " + TestQuery.dtUsers.Rows[i].ItemArray[0];
                lbFio.AutoSize = true;
                pn.Controls.Add(lbFio);
                var lbPhone = new Label();
                lbPhone.Text = "Телефон: " + TestQuery.dtUsers.Rows[i].ItemArray[1];
                lbPhone.AutoSize = true;
                lbPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                lbPhone.Location = new System.Drawing.Point(3, 70);
                lbPhone.Size = new System.Drawing.Size(126, 23);
                var bt = new Button();
                bt.Dock = System.Windows.Forms.DockStyle.Right;
                bt.Location = new System.Drawing.Point(343, 0);
                bt.Size = new System.Drawing.Size(75, 103);
                bt.Text = ">";
                bt.Click += button1_Click;
                bt.Name = TestQuery.dtUsers.Rows[i].ItemArray[2].ToString();
                var btDel = new Button();
                btDel.Dock = System.Windows.Forms.DockStyle.Right;
                btDel.Location = new System.Drawing.Point(334, 0);
                btDel.Size = new System.Drawing.Size(75, 103);
                btDel.Text = "X";
                btDel.Click += Delete_Click;
                btDel.Name = TestQuery.dtUsers.Rows[i].ItemArray[2].ToString();
                pn.Controls.Add(btDel);
                pn.Controls.Add(bt);
                pn.Controls.Add(lbPhone);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = (sender as Button).Name;
            TestQuery.TestSelectForCardsCurrentUser(name);
            this.Hide();
            DataViewUser dataViewUser = new DataViewUser();
            dataViewUser.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panelCard_Click(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string name = (sender as Button).Name;
            TestQuery.TestDeleteForCards(name);
            TestQuery.TestSelectForCards();
            FillCards();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
        }
    }
}
