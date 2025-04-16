//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace MoladWithSearch
//{
//    public partial class Searcher : Form
//    {
//        public Searcher()
//        {
//            //InitializeComponent();

//            //cmbMonth.Items.Add("TISHREI");
//            //cmbMonth.Items.Add("CHESHVAN");
//            //cmbMonth.Items.Add("KISLEV");
//            //cmbMonth.Items.Add("TEVES");
//            //cmbMonth.Items.Add("SHEVAT");
//            //cmbMonth.Items.Add("ADAR 1");
//            //cmbMonth.Items.Add("ADAR 2");
//            //cmbMonth.Items.Add("NISSAN");
//            //cmbMonth.Items.Add("IYAR");
//            //cmbMonth.Items.Add("SIVAN");
//            //cmbMonth.Items.Add("TAMUZ");
//            //cmbMonth.Items.Add("AV");
//            //cmbMonth.Items.Add("ELUL");


//        }

//        private void btnSearch_Click(object sender, EventArgs e)
//        {
//            //Closes Search Form

//            if (cmbMonth.Text == "")
//            {
//                MessageBox.Show("Please Enter A Month");
//            }

//            else if (txtYear.Text == "")
//            {
//                MessageBox.Show("Please Enter A Year");
//            }

//            else if (int.Parse(txtYear.Text) <= 3761)
//            {
//                MessageBox.Show("Please Enter A Later Year");
//            }

//            else if (int.Parse(txtYear.Text) >= 13760)
//            {
//                MessageBox.Show("Please Enter An Earlier Year");
//            }

//            else
//            {

//                Close();
//            }
//        }

//        public string GetMonthSearch()
//        {
//            //Retruns Seached Month

//            return cmbMonth.Text;
//        }

//        public string GetYearSearch()
//        {
//            //Retruns Seached Year

//            return txtYear.Text;
//        }

//    }
//}
