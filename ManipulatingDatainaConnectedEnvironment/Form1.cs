using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManipulatingDatainaConnectedEnvironment
{
    public partial class Form1 : Form
    {
        DataTable dt;
        DataRow dr;
        string code;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt = hRDataSet.Tables["empdetails"];
            dr = dt.NewRow();
            dr[0] = txCode.Text;
            dr[1] = txName.Text;
            dr[2] = txAddress.Text;
            dr[3] = txState.Text;
            dr[4] = txCountry.Text;
            dr[5] = cbDesignation.SelectedItem;
            dr[6] = cbDepartment.SelectedItem;
            dt.Rows.Add(dr);
            empdetailsTableAdapter.Update(hRDataSet);
            txCode.Text = System.Convert.ToString(dr[0]);
            txCode.Enabled = false;
            txName.Enabled = false;
            txAddress.Enabled = false;
            txState.Enabled = false;
            txCountry.Enabled = false;
            cbDesignation.Enabled = false;
            cbDepartment.Enabled = false;
            this.empdetailsTableAdapter.Fill(this.hRDataSet.empdetails);
            cmdAdd.Enabled = true;
            cmdSave.Enabled = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hRDataSet.empdetails' table. You can move, or remove it, as needed.
            this.empdetailsTableAdapter.Fill(this.hRDataSet.empdetails);
            this.empdetailsTableAdapter.Fill(this.hRDataSet.empdetails);
            txCode.Enabled = false;
            txName.Enabled = false;
            txAddress.Enabled = false;
            txState.Enabled = false;
            txCountry.Enabled = false;
            cbDesignation.Enabled = false;
            cbDepartment.Enabled = false;
            cbDesignation.Items.Add("MANAGER");
            cbDesignation.Items.Add("AUTHOR");
            cbDesignation.Items.Add("Designer");
            cbDepartment.Items.Add("MARKETING");
            cbDepartment.Items.Add("FINANCE");
            cbDepartment.Items.Add("IDD");
            cmdSave.Enabled = false;


        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            cmdSave.Enabled = true;

            txName.Enabled = true;
            txAddress.Enabled = true;
            txState.Enabled = true;
            txCountry.Enabled = true;
            cbDesignation.Enabled = true;
            cbDepartment.Enabled = true;

            txName.Text = "";
            txAddress.Text = "";
            txState.Text = "";
            txCountry.Text = "";
            cbDesignation.Text = "";
            cbDepartment.Text = "";

            int ctr, len;
            string codeval;
            dt = hRDataSet.Tables["empdetails"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            code = dr["ccode"].ToString();
            codeval = code.Substring(1, 3);
            ctr = Convert.ToInt32(codeval);
            if((ctr >= 1) && (ctr < 9))
            {
                ctr = ctr + 1;
                txCode.Text = "C00" + ctr;
            }else if((ctr >= 9) && (ctr < 9)) {
                ctr = ctr + 1;
                txCode.Text = "C0" + ctr;

            }
            else if(ctr >= 99)
            {
                ctr = ctr + 1;
                txCode.Text = "C" + ctr;
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string code;
            code = txCode.Text;
            dr = hRDataSet.Tables["empdetails"].Rows.Find(code);
            dr.Delete();
            empdetailsTableAdapter.Update(hRDataSet);
        }
    }
}
