using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using CRM_BAL;
using CRM_DAL;

namespace CRM_User_Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class frmCRM_Adm_Dashbord : Window
    {

        #region Global Veriable
        NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat;
        public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConstCRM"].ToString());
        SqlCommand cmd;
        SqlDataReader dr;

        SaveFileDialog sfd = new SaveFileDialog();

        static int PK_ID;
        public string filepath;
        public BitmapImage bmp;
        byte[] picture;
        byte[] pictureView;
        string maincked, CName, soe;
        string bpg, cid1;
        int fetcdoc, Cust_id;
        int exist, vsoe;
        List<string> checkedStuff;
        static DataTable dtstat = new DataTable();
        double MA;
        #endregion Global Veriable

        BAL_DealerEntry bdealeretr = new BAL_DealerEntry();
        DAL_DealerEntry ddealeretr = new DAL_DealerEntry();

        BAL_EmployeeEntry bempetr = new BAL_EmployeeEntry();
        DAL_EmployeeEntry dempetr = new DAL_EmployeeEntry();

        CRM_EmployeePhoto bemphpoto = new CRM_EmployeePhoto();
        DAL_EmployeePhoto dempphoto = new DAL_EmployeePhoto();

        BAL_AddProduct baddprd = new BAL_AddProduct();
        DAL_AddProducts daddprd = new DAL_AddProducts();
       // DAL_AddProduct dalprd = new DAL_AddProduct();

        BAL_Pre_Procurement bpreproc = new BAL_Pre_Procurement();
        DAL_Pre_Procurement dpreproc = new DAL_Pre_Procurement();

        BAL_Followup balfollow = new BAL_Followup();
        BAL_FollowUp_Products balfollwproducts = new BAL_FollowUp_Products();
        DAL_Followup dalfollow = new DAL_Followup();

        BAL_AddComments balfollwpcomt = new BAL_AddComments();
        DAL_AddComments dalfollowcomt = new DAL_AddComments();

        BAL_CustomerEntry bcustomer = new BAL_CustomerEntry();
        DAL_CustomerEntry dcustomer = new DAL_CustomerEntry();

        BAL_StockDetails bstockDet = new BAL_StockDetails();
        DAL_StockDetails dstockDet = new DAL_StockDetails();
        DAL_StockDetailsUpdate dstUpdate = new DAL_StockDetailsUpdate();
        DAL_StockAddQty daddqty = new DAL_StockAddQty();

        BAL_FinalDealer bfinaldealer1 = new BAL_FinalDealer();
        DAL_FinalDealer dfinaldealer = new DAL_FinalDealer();
        DAL_FinalDealerUpdate dFup = new DAL_FinalDealerUpdate();

        #region Load Event
        public frmCRM_Adm_Dashbord()
        {
            InitializeComponent();

            checkedStuff = new List<string>();
            PREPROCUREMENTid();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        #endregion Load Event

        private void mainDashBordBorder_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           
        }

        
        private void btnAPPClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            //this.Close();
        }

        #region Dealer Function
        #region DealerEntry Button Event
        private void btnAdm_Dealer_Save_Click(object sender, RoutedEventArgs e)
        {
            if (Dealer_Validation() == true)
                return;

            try
            {
                bdealeretr.Flag = 1;
                bdealeretr.DealerEntryID = lblDealerID.Content.ToString();
                bdealeretr.CompanyName = txtAdm_CompanyName.Text;
                bdealeretr.DealerFirstName = txtAdm_DealerFirstName.Text;
                bdealeretr.DealerLastName = txtAdm_DealerLastName.Text;
                bdealeretr.DateOfBirth = dtpAdm_Dealer_DOB.Text;
                bdealeretr.MobileNo = txtAdm_Dealer_MobileNo.Text;
                bdealeretr.PhoneNo = txtAdm_Dealer_PhoneNo.Text;
                bdealeretr.DealerAddress = txtAdm_Dealer_Address.Text;
                bdealeretr.City = cmbDealer_City.Text;
                bdealeretr.Zip = txtAdm_Dealer_Zip.Text;
                bdealeretr.DState = cmbDealer_State.Text;
                bdealeretr.Country =cmbDealer_Country.Text;
                bdealeretr.S_Status = "Active";

                //string STRTODAYDATE = System.DateTime.Now.ToShortDateString();
                //string time = System.DateTime.Now.ToShortTimeString();
                //string[] STRVAL = STRTODAYDATE.Split('-');
                //string STR_DATE1 = STRVAL[0];
                //string STR_MONTH = STRVAL[1];
                //string STR_YEAR = STRVAL[2];
                //string DATE = STR_DATE1 + "-" + STR_MONTH + "-" + STR_YEAR;
                ////txtdate.Text = DATE;
                ////txttime.Text = time;

                //baddprd.C_Date =Convert .ToDateTime( DATE);
                bdealeretr.C_Date = System.DateTime.Now.ToShortDateString();
                ddealeretr.EmployeeEntry_Insert_Update_Delete(bdealeretr);
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Data Save Successfully";
                obj.ShowDialog();
                //MessageBox.Show("Data Save Successfully", caption, MessageBoxButton.OK, MessageBoxImage.Information);
                Dealer_ResetText();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            Dealerid();
            Load_Delaler_City();
            Load_Delaler_State();
            Load_Delaler_Country();
        }

        private void btnAdm_Dealer_Clear_Click(object sender, RoutedEventArgs e)
        {
            Dealer_ResetText();
            Load_Delaler_City();
            Load_Delaler_State();
            Load_Delaler_Country();
        }

        private void btnAdm_Dealer_Exit_Click(object sender, RoutedEventArgs e)
        {
            grdAdm_DealerDetails.Visibility = System.Windows.Visibility.Hidden;
            Dealer_ResetText();
        }
        #endregion DealerEntry Button Event

        #region Dealer Fun
        public bool Dealer_Validation()
        {
            bool result = false;
            if (txtAdm_DealerFirstName.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Dealer First Name";
                obj.ShowDialog();
                //MessageBox.Show("Please Enter Dealer First Name", caption, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (txtAdm_DealerLastName.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Dealer Last Name";
                obj.ShowDialog();
                //MessageBox.Show("Please Enter Dealer Last Name", caption, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (dtpAdm_Dealer_DOB.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Dealer Date Of Birth";
                obj.ShowDialog();
                //MessageBox.Show("Please Select Dealer Date Of Birth", caption, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (txtAdm_CompanyName.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Company Name";
                obj.ShowDialog();
                //MessageBox.Show("Please Enter Company Name", caption, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (txtAdm_Dealer_MobileNo.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Dealer Mobile No.";
                obj.ShowDialog();
                //MessageBox.Show("Please Enter Dealer Mobile No", caption, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (txtAdm_Dealer_PhoneNo.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Dealer Phone  No.";
                obj.ShowDialog();
                //MessageBox.Show("Please Enter Dealer Phone No", caption, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (txtAdm_Dealer_Address.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Dealer Address";
                obj.ShowDialog();
                //MessageBox.Show("Please Enter Dealer Address", caption, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (cmbDealer_City.Text == "Select")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select City";
                obj.ShowDialog();
               // MessageBox.Show("Please Select City", caption, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (cmbDealer_State.Text == "Select")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select State";
                obj.ShowDialog();
                //MessageBox.Show("Please Select State", caption, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (cmbDealer_Country.Text == "Select")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Country";
                obj.ShowDialog();
                //MessageBox.Show("Please Select Country", caption, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return result;
        }

        public void Dealer_ResetText()
        {
            txtAdm_CompanyName.Text = "";
            txtAdm_DealerFirstName.Text = "";
            txtAdm_DealerLastName.Text = "";
            dtpAdm_Dealer_DOB.SelectedDate = null;
            txtAdm_Dealer_MobileNo.Text = "";
            txtAdm_Dealer_PhoneNo.Text = "";
            txtAdm_Dealer_Address.Text = "";
            cmbDealer_City.SelectedItem = "Select";
            txtAdm_Dealer_Zip.Text = "";
            cmbDealer_State.SelectedItem = "Select";
            cmbDealer_Country.SelectedItem = "Select";
        }

        public void Dealerid()
        {

            int id1 = 0;
            //SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("select (COUNT(ID)) from tbl_DealerEntry", con);
            id1 = Convert.ToInt32(cmd.ExecuteScalar());
            id1 = id1 + 1;
            lblDealerID.Content = "# Dealer /" + id1.ToString();
            con.Close();


        }

        public void Load_Delaler_City()
        {
            cmbDealer_City.Text = "Select";
            string q = "SELECT distinct(City) As City FROM tbl_DealerEntry ";
            cmd = new SqlCommand(q, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //cmbInsurance_CustName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                cmbDealer_City.ItemsSource = ds.Tables[0].DefaultView;
                cmbDealer_City.DisplayMemberPath = ds.Tables[0].Columns["City"].ToString();
            }
        }

        public void Load_Delaler_State()
        {
            cmbDealer_State.Text = "Select";
            string q = "SELECT distinct(DState) As DState FROM tbl_DealerEntry ";
            cmd = new SqlCommand(q, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //cmbInsurance_CustName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                cmbDealer_State.ItemsSource = ds.Tables[0].DefaultView;
                cmbDealer_State.DisplayMemberPath = ds.Tables[0].Columns["DState"].ToString();
            }
        }

        public void Load_Delaler_Country()
        {
            cmbDealer_Country.Text = "Select";
            string q = "SELECT distinct(Country) As Country FROM tbl_DealerEntry ";
            cmd = new SqlCommand(q, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //cmbInsurance_CustName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                cmbDealer_Country.ItemsSource = ds.Tables[0].DefaultView;
                cmbDealer_Country.DisplayMemberPath = ds.Tables[0].Columns["Country"].ToString();
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,-]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        //public void DealerDetails_LoadData()
        //{
        //    try
        //    {
        //        String str;
        //        //con.Open();
        //        DataSet ds = new DataSet();
        //        str = "SELECT [ID],[DealerEntryID],[CompanyName],[DealerFirstName] + ' ' + [DealerLastName] AS [DealerName],[DateOfBirth],[MobileNo],[PhoneNo],[DealerAddress] " +
        //                     "FROM [tbl_DealerEntry] " +
        //                     "WHERE ";
        //        if (txtAdm_CompName_Search.Text.Trim() != string.Empty)
        //        {
        //            str = str + "[CompanyName] LIKE ISNULL('" + txtAdm_CompName_Search.Text.Trim() + "',CompanyName) + '%' AND ";
        //        }
        //        if (txtAdm_DealerName_Search.Text.Trim() != string.Empty)
        //        {
        //            str = str + "[DealerFirstName] LIKE ISNULL('" + txtAdm_DealerName_Search.Text.Trim() + "',DealerFirstName) + '%' AND ";
        //        }
        //        if (txtAdm_DealerMN_Search.Text.Trim() != string.Empty)
        //        {
        //            str = str + "[MobileNo] LIKE ISNULL('" + txtAdm_DealerMN_Search.Text.Trim() + "',MobileNo) + '%' AND ";
        //        }
        //        str = str + " S_Status = 'Active' ORDER BY DealerName ASC ";
        //        SqlCommand cmd = new SqlCommand(str, con);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(ds);

        //        //if (ds.Tables[0].Rows.Count > 0)
        //        //{
        //        dgvAdm_Dealerdetails.ItemsSource = ds.Tables[0].DefaultView;
        //        //}
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        #endregion Fun

        #region Dealer Event
        private void menu_AdmDealerEntry_Click(object sender, RoutedEventArgs e)
        {
            grdAdm_DealerDetails.Visibility = System.Windows.Visibility.Visible;
        }

        private void grdAdm_DealerDetails_Loaded(object sender, RoutedEventArgs e)
        {
            Dealerid();
            Load_Delaler_City();
            Load_Delaler_State();
            Load_Delaler_Country();
        }
        #endregion Dealer Event
        #endregion Dealer Function

        #region Employee Button Event 
        private void btnAdm_Emp_Save_Click(object sender, RoutedEventArgs e)
        {
            if (Employee_Validation() == true)
                return;

            try
            {
                bempetr.Flag = 1;
                bempetr.EmployeeID = lblEmployeeID.Content.ToString();
                bempetr.EmployeeFirstName = txtAdm_EmpFirstName.Text;
                bempetr.EmployeeLastName = txtAdm_EmpLastName.Text;
                bempetr.DateOfBirth = dtpAdm_Emp_DOB.Text;
                bempetr.MobileNo = txtAdm_Emp_MobileNo.Text;
                bempetr.PhoneNo = txtAdm_Emp_PhoneNo.Text;
                bempetr.EmpAddress = txtAdm_Emp_Address.Text;
                bempetr.EmpCity = cmbEmp_City.Text;
                bempetr.EmpZipNo = txtAdm_Emp_Zip.Text;
                bempetr.EmpState = cmbEmp_State.Text;
                bempetr.EmpCountry = cmbEmp_Country.Text;
                bempetr.Designation = txtAdm_Emp_Designation.Text;
                bempetr.DateOfJoining = dtpAdm_Emp_DOJ.Text;
                bempetr.NoOfYears = cmbAdm_Emp_YearExp.SelectedItem.ToString();
                bempetr.Years = lblYears.Content.ToString();
                bempetr.NoOfMonths = cmbAdm_Emp_Months.SelectedItem.ToString();
                bempetr.Months = lblMonths.Content.ToString();
                bempetr.Salary = Convert.ToDouble(txtAdm_Emp_Salary.Text);
                bempetr.S_Status = "Active";
                bempetr.C_Date = System.DateTime.Now.ToShortDateString();
                dempetr.EmployeeEntry_Insert_Update_Delete(bempetr);

                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Data Save Successfully";
                obj.ShowDialog();
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            if(txtEmp_PhotoPath.Text.Trim() != string.Empty)
            {
                if(txtEmployeeID.Text.Trim() == string.Empty)
                {
                    GetMaxID();
                }
                try
                {
                    bemphpoto.Flag = 1;
                    bemphpoto.EmployeeID = Convert.ToInt32(txtEmployeeID.Text);
                    bemphpoto.PhotoPath = txtEmp_PhotoPath.Text;
                    bemphpoto.EmpPhoto = (byte[])(picture);
                    bemphpoto.S_Status = "Active";
                    bemphpoto.C_Date = System.DateTime.Now.ToShortDateString();
                    dempphoto.EmployeePhoto_Insert_Update_Delete(bemphpoto);

                    //frmValidationMessage obj = new frmValidationMessage();
                    //obj.lblMessage.Content = "Photo Save Successfully";
                    //obj.ShowDialog();
                }
                catch 
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }

            Employee_ResetText();
            EEMPLOYEEid();
            Load_Employee_City();
            Load_Employee_State();
            Load_Employee_Country();
        }

        private void btnAdm_Emp_Clear_Click(object sender, RoutedEventArgs e)
        {
            Employee_ResetText();
        }

        private void btnAdm_Emp_Exit_Click(object sender, RoutedEventArgs e)
        {
            grdAdm_EmployeeEntry.Visibility = System.Windows.Visibility.Hidden;
        }
        #endregion Employee Button Event

        #region EmployeeEntry Function
        public bool Employee_Validation()
        {
            bool result = false;
            if (txtAdm_EmpFirstName.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Employee First Name";
                obj.ShowDialog();
                txtAdm_EmpFirstName.BorderBrush = Brushes.Red;
                
            }
            else if (txtAdm_EmpLastName.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Employee Last Name";
                obj.ShowDialog();
                txtAdm_EmpLastName.BorderBrush = Brushes.Red;
                
            }
            else if (dtpAdm_Emp_DOB.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Employee Date Of Birth";
                obj.ShowDialog();
                dtpAdm_Emp_DOB.BorderBrush = Brushes.Red;
                
            }
            else if (txtAdm_Emp_MobileNo.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Employee Mobile No.";
                obj.ShowDialog();
                txtAdm_Emp_MobileNo.BorderBrush = Brushes.Red;
                
            }
            else if (txtAdm_Emp_Address.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Employee Address";
                obj.ShowDialog();
                txtAdm_Emp_Address.BorderBrush = Brushes.Red;
                
            }
            else if (cmbEmp_City.Text == "Select")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Employee City";
                obj.ShowDialog();
                cmbEmp_City.BorderBrush = Brushes.Red;
                
            }
            else if (cmbEmp_State.Text == "Select")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Employee State";
                obj.ShowDialog();
                cmbEmp_State.BorderBrush = Brushes.Red;
                cmbEmp_State.Focus();
            }
            else if (cmbEmp_Country.Text == "Select")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Employee Country";
                obj.ShowDialog();
                cmbEmp_Country.BorderBrush = Brushes.Red;
                
            }
            else if (txtAdm_Emp_Designation.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Employee Designation";
                obj.ShowDialog();
                txtAdm_Emp_Designation.BorderBrush = Brushes.Red;
                
            }
            else if (dtpAdm_Emp_DOJ.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Employee Joining Date";
                obj.ShowDialog();
                dtpAdm_Emp_DOJ.BorderBrush = Brushes.Red;
                
            }
            else if (cmbAdm_Emp_YearExp.Text == "Select Year")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Employee Experience Year";
                obj.ShowDialog();
                cmbAdm_Emp_YearExp.BorderBrush = Brushes.Red;
                
                //MessageBox.Show("Please Select Employee Experience Year", caption, MessageBoxButton.OK);
            }
            else if (cmbAdm_Emp_Months.Text == "Select Months")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Employee Experience Month";
                obj.ShowDialog();
                cmbAdm_Emp_Months.BorderBrush = Brushes.Red;
                
            }
            else if (txtAdm_Emp_Salary.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Employee Salary";
                obj.ShowDialog();
                txtAdm_Emp_Salary.BorderBrush = Brushes.Red;
                
            }
            return result;
        }

        public void Employee_ResetText()
        {
            //txtAdm_EmpID.Text = "";
            txtAdm_EmpFirstName.Text = "";
            txtAdm_EmpLastName.Text = "";
            dtpAdm_Emp_DOB.SelectedDate = null;
            txtAdm_Emp_MobileNo.Text = "";
            txtAdm_Emp_PhoneNo.Text = "";
            txtAdm_Emp_Designation.Text = "";
            //txtAdm_Emp_Experience.Text = "";
            txtAdm_Emp_Salary.Text = "";
            dtpAdm_Emp_DOJ.SelectedDate = null;
            cmbAdm_Emp_YearExp.Text = "Select Year";
            cmbAdm_Emp_Months.Text = "Select Months";
            cmbEmp_City.Text = "Select";
            cmbEmp_State.Text = "Select";
            cmbEmp_Country.Text = "Select";
            txtAdm_Emp_Address.Text = "";
            txtAdm_Emp_Zip.Text = "";
            img_EmployeePhoto.Source = null;
            cmbAdm_Emp_Months.Visibility = System.Windows.Visibility.Hidden;
            lblMonths.Visibility = System.Windows.Visibility.Hidden;
        }

        public void LoadNoOfYears()
        {
            cmbAdm_Emp_YearExp.Text = "Select Year";
            cmbAdm_Emp_YearExp.Items.Add("0");
            cmbAdm_Emp_YearExp.Items.Add("1");
            cmbAdm_Emp_YearExp.Items.Add("2");
            cmbAdm_Emp_YearExp.Items.Add("3");
            cmbAdm_Emp_YearExp.Items.Add("4");
            cmbAdm_Emp_YearExp.Items.Add("5");
            cmbAdm_Emp_YearExp.Items.Add("6");
            cmbAdm_Emp_YearExp.Items.Add("7");
            cmbAdm_Emp_YearExp.Items.Add("8");
            cmbAdm_Emp_YearExp.Items.Add("9");
            cmbAdm_Emp_YearExp.Items.Add("10");
            cmbAdm_Emp_YearExp.Items.Add("11");
            cmbAdm_Emp_YearExp.Items.Add("12");
            cmbAdm_Emp_YearExp.Items.Add("13");
            cmbAdm_Emp_YearExp.Items.Add("14");
            cmbAdm_Emp_YearExp.Items.Add("15");
        }

        public void LoadNoOfMonths()
        {
            cmbAdm_Emp_Months.Text = "Select Months";
            cmbAdm_Emp_Months.Items.Add("0");
            cmbAdm_Emp_Months.Items.Add("1");
            cmbAdm_Emp_Months.Items.Add("2");
            cmbAdm_Emp_Months.Items.Add("3");
            cmbAdm_Emp_Months.Items.Add("4");
            cmbAdm_Emp_Months.Items.Add("5");
            cmbAdm_Emp_Months.Items.Add("6");
            cmbAdm_Emp_Months.Items.Add("7");
            cmbAdm_Emp_Months.Items.Add("8");
            cmbAdm_Emp_Months.Items.Add("9");
            cmbAdm_Emp_Months.Items.Add("10");
            cmbAdm_Emp_Months.Items.Add("11");
        }

        public void EEMPLOYEEid()
        {

            int id1 = 0;
            // SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("select (COUNT(ID)) from tbl_Employee", con);
            id1 = Convert.ToInt32(cmd.ExecuteScalar());
            id1 = id1 + 1;
            lblEmployeeID.Content = "# Emp /" + id1.ToString();
            con.Close();


        }

        public void Load_Employee_City()
        {
            cmbEmp_City.Text = "Select";
            string q = "SELECT distinct(EmpCity) As EmpCity FROM tbl_Employee ";
            cmd = new SqlCommand(q, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //cmbInsurance_CustName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                cmbEmp_City.ItemsSource = ds.Tables[0].DefaultView;
                cmbEmp_City.DisplayMemberPath = ds.Tables[0].Columns["EmpCity"].ToString();
            }
        }

        public void Load_Employee_State()
        {
            cmbEmp_State.Text = "Select";
            string q = "SELECT distinct(EmpState) As EmpState FROM tbl_Employee ";
            cmd = new SqlCommand(q, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //cmbInsurance_CustName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                cmbEmp_State.ItemsSource = ds.Tables[0].DefaultView;
                cmbEmp_State.DisplayMemberPath = ds.Tables[0].Columns["EmpState"].ToString();
            }
        }

        public void Load_Employee_Country()
        {
            cmbEmp_Country.Text = "Select";
            string q = "SELECT distinct(EmpCountry) As EmpCountry FROM tbl_Employee ";
            cmd = new SqlCommand(q, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //cmbInsurance_CustName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                cmbEmp_Country.ItemsSource = ds.Tables[0].DefaultView;
                cmbEmp_Country.DisplayMemberPath = ds.Tables[0].Columns["EmpCountry"].ToString();
            }
        }

        private void cmbAdm_Emp_YearExp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbAdm_Emp_Months.Visibility = System.Windows.Visibility.Visible;
            lblMonths.Visibility = System.Windows.Visibility.Visible;
        }

        public void GetData_EmployeeDetails()
        {
            try
            {
                String str;
                //con.Open();
                DataSet ds = new DataSet();
                str = "SELECT [ID],[EmployeeID],[EmployeeFirstName] + ' ' + [EmployeeLastName] AS [EmployeeName],[DateOfBirth],[EmpAddress],[MobileNo],[Designation],[DateOfJoining],[NoOfYears] + ' ' + [Years] + ' , ' + [NoOfMonths] + ' ' + [Months] AS [Experience],[Salary] " +
                      "FROM [tbl_Employee] " +
                      "WHERE ";
                if (txtAdm_EmployeeName_Search.Text.Trim() != "")
                {
                    str = str + "[EmployeeFirstName] LIKE ISNULL('" + txtAdm_EmployeeName_Search.Text.Trim() + "',[EmployeeFirstName]) + '%' AND ";
                }
                if (txtAdm_EmployeeMN_Search.Text.Trim() != "")
                {
                    str = str + "[MobileNo] LIKE ISNULL('" + txtAdm_EmployeeMN_Search.Text.Trim() + "',[MobileNo]) + '%' AND ";
                }
                str = str + " [S_Status] = 'Active' ORDER BY [EmployeeName] ASC ";
                //str = str + " S_Status = 'Active' ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                dgvAdm_EmployeeDetails.ItemsSource = ds.Tables[0].DefaultView;
                //}
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void GetMaxID()
        {
            string sqlquery = "SELECT max(ID) as ID FROM tbl_Employee";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtMaxID.Text = dt.Rows[0]["ID"].ToString();
                txtEmployeeID.Text = txtMaxID.Text.Trim();
            }
        }
        #endregion EmployeeEntry Function

        #region Employee Event
        private void grdAdm_EmployeeEntry_Loaded(object sender, RoutedEventArgs e)
        {
            EEMPLOYEEid();
            LoadNoOfYears();
            LoadNoOfMonths();
            Load_Employee_City();
            Load_Employee_State();
            Load_Employee_Country();
            cmbAdm_Emp_Months.Visibility = System.Windows.Visibility.Hidden;
            lblMonths.Visibility = System.Windows.Visibility.Hidden;
        }

        private void grdAdm_EmployeeDetails_Loaded(object sender, RoutedEventArgs e)
        {
            GetData_EmployeeDetails();
        }

        private void txtAdm_EmployeeName_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetData_EmployeeDetails();
        }

        private void txtAdm_EmployeeMN_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetData_EmployeeDetails();
        }

        private void menu_AdmEmployeeEntry_Click(object sender, RoutedEventArgs e)
        {
            grdAdm_EmployeeEntry.Visibility = System.Windows.Visibility.Visible;
        }
        #endregion Employee Event

     

        private void btnAdm_EmployeeExit_Click(object sender, RoutedEventArgs e)
        {
            grdAdm_EmployeeDetails.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btndgv_EmployeeEditUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id1 = (DataRowView)dgvAdm_EmployeeDetails.SelectedItem; //get specific ID from          DataGrid after click on Edit button in DataGrid   
                PK_ID = Convert.ToInt32(id1.Row["ID"].ToString());
                con.Open();
                string sqlquery = "SELECT * FROM tbl_Employee where ID='" + PK_ID + "' ";
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtAdm_EmployeeID.Text = dt.Rows[0]["ID"].ToString();
                }

                frmViewEmployeeDetails obj = new frmViewEmployeeDetails();
                obj.EmployeeID(txtAdm_EmployeeID.Text.Trim());
                obj.FillData();
                obj.LoadNoOfYears1();
                obj.LoadNoOfMonths1();
                obj.ShowDialog();

                // con.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            GetData_EmployeeDetails();
        }

        private void btnEmpPhotoBrowse_Click(object sender, RoutedEventArgs e)
        {
            var fd = new Microsoft.Win32.OpenFileDialog();
            //   fd.Filter = "*.jpeg";

            fd.Filter = "All image formats (*.jpg; *.jpeg; *.bmp; *.png; *.gif)|*.jpg;*.jpeg;*.bmp;*.png;*.gif";
            var ret = fd.ShowDialog();

            if (ret.GetValueOrDefault())
            {

                txtEmp_PhotoPath.Text = fd.FileName;
                filepath = fd.FileName;
                picture = System.IO.File.ReadAllBytes(fd.FileName);
                try
                {
                    bmp = new BitmapImage(new Uri(fd.FileName, UriKind.Absolute));
                    img_EmployeePhoto.Source = bmp;
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid image file.", "Browse", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void btnSavePhoto_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmp_PhotoPath.Text.Trim() != string.Empty)
            {
                if (txtEmployeeID.Text.Trim() == string.Empty)
                {
                    GetMaxID();
                }
                try
                {
                    bemphpoto.Flag = 1;
                    bemphpoto.EmployeeID = Convert.ToInt32(txtEmployeeID.Text);
                    bemphpoto.PhotoPath = txtEmp_PhotoPath.Text;
                    bemphpoto.EmpPhoto = (byte[])(picture);
                    bemphpoto.S_Status = "Active";
                    bemphpoto.C_Date = System.DateTime.Now.ToShortDateString();
                    dempphoto.EmployeePhoto_Insert_Update_Delete(bemphpoto);

                    frmValidationMessage obj = new frmValidationMessage();
                    obj.lblMessage.Content = "Photo Save Successfully";
                    obj.ShowDialog();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
            else
                MessageBox.Show("Browse Photo", "UniWeb Technocrats", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //////////////////

        #region AddProduct Function
        #region Domain Function Event
        private void btnAddDomain_Click(object sender, RoutedEventArgs e)
        {
            if (Domain_Validation() == true)
                return;

            try
            {
                string strpan, stradhar, strpass, straddress, strseventw, strfrm16, strdelerlic, strnoidpf, strnodoc, strcmpid;
                baddprd.Flag = 1;
                baddprd.Domain_Name = txtdomain.Text;
                if (chkpancard.IsChecked == true)
                {
                    strpan = "Yes";
                }
                else
                {
                    strpan = "No";
                }
                if (chkadharcard.IsChecked == true)
                {
                    stradhar = "Yes";
                }
                else
                {
                    stradhar = "No";
                }
                if (chkPassport.IsChecked == true)
                {
                    strpass = "Yes";
                }
                else
                {
                    strpass = "No";
                }
                if (chkaddress.IsChecked == true)
                {
                    straddress = "Yes";
                }
                else
                {
                    straddress = "No";
                }
                if (chkseventwelve.IsChecked == true)
                {
                    strseventw = "Yes";
                }
                else
                {
                    strseventw = "No";
                }
                if (chkform16.IsChecked == true)
                {
                    strfrm16 = "Yes";
                }
                else
                {
                    strfrm16 = "No";
                }
                if (chkdealerlisence.IsChecked == true)
                {
                    strdelerlic = "Yes";
                }
                else
                {
                    strdelerlic = "No";
                }
                if (chkotherid.IsChecked == true)
                {
                    strnoidpf = "Yes";
                }
                else
                {
                    strnoidpf = "No";
                }
                if (chknodocument.IsChecked == true)
                {
                    strnodoc = "Yes";
                }
                else { strnodoc = "No"; }
                if (chkcidproof.IsChecked == true)
                {
                    strcmpid = "Yes";
                }
                else
                {
                    strcmpid = "No";
                }
                baddprd.PAN_Card = strpan;
                baddprd.Adhar_Card = stradhar;
                baddprd.Passport = strpass;
                baddprd.Address_Proof = straddress;
                baddprd.Seven_Twevel = strseventw;
                baddprd.Form_16 = strfrm16;
                baddprd.Dealer_Lisence = strdelerlic;
                baddprd.Other_ID_Proof = strnoidpf;
                baddprd.No_Documents = strnodoc;
                baddprd.Cmp_ID_Proof = strcmpid;
                baddprd.S_Status = "Active";

                baddprd.C_Date = System.DateTime.Now.ToShortDateString();
                daddprd.AddDomain_Insert_Update_Delete(baddprd);
                //MessageBox.Show("Data Save Successfully");
                //frmValidationMessage obj = new frmValidationMessage();
                lblDomainErrorMsg.Foreground = Brushes.Green;
                lblDomainErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblDomainErrorMsg.Content = "Data Save Successfully";
                
                txtdomain.Text = "";
                chkaddress.IsChecked = false;
                chkadharcard.IsChecked = false;
                chkcidproof.IsChecked = false;
                chkdealerlisence.IsChecked = false;
                chkform16.IsChecked = false;
                chknodocument.IsChecked = false;
                chkotherid.IsChecked = false;
                chkpancard.IsChecked = false;
                chkPassport.IsChecked = false;
                chkseventwelve.IsChecked = false;
                //lblDomainSaveMsg.Visibility = System.Windows.Visibility.Hidden;
                Load_Domain();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }

        private void btndomainexit_Click(object sender, RoutedEventArgs e)
        {
            grd_Domain.Visibility = System.Windows.Visibility.Hidden;
            lblDomainErrorMsg.Visibility = System.Windows.Visibility.Hidden;
        }

        public bool Domain_Validation()
        {
            bool result = false;
            if (txtdomain.Text == "")
            {
                result = true;
                lblDomainErrorMsg.Foreground = Brushes.Red;
                lblDomainErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblDomainErrorMsg.Content = "Please Enter Domain Name";
                txtdomain.BorderBrush = Brushes.Red;

            }
            return result;
        }

        private void txtdomain_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblDomainErrorMsg.Visibility = System.Windows.Visibility.Hidden;
        }

        #endregion Domain Function Event

        #region Products Function Event
        public void Load_DomainP()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID,Domain_Name from tb_Domain ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmb_DomainProduct.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmb_DomainProduct.ItemsSource = ds.Tables[0].DefaultView;
                    cmb_DomainProduct.DisplayMemberPath = ds.Tables[0].Columns["Domain_Name"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }

        }

        private void btnProductSave_Click(object sender, RoutedEventArgs e)
        {
            if (Products_Validation() == true)
                return;

            try
            {
                baddprd.Flag = 1;
                baddprd.Domain_ID = Convert.ToInt32(cmb_DomainProduct.SelectedValue.GetHashCode());
                baddprd.Product_Name = txtProductName.Text;
                baddprd.S_Status = "Active";
                baddprd.C_Date = System.DateTime.Now.ToShortDateString();
                daddprd.AddProducts_Insert_Update_Delete(baddprd);
                lblProductErrorMsg.Foreground = Brushes.Green;
                lblProductErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblProductErrorMsg.Content = "Data Save Successfully";
                txtProductName.Text = "";
                //lblProductSaveMsg.Visibility = System.Windows.Visibility.Hidden;
                Load_DomainP();
                //Fetch_Product();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnProduct_Exit_Click(object sender, RoutedEventArgs e)
        {
            grd_Product.Visibility = System.Windows.Visibility.Hidden;
            lblProductSaveMsg.Visibility = System.Windows.Visibility.Hidden;
            lblProductErrorMsg.Visibility = System.Windows.Visibility.Hidden;
        }

        public bool Products_Validation()
        {
            bool result = false;
            if (cmb_DomainProduct.SelectedItem == null)
            {
                result = true;
                lblProductErrorMsg.Foreground = Brushes.Red;
                lblProductErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblProductErrorMsg.Content = "Please Select Dmain Name";
                cmb_DomainProduct.BorderBrush = Brushes.Red;
            }
            else if (txtProductName.Text == "")
            {
                result = true;
                lblProductErrorMsg.Foreground = Brushes.Red;
                lblProductErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblProductErrorMsg.Content = "Please Enter Product Name";
                txtProductName.BorderBrush = Brushes.Red;
            }
            return result;
        }

        private void cmb_DomainProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //lblProductErrorMsg.Visibility = System.Windows.Visibility.Hidden;
        }
        #endregion Products Function Event

        #region Brand Function Event
        private void btnBrandSave_Click(object sender, RoutedEventArgs e)
        {
            if (Brand_Validation() == true)
                return;

            try
            {

                baddprd.Flag = 1;
                baddprd.Product_ID = Convert.ToInt32(cmbProductBrand.SelectedValue.GetHashCode());
                baddprd.Brand_Name = txtBrand.Text;
                baddprd.S_Status = "Active";
                baddprd.C_Date = System.DateTime.Now.ToShortDateString();
                daddprd.AddBrand_Insert_Update_Delete(baddprd);
                lblbrandErrorMsg.Foreground = Brushes.Green;
                lblbrandErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblbrandErrorMsg.Content = "Data Save Successfully";
                txtBrand.Text = "";
                cmbProductBrand.SelectedValue = null;
                //lblbrandSaveData.Visibility = System.Windows.Visibility.Hidden;
                Load_Domain();
                // fetch_Brand();
                // Load_DomainB();
                // Load_BrandProduct();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnBrandExit_Click(object sender, RoutedEventArgs e)
        {
            grd_Brand.Visibility = System.Windows.Visibility.Hidden;
            lblbrandSaveData.Visibility = System.Windows.Visibility.Hidden;
            lblbrandErrorMsg.Visibility = System.Windows.Visibility.Hidden;
        }

        public void Load_Domain()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID, Domain_Name from tb_Domain ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbP_domain.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbP_domain.ItemsSource = ds.Tables[0].DefaultView;
                    cmbP_domain.DisplayMemberPath = ds.Tables[0].Columns["Domain_Name"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }

        }

        public bool Brand_Validation()
        {
            bool result = false;
            if (cmbDomainBrand.SelectedItem == null)
            {
                result = true;
                lblbrandErrorMsg.Foreground = Brushes.Red;
                lblbrandErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblbrandErrorMsg.Content = "Please Select Dmain Name";
                cmbDomainBrand.BorderBrush = Brushes.Red;
            }
            else if (cmbProductBrand.SelectedItem == null)
            {
                result = true;
                lblbrandErrorMsg.Foreground = Brushes.Red;
                lblbrandErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblbrandErrorMsg.Content = "Please Select Products";
                cmbProductBrand.BorderBrush = Brushes.Red;
            }
            else if (txtBrand.Text == "")
            {
                result = true;
                lblbrandErrorMsg.Foreground = Brushes.Red;
                lblbrandErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblbrandErrorMsg.Content = "Please Enter Brand Name";
                txtBrand.BorderBrush = Brushes.Red;
            }
            return result;
        }

        public void Load_BrandProduct()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID, Domain_ID, Product_Name from tlb_Products where Domain_ID ='" + cmbDomainBrand.SelectedValue.GetHashCode() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbProductBrand.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbProductBrand.ItemsSource = ds.Tables[0].DefaultView;
                    cmbProductBrand.DisplayMemberPath = ds.Tables[0].Columns["Product_Name"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }

        }

        private void cmbDomainBrand_DropDownClosed(object sender, EventArgs e)
        {
            //lblbrandErrorMsg.Visibility = System.Windows.Visibility.Hidden;
        }

        private void cmbDomainBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbProductBrand.SelectedValue = null;
            //lblbrandErrorMsg.Visibility = System.Windows.Visibility.Hidden;
            Load_BrandProduct();
        }

        private void txtBrand_TextChanged(object sender, TextChangedEventArgs e)
        {
            //lblbrandErrorMsg.Visibility = System.Windows.Visibility.Hidden;
        }
        #endregion Brand Function Event

        #region PRoductCategory Function Event
        public bool ProductCategory_Validation()
        {
            bool result = false;
            if (cmbDomainPCategory.SelectedItem == null)
            {
                result = true;
                lblProductCatrgoryError.Foreground = Brushes.Red;
                lblProductCatrgoryError.Visibility = System.Windows.Visibility.Visible;
                lblProductCatrgoryError.Content = "Please Select Dmain Name";
                cmbDomainPCategory.BorderBrush = Brushes.Red;
            }
            else if (cmbProductPCategoryy.SelectedItem == null)
            {
                result = true;
                lblProductCatrgoryError.Foreground = Brushes.Red;
                lblProductCatrgoryError.Visibility = System.Windows.Visibility.Visible;
                lblProductCatrgoryError.Content = "Please Select Products";
                cmbProductPCategoryy.BorderBrush = Brushes.Red;
            }
            else if(cmbBrandPCategory.SelectedItem == null)
            {
                result = true;
                lblProductCatrgoryError.Foreground = Brushes.Red;
                lblProductCatrgoryError.Visibility = System.Windows.Visibility.Visible;
                lblProductCatrgoryError.Content = "Please Select Product Brand";
                cmbBrandPCategory.BorderBrush = Brushes.Red;
            }
            else if (txtPCategoy.Text == "")
            {
                result = true;
                lblProductCatrgoryError.Foreground = Brushes.Red;
                lblProductCatrgoryError.Visibility = System.Windows.Visibility.Visible;
                lblProductCatrgoryError.Content = "Please Enter Product Category";
                txtBrand.BorderBrush = Brushes.Red;
            }
            return result;
        }
        
        public void Load_PCProduct()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID,Domain_ID, Product_Name from tlb_Products where Domain_ID='" + cmbDomainPCategory.SelectedValue.GetHashCode() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbProductPCategoryy.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbProductPCategoryy.ItemsSource = ds.Tables[0].DefaultView;
                    cmbProductPCategoryy.DisplayMemberPath = ds.Tables[0].Columns["Product_Name"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }
        }

        public void Load_PCBrand()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID,Product_ID, Brand_Name from tlb_Brand where Product_ID='" + cmbProductPCategoryy.SelectedValue.GetHashCode() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbBrandPCategory.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbBrandPCategory.ItemsSource = ds.Tables[0].DefaultView;
                    cmbBrandPCategory.DisplayMemberPath = ds.Tables[0].Columns["Brand_Name"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }
        }

        private void cmbDomainPCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbBrandPCategory.SelectedValue = null;
            cmbProductPCategoryy.SelectedValue = null;
            lblProductCatrgoryError.Visibility = System.Windows.Visibility.Hidden;
            Load_PCProduct();
        }

        private void cmbProductPCategoryy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblProductCatrgoryError.Visibility = System.Windows.Visibility.Hidden;
            Load_PCBrand();
        }

        private void btnPCategorySave_Click(object sender, RoutedEventArgs e)
        {
            if (ProductCategory_Validation() == true)
                return;
            try
            {

                baddprd.Flag = 1;
                baddprd.Brand_ID = Convert.ToInt32(cmbBrandPCategory.SelectedValue.GetHashCode());
                baddprd.Product_Category = txtPCategoy.Text;
                baddprd.S_Status = "Active";
                baddprd.C_Date = System.DateTime.Now.ToShortDateString();
                daddprd.AddP_Category_Insert_Update_Delete(baddprd);
                //MessageBox.Show("Data Save Successfully");
                lblProductCatrgoryError.Foreground = Brushes.Green;
                lblProductCatrgoryError.Visibility = System.Windows.Visibility.Visible;
                lblProductCatrgoryError.Content = "Data Save Successfully";
                txtPCategoy.Text = "";
                cmbBrandPCategory.SelectedValue = null;
                cmbProductPCategoryy.SelectedValue = null;
                cmbDomainPCategory.SelectedValue = null;
                //lblProductCatrgorySaveData.Visibility = System.Windows.Visibility.Hidden;
                Load_Domain();
                //  Load_PCDomain();
                // Fetch_PC();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnPCategoryExit_Click(object sender, RoutedEventArgs e)
        {
            grd_ProductCategory.Visibility = System.Windows.Visibility.Hidden;
            lblProductCatrgoryError.Visibility = System.Windows.Visibility.Hidden;
            lblProductCatrgorySaveData.Visibility = System.Windows.Visibility.Hidden;
        }

        private void cmbBrandPCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //lblProductCatrgoryError.Visibility = System.Windows.Visibility.Hidden;
        }

        private void txtPCategoy_TextChanged(object sender, TextChangedEventArgs e)
        {
            //lblProductCatrgoryError.Visibility = System.Windows.Visibility.Hidden;
        }
        #endregion PRoductCategory Function Event

        #region ModelNo Function Event
        public bool ModelNo_Validation()
        {
            bool result = false;
            if (cmbDomainModelno.SelectedItem == null)
            {
                result = true;
                lblModelNoErrorMsg.Foreground = Brushes.Red;
                lblModelNoErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblModelNoErrorMsg.Content = "Please Select Dmain Name";
                cmbDomainPCategory.BorderBrush = Brushes.Red;
            }
            else if (cmbProductModelno.SelectedItem == null)
            {
                result = true;
                lblModelNoErrorMsg.Foreground = Brushes.Red;
                lblModelNoErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblModelNoErrorMsg.Content = "Please Select Products";
                cmbProductModelno.BorderBrush = Brushes.Red;
            }
            else if (cmbBrandModelno.SelectedItem == null)
            {
                result = true;
                lblModelNoErrorMsg.Foreground = Brushes.Red;
                lblModelNoErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblModelNoErrorMsg.Content = "Please Select Product Brand";
                cmbBrandModelno.BorderBrush = Brushes.Red;
            }
            else if (cmbPCategoryModelno.SelectedItem == null)
            {
                result = true;
                lblModelNoErrorMsg.Foreground = Brushes.Red;
                lblModelNoErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblModelNoErrorMsg.Content = "Please Select Product Model No";
                cmbPCategoryModelno.BorderBrush = Brushes.Red;
            }
            else if (txtmodelno.Text == "")
            {
                result = true;
                lblModelNoErrorMsg.Foreground = Brushes.Red;
                lblModelNoErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblModelNoErrorMsg.Content = "Please Enter Product Model No";
                txtmodelno.BorderBrush = Brushes.Red;
            }
            return result;
        }

        public void Load_MProduct()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID,Domain_ID, Product_Name from tlb_Products where Domain_ID='" + cmbDomainModelno.SelectedValue.GetHashCode() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbProductModelno.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbProductModelno.ItemsSource = ds.Tables[0].DefaultView;
                    cmbProductModelno.DisplayMemberPath = ds.Tables[0].Columns["Product_Name"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }
        }

        public void Load_MBrand()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID,Product_ID,Brand_Name from tlb_Brand where Product_ID='" + cmbProductModelno.SelectedValue.GetHashCode() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbBrandModelno.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbBrandModelno.ItemsSource = ds.Tables[0].DefaultView;
                    cmbBrandModelno.DisplayMemberPath = ds.Tables[0].Columns["Brand_Name"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }
        }

        public void Load_MPC()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID,Brand_ID, Product_Category from tlb_P_Category where Brand_ID='" + cmbBrandModelno.SelectedValue.GetHashCode() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbPCategoryModelno.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbPCategoryModelno.ItemsSource = ds.Tables[0].DefaultView;
                    cmbPCategoryModelno.DisplayMemberPath = ds.Tables[0].Columns["Product_Category"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }
        }

        private void btnModelNoSave_Click(object sender, RoutedEventArgs e)
        {
            if (ModelNo_Validation() == true)
                return;

            try
            {

                baddprd.Flag = 1;
                baddprd.P_Category = Convert.ToInt32(cmbPCategoryModelno.SelectedValue.GetHashCode());
                baddprd.Model_No = txtmodelno.Text;
                baddprd.S_Status = "Active";
                baddprd.C_Date = System.DateTime.Now.ToShortDateString();
                daddprd.AddModel_Insert_Update_Delete(baddprd);
                //MessageBox.Show("Data Save Successfully");
                lblModelNoErrorMsg.Foreground = Brushes.Green;
                lblModelNoErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblModelNoErrorMsg.Content = "Data Save Successfully";
                txtmodelno.Text = "";
                cmbDomainModelno.SelectedValue = null;
                cmbProductModelno.SelectedValue = null;
                cmbBrandModelno.SelectedValue = null;
                cmbPCategoryModelno.SelectedValue = null;
                //lblModelNoSaveMsg.Visibility = System.Windows.Visibility.Hidden;
                Load_Domain();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnmodelnoexie_Click(object sender, RoutedEventArgs e)
        {
            grd_ModelNo.Visibility = System.Windows.Visibility.Hidden;
            lblModelNoErrorMsg.Visibility = System.Windows.Visibility.Hidden;
            lblModelNoSaveMsg.Visibility = System.Windows.Visibility.Hidden;
        }

        private void cmbDomainModelno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbProductModelno.SelectedValue = null;
            cmbBrandModelno.SelectedValue = null;
            cmbPCategoryModelno.SelectedValue = null;
            //lblModelNoErrorMsg.Visibility = System.Windows.Visibility.Hidden;
            Load_MProduct();
        }

        private void cmbProductModelno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbBrandModelno.SelectedValue = null;
            cmbPCategoryModelno.SelectedValue = null;
            //lblModelNoErrorMsg.Visibility = System.Windows.Visibility.Hidden;
            Load_MBrand();
        }

        private void cmbBrandModelno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbPCategoryModelno.SelectedValue = null;
            //lblModelNoErrorMsg.Visibility = System.Windows.Visibility.Hidden;
            Load_MPC();
        }

        private void cmbPCategoryModelno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //lblModelNoErrorMsg.Visibility = System.Windows.Visibility.Hidden;
        }

        private void txtmodelno_TextChanged(object sender, TextChangedEventArgs e)
        {
            //lblModelNoErrorMsg.Visibility = System.Windows.Visibility.Hidden;
        }
        #endregion ModelNo Function Event

        #region Color Function Event
        public bool Color_Validation()
        {
            bool result = false;
            if (cmbDomainColor.SelectedItem == null)
            {
                result = true;
                lblColorErrorMsg.Foreground = Brushes.Red;
                lblColorErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblColorErrorMsg.Content = "Please Select Dmain Name";
                cmbDomainColor.BorderBrush = Brushes.Red;
            }
            else if (cmbProductColor.SelectedItem == null)
            {
                result = true;
                lblColorErrorMsg.Foreground = Brushes.Red;
                lblColorErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblColorErrorMsg.Content = "Please Select Products";
                cmbProductColor.BorderBrush = Brushes.Red;
            }
            else if (cmbBrandColor.SelectedItem == null)
            {
                result = true;
                lblColorErrorMsg.Foreground = Brushes.Red;
                lblColorErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblColorErrorMsg.Content = "Please Select Product Brand";
                cmbBrandColor.BorderBrush = Brushes.Red;
            }
            else if (cmbPCategoryColor.SelectedItem == null)
            {
                result = true;
                lblColorErrorMsg.Foreground = Brushes.Red;
                lblColorErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblColorErrorMsg.Content = "Please Select Product Model No";
                cmbPCategoryColor.BorderBrush = Brushes.Red;
            }
            else if (cmbModelColor.SelectedItem == null)
            {
                result = true;
                lblColorErrorMsg.Foreground = Brushes.Red;
                lblColorErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblColorErrorMsg.Content = "Please Select Product Model Color";
                cmbModelColor.BorderBrush = Brushes.Red;
            }
            else if (txtcolor.Text == "")
            {
                result = true;
                lblColorErrorMsg.Foreground = Brushes.Red;
                lblColorErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblColorErrorMsg.Content = "Please Enter Product Model No";
                txtcolor.BorderBrush = Brushes.Red;
            }
            return result;
        }

        public void Load_CProduct()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID,Domain_ID, Product_Name from tlb_Products where Domain_ID='" + cmbDomainColor.SelectedValue.GetHashCode() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbProductColor.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbProductColor.ItemsSource = ds.Tables[0].DefaultView;
                    cmbProductColor.DisplayMemberPath = ds.Tables[0].Columns["Product_Name"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }
        }

        public void Load_CBrand()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID,Product_ID, Brand_Name from tlb_Brand where Product_ID='" + cmbProductColor.SelectedValue.GetHashCode() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbBrandColor.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbBrandColor.ItemsSource = ds.Tables[0].DefaultView;
                    cmbBrandColor.DisplayMemberPath = ds.Tables[0].Columns["Brand_Name"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }
        }
        
        public void Load_CPC()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID,Brand_ID, Product_Category from tlb_P_Category where Brand_ID='" + cmbBrandColor.SelectedValue.GetHashCode() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbPCategoryColor.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbPCategoryColor.ItemsSource = ds.Tables[0].DefaultView;
                    cmbPCategoryColor.DisplayMemberPath = ds.Tables[0].Columns["Product_Category"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }
        }
        
        public void Load_CModel()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID,P_Category, Model_No from tlb_Model where P_Category='" + cmbPCategoryColor.SelectedValue.GetHashCode() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbModelColor.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbModelColor.ItemsSource = ds.Tables[0].DefaultView;
                    cmbModelColor.DisplayMemberPath = ds.Tables[0].Columns["Model_No"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }
        }
        
        public void fetch_Color()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID, Color from tlb_Color where Model_No_ID='" + cmbP_ModelNo.SelectedValue.GetHashCode() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbP_Color.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbP_Color.ItemsSource = ds.Tables[0].DefaultView;
                    cmbP_Color.DisplayMemberPath = ds.Tables[0].Columns["Color"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }
        }

        private void btnColorSave_Click(object sender, RoutedEventArgs e)
        {
            if (Color_Validation() == true)
                return;

            try
            {
                baddprd.Flag = 1;
                baddprd.Model_No_ID = Convert.ToInt32(cmbModelColor.SelectedValue.GetHashCode());
                baddprd.Color = txtcolor.Text;
                baddprd.S_Status = "Active";
                baddprd.C_Date = System.DateTime.Now.ToShortDateString();
                daddprd.AddColor_Insert_Update_Delete(baddprd);
                //MessageBox.Show("Data Save Successfully");
                lblColorErrorMsg.Foreground = Brushes.Green;
                lblColorErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblColorErrorMsg.Content = "Data Save Successfully";
                txtcolor.Text = "";
                cmbDomainColor.SelectedValue = null;
                cmbProductColor.SelectedValue = null;
                cmbBrandColor.SelectedValue = null;
                cmbPCategoryColor.SelectedValue = null;
                cmbModelColor.SelectedValue = null;
                //lblColorSaveMsg.Visibility = System.Windows.Visibility.Hidden;

                Load_Domain();
                // fetch_Color();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnColorExit_Click(object sender, RoutedEventArgs e)
        {
            grd_Color.Visibility = System.Windows.Visibility.Visible;
            lblColorSaveMsg.Visibility = System.Windows.Visibility.Hidden;
            lblColorErrorMsg.Visibility = System.Windows.Visibility.Hidden;
        }

        private void cmbDomainColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbProductColor.SelectedValue = null;
            cmbBrandColor.SelectedValue = null;
            cmbPCategoryColor.SelectedValue = null;
            cmbModelColor.SelectedValue = null;
            //lblColorErrorMsg.Visibility = System.Windows.Visibility.Hidden;
            Load_CProduct();
        }

        private void cmbProductColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //cmbProductColor.SelectedValue = null;
            cmbBrandColor.SelectedValue = null;
            cmbPCategoryColor.SelectedValue = null;
            cmbModelColor.SelectedValue = null;
            //lblColorErrorMsg.Visibility = System.Windows.Visibility.Hidden;
            Load_CBrand();
        }

        private void cmbBrandColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbPCategoryColor.SelectedValue = null;
            cmbModelColor.SelectedValue = null;
            //lblColorErrorMsg.Visibility = System.Windows.Visibility.Hidden;
            Load_CPC();
        }

        private void cmbPCategoryColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbModelColor.SelectedValue = null;
            //lblColorErrorMsg.Visibility = System.Windows.Visibility.Hidden;
            Load_CModel();
        }

        private void cmbModelColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //lblColorErrorMsg.Visibility = System.Windows.Visibility.Hidden;
        }

        private void txtcolor_TextChanged(object sender, TextChangedEventArgs e)
        {
            //lblColorErrorMsg.Visibility = System.Windows.Visibility.Hidden;
        }
        #endregion Color Function Event

        #region Master Button Event
        public void Load_PCDomain()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID, Domain_Name from tb_Domain ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbDomainPCategory.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbDomainPCategory.ItemsSource = ds.Tables[0].DefaultView;
                    cmbDomainPCategory.DisplayMemberPath = ds.Tables[0].Columns["Domain_Name"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }

        }

        public void Load_MDomain()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID,Domain_Name from tb_Domain ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbDomainModelno.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbDomainModelno.ItemsSource = ds.Tables[0].DefaultView;
                    cmbDomainModelno.DisplayMemberPath = ds.Tables[0].Columns["Domain_Name"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }
        }

        public void Load_CDomain()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID, Domain_Name from tb_Domain ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbDomainColor.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbDomainColor.ItemsSource = ds.Tables[0].DefaultView;
                    cmbDomainColor.DisplayMemberPath = ds.Tables[0].Columns["Domain_Name"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }
        }

        public void Load_DomainB()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID, Domain_Name from tb_Domain ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbDomainBrand.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbDomainBrand.ItemsSource = ds.Tables[0].DefaultView;
                    cmbDomainBrand.DisplayMemberPath = ds.Tables[0].Columns["Domain_Name"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }

        }


        private void btnP_AddDomain_Click(object sender, RoutedEventArgs e)
        {
            grd_Domain.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnP_AddProduct_Click_1(object sender, RoutedEventArgs e)
        {
            grd_Product.Visibility = System.Windows.Visibility.Visible;
            Load_DomainP();
        }

        private void btnP_AddBrand_Click(object sender, RoutedEventArgs e)
        {

            grd_Brand.Visibility = System.Windows.Visibility.Visible;
            Load_DomainB();
        }

        private void btnP_AddPCategory_Click(object sender, RoutedEventArgs e)
        {
            grd_ProductCategory.Visibility = System.Windows.Visibility.Visible;
            Load_PCDomain();
        }

        private void btnP_AddModelNo_Click(object sender, RoutedEventArgs e)
        {
            grd_ModelNo.Visibility = Visibility;
            Load_MDomain();
        }

        private void btnP_AddColor1_Click_1(object sender, RoutedEventArgs e)
        {
            grd_Color.Visibility = Visibility;
            Load_CDomain();
        }
        #endregion Master Button Event

        #region AddProduct Function Event
        public void Fetch_Product()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID, Domain_ID,Product_Name from tlb_Products where  Domain_ID='" + cmbP_domain.SelectedValue.GetHashCode() + "' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbP_Product.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbP_Product.ItemsSource = ds.Tables[0].DefaultView;
                    cmbP_Product.DisplayMemberPath = ds.Tables[0].Columns["Product_Name"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }

        }

        public void fetch_Brand()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID, Brand_Name from tlb_Brand where Product_ID='" + cmbP_Product.SelectedValue.GetHashCode() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbP_Brand.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbP_Brand.ItemsSource = ds.Tables[0].DefaultView;
                    cmbP_Brand.DisplayMemberPath = ds.Tables[0].Columns["Brand_Name"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }

        }

        public void Fetch_PC()
        {

            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT  ID,Product_Category from tlb_P_Category where Brand_ID='" + cmbP_Brand.SelectedValue.GetHashCode() + "' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbP_PCategory.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbP_PCategory.ItemsSource = ds.Tables[0].DefaultView;
                    cmbP_PCategory.DisplayMemberPath = ds.Tables[0].Columns["Product_Category"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }
        }

        public void fetch_Model()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID, Model_No from tlb_Model where P_Category='" + cmbP_PCategory.SelectedValue.GetHashCode() + "' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbP_ModelNo.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbP_ModelNo.ItemsSource = ds.Tables[0].DefaultView;
                    cmbP_ModelNo.DisplayMemberPath = ds.Tables[0].Columns["Model_No"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }
        }


        private void cmbP_domain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbP_Product.SelectedValue = null;
            cmbP_Brand.SelectedValue = null;
            cmbP_PCategory.SelectedValue = null;
            cmbP_ModelNo.SelectedValue = null;
            cmbP_Color.SelectedValue = null;
            Fetch_Product();
        }

        private void cmbP_Product_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbP_Brand.SelectedValue = null;
            cmbP_PCategory.SelectedValue = null;
            cmbP_ModelNo.SelectedValue = null;
            cmbP_Color.SelectedValue = null;
            fetch_Brand();
        }

        private void cmbP_Brand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbP_PCategory.SelectedValue = null;
            cmbP_ModelNo.SelectedValue = null;
            cmbP_Color.SelectedValue = null;
            Fetch_PC();
        }

        private void cmbP_PCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbP_ModelNo.SelectedValue = null;
            cmbP_Color.SelectedValue = null;
            fetch_Model();
        }

        private void cmbP_ModelNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbP_Color.SelectedValue = null;
            fetch_Color();
        }
        #endregion AddProduct Function Event

        #region AddFun Button Event
        public bool AddProducts_Validation()
        {
            bool result = false;
            if (cmbP_domain.SelectedItem == null)
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Domain Name";
                obj.ShowDialog();
                cmbP_domain.BorderBrush = Brushes.Red;
            }
            else if (cmbP_Product.SelectedItem == null)
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Product Name";
                obj.ShowDialog();
                cmbP_Product.BorderBrush = Brushes.Red;
            }
            else if (cmbP_Brand.SelectedItem == null)
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Brand Name";
                obj.ShowDialog();
                cmbP_Brand.BorderBrush = Brushes.Red;
            }
            else if (cmbP_PCategory.SelectedItem == null)
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Product Category";
                obj.ShowDialog();
                cmbP_PCategory.BorderBrush = Brushes.Red;
            }
            else if (cmbP_ModelNo.SelectedItem == null)
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Model No";
                obj.ShowDialog();
                cmbP_ModelNo.BorderBrush = Brushes.Red;
            }
            else if (cmbP_Color.SelectedItem == null)
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Color";
                obj.ShowDialog();
                cmbP_Color.BorderBrush = Brushes.Red;
            }
            else if (txtP_Price.Text == "")
            {
                result = true;
                lblColorErrorMsg.Foreground = Brushes.Red;
                lblColorErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblColorErrorMsg.Content = "Please Enter Product Price";
                txtP_Price.BorderBrush = Brushes.Red;
            }
            return result;
        }

        public void clearAllADDProducts()
        {
            cmbP_domain.SelectedValue = null;
            cmbP_Product.SelectedValue = null;
            cmbP_Brand.SelectedValue = null;
            cmbP_PCategory.SelectedValue = null;
            cmbP_ModelNo.SelectedValue = null;
            cmbP_Color.SelectedValue = null;
            Load_Domain();

        }
        
        private void btnSave_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (AddProducts_Validation() == true)
                return;

            try
            {

                baddprd.Flag = 1;
                baddprd.Domain_ID = Convert.ToInt32(cmbP_domain.SelectedValue.GetHashCode());
                baddprd.Product_ID = Convert.ToInt32(cmbP_Product.SelectedValue.GetHashCode());
                baddprd.Brand_ID = Convert.ToInt32(cmbP_Brand.SelectedValue.GetHashCode());
                baddprd.P_Category = Convert.ToInt32(cmbP_PCategory.SelectedValue.GetHashCode());
                baddprd.Model_No_ID = Convert.ToInt32(cmbP_ModelNo.SelectedValue.GetHashCode());
                baddprd.Color_ID = Convert.ToInt32(cmbP_Color.SelectedValue.GetHashCode());
                baddprd.Narration = txtP_Narration.Text;
                baddprd.Price = Convert.ToDouble(txtP_Price.Text);
                baddprd.S_Status = "Active";
                baddprd.C_Date = System.DateTime.Now.ToShortDateString();
                daddprd.Save_Insert_Update_Delete(baddprd);
                //MessageBox.Show("Data Save Successfully");
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Data Save Successfully";
                obj.ShowDialog();
                txtP_Narration.Text = "";
                txtP_Price.Text = "";
                clearAllADDProducts();
                // Load_Domain();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnClear_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            clearAllADDProducts();
        }

        private void btnExit_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            clearAllADDProducts();
            grd_AddProducts.Visibility = Visibility.Hidden;
        }
        #endregion AddFun Button Event

        private void menu_AddProducts_Click(object sender, RoutedEventArgs e)
        {
            grd_AddProducts.Visibility = System.Windows.Visibility.Visible;
            Load_Domain();
        }
        #endregion AddProduct Function

        #region Pre-Procurement Function
        #region Pre-Proc Function
        public void fetch_Documents()
        {

            try
            {
                con.Open();

                cmd = new SqlCommand("Select PAN_Card,Adhar_Card,Passport,Address_Proof,Seven_Twevel,Form_16,Dealer_Lisence,Other_ID_Proof,No_Documents,Cmp_ID_Proof  from tb_Domain where ID='" + cmbPreDomain.SelectedValue.GetHashCode() + "' ", con);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string p = dr["PAN_Card"].ToString();
                    string ad = dr["Adhar_Card"].ToString();
                    string pa = dr["Passport"].ToString();
                    string addr = dr["Address_Proof"].ToString();
                    string st = dr["Seven_Twevel"].ToString();
                    string frm = dr["Form_16"].ToString();
                    string dl = dr["Dealer_Lisence"].ToString();
                    string oidp = dr["Other_ID_Proof"].ToString();
                    string nod = dr["No_Documents"].ToString();
                    string cmpid = dr["Cmp_ID_Proof"].ToString();
                    if (p == "Yes")
                    {
                        chkPANCARD.IsEnabled = true;
                        //chkPANCARD.IsChecked = true;
                    }
                    if (pa == "Yes")
                    {
                        chkPASSPORT.IsEnabled = true;
                    }
                    if (ad == "Yes")
                    {
                        CHKADHARC.IsEnabled = true;
                        //chkPANCARD.IsChecked = true;
                    }
                    if (addr == "Yes")
                    {
                        chkaddressproof.IsEnabled = true;
                    }
                    if (st == "Yes")
                    {
                        chk7_12.IsEnabled = true;
                    }
                    if (frm == "Yes")
                    {
                        chkform_16.IsEnabled = true;
                    }
                    if (dl == "Yes")
                    {
                        chkDEALERL.IsEnabled = true;
                    }
                    if (oidp == "Yes")
                    {
                        chkOTHERID.IsEnabled = true;
                    }
                    if (nod == "Yes")
                    {
                        chkNODOCS.IsEnabled = true;
                    }
                    if (cmpid == "Yes")
                    {
                        chkcmpid.IsEnabled = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }


        }

        public void Fetch_Pre_Product()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID, Product_Name from tlb_Products where Domain_ID='" + cmbPreDomain.SelectedValue.GetHashCode() + "' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbPreProduct.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbPreProduct.ItemsSource = ds.Tables[0].DefaultView;
                    cmbPreProduct.DisplayMemberPath = ds.Tables[0].Columns["Product_Name"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }

        }

        public void fetch_Pre_Brand()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID, Brand_Name from tlb_Brand where Product_ID='" + cmbPreProduct.SelectedValue.GetHashCode() + "' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbPreBrand.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbPreBrand.ItemsSource = ds.Tables[0].DefaultView;
                    cmbPreBrand.DisplayMemberPath = ds.Tables[0].Columns["Brand_Name"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }

        }

        public void Fetch_Pre_PC()
        {

            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT  ID,Product_Category from tlb_P_Category where Brand_ID='" + cmbPreBrand.SelectedValue.GetHashCode() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbPrePCategory.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbPrePCategory.ItemsSource = ds.Tables[0].DefaultView;
                    cmbPrePCategory.DisplayMemberPath = ds.Tables[0].Columns["Product_Category"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }
        }

        public void fetch_Pre_Model()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID, Model_No from tlb_Model where P_Category='" + cmbPrePCategory.SelectedValue.GetHashCode() + "' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbPreModel.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbPreModel.ItemsSource = ds.Tables[0].DefaultView;
                    cmbPreModel.DisplayMemberPath = ds.Tables[0].Columns["Model_No"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }
        }

        public void fetch_Pre_Color()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID, Color from tlb_Color where Model_No_ID='" + cmbPreModel.SelectedValue.GetHashCode() + "' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmd_PreColor.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmd_PreColor.ItemsSource = ds.Tables[0].DefaultView;
                    cmd_PreColor.DisplayMemberPath = ds.Tables[0].Columns["Color"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }
        }

        public bool PrePro_Validation()
        {
            bool result = false;
            if (cmbPre_Pro_Salename.SelectedItem == null)
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Dealer Name";
                cmbPre_Pro_Salename.BorderBrush = Brushes.Red;
                obj.ShowDialog();
                
            }
            else if (cmbPreDomain.SelectedItem == null)
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Domain Name";
                cmbPreDomain.BorderBrush = Brushes.Red;
                obj.ShowDialog();
                
            }
            else if (txtDealer_CompanyName.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Domain Name";
                txtDealer_CompanyName.BorderBrush = Brushes.Red;
                obj.ShowDialog();

            }
            else if (cmbPreProduct.SelectedItem == null)
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Product Name";
                cmbPreProduct.BorderBrush = Brushes.Red;
                obj.ShowDialog();                
            }
            else if (cmbPreBrand.SelectedItem == null)
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Brand";
                cmbPreBrand.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }
            else if (cmbPrePCategory.SelectedItem == null)
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Product Category";
                cmbPrePCategory.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }
            else if (cmbPreModel.SelectedItem == null)
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Model No";
                cmbPreModel.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }
            else if (cmd_PreColor.SelectedItem == null)
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Color";
                cmd_PreColor.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }
            else if (txtPrice.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Price";
                txtPrice.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }
            else if (txtQuantity.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Quantity";
                txtQuantity.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }
            else if (cmbPreInsurance.SelectedItem == null)
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Insurance";
                cmbPreInsurance.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }
            else if (txtPreWarranty.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Product Warranty";
                txtPreWarranty.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }
            else if (cmbPreFollowup.SelectedItem == null)
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Follow-Up";
                cmbPreFollowup.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }
            
            return result;
        }

        public void Fetch_Pre_Domain()
        {
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("Select DISTINCT ID, Domain_Name from tb_Domain ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // con.Open();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    // cmbPreDomain.Text = "--Select--";
                    cmbPreDomain.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbPreDomain.ItemsSource = ds.Tables[0].DefaultView;
                    cmbPreDomain.DisplayMemberPath = ds.Tables[0].Columns["Domain_Name"].ToString();
                    // cmbPreDomain.Items.Insert(0, "--Select--");
                    // cmbPreDomain.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                con.Close();
            }

        }

        public void clearallPreProcurement()
        {
            cmbPre_Pro_Salename.SelectedValue = null;
            cmbPreDomain.SelectedValue = null;
            cmbPreProduct.SelectedValue = null;
            cmbPrePCategory.SelectedValue = null;
            cmbPreBrand.SelectedValue = null;
            cmbPreModel.SelectedValue = null;
            cmd_PreColor.SelectedValue = null;
            //txtprephone.Text = "";
            txtPreFerbcost.Text = "";
            txtnarration.Text = "";
            txtQuantity.Text = "";
            txtTotalPrice.Text = "";
            txtNetAmount.Text = "";
            txtpreroundoff.Text = "";
            txtDealer_CompanyName.Text = "";
            chkadharcard.IsChecked = false;
            chkNODOCS.IsChecked = false;
            chkaddress.IsChecked = false;
            chk7_12.IsChecked = false;
            chkform16.IsChecked = null;
            chkPANCARD.IsEnabled = false;
            chkPASSPORT.IsEnabled = false;
            CHKADHARC.IsEnabled = false;
            chkOTHERID.IsEnabled = false;
            chkDEALERL.IsEnabled = false;
            chkaddressproof.IsEnabled = false;
            
            cmbPreInsurance.Items.Clear();
            cmbPreFollowup.Items.Clear();
            load_Insurance();
            load_Followup();
            txtPrice.Text = "";
            chkcmpid.IsEnabled = false;
            txtPreWarranty.Text = "";

            cmbPreProduct.IsEnabled = false;
            cmbPreBrand.IsEnabled = false;
            cmbPrePCategory.IsEnabled = false;
            cmbPreModel.IsEnabled = false;
            cmd_PreColor.IsEnabled = false;
        }

        public void PREPROCUREMENTid()
        {

            int id1 = 0;
            // SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("select (COUNT(ID)) from Pre_Procurement", con);
            id1 = Convert.ToInt32(cmd.ExecuteScalar());
            id1 = id1 + 1;
            lblPro_no.Content = "# Pre_Proc/" + id1.ToString();
            con.Close();


        }

        public void load_Insurance()
        {
            cmbPreInsurance.Text = "--Select--";
            cmbPreInsurance.Items.Add("Yes");
            cmbPreInsurance.Items.Add("No");

        }

        public void load_Followup()
        {
            cmbPreFollowup.Text = "--Select--";
            cmbPreFollowup.Items.Add("Default");
            cmbPreFollowup.Items.Add("Custom");

        }
        
        public void load_DSelect()
        {
            cmbPreDomain.Text = "--Select--";
            cmbPreProduct.Text = "--Select--";
            cmbPreBrand.Text = "--Select--";
            cmbPrePCategory.Text = "--Select--";
            cmbPreModel.Text = "--Select--";
            cmd_PreColor.Text = "--Select--";
        }

        public void FetchDealarname()
        {
            try
            {
                con.Open();
                String str2 = "Select ID, [DealerFirstName]+' '+[DealerLastName] as [DealerName] from tbl_DealerEntry  where  S_Status='Active' ";
                cmd = new SqlCommand(str2, con);
                DataSet ds = new DataSet();
                // dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {


                    cmbPre_Pro_Salename.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                    cmbPre_Pro_Salename.ItemsSource = ds.Tables[0].DefaultView;
                    //string a = ds.Tables[0].Columns["DealerFirstName"].ToString();
                    //string b = ds.Tables[0].Columns["DealerLastName"].ToString();
                    cmbPre_Pro_Salename.DisplayMemberPath = ds.Tables[0].Columns["DealerName"].ToString();

                }

            }
            catch { throw; }
            finally { con.Close(); }
        }

        public void SetWarrantyYM()
        {
            cmbPreWarrantyYM.Text = "---Select---";
            cmbPreWarrantyYM.Items.Add("Month");
            cmbPreWarrantyYM.Items.Add("Year");
        }
        #endregion Pre-Proc Function

        #region Pre-Proc Event
        private void cmbPreDomain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // fetcdoc = cmbPreDomain.SelectedValue.GetHashCode();
            cmbPreProduct.IsEnabled = true;
            cmbPreProduct.SelectedValue = null;
            cmbPrePCategory.SelectedValue = null;
            cmbPreBrand.SelectedValue = null;
            cmbPreModel.SelectedValue = null;
            cmd_PreColor.SelectedValue = null;
            fetch_Documents();
            Fetch_Pre_Product();
        }

        private void cmbPreProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbPreBrand.IsEnabled = true;
            cmbPrePCategory.SelectedValue = null;
            cmbPreBrand.SelectedValue = null;
            cmbPreModel.SelectedValue = null;
            cmd_PreColor.SelectedValue = null;

            fetch_Pre_Brand();
        }

        private void cmbPreBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbPrePCategory.IsEnabled = true;
            cmbPrePCategory.SelectedValue = null;
            cmbPreModel.SelectedValue = null;
            cmd_PreColor.SelectedValue = null;
            Fetch_Pre_PC();
        }

        private void cmbPrePCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbPreModel.IsEnabled = true;
            //cmbPreBrand.SelectedValue = null;
            cmbPreModel.SelectedValue = null;
            cmd_PreColor.SelectedValue = null;
            fetch_Pre_Model();
        }

        private void cmbPreModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmd_PreColor.IsEnabled = true;
            cmd_PreColor.SelectedValue = null;
            fetch_Pre_Color();
        }

        private void cmd_PreColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            con.Open();

            cmd = new SqlCommand("Select  Price from Pre_Products where Color_ID='" + cmd_PreColor.SelectedValue.GetHashCode() + "' ", con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtPrice.Text = dr["Price"].ToString();
                txtPreFerbcost.Text = "0.00";
            }
            con.Close();
        }

        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPrice.Text == "")
            {
                //MessageBox.Show("Please Insert Price", caption, MessageBoxButton.OK);
                txtQuantity.Text = 0.ToString();

            }
            else if (txtQuantity.Text == "")
            {
                txtTotalPrice.Text = txtPrice.Text;
            }
            else if (txtPrice.Text != "" && txtQuantity.Text != "")
            {
                double tamt1;
                nfi = (NumberFormatInfo)nfi.Clone();
                nfi.CurrencySymbol = "";

                double prc = Convert.ToDouble(txtPrice.Text);
                double qty = Convert.ToDouble(txtQuantity.Text);
                double tamt = (prc * qty);
                txtTotalPrice.Text = tamt.ToString();
                //  txtpreroundoff.Text = Math.Round(tamt).ToString();
                //roundoff Method
                if (txtTotalPrice.Text.Trim().Length > 0)
                {
                    tamt1 = Convert.ToDouble(txtTotalPrice.Text);
                }
                else
                {
                    tamt1 = 0;
                }
                double netAmt = Math.Round(tamt1);
                double roundDiff = netAmt - tamt1;
                double roundDiff1 = Math.Round(roundDiff, 2);

                txtNetAmount.Text = String.Format(nfi, "{0:C}", Convert.ToDouble(netAmt));
                //txtRoundUp.Text = String.Format(nfi, "{0:C}", Convert.ToDouble(roundDiff));
                txtpreroundoff.Text = Convert.ToString(roundDiff1);

            }
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cbox = sender as CheckBox;
            string s = cbox.Content as string;

            if ((bool)cbox.IsChecked)
                checkedStuff.Add(s);
            else
                checkedStuff.Remove(s);
        }
        
        private void cmbPre_Pro_Salename_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            con.Open();

            cmd = new SqlCommand("Select  [CompanyName] from tbl_DealerEntry where ID='" + cmbPre_Pro_Salename.SelectedValue.GetHashCode() + "' ", con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtDealer_CompanyName.Text = dr["CompanyName"].ToString();
            }
            con.Close();
        }
        #endregion Pre-Proc Event
        
        #region Pre-Proc Button Event
        private void btnSave_PreProcurement_Click(object sender, RoutedEventArgs e)
        {
            if (PrePro_Validation() == true)
                return;

                try
                {

                    bpreproc.Flag = 1;
                    bpreproc.DealerID = cmbPre_Pro_Salename.SelectedValue.GetHashCode(); //txtsalername.Text;

                    //bpreproc.Phone_Id = txtprephone .Text ;
                    bpreproc.Domain_ID = Convert.ToInt32(cmbPreDomain.SelectedValue.GetHashCode());
                    bpreproc.Product_ID = Convert.ToInt32(cmbPreProduct.SelectedValue.GetHashCode());
                    bpreproc.Brand_ID = Convert.ToInt32(cmbPreBrand.SelectedValue.GetHashCode());
                    bpreproc.P_Category = Convert.ToInt32(cmbPrePCategory.SelectedValue.GetHashCode());
                    bpreproc.Model_No_ID = Convert.ToInt32(cmbPreModel.SelectedValue.GetHashCode());
                    bpreproc.Color_ID = Convert.ToInt32(cmd_PreColor.SelectedValue.GetHashCode());

                    bpreproc.Procurment_Price = Convert.ToDouble(txtPrice.Text);
                    bpreproc.Quantity = Convert.ToDouble(txtQuantity.Text);
                    bpreproc.Total_Amount = Convert.ToDouble(txtTotalPrice.Text);
                    bpreproc.Net_Amount = Convert.ToDouble(txtNetAmount.Text);
                    bpreproc.Round_Off = Convert.ToDouble(txtpreroundoff.Text);
                    //    for (int i = 0; i < 5;i++ )
                    //    { 
                    //        if (chkidproof.IsChecked == true)
                    //        {
                    //            maincked = "ID Proof";
                    //        }

                    //    if(chkaddressproof  .IsChecked ==true )
                    //    {
                    //        maincked = "Address Proof";
                    //    }
                    //        string concate += ","+item maincked;
                    //}
                    string checkList = string.Join(",", checkedStuff.ToArray());
                    if (checkList == null)
                    { bpreproc.Reg_Document = "No"; }
                    else if (checkList != null)
                    {
                        bpreproc.Reg_Document = checkList;
                    }

                    bpreproc.Have_Insurance = cmbPreInsurance.SelectedValue.ToString();
                    string a = (txtPreWarranty.Text) + " - " + (cmbPreWarrantyYM.SelectedItem.ToString());
                    bpreproc.Warranty = a;
                    bpreproc.re_ferb_cost = Convert.ToDouble(txtPreFerbcost.Text);
                    bpreproc.Follow_up = cmbPreFollowup.SelectedValue.ToString();
                    bpreproc.Narration = txtnarration.Text;
                    bpreproc.PendingPreProc = "Active";
                    bpreproc.S_Status = "Active";
                    bpreproc.C_Date = System.DateTime.Now.ToShortDateString();
                    dpreproc.Pre_Procurement_Save_Insert_Update_Delete(bpreproc);
                    //MessageBox.Show("Data Save Successfully");
                    frmValidationMessage obj = new frmValidationMessage();
                    obj.lblMessage.Content = "Data Save Successfully";
                    obj.ShowDialog();
                    txtP_Narration.Text = txtnarration.Text;
                    txtP_Price.Text = "";
                    clearallPreProcurement();
                    PREPROCUREMENTid();
                    Fetch_Pre_Domain();


                    //baddprd.Flag = 1;
                    //baddprd.Domain_Name = cmbP_domain.SelectedValue.ToString ();
                    //baddprd.Product_Name = cmbP_Product.SelectedValue.ToString();
                    //baddprd.Brand_Name = cmbP_Brand.SelectedValue.ToString();
                    //baddprd.Product_Category = cmbP_PCategory.SelectedValue.ToString();
                    //baddprd.Model_No = cmbP_ModelNo.SelectedValue.ToString();
                    //baddprd.Color = cmbP_Color.SelectedValue.ToString();
                    //baddprd.Narration = txtP_Narration.Text;
                    //baddprd.Price = Convert.ToDouble(txtP_Price.Text);
                    //baddprd.S_Status = "Active";
                    //baddprd.C_Date = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                    //dalprd.Save_Insert_Update_Delete(baddprd);
                    //MessageBox.Show("Data Save Successfully");
                    //txtP_Narration.Text = "";
                    //txtP_Price.Text = "";
                    // Load_Domain();
                }
                catch (Exception)
                {

                    throw;
                }
        }

        private void btnClear_PreProcurment_Click(object sender, RoutedEventArgs e)
        {
            clearallPreProcurement();
        }

        private void btnExit_PreProcurement_Click(object sender, RoutedEventArgs e)
        {
            grdAdm_PreProcurement.Visibility = System.Windows.Visibility.Hidden;
        }

        private void menu_AddNewProcurement_Click(object sender, RoutedEventArgs e)
        {
            grdAdm_PreProcurement.Visibility = System.Windows.Visibility.Visible;
            load_DSelect();
            Fetch_Pre_Domain();
            load_Insurance();
            load_Followup();
            FetchDealarname();
            SetWarrantyYM();
            PREPROCUREMENTid();
        }
        #endregion Pre-Proc Button Event

        #endregion Pre-Procurement Function

        #region Followup Function
        #region Followup Fun
        public void Folloupiid()
        {

            int id1 = 0;
            // SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("select (COUNT(ID)) from tlb_FollowUp", con);
            id1 = Convert.ToInt32(cmd.ExecuteScalar());
            id1 = id1 + 1;
            lblwalkin.Content = "# Walk-Ins /" + id1.ToString();
            con.Close();
        }

        public void clearfunctionforfollowup()
        {
            //FolloupID_fetch();
            cmbFollowpTitle.Text = null;
            txtAdm_FollowupFirstName.Text = "";
            txtAdm_FollowupLastName.Text = "";
            dp_Dob.SelectedDate = null;
            cmbFollowup_Occupation.Text = null;
            txtCMobile.Text = "";
            txtAdm_Followup_PhoneNo.Text = "";
            txtCAddress.Text = "";
            txtCEmailid.Text = "";
            cmbFollowup_City.Text = null;
            txtFollowup_Zip.Text = "";
            cmbFollowup_State.Text = null;
            cmbFollowup_Country.Text = null;
            txtFollowupDescription.Text = "";
            txtFollowAnnualRevenue.Text = "";
            cmbCEmployeename.SelectedValue = null;
            cmbCSourceofEnq.Text = null;
            txtFollowFaxNo.Text = "";
            txtFollowWebsite.Text = "";
            dgvFoll_AddProducts.ItemsSource = null;
            //loadSourceofEnq();
        }

        public bool Followup_Validation()
        {
            bool result = false;
            if (cmbCEmployeename.Text == "-None-")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Employee Name";
                cmbCEmployeename.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }
            else if (txtAdm_FollowupFirstName.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Follow-up First Name";
                txtAdm_FollowupFirstName.BorderBrush = Brushes.Red;
                obj.ShowDialog();

            }
            else if (txtAdm_FollowupLastName.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Follow-up Last Name";
                txtAdm_FollowupLastName.BorderBrush = Brushes.Red;
                obj.ShowDialog();

            }
            else if (dp_Dob.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Follow-up Date of Birth";
                dp_Dob.BorderBrush = Brushes.Red;
                obj.ShowDialog();

            }
            else if (cmbCSourceofEnq.Text == "-None-")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Source of Enquiry";
                cmbCSourceofEnq.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }
            else if (cmbFollowup_Occupation.Text == "-None-")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Occupation";
                cmbFollowup_Occupation.BorderBrush = Brushes.Red;
                obj.ShowDialog();

            }
            else if (txtCMobile.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Follow-up Mobile No.";
                txtCMobile.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }
            else if (dp_Cdate.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Follow-up Date";
                dp_Cdate.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }            
            return result;
        }

        public void Load_Followup_City()
        {
            cmbFollowup_City.Text = "-None-";
            string q = "SELECT distinct(City) As City FROM tlb_FollowUp ";
            cmd = new SqlCommand(q, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //cmbInsurance_CustName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                cmbFollowup_City.ItemsSource = ds.Tables[0].DefaultView;
                cmbFollowup_City.DisplayMemberPath = ds.Tables[0].Columns["City"].ToString();
            }
        }

        public void Load_Followup_State()
        {
            cmbFollowup_State.Text = "-None-";
            string q = "SELECT distinct(State) As State FROM tlb_FollowUp ";
            cmd = new SqlCommand(q, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //cmbInsurance_CustName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                cmbFollowup_State.ItemsSource = ds.Tables[0].DefaultView;
                cmbFollowup_State.DisplayMemberPath = ds.Tables[0].Columns["State"].ToString();
            }
        }

        public void Load_Followup_Country()
        {
            cmbFollowup_Country.Text = "-None-";
            string q = "SELECT distinct(Country) As Country FROM tlb_FollowUp ";
            cmd = new SqlCommand(q, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //cmbInsurance_CustName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                cmbFollowup_Country.ItemsSource = ds.Tables[0].DefaultView;
                cmbFollowup_Country.DisplayMemberPath = ds.Tables[0].Columns["Country"].ToString();
            }
        }

        public void Load_Followup_Occupation()
        {
            cmbFollowup_Occupation.Text = "-None-";
            string q = "SELECT distinct(Occupation) As Occupation FROM tlb_FollowUp ";
            cmd = new SqlCommand(q, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //cmbInsurance_CustName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                cmbFollowup_Occupation.ItemsSource = ds.Tables[0].DefaultView;
                cmbFollowup_Occupation.DisplayMemberPath = ds.Tables[0].Columns["Occupation"].ToString();
            }
        }

        public void Load_Followup_Employee()
        {
            cmbCEmployeename.Text = "-None-";
            string q = "SELECT [ID], [EmployeeFirstName]  + ' ' +   [EmployeeLastName] AS [EmployeeName] FROM tbl_Employee ";
            cmd = new SqlCommand(q, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbCEmployeename.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                cmbCEmployeename.ItemsSource = ds.Tables[0].DefaultView;
                cmbCEmployeename.DisplayMemberPath = ds.Tables[0].Columns["EmployeeName"].ToString();
            }
        }

        public void LoadSourceofEnq()
        {
            cmbCSourceofEnq.Text = "Select";
            cmbCSourceofEnq.Items.Add("Newspaper");
            cmbCSourceofEnq.Items.Add("Poster");
            cmbCSourceofEnq.Items.Add("Friends / Colleagues");
            cmbCSourceofEnq.Items.Add("Net / Website");
            cmbCSourceofEnq.Items.Add("Non");
        }
        #endregion Followup Fun

        #region Followup Button Event
        private void btnFollowup_Save_Click(object sender, RoutedEventArgs e)
        {
            if (Followup_Validation() == true)
                return;

            try
            {
                balfollow.Flag = 1;
                balfollow.EmployeeID = cmbCEmployeename.SelectedValue.GetHashCode();
                balfollow.Followup_ID = lblwalkin.Content.ToString();
                balfollow.FTitle = cmbFollowpTitle.Text;
                balfollow.FiratName = txtAdm_FollowupFirstName.Text;
                balfollow.LastName = txtAdm_FollowupLastName.Text;
                balfollow.Date_Of_Birth = dp_Dob.Text;
                balfollow.Mobile_No = txtCMobile.Text;
                balfollow.PhoneNo = txtAdm_Followup_PhoneNo.Text;
                balfollow.SourceOfEnquiry = cmbCSourceofEnq.Text;
                soe = cmbCSourceofEnq.Text;
                if (soe == "Newspaper")
                {
                    vsoe = 1;
                }
                else if (soe == "Advertisement")
                {
                    vsoe = 2;
                }
                else if (soe == "Friends / Colleagues")
                {
                    vsoe = 3;

                }
                else if (soe == "External Referral")
                {
                    vsoe = 4;

                }
                else if (soe == "Online Store")
                {
                    vsoe = 5;
                }
                else if (soe == "Public Relation")
                {
                    vsoe = 6;
                }
                else if (soe == "Sales Mail Alias")
                {
                    vsoe = 7;
                }
                else if (soe == "Net / Website")
                {
                    vsoe = 8;
                }
                else if (soe == "Other")
                {
                    vsoe = 9;
                }
                balfollow.SourceOfEnquiryID = vsoe;
                balfollow.Occupation = cmbFollowup_Occupation.Text;
                balfollow.AnnualRevenue = Convert.ToDouble(txtFollowAnnualRevenue.Text);
                balfollow.Email_ID = txtCEmailid.Text;
                balfollow.FaxNo = txtFollowFaxNo.Text;
                balfollow.Wbsite = txtFollowWebsite.Text;
                balfollow.Street = txtCAddress.Text;
                balfollow.City = cmbFollowup_City.Text;
                balfollow.State = cmbEmp_State.Text;
                balfollow.ZipNo = txtFollowup_Zip.Text;
                balfollow.Country = cmbFollowup_Country.Text;
                balfollow.Description = txtFollowupDescription.Text;
                balfollow.F_Date = dp_Cdate.Text;
                balfollow.S_Status = "Active";
                balfollow.C_Date = System.DateTime.Now.ToString();
                dalfollow.Follwup_Save_Insert_Update_Delete(balfollow);
                //MessageBox.Show("Customer Added sucsessfully ", caption, MessageBoxButton.OK);
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Data Save Successfully";
                obj.ShowDialog();
                //clearfunctionforfollowup();
                GetMax_FollowUpID();
                try
                {
                    FollowupProduct_SaveDetails();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            FollowUp_FillData();
            //Load_Followup_City();
            //Load_Followup_Country();
            //Load_Followup_State();
            //Load_Followup_Occupation();
            //Load_Followup_Employee();
            //Folloupiid();
        }

        private void btnfFollowup_Clear_Click(object sender, RoutedEventArgs e)
        {
            clearfunctionforfollowup();
        }

        private void btnFollowup_Exit_Click(object sender, RoutedEventArgs e)
        {
            grdFollowupEntry.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btnFollowCalc_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process P = System.Diagnostics.Process.Start("Calc.exe");
            P.WaitForInputIdle();
        }
        #endregion Followup Button Event

        private void grdFollowupEntry_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Followup_City();
            Load_Followup_Country();
            Load_Followup_State();
            Load_Followup_Occupation();
            //LoadSourceofEnq();
            Load_Followup_Employee();
            Folloupiid();
            //txtAdm_FollowupFirstName.Focus();
        }

        private void menu_WalkisEntry_Click(object sender, RoutedEventArgs e)
        {
            grdFollowupEntry.Visibility = System.Windows.Visibility.Visible;
            Load_Followup_City();
            Load_Followup_Country();
            Load_Followup_State();
            Load_Followup_Occupation();
            //LoadSourceofEnq();
            Load_Followup_Employee();
            Folloupiid();
            //txtAdm_FollowupFirstName.Focus();
            cmbCEmployeename.Focus();
        }
        #endregion Followup Function

        #region Customer Function
        #region Cust Fun
        public void Customeriid()
        {

            int id1 = 0;
            // SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("select (COUNT(ID)) from tlb_Customer", con);
            id1 = Convert.ToInt32(cmd.ExecuteScalar());
            id1 = id1 + 1;
            lblCustomerID.Content = "# Customer / " + id1.ToString();
            con.Close();
        }

        public void clearfunctionforCustomer()
        {
            //FolloupID_fetch();
            txtCustomerFirstName.Text = "";
            txtCustomerLastName.Text = "";
            dtpCustomer_DOB.SelectedDate = null;
            cmbCustomer_Occupation.Text = null;
            txtCustomer_Mobile.Text = "";
            txtCustomer_PhoneNo.Text = "";
            txtCustomer_Address.Text = "";
            txtCustomer_Emailid.Text = "";
            cmbCustomer_City.Text = null;
            txtCustomer_Zip.Text = "";
            cmbCustomer_State.Text = null;
            cmbCustomer_Country.Text = null;
            cmbCustomer_SourceofEnq.ItemsSource = null;
            LoadCustomer_SourceofEnq();
        }

        public bool Customer_Validation()
        {
            bool result = false;
            if (txtCustomerFirstName.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Customer First Name";
                txtCustomerFirstName.BorderBrush = Brushes.Red;
                obj.ShowDialog();

            }
            else if (txtCustomerLastName.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Customer Last Name";
                txtCustomerLastName.BorderBrush = Brushes.Red;
                obj.ShowDialog();

            }
            else if (dtpCustomer_DOB.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Customer Date of Birth";
                dtpCustomer_DOB.BorderBrush = Brushes.Red;
                obj.ShowDialog();

            }
            else if (cmbCustomer_Occupation.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Customer Occupation";
                cmbCustomer_Occupation.BorderBrush = Brushes.Red;
                obj.ShowDialog();

            }
            else if (txtCustomer_Mobile.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Customer Mobile No.";
                txtCustomer_Mobile.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }
            else if (txtCustomer_Address.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Customer Address";
                txtCustomer_Address.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }
            else if (cmbCustomer_City.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select City";
                cmbCustomer_City.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }
            else if (cmbCustomer_State.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select State";
                cmbCustomer_State.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }
            else if (cmbCustomer_Country.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Country";
                cmbCustomer_Country.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }
            else if (cmbCustomer_SourceofEnq.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Source of Enquiry";
                cmbCustomer_SourceofEnq.BorderBrush = Brushes.Red;
                obj.ShowDialog();
            }

            return result;
        }

        public void Load_Customer_City()
        {
            cmbCustomer_City.Text = "Select";
            string q = "SELECT distinct(City) As City FROM tlb_Customer ";
            cmd = new SqlCommand(q, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //cmbInsurance_CustName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                cmbCustomer_City.ItemsSource = ds.Tables[0].DefaultView;
                cmbCustomer_City.DisplayMemberPath = ds.Tables[0].Columns["City"].ToString();
            }
        }

        public void Load_Customer_State()
        {
            cmbCustomer_State.Text = "Select";
            string q = "SELECT distinct(State) As State FROM tlb_Customer ";
            cmd = new SqlCommand(q, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //cmbInsurance_CustName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                cmbCustomer_State.ItemsSource = ds.Tables[0].DefaultView;
                cmbCustomer_State.DisplayMemberPath = ds.Tables[0].Columns["State"].ToString();
            }
        }

        public void Load_Customer_Country()
        {
            cmbCustomer_Country.Text = "Select";
            string q = "SELECT distinct(Country) As Country FROM tlb_Customer ";
            cmd = new SqlCommand(q, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //cmbInsurance_CustName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                cmbCustomer_Country.ItemsSource = ds.Tables[0].DefaultView;
                cmbCustomer_Country.DisplayMemberPath = ds.Tables[0].Columns["Country"].ToString();
            }
        }

        public void Load_Customer_Occupation()
        {
            cmbCustomer_Occupation.Text = "Select";
            string q = "SELECT distinct(Occupation) As Occupation FROM tlb_Customer ";
            cmd = new SqlCommand(q, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //cmbInsurance_CustName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
                cmbCustomer_Occupation.ItemsSource = ds.Tables[0].DefaultView;
                cmbCustomer_Occupation.DisplayMemberPath = ds.Tables[0].Columns["Occupation"].ToString();
            }
        }
        
        public void LoadCustomer_SourceofEnq()
        {
            cmbCustomer_SourceofEnq.Text = "Select";
            cmbCustomer_SourceofEnq.Items.Add("Newspaper");
            cmbCustomer_SourceofEnq.Items.Add("Poster");
            cmbCustomer_SourceofEnq.Items.Add("Friends / Colleagues");
            cmbCustomer_SourceofEnq.Items.Add("Net / Website");
            cmbCustomer_SourceofEnq.Items.Add("Non");
        }
        #endregion Cust Fun

        #region Customer Button Event
        private void btnSave_Customer_Click(object sender, RoutedEventArgs e)
        {
            if (Customer_Validation() == true)
                return;

            try
            {
                bcustomer.Flag = 1;
                bcustomer.Cust_ID = lblCustomerID.Content.ToString();
                bcustomer.FirstName = txtCustomerFirstName.Text;
                bcustomer.LastName = txtCustomerLastName.Text;
                bcustomer.Date_Of_Birth = dtpCustomer_DOB.Text;
                bcustomer.Occupation = cmbCustomer_Occupation.Text;
                bcustomer.Mobile_No = txtCustomer_Mobile.Text;
                bcustomer.PhoneNo = txtCustomer_PhoneNo.Text;
                bcustomer.Email_ID = txtCustomer_Emailid.Text;
                bcustomer.Address = txtCustomer_Address.Text;
                bcustomer.City = cmbCustomer_City.Text;
                bcustomer.ZipNo = txtCustomer_Zip.Text;
                bcustomer.State = cmbCustomer_State.Text;
                bcustomer.Country = cmbCustomer_Country.Text;
                bcustomer.SourceOfEnquiry = cmbCustomer_SourceofEnq.Text;
                soe = cmbCustomer_SourceofEnq.SelectedValue.ToString();
                if (soe == "Newspaper")
                {
                    vsoe = 1;
                }
                else if (soe == "Poster")
                {
                    vsoe = 2;
                }
                else if (soe == "Friends / Colleagues")
                {
                    vsoe = 3;

                }
                else if (soe == "Net / Website")
                {
                    vsoe = 4;

                }
                else if (soe == "Non")
                {
                    vsoe = 5;
                }
                bcustomer.SourceEnquiryID = vsoe;
                bcustomer.S_Status = "Active";
                bcustomer.C_Date = System.DateTime.Now.ToString();
                dcustomer.Customer_Save_Insert_Update_Delete(bcustomer);
                //MessageBox.Show("Customer Added sucsessfully ", caption, MessageBoxButton.OK);
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Data Save Successfully";
                obj.ShowDialog();
                clearfunctionforCustomer();
                Customeriid();
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            Load_Customer_City();
            Load_Customer_Country();
            Load_Customer_State();
            Load_Customer_Occupation();
            Customeriid();
        }

        private void btnClear_Customer_Click(object sender, RoutedEventArgs e)
        {
            clearfunctionforCustomer();
        }

        private void btnExit_Customer_Click(object sender, RoutedEventArgs e)
        {
            grdCustomerEntry.Visibility = System.Windows.Visibility.Hidden;
        }
        #endregion Customer Button Event

        private void grdCustomerEntry_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Customer_City();
            Load_Customer_Country();
            Load_Customer_State();
            Load_Customer_Occupation();
            //LoadCustomer_SourceofEnq();
            Customeriid();
            //txtCustomerFirstName.Focus();
        }

        private void menu_CustomerEntry_Click(object sender, RoutedEventArgs e)
        {
            grdCustomerEntry.Visibility = System.Windows.Visibility.Visible;
            Load_Customer_City();
            Load_Customer_Country();
            Load_Customer_State();
            Load_Customer_Occupation();
            LoadCustomer_SourceofEnq();
            Customeriid();
            //txtCustomerFirstName.Focus();
        }
        #endregion Customer Function


        #region FinalPreProcurement Button Event
        private void btnFinal_PreProcurement_Refresh_Click(object sender, RoutedEventArgs e)
        {
            dtpFrom_FinalPreProcurement.SelectedDate = null;
            dtpTo_FinalPreProcurement.SelectedDate = null;
            cmbFilter_FinalPreProcuremet.Text = "Select";
            txtFilter_finalPreProcurement.Text = "";
        }

        private void btndgv_final_PreProcurement_Click(object sender, RoutedEventArgs e)
        {
            object item = dgvFinal_PreProcurement.SelectedItem;
            string ID = (dgvFinal_PreProcurement.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            grd_View_FinalPreProcurement.Visibility = System.Windows.Visibility.Visible;
            
            try
            {
                con.Open();
                string sqlquery = "SELECT P.[ID],P.[DealerID],P.[Domain_ID],P.[Product_ID],P.[Brand_ID],P.[P_Category],P.[Model_No_ID],P.[Color_ID],P.[Warranty],P.[Quantity],P.[C_Date],P.[Have_Insurance] " +
                      ",D.[DealerFirstName] + ' ' + D.[DealerLastName] AS [DealerName],D.[MobileNo],D.[PhoneNo],D.[CompanyName],D.[DealerAddress],D.[City] " +
                      ",DM.[Domain_Name] + ' , ' +  PM.[Product_Name] + ' , ' + B.[Brand_Name] + ' , ' + PC.[Product_Category] + ' , ' + MN.[Model_No] + ' , ' + C.[Color] AS [Products]" +
                    //",PP.[Price] " +
                      "FROM [Pre_Procurement] P " +
                      "INNER JOIN [tbl_DealerEntry] D ON D.[ID] = P.[DealerID] " +
                      "INNER JOIN [tb_Domain] DM ON DM.[ID]=P.[Domain_ID] " +
                      "INNER JOIN [tlb_Products] PM ON PM.[ID]=P.[Product_ID] " +
                      "INNER JOIN [tlb_Brand] B ON B.[ID]=P.[Brand_ID] " +
                      "INNER JOIN [tlb_P_Category] PC ON PC.[ID]=P.[P_Category]" +
                      "INNER JOIN [tlb_Model] MN ON MN.[ID]=P.[Model_No_ID] " +
                      "INNER JOIN [tlb_Color] C ON C.[ID]=P.[Color_ID] " +
                    //"INNER JOIN [Pre_Products] PP ON PP.[Model_No_ID]=P.[Model_No_ID] " +
                      "WHERE P.[ID]='" + ID + "' ";

                SqlCommand cmd = new SqlCommand(sqlquery, con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtPreProID.Text = dt.Rows[0]["ID"].ToString();
                    lblViewdealerName.Content = dt.Rows[0]["DealerName"].ToString();
                    lblViewCompanyName.Content = dt.Rows[0]["CompanyName"].ToString();
                    lblViewDealerMobileNo.Content = dt.Rows[0]["MobileNo"].ToString();
                    lblViewDealerPhoneNo.Content = dt.Rows[0]["PhoneNo"].ToString();
                    lblViewDealerAddress.Content = dt.Rows[0]["DealerAddress"].ToString();
                    lblViewDealerCity.Content = dt.Rows[0]["City"].ToString();
                }

                //grd_FinalizeProducts.Visibility = System.Windows.Visibility.Visible;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            Pending_PreProcurement();
        }

        private void menu_FinalPreProcurementList_Click(object sender, RoutedEventArgs e)
        {
            grdFinalPreProcurement.Visibility = System.Windows.Visibility.Visible;
            Final_PreProcurement();
            LoadFinal_PreProcurement();
        }

        private void btnFinalPreProcurement_Exit_Click(object sender, RoutedEventArgs e)
        {
            grdFinalPreProcurement.Visibility = System.Windows.Visibility.Hidden;
        }
        #endregion FinalPreProcurement Button Event

        #region Pre-Procurement Details Function
        public void LoadFinal_PreProcurement()
        {
            cmbFilter_FinalPreProcuremet.Text = "Select";
            //cmbAdm_DealerFilter_Search.Items.Add("Domain");
            cmbFilter_FinalPreProcuremet.Items.Add("Dealer Name");
            cmbFilter_FinalPreProcuremet.Items.Add("Dealer MobileNo");
            cmbFilter_FinalPreProcuremet.Items.Add("Product Type");
            cmbFilter_FinalPreProcuremet.Items.Add("Brand");
            cmbFilter_FinalPreProcuremet.Items.Add("Product Category");
            cmbFilter_FinalPreProcuremet.Items.Add("Model");
            cmbFilter_FinalPreProcuremet.Items.Add("Color");
            cmbFilter_FinalPreProcuremet.Items.Add("Products / Services");
        }

        public void Final_PreProcurement()
        {
            try
            {
                String str;
                //con.Open();
                DataSet ds = new DataSet();
                str = "SELECT P.[ID],P.[DealerID],P.[Domain_ID],P.[Product_ID],P.[Brand_ID],P.[P_Category],P.[Model_No_ID],P.[Color_ID],P.[Warranty],P.[Quantity],P.[C_Date],P.[Have_Insurance] " +
                      ",D.[DealerFirstName] + ' ' + D.[DealerLastName] AS [DealerName],D.[MobileNo],D.[PhoneNo],D.[CompanyName],D.[City] " +
                      ",DM.[Domain_Name] + ' , ' +  PM.[Product_Name] + ' , ' + B.[Brand_Name] + ' , ' + PC.[Product_Category] + ' , ' + MN.[Model_No] + ' , ' + C.[Color] AS [Products]" +
                      //",PP.[Price] " +
                      "FROM [Pre_Procurement] P " +
                      "INNER JOIN [tbl_DealerEntry] D ON D.[ID] = P.[DealerID] " +
                      "INNER JOIN [tb_Domain] DM ON DM.[ID]=P.[Domain_ID] " +
                      "INNER JOIN [tlb_Products] PM ON PM.[ID]=P.[Product_ID] " +
                      "INNER JOIN [tlb_Brand] B ON B.[ID]=P.[Brand_ID] " +
                      "INNER JOIN [tlb_P_Category] PC ON PC.[ID]=P.[P_Category]" +
                      "INNER JOIN [tlb_Model] MN ON MN.[ID]=P.[Model_No_ID] " +
                      "INNER JOIN [tlb_Color] C ON C.[ID]=P.[Color_ID] " +
                      //"INNER JOIN [Pre_Products] PP ON PP.[Model_No_ID]=P.[Model_No_ID] " +
                      "WHERE ";
                if ((dtpFrom_FinalPreProcurement.SelectedDate != null) && (dtpTo_FinalPreProcurement.SelectedDate != null))
                {
                    DateTime StartDate = Convert.ToDateTime(dtpFrom_FinalPreProcurement.Text.Trim() + " 00:00:00.000");
                    DateTime EndDate = Convert.ToDateTime(dtpTo_FinalPreProcurement.Text.Trim() + " 23:59:59.999");
                    str = str + "P.[C_Date] Between '" + StartDate + "' AND '" + EndDate + "'  AND ";
                }

                //if (cmbAdm_DealerFilter_Search.Text.Equals("Domain"))
                //{
                //    if (txtAdm_Dealer_Filter_Search.Text.Trim() != "")
                //    {
                //        str = str + "DM.[Domain_Name] LIKE ISNULL('" + txtAdm_Dealer_Filter_Search.Text.Trim() + "',DM.[Domain_Name]) + '%' AND ";
                //    }
                //}
                if (cmbFilter_FinalPreProcuremet.Text.Equals("Dealer Name"))
                {
                    if (txtFilter_finalPreProcurement.Text.Trim() != "")
                    {
                        str = str + "D.[DealerFirstName] LIKE ISNULL('" + txtFilter_finalPreProcurement.Text.Trim() + "',D.[DealerFirstName]) + '%' AND ";
                    }
                }
                if (cmbFilter_FinalPreProcuremet.Text.Equals("Dealer MobileNo"))
                {
                    if (txtFilter_finalPreProcurement.Text.Trim() != "")
                    {
                        str = str + "D.[MobileNo] LIKE ISNULL('" + txtFilter_finalPreProcurement.Text.Trim() + "',D.[MobileNo]) + '%' AND ";
                    }
                }
                if (cmbFilter_FinalPreProcuremet.Text.Equals("Product Type"))
                {
                    if (txtFilter_finalPreProcurement.Text.Trim() != "")
                    {
                        str = str + "PM.[Product_Name] LIKE ISNULL('" + txtFilter_finalPreProcurement.Text.Trim() + "',PM.[Product_Name]) + '%' AND ";
                    }
                }
                if (cmbFilter_FinalPreProcuremet.Text.Equals("Brand"))
                {
                    if (txtFilter_finalPreProcurement.Text.Trim() != "")
                    {
                        str = str + "B.[Brand_Name] LIKE ISNULL('" + txtFilter_finalPreProcurement.Text.Trim() + "',B.[Brand_Name]) + '%' AND ";
                    }
                }
                if (cmbFilter_FinalPreProcuremet.Text.Equals("Product Category"))
                {
                    if (txtFilter_finalPreProcurement.Text.Trim() != "")
                    {
                        str = str + "PC.[Product_Category] LIKE ISNULL('" + txtFilter_finalPreProcurement.Text.Trim() + "',PC.[Product_Category]) + '%' AND ";
                    }
                }
                if (cmbFilter_FinalPreProcuremet.Text.Equals("Model"))
                {
                    if (txtFilter_finalPreProcurement.Text.Trim() != "")
                    {
                        str = str + "MN.[Model_No] LIKE ISNULL('" + txtFilter_finalPreProcurement.Text.Trim() + "',MN.[Model_No]) + '%' AND ";
                    }
                }
                if (cmbFilter_FinalPreProcuremet.Text.Equals("Color"))
                {
                    if (txtFilter_finalPreProcurement.Text.Trim() != "")
                    {
                        str = str + "C.[Color] LIKE ISNULL('" + txtFilter_finalPreProcurement.Text.Trim() + "',C.[Color]) + '%' AND ";
                    }
                }
                if (cmbFilter_FinalPreProcuremet.Text.Equals("Products / Services"))
                {
                    if (txtFilter_finalPreProcurement.Text.Trim() != "")
                    {
                        str = str + "[Products] LIKE ISNULL('" + txtFilter_finalPreProcurement.Text.Trim() + "',[Products]) + '%' AND ";
                    }
                }
                str = str + " P.[S_Status] = 'Active' ORDER BY P.[C_Date] ASC ";
                //str = str + " S_Status = 'Active' ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                dgvFinal_PreProcurement.ItemsSource = ds.Tables[0].DefaultView;
                //}
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void Pending_PreProcurement()
        {
            try
            {
                String str;
                //con.Open();
                DataSet ds = new DataSet();
                str = "SELECT P.[ID],P.[DealerID],P.[Domain_ID],P.[Product_ID],P.[Brand_ID],P.[P_Category],P.[Model_No_ID],P.[Color_ID],P.[Warranty],P.[Quantity],P.[C_Date],P.[Have_Insurance],P.[Procurment_Price] " +
                      ",D.[DealerFirstName] + ' ' + D.[DealerLastName] AS [DealerName],D.[MobileNo],D.[PhoneNo],D.[CompanyName],D.[City] " +
                      //",DM.[Domain_Name] + ' , ' PM.[Product_Name] + ' , ' + B.[Brand_Name] + ' , ' + PC.[Product_Category] + ' , ' + MN.[Model_No] + ' , ' + C.[Color] AS [Products]" +
                      ",PM.[Product_Name],B.[Brand_Name],PC.[Product_Category],MN.[Model_No],C.[Color] " +
                    //",PP.[Price] " +
                      "FROM [Pre_Procurement] P " +
                      "INNER JOIN [tbl_DealerEntry] D ON D.[ID] = P.[DealerID] " +
                      "INNER JOIN [tb_Domain] DM ON DM.[ID]=P.[Domain_ID] " +
                      "INNER JOIN [tlb_Products] PM ON PM.[ID]=P.[Product_ID] " +
                      "INNER JOIN [tlb_Brand] B ON B.[ID]=P.[Brand_ID] " +
                      "INNER JOIN [tlb_P_Category] PC ON PC.[ID]=P.[P_Category]" +
                      "INNER JOIN [tlb_Model] MN ON MN.[ID]=P.[Model_No_ID] " +
                      "INNER JOIN [tlb_Color] C ON C.[ID]=P.[Color_ID] " +
                    //"INNER JOIN [Pre_Products] PP ON PP.[Model_No_ID]=P.[Model_No_ID] " +
                      "WHERE P.[ID]= '" + txtPreProID.Text.Trim() + "' AND P.[PendingPreProc] = 'Active' ORDER BY P.[C_Date] ASC";
                
                //str = str + " P.[S_Status] = 'Active' ORDER BY P.[C_Date] ASC ";
                //str = str + " S_Status = 'Active' ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                dgvPending_PreProcurements.ItemsSource = ds.Tables[0].DefaultView;
                //}
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        private void grdFinalPreProcurement_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFinal_PreProcurement();
            Final_PreProcurement();
        }

        private void txtFilter_finalPreProcurement_TextChanged(object sender, TextChangedEventArgs e)
        {
            Final_PreProcurement();
        }

        private void dtpFrom_FinalPreProcurement_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Final_PreProcurement();
        }

        private void dtpTo_FinalPreProcurement_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Final_PreProcurement();
        }

        private void btnPreProBack_Click(object sender, RoutedEventArgs e)
        {
            grdFinalPreProcurement.Visibility = System.Windows.Visibility.Visible;
            grd_View_FinalPreProcurement.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btnPreProPrevivew_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion Pre-Procurement Details Function

        #region FinalizePreprocurement Finction
        #region FinalizeProcurement fun
        public void View_Final_PreProcurement()
        {
            try
            {
                String str;
                //con.Open();
                DataSet ds = new DataSet();
                str = "SELECT P.[ID],P.[DealerID],P.[Domain_ID],P.[Product_ID],P.[Brand_ID],P.[P_Category],P.[Model_No_ID],P.[Color_ID],P.[Warranty],P.[Quantity],P.[C_Date],P.[Have_Insurance] " +
                      ",D.[DealerFirstName] + ' ' + D.[DealerLastName] AS [DealerName],D.[MobileNo],D.[PhoneNo],D.[CompanyName],D.[City] " +
                      ",DM.[Domain_Name] + ' , ' +  PM.[Product_Name] + ' , ' + B.[Brand_Name] + ' , ' + PC.[Product_Category] + ' , ' + MN.[Model_No] + ' , ' + C.[Color] AS [Products]" +
                    //",PP.[Price] " +
                      "FROM [Pre_Procurement] P " +
                      "INNER JOIN [tbl_DealerEntry] D ON D.[ID] = P.[DealerID] " +
                      "INNER JOIN [tb_Domain] DM ON DM.[ID]=P.[Domain_ID] " +
                      "INNER JOIN [tlb_Products] PM ON PM.[ID]=P.[Product_ID] " +
                      "INNER JOIN [tlb_Brand] B ON B.[ID]=P.[Brand_ID] " +
                      "INNER JOIN [tlb_P_Category] PC ON PC.[ID]=P.[P_Category]" +
                      "INNER JOIN [tlb_Model] MN ON MN.[ID]=P.[Model_No_ID] " +
                      "INNER JOIN [tlb_Color] C ON C.[ID]=P.[Color_ID] " +
                    //"INNER JOIN [Pre_Products] PP ON PP.[Model_No_ID]=P.[Model_No_ID] " +
                      "WHERE ";
                if ((dtpFrom_View_FinalPreProcurement.SelectedDate != null) && (dtpTo_View_FinalPreProcurement.SelectedDate != null))
                {
                    DateTime StartDate = Convert.ToDateTime(dtpFrom_View_FinalPreProcurement.Text.Trim() + " 00:00:00.000");
                    DateTime EndDate = Convert.ToDateTime(dtpTo_View_FinalPreProcurement.Text.Trim() + " 23:59:59.999");
                    str = str + "P.[C_Date] Between '" + StartDate + "' AND '" + EndDate + "'  AND ";
                }

                //if (cmbAdm_DealerFilter_Search.Text.Equals("Domain"))
                //{
                //    if (txtAdm_Dealer_Filter_Search.Text.Trim() != "")
                //    {
                //        str = str + "DM.[Domain_Name] LIKE ISNULL('" + txtAdm_Dealer_Filter_Search.Text.Trim() + "',DM.[Domain_Name]) + '%' AND ";
                //    }
                //}
                if (cmb_View_Filter_FinalPreProcuremet.Text.Equals("Dealer Name"))
                {
                    if (txt_View_Filter_finalPreProcurement.Text.Trim() != "")
                    {
                        str = str + "D.[DealerFirstName] LIKE ISNULL('" + txt_View_Filter_finalPreProcurement.Text.Trim() + "',D.[DealerFirstName]) + '%' AND ";
                    }
                }
                if (cmb_View_Filter_FinalPreProcuremet.Text.Equals("Dealer MobileNo"))
                {
                    if (txt_View_Filter_finalPreProcurement.Text.Trim() != "")
                    {
                        str = str + "D.[MobileNo] LIKE ISNULL('" + txt_View_Filter_finalPreProcurement.Text.Trim() + "',D.[MobileNo]) + '%' AND ";
                    }
                }
                if (cmb_View_Filter_FinalPreProcuremet.Text.Equals("Product Type"))
                {
                    if (txt_View_Filter_finalPreProcurement.Text.Trim() != "")
                    {
                        str = str + "PM.[Product_Name] LIKE ISNULL('" + txt_View_Filter_finalPreProcurement.Text.Trim() + "',PM.[Product_Name]) + '%' AND ";
                    }
                }
                if (cmb_View_Filter_FinalPreProcuremet.Text.Equals("Brand"))
                {
                    if (txt_View_Filter_finalPreProcurement.Text.Trim() != "")
                    {
                        str = str + "B.[Brand_Name] LIKE ISNULL('" + txt_View_Filter_finalPreProcurement.Text.Trim() + "',B.[Brand_Name]) + '%' AND ";
                    }
                }
                if (cmb_View_Filter_FinalPreProcuremet.Text.Equals("Product Category"))
                {
                    if (txt_View_Filter_finalPreProcurement.Text.Trim() != "")
                    {
                        str = str + "PC.[Product_Category] LIKE ISNULL('" + txt_View_Filter_finalPreProcurement.Text.Trim() + "',PC.[Product_Category]) + '%' AND ";
                    }
                }
                if (cmb_View_Filter_FinalPreProcuremet.Text.Equals("Model"))
                {
                    if (txt_View_Filter_finalPreProcurement.Text.Trim() != "")
                    {
                        str = str + "MN.[Model_No] LIKE ISNULL('" + txt_View_Filter_finalPreProcurement.Text.Trim() + "',MN.[Model_No]) + '%' AND ";
                    }
                }
                if (cmb_View_Filter_FinalPreProcuremet.Text.Equals("Color"))
                {
                    if (txt_View_Filter_finalPreProcurement.Text.Trim() != "")
                    {
                        str = str + "C.[Color] LIKE ISNULL('" + txt_View_Filter_finalPreProcurement.Text.Trim() + "',C.[Color]) + '%' AND ";
                    }
                }
                if (cmb_View_Filter_FinalPreProcuremet.Text.Equals("Products / Services"))
                {
                    if (txt_View_Filter_finalPreProcurement.Text.Trim() != "")
                    {
                        str = str + "[Products] LIKE ISNULL('" + txt_View_Filter_finalPreProcurement.Text.Trim() + "',[Products]) + '%' AND ";
                    }
                }
                str = str + " P.[S_Status] = 'Active' ORDER BY P.[C_Date] ASC ";
                //str = str + " S_Status = 'Active' ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                dgv_View_Final_PreProcurement.ItemsSource = ds.Tables[0].DefaultView;
                //}
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void Salesid()
        {

            int id1 = 0;
            // SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("select (COUNT(ID)) from Final_DealerDetails", con);
            id1 = Convert.ToInt32(cmd.ExecuteScalar());
            id1 = id1 + 1;
            lblSalesNo.Content = "# Sales /" + id1.ToString();
            con.Close();


        }

        private bool FinalPro_Validation()
        {
            bool result = false;
            if (txtPrice1.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Price";
                obj.ShowDialog();
            }
            else if (txtQuantityF.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Enter Quantity";
                obj.ShowDialog();
            }
            else if (dtpFinalDate.Text == "")
            {
                result = true;
                frmValidationMessage obj = new frmValidationMessage();
                obj.lblMessage.Content = "Please Select Date";
                obj.ShowDialog();
            }
            return result;
        }

        private bool CheckProduct()
        {
            try
            {
                bool result = false;
                string str = "SELECT * FROM [StockDetails] WHERE [S_Status] = 'Active' ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (txtAdm_DomainID.Text.Trim() == dt.Rows[i]["Domain_ID"].ToString())
                        {
                            if (txtAdm_ProductID.Text.Trim() == dt.Rows[i]["Product_ID"].ToString())
                            {
                                if (txtAdm_BrandID.Text.Trim() == dt.Rows[i]["Brand_ID"].ToString())
                                {
                                    if (txtAdm_ProductCatID.Text.Trim() == dt.Rows[i]["P_Category"].ToString())
                                    {
                                        if (txtAdm_ModelID.Text.Trim() == dt.Rows[i]["Model_No_ID"].ToString())
                                        {
                                            if (txtAdm_ColorID.Text.Trim() == dt.Rows[i]["Color_ID"].ToString())
                                            {
                                                //if ((txtAdm_DomainID.Text.Trim() == dt.Rows[i]["Domain_ID"].ToString()) && (txtAdm_ProductID.Text.Trim() == dt.Rows[i]["Product_ID"].ToString()) &&
                                                //    (txtAdm_BrandID.Text.Trim() == dt.Rows[i]["Brand_ID"].ToString()) && (txtAdm_ProductCatID.Text.Trim() == dt.Rows[i]["P_Category"].ToString()) &&
                                                //    (txtAdm_ModelID.Text.Trim() == dt.Rows[i]["Model_No_ID"].ToString()) && (txtAdm_ColorID.Text.Trim() == dt.Rows[i]["Color_ID"].ToString()))
                                                //string qry = "Select [ID],[Domain_ID],[Product_ID],[Brand_ID],[P_Category],[Model_No_ID],[Color_ID] From [StockDetails] Where [Domain_ID] = '" + txtAdm_DomainID.Text.Trim() + "' And [Product_ID] = '" + txtAdm_ProductID.Text.Trim() + "' And [Brand_ID] = '" + txtAdm_BrandID.Text.Trim() + "' And [P_Category] = '" + txtAdm_ProductCatID.Text.Trim() + "' And [Model_No_ID] = '" + txtAdm_ModelID.Text.Trim() + "' And [Color_ID] = '" + txtAdm_ColorID.Text.Trim() + "' ";
                                                string qry = "Select [ID],[Products123] From [StockDetails] Where  [Products123] = '" + lblProducts.Content.ToString() + "' ";

                                                SqlCommand cmd1 = new SqlCommand(qry, con);
                                                SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                                                DataTable dt1 = new DataTable();
                                                adp.Fill(dt1);
                                                if (dt.Rows.Count > 0)
                                                {
                                                    txtAdm_StockID.Text = dt.Rows[0]["ID"].ToString();
                                                }


                                                result = true;
                                                return result;
                                            }
                                            else
                                            {
                                                result = false;
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        int aviQty;
        int newQty;
        int add;

        public void AddQuantity_Check()
        {
            try
            {
                String str;
                //con.Open();
                DataSet ds = new DataSet();
                str = "SELECT [ID],[AvilableQty] From [StockDetails] Where [ID]='" + txtAdm_StockID.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    txtAdm_AvilableQty.Text = dt.Rows[0]["AvilableQty"].ToString();
                }
               
            }
                catch(Exception)
            {
                    throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddQuantity()
        {
            try
            {         
                aviQty = Convert.ToInt32(txtAdm_AvilableQty.Text);
                newQty = Convert.ToInt32(txtQuantityF.Text);
                add = aviQty + newQty;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion FinalizeProcurement fun

        #region View FinalizePreProcurement Button Event
        private void menu_FinalizePreProcurement_Click(object sender, RoutedEventArgs e)
        {
            grd_View_FinalProcurement.Visibility = System.Windows.Visibility.Visible;
            View_Final_PreProcurement();
        }

        private void btn_View_FinalPreProcurement_Exit_Click(object sender, RoutedEventArgs e)
        {
            //grd_View_FinalPreProcurement.Visibility = System.Windows.Visibility.Hidden;
            grd_View_FinalProcurement.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btn_View_Final_PreProcurement_Refresh_Click(object sender, RoutedEventArgs e)
        {
            dtpFrom_View_FinalPreProcurement.SelectedDate = null;
            dtpTo_View_FinalPreProcurement.SelectedDate = null;
            cmb_View_Filter_FinalPreProcuremet.Text = "Select";
            txt_View_Filter_finalPreProcurement.Text = "";
        }

        private void btndgv_finalize_PreProcurement_Click(object sender, RoutedEventArgs e)
        {
            object item = dgv_View_Final_PreProcurement.SelectedItem;
            string ID = (dgv_View_Final_PreProcurement.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            //MessageBox.Show(ID);
            grd_FinalizeProducts.Visibility = System.Windows.Visibility.Visible;
            Salesid();

            try
            {
                con.Open();
                string sqlquery = "SELECT P.[ID],P.[DealerID],P.[Domain_ID],P.[Product_ID],P.[Brand_ID],P.[P_Category],P.[Model_No_ID],P.[Color_ID],P.[Warranty],P.[Quantity],P.[C_Date],P.[Procurment_Price],P.[Net_Amount],P.[Have_Insurance] " +
                      ",D.[DealerFirstName] + '' + D.[DealerLastName] AS [DealerName],D.[MobileNo],D.[PhoneNo] " +
                      ",DM.[Domain_Name] + ' , ' +  PM.[Product_Name] + ' , ' + B.[Brand_Name] + ' , ' + PC.[Product_Category] + ' , ' + MN.[Model_No] + ' , ' + C.[Color] AS [Products]" +
                    //",PP.[Price] " +
                      "FROM [Pre_Procurement] P " +
                      "INNER JOIN [tbl_DealerEntry] D ON D.[ID] = P.[DealerID] " +
                      "INNER JOIN [tb_Domain] DM ON DM.[ID]=P.[Domain_ID] " +
                      "INNER JOIN [tlb_Products] PM ON PM.[ID]=P.[Product_ID] " +
                      "INNER JOIN [tlb_Brand] B ON B.[ID]=P.[Brand_ID] " +
                      "INNER JOIN [tlb_P_Category] PC ON PC.[ID]=P.[P_Category]" +
                      "INNER JOIN [tlb_Model] MN ON MN.[ID]=P.[Model_No_ID] " +
                      "INNER JOIN [tlb_Color] C ON C.[ID]=P.[Color_ID] " +
                    //"INNER JOIN [Pre_Products] PP ON PP.[Model_No_ID]=P.[Model_No_ID] " +
                      "WHERE P.[ID]='" + ID + "' ";

                SqlCommand cmd = new SqlCommand(sqlquery, con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtAdm_DealerID.Text = dt.Rows[0]["DealerID"].ToString();
                    txtAdm_DomainID.Text = dt.Rows[0]["Domain_ID"].ToString();
                    txtAdm_ProductID.Text = dt.Rows[0]["Product_ID"].ToString();
                    txtAdm_BrandID.Text = dt.Rows[0]["Brand_ID"].ToString();
                    txtAdm_ProductCatID.Text = dt.Rows[0]["P_Category"].ToString();
                    txtAdm_ModelID.Text = dt.Rows[0]["Model_No_ID"].ToString();
                    txtAdm_ColorID.Text = dt.Rows[0]["Color_ID"].ToString();
                    lblProceWarranty.Content = dt.Rows[0]["Warranty"].ToString();
                    lblProcDate.Content = dt.Rows[0]["C_Date"].ToString();
                    lblProducts.Content = dt.Rows[0]["Products"].ToString();
                    double Abc = Convert.ToDouble(dt.Rows[0]["Net_Amount"].ToString());
                    lblProceNetAmt.Content = Convert.ToDouble(Microsoft.VisualBasic.Strings.Format(Abc, "##,###.00"));
                    double price = Convert.ToDouble(dt.Rows[0]["Procurment_Price"].ToString());
                    lblProcePrice.Content = Convert.ToDouble(Microsoft.VisualBasic.Strings.Format(price, "##,###.00"));
                    double qt = Convert.ToDouble(dt.Rows[0]["Quantity"].ToString());
                    lblProceQty.Content = Convert.ToDouble(Microsoft.VisualBasic.Strings.Format(qt, "##,###.00"));
                    lblInsurance.Content = dt.Rows[0]["Have_Insurance"].ToString();
                    lblProceWarranty.Content = dt.Rows[0]["Warranty"].ToString();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
       
        private void btnFinalProcurement_Close_Click(object sender, RoutedEventArgs e)
        {
            grd_FinalizeProducts.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btnFinalProcurement_Click(object sender, RoutedEventArgs e)
        {
            if (FinalPro_Validation() == true)
                return;

            if (CheckProduct() == true)
            {
                try
                {
                    bstockDet.Flag = 1;
                    bstockDet.SID = Convert.ToInt32(txtAdm_StockID.Text);
                    //bstockDet.Products123 = lblProducts.Content.ToString();
                    bstockDet.NewQty = txtQuantityF.Text;
                    bstockDet.FinalPrice = Convert.ToDouble(txtPrice1.Text);
                    bstockDet.S_Status = "Active";
                    bstockDet.C_Date = Convert.ToString(System.DateTime.Now.ToShortDateString());
                    dstUpdate.AddStockDetailsUp_Insert_Update_Delete(bstockDet);
                    //MessageBox.Show("Data Save Successfully", caption, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }

                AddQuantity_Check();
                AddQuantity();
                try
                {
                    bstockDet.Flag = 1;
                    bstockDet.SID = Convert.ToInt32(txtAdm_StockID.Text);
                    //bstockDet.Products123 = lblProducts.Content.ToString();
                    bstockDet.AvilableQty = Convert.ToString(add);
                    daddqty.AddQtyStockDetails_Insert_Update_Delete(bstockDet);
                    //MessageBox.Show("Quantity Save Succesfully...", caption, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }


                try
                {
                    bstockDet.Flag = 1;
                    bstockDet.SID = Convert.ToInt32(txtAdm_StockID.Text);
                    //bstockDet.Products123 = lblProducts.Content.ToString();
                    bstockDet.AvilableQty = Convert.ToString(add);
                    daddqty.AddQtyStockDetails_Insert_Update_Delete(bstockDet);
                    //MessageBox.Show("Quantity Save Succesfully...", caption, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                try
                {
                    bstockDet.Flag = 1;
                    bstockDet.DomainID = Convert.ToInt32(txtAdm_DomainID.Text);
                    bstockDet.ProductID = Convert.ToInt32(txtAdm_ProductID.Text);
                    bstockDet.BrandID = Convert.ToInt32(txtAdm_BrandID.Text);
                    bstockDet.ProductCatID = Convert.ToInt32(txtAdm_ProductCatID.Text);
                    bstockDet.ModelID = Convert.ToInt32(txtAdm_ModelID.Text);
                    bstockDet.ColorId = Convert.ToInt32(txtAdm_ColorID.Text);
                    bstockDet.Products1234 = lblProducts.Content.ToString();

                    // bstockDet.Products123= lblProducts.Content.ToString();


                    bstockDet.Products1234 = lblProducts.Content.ToString();
                    //bstockDet.Products123= lblProducts.Content.ToString();
                    bstockDet.AvilableQty = txtQuantityF.Text;
                    bstockDet.SaleQty = txtSaleQuantity.Text;
                    bstockDet.NewQty = txtQuantityF.Text;
                    bstockDet.FinalPrice = Convert.ToDouble(txtPrice1.Text);
                    bstockDet.Insurance = lblInsurance.Content.ToString();
                    bstockDet.Warranty = lblProceWarranty .Content.ToString();
                    bstockDet.S_Status = "Active";
                    bstockDet.C_Date = Convert.ToString(System.DateTime.Now.ToShortDateString());
                    dstockDet.AddStockDetails_Insert_Update_Delete(bstockDet);
                    //MessageBox.Show("Data Save Successfully", caption, MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }

            string abc;

            if (chbDefault.IsChecked == true)
            {
                abc = "Default";
            }
            else
            {
                abc = "No";
            }

            //final dealer
            try
            {
                bfinaldealer1.Flag = 1;
                bfinaldealer1.FDealerID = Convert.ToInt32(txtAdm_DealerID.Text);
                bfinaldealer1.SalesID = lblSalesNo.Content.ToString();
                bfinaldealer1.Domain_ID = Convert.ToInt32(txtAdm_DomainID.Text);
                bfinaldealer1.Product_ID = Convert.ToInt32(txtAdm_ProductID.Text);
                bfinaldealer1.Brand_ID = Convert.ToInt32(txtAdm_BrandID.Text);
                bfinaldealer1.P_Category = Convert.ToInt32(txtAdm_ProductCatID.Text);
                bfinaldealer1.Model_No_ID = Convert.ToInt32(txtAdm_ModelID.Text);
                bfinaldealer1.Color_ID = Convert.ToInt32(txtAdm_ColorID.Text);
                bfinaldealer1.ProcNetAmt = Convert.ToDouble(lblProceNetAmt.Content.ToString());
                bfinaldealer1.ProcPrice = Convert.ToDouble(lblProcePrice.Content.ToString());
                bfinaldealer1.ProcQty = lblProceQty.Content.ToString();
                bfinaldealer1.FinalPrice = Convert.ToDouble(txtPrice1.Text);
                bfinaldealer1.FinalQty = txtQuantityF.Text;
                bfinaldealer1.SubTotal = Convert.ToDouble(txtTotalPrice1.Text);
                bfinaldealer1.RoundUp = Convert.ToDouble(txtpreroundoff1.Text);
                bfinaldealer1.NetAmt = Convert.ToDouble(txtNetAmount1.Text);
                //bfinaldealer.FinalDate = Convert.ToString(dtpFinalDate.Text);
                bfinaldealer1.SDefault = abc;
                bfinaldealer1.ServiceIntervalMonth = txtAdm_FinalMonths.Text;
                //bfinaldealer1.FMonths = lblFinal_Months.Content.ToString();
                bfinaldealer1.S_Status = "Active";
                bfinaldealer1.C_Date = Convert.ToString(System.DateTime.Now.ToShortDateString());
                dfinaldealer.FinalDealer_Insert_Update_Delete(bfinaldealer1);
                //MessageBox.Show("Data Save Successfully", caption, MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            //AddQuantity_Check();
            //AddQuantity();

            //try
            //{
            //    bstockDet.Flag = 1;
            //    bstockDet.SID = Convert.ToInt32(txtAdm_StockID.Text);
            //    //bstockDet.Products123 = lblProducts.Content.ToString();
            //    bstockDet.AvilableQty = Convert.ToString(add);
            //    daddqty.AddQtyStockDetails_Insert_Update_Delete(bstockDet);
            //    //MessageBox.Show("Quantity Save Succesfully...", caption, MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //finally
            //{
            //    con.Close();
            //}


            //try
            //{
            //    bstockDet.Flag = 1;
            //    bstockDet.SID = Convert.ToInt32(txtAdm_StockID.Text);
            //    //bstockDet.Products123 = lblProducts.Content.ToString();
            //    bstockDet.AvilableQty = Convert.ToString(add);
            //    daddqty.AddQtyStockDetails_Insert_Update_Delete(bstockDet);
            //    //MessageBox.Show("Quantity Save Succesfully...", caption, MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //finally
            //{
            //    con.Close();
            //}

            try
            {
                bfinaldealer1.Flag = 1;
                bfinaldealer1.FDealerID = Convert.ToInt32(txtAdm_DealerID.Text);
                bfinaldealer1.S_Status = "DeActive";
                dFup.FinalUpdateD_Insert_Update_Delete(bfinaldealer1);
                //MessageBox.Show("Update Final Dealer Succesfully...", caption, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            frmValidationMessage obj = new frmValidationMessage();
            obj.lblMessage.Content = "Data Save Successfully";
            obj.ShowDialog();

          //  MessageBox.Show("Data Save Successfully", caption, MessageBoxButton.OK, MessageBoxImage.Information);

            //txtAdm_DomainID.Text = "";
            //txtAdm_ProductID.Text = "";
            txtAdm_StockID.Text = "";
            txtAdm_BrandID.Text = "";
            txtAdm_AvilableQty.Text = "";
            txtAdm_ColorID.Text = "";
            txtAdm_DomainID.Text = "";
            txtAdm_ProductCatID.Text = "";
            txtAdm_ProductID.Text = "";
            txtAdm_DealerID.Text = "";
            lblSalesNo.Content = "";
            lblProcDate.Content = "";
            lblProducts.Content = "";
            lblProceNetAmt.Content = "";
            lblProcePrice.Content = "";
            txtPrice1.Text = "";
            txtQuantityF.Text = "";
            dtpFinalDate.Text = "";
            txtTotalPrice1.Text = "";
            txtpreroundoff1.Text = "";
            txtNetAmount1.Text = "";

            Final_PreProcurement();

            Salesid();
        }
        #endregion View FinalizePreProcurement Button Event

        #region FinalizePreprocurement Event
        private void txtQuantityF_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPrice1.Text == "")
            {
                //MessageBox.Show("Please Insert Price", caption, MessageBoxButton.OK);
                txtQuantityF.Text = 0.ToString();

            }
            else if (txtQuantityF.Text == "")
            {
                txtTotalPrice1.Text = txtPrice1.Text;
            }
            else if (txtPrice1.Text != "" && txtQuantityF.Text != "")
            {
                double tamt1;
                nfi = (NumberFormatInfo)nfi.Clone();
                nfi.CurrencySymbol = "";

                double prc = Convert.ToDouble(txtPrice1.Text);
                double qty = Convert.ToDouble(txtQuantityF.Text);
                double tamt = (prc * qty);
                txtTotalPrice1.Text = tamt.ToString();
                //  txtpreroundoff.Text = Math.Round(tamt).ToString();
                //roundoff Method
                if (txtTotalPrice1.Text.Trim().Length > 0)
                {
                    tamt1 = Convert.ToDouble(txtTotalPrice1.Text);
                }
                else
                {
                    tamt1 = 0;
                }
                double netAmt = Math.Round(tamt1);
                double roundDiff = netAmt - tamt1;
                double roundDiff1 = Math.Round(roundDiff, 2);

                txtNetAmount1.Text = String.Format(nfi, "{0:C}", Convert.ToDouble(netAmt));
                //txtRoundUp.Text = String.Format(nfi, "{0:C}", Convert.ToDouble(roundDiff));
                txtpreroundoff1.Text = Convert.ToString(roundDiff1);

            }
        }

        private void dtpFrom_View_FinalPreProcurement_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            View_Final_PreProcurement();
        }

        private void dtpTo_View_FinalPreProcurement_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            View_Final_PreProcurement();
        }

        private void txt_View_Filter_finalPreProcurement_TextChanged(object sender, TextChangedEventArgs e)
        {
            View_Final_PreProcurement();
        }
        #endregion FinalizePreprocurement Event
        #endregion FinalizePreprocurement Finction

        #region StockDetails Function
        public void StockDetails()
        {
            try
            {
                String str;
                //con.Open();
                DataSet ds = new DataSet();
                str = "SELECT P.[ID],P.[Domain_ID],P.[Product_ID],P.[Brand_ID],P.[P_Category],P.[Model_No_ID],P.[Color_ID],P.[Products123],P.[AvilableQty],P.[SaleQty],P.[NewQty],P.[FinalPrice] " +
                      ",DM.[Domain_Name],PM.[Product_Name], B.[Brand_Name] , PC.[Product_Category] ,MN.[Model_No] ,C.[Color] " +
                      //",PP.[Price] " +
                      "FROM [StockDetails] P " +
                      "INNER JOIN [tb_Domain] DM ON DM.[ID]=P.[Domain_ID] " +
                      "INNER JOIN [tlb_Products] PM ON PM.[ID]=P.[Product_ID] " +
                      "INNER JOIN [tlb_Brand] B ON B.[ID]=P.[Brand_ID] " +
                      "INNER JOIN [tlb_P_Category] PC ON PC.[ID]=P.[P_Category]" +
                      "INNER JOIN [tlb_Model] MN ON MN.[ID]=P.[Model_No_ID] " +
                      "INNER JOIN [tlb_Color] C ON C.[ID]=P.[Color_ID] " +
                      //"INNER JOIN [Pre_Products] PP ON PP.[Model_No_ID]=P.[Model_No_ID] " +
                      "WHERE ";

                if (txtAdm_Stock_Filter_Search_Price.Text.Trim() != "")
                {
                    str = str + "P.[FinalPrice] LIKE ISNULL('" + txtAdm_Stock_Filter_Search_Price.Text.Trim() + "',P.[FinalPrice]) + '%' AND ";
                }
                if (cmbAdm_StockFilter_Search.Text.Equals("Domain"))
                {
                    if (txtAdm_Stock_Filter_Search.Text.Trim() != "")
                    {
                        str = str + "DM.[Domain_Name] LIKE ISNULL('" + txtAdm_Stock_Filter_Search.Text.Trim() + "',DM.[Domain_Name]) + '%' AND ";
                    }
                }
                if (cmbAdm_StockFilter_Search.Text.Equals("Product Type"))
                {
                    if (txtAdm_Stock_Filter_Search.Text.Trim() != "")
                    {
                        str = str + "PM.[Product_Name] LIKE ISNULL('" + txtAdm_Stock_Filter_Search.Text.Trim() + "',PM.[Product_Name]) + '%' AND ";
                    }
                }
                if (cmbAdm_StockFilter_Search.Text.Equals("Brand"))
                {
                    if (txtAdm_Stock_Filter_Search.Text.Trim() != "")
                    {
                        str = str + "B.[Brand_Name] LIKE ISNULL('" + txtAdm_Stock_Filter_Search.Text.Trim() + "',B.[Brand_Name]) + '%' AND ";
                    }
                }
                if (cmbAdm_StockFilter_Search.Text.Equals("Product Category"))
                {
                    if (txtAdm_Stock_Filter_Search.Text.Trim() != "")
                    {
                        str = str + "PC.[Product_Category] LIKE ISNULL('" + txtAdm_Stock_Filter_Search.Text.Trim() + "',PC.[Product_Category]) + '%' AND ";
                    }
                }
                if (cmbAdm_StockFilter_Search.Text.Equals("Model"))
                {
                    if (txtAdm_Stock_Filter_Search.Text.Trim() != "")
                    {
                        str = str + "MN.[Model_No] LIKE ISNULL('" + txtAdm_Stock_Filter_Search.Text.Trim() + "',MN.[Model_No]) + '%' AND ";
                    }
                }
                if (cmbAdm_StockFilter_Search.Text.Equals("Color"))
                {
                    if (txtAdm_Stock_Filter_Search.Text.Trim() != "")
                    {
                        str = str + "C.[Color] LIKE ISNULL('" + txtAdm_Stock_Filter_Search.Text.Trim() + "',C.[Color]) + '%' AND ";
                    }
                }

                str = str + " P.[S_Status] = 'Active' ORDER BY P.[C_Date] ASC ";
                //str = str + " S_Status = 'Active' ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                dgvAdm_StockDetails.ItemsSource = ds.Tables[0].DefaultView;
                //}
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        #region StockDetails Button Event
        private void menu_stockDetails_Click(object sender, RoutedEventArgs e)
        {
            grd_View_StockDetails.Visibility = System.Windows.Visibility.Visible;
            StockDetails();
        }

        private void btn_View_StockDetails_Exit_Click(object sender, RoutedEventArgs e)
        {
            grd_View_StockDetails.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btn_View_Final_StockDetails_Refresh_Click(object sender, RoutedEventArgs e)
        {
            txtAdm_Stock_Filter_Search.Text = "";
            txtAdm_Stock_Filter_Search_Price.Text = "";
            //cmbAdm_StockFilter_Search.Text = "Select";
            StockDetails();
        }
        #endregion StockDetails Button Event

        #region StockDetails Event
        private void txtAdm_Stock_Filter_Search_Price_TextChanged(object sender, TextChangedEventArgs e)
        {
            StockDetails();
        }

        private void txtAdm_Stock_Filter_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            StockDetails();
        }

        private void grd_View_StockDetails_Loaded(object sender, RoutedEventArgs e)
        {
            StockDetails();
        }
        #endregion StockDetails Event
        #endregion StockDetails Function

        private void menu_EmployeeDetails_Click(object sender, RoutedEventArgs e)
        {
            grdAdm_EmployeeDetails.Visibility = System.Windows.Visibility.Visible;
        }

        private void hlAddProducts_Click(object sender, RoutedEventArgs e)
        {
            frmAddProducts obj = new frmAddProducts();
            obj.ShowDialog();
            if(obj.DialogResult == true)
            {
                if (dtstat.Rows.Count == 0)
                {
                    dtstat.Columns.Add("ID");
                    dtstat.Columns.Add("Product_Name");
                    dtstat.Columns.Add("Brand_Name");
                    dtstat.Columns.Add("Product_Category");
                    dtstat.Columns.Add("Model_No");
                    dtstat.Columns.Add("Color");
                    dtstat.Columns.Add("Price");
                }
                DataRow dr = dtstat.NewRow();
                dr["ID"] = obj.txtProductsID.Text;
                dr["Product_Name"] = obj.txtPRoductName.Text;
                dr["Brand_Name"] = obj.txtBrandName.Text;
                dr["Product_Category"] = obj.txtPRoductCategory.Text;
                dr["Model_No"] = obj.txtModelNo.Text;
                dr["Color"] = obj.txtColor.Text;
                dr["Price"] = obj.txtPrice.Text;

                dtstat.Rows.Add(dr);
                dgvFoll_AddProducts.ItemsSource = dtstat.DefaultView;
                dgvFoll_AddProducts.CanUserAddRows = false;
            }
            //obj.Show();
        }

        public void ProductID123(string piid)
        {
            txtProductID.Text = piid;
        }

        public void AddAllProducts_Details()
        {
            try
            {
                String str;
                //con.Open();
                DataSet ds = new DataSet();
                str = "SELECT P.[ID],P.[Domain_ID],P.[Product_ID],P.[Brand_ID],P.[P_Category],P.[Model_No_ID],P.[Color_ID],P.[Price] " +
                      ",DM.[Domain_Name],PM.[Product_Name], B.[Brand_Name] , PC.[Product_Category] ,MN.[Model_No] ,C.[Color] " +
                      "FROM [Pre_Products] P " +
                      "INNER JOIN [tb_Domain] DM ON DM.[ID]=P.[Domain_ID] " +
                      "INNER JOIN [tlb_Products] PM ON PM.[ID]=P.[Product_ID] " +
                      "INNER JOIN [tlb_Brand] B ON B.[ID]=P.[Brand_ID] " +
                      "INNER JOIN [tlb_P_Category] PC ON PC.[ID]=P.[P_Category]" +
                      "INNER JOIN [tlb_Model] MN ON MN.[ID]=P.[Model_No_ID] " +
                      "INNER JOIN [tlb_Color] C ON C.[ID]=P.[Color_ID] " +
                      "WHERE P.[ID]= '" + txtProductID.Text + "' AND P.[S_Status] = 'Active' ORDER BY PM.[Product_Name] ASC";
                
                //str = str + " P.[S_Status] = 'Active' ORDER BY PM.[Product_Name] ASC ";
                //str = str + " S_Status = 'Active' ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                dgvFoll_AddProducts.ItemsSource = ds.Tables[0].DefaultView;
                //}
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void GetMax_FollowUpID()
        {
            string sqlquery = "SELECT max(ID) as ID FROM tlb_FollowUp";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtMax_FolloupID.Text = dt.Rows[0]["ID"].ToString();
                txtFollowupID.Text = txtMax_FolloupID.Text.Trim();
            }
        }

        int i;

        public void FollowupProduct_SaveDetails()
        {
            if (dtstat.Rows.Count > 0)
            {
                for (i = 0; i < dtstat.Rows.Count; i++)
                {                    
                    balfollwproducts.Flag = 1;
                    balfollwproducts.FolloupProductID = Convert.ToInt32(txtFollowupID.Text);
                    balfollwproducts.FProductID = Convert.ToInt32(dtstat.Rows[i]["ID"].ToString());
                    balfollwproducts.S_Status = "Active";
                    balfollwproducts.C_Date = System.DateTime.Now.ToShortDateString();
                    dalfollow.FollwupProducts_Save_Insert_Update_Delete(balfollwproducts);
                    MessageBox.Show("Done");
                }
            }
            
            
        }


        private void btnSaleProductsFetch_Click(object sender, RoutedEventArgs e)
        {
            StockProducts sp = new StockProducts();
            sp.Show();
        }


        public void FollowUp_FillData()
        {
            try
            {
                con.Open();
                string sqlquery = "SELECT F.[ID],F.[EmployeeID],F.[Followup_ID],F.[FTitle] + ' ' + F.[FiratName] + ' ' + F.[LastName] AS [FollowupName],F.[Date_Of_Birth] " +
                                  ",F.[Mobile_No],F.[Phone_No],F.[SourceOfEnquiry],F.[Occupation],F.[AnnualRevenue],F.[Email_ID],F.[FaxNo],F.[Wbsite],F.[Street],F.[City],F.[State],F.[ZipNo],F.[Country],F.[Description],F.[F_Date] " +
                                  ",E.[EmployeeFirstName] + ' ' + E.[EmployeeLastName] AS [EmployeeName] " +
                                  "FROM [tlb_FollowUp] F " +
                                  "INNER JOIN [tbl_Employee] E ON E.[ID]=F.[EmployeeID] " +
                                  "where F.[ID]='" + txtFollowupID.Text + "' ";
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //leadinformation
                    txtFollowupViewID.Text = dt.Rows[0]["ID"].ToString();
                    lblFollow_upName.Content = dt.Rows[0]["FollowupName"].ToString();
                    lblLeadOwnerName.Content = dt.Rows[0]["EmployeeName"].ToString();
                    lblLeadOwnerPhNo.Content = dt.Rows[0]["Phone_No"].ToString();
                    lblLeadOwnerMbNo.Content = dt.Rows[0]["Mobile_No"].ToString();
                    lblFLeadName.Content = dt.Rows[0]["FollowupName"].ToString();
                    lblFLeadOwner.Content = dt.Rows[0]["EmployeeName"].ToString();
                    lblFPhoneNo.Content = dt.Rows[0]["Phone_No"].ToString();
                    lblFMobileNo.Content = dt.Rows[0]["Mobile_No"].ToString();
                    lblFDOB.Content = dt.Rows[0]["Date_Of_Birth"].ToString();
                    lblFLeadSource.Content = dt.Rows[0]["SourceOfEnquiry"].ToString();
                    lblFAnulRevenu.Content = dt.Rows[0]["AnnualRevenue"].ToString();
                    lblFEmail.Content = dt.Rows[0]["Email_ID"].ToString();
                    lblFFax.Content = dt.Rows[0]["FaxNo"].ToString();
                    lblFWebsite.Content = dt.Rows[0]["Website"].ToString();
                    lblFOccupation.Content = dt.Rows[0]["Occupation"].ToString();
                    //address information
                    lblFStreet.Content = dt.Rows[0]["Street"].ToString();
                    lblFCity.Content = dt.Rows[0]["City"].ToString();
                    lblFState.Content = dt.Rows[0]["State"].ToString();
                    lblFCountry.Content = dt.Rows[0]["Country"].ToString();
                    lblFZipCode.Content = dt.Rows[0]["ZipNo"].ToString();
                    //description
                    lblFDesctiption.Content = dt.Rows[0]["Description"].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            btnAdm_Emp_Save.Content = "Update";
        }

        private void btnFollowup_ViewInfor_Click(object sender, RoutedEventArgs e)
        {
            grd_LeadInformation.Visibility = System.Windows.Visibility.Visible;
            FollowUp_FillData();
        }

        private void btnFollowupBrowse_Click(object sender, RoutedEventArgs e)
        {
            var fd = new Microsoft.Win32.OpenFileDialog();
            //   fd.Filter = "*.jpeg";

            fd.Filter = "All image formats (*.jpg; *.jpeg; *.bmp; *.png; *.gif)|*.jpg;*.jpeg;*.bmp;*.png;*.gif";
            var ret = fd.ShowDialog();

            if (ret.GetValueOrDefault())
            {

                txtFollowup_PhotoPath.Text = fd.FileName;
                filepath = fd.FileName;

                try
                {
                    bmp = new BitmapImage(new Uri(fd.FileName, UriKind.Absolute));
                    imgWalkins.Source = bmp;
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid image file.", "Browse", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void btnFollowupSavePhoto(object sender, RoutedEventArgs e)
        {
            string imagepath = filepath.ToString();
            string picname = imagepath.Substring(imagepath.LastIndexOf('\\'));

            string path = AppDomain.CurrentDomain.BaseDirectory + '\\';
            if (!(System.IO.Directory.Exists(path)))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string path1 = path + "\\images\\WalkIns\\" + picname + ".JPG";
            ///
            using (System.IO.FileStream filestream = new System.IO.FileStream(Convert.ToString(path1), System.IO.FileMode.Create))
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                encoder.QualityLevel = 100;
                encoder.Save(filestream);
            }
            //MessageBox.Show("Image Successfully Saved :" + path + "'\'Image'\'" + picname);
            frmValidationMessage obj = new frmValidationMessage();
            obj.lblMessage.Content = "Image Save Successfully";
            obj.ShowDialog();


        }

        
        #region FollowupComments Function
        public void ViewAllComments_Details()
        {
            try
            {
                String str;
                //con.Open();
                DataSet ds = new DataSet();
                str = "SELECT [ID],[FollowupID],[Comments],[C_Date] FROM [tlb_FollowUpComments] WHERE [FollowupID]= '" + txtFollowupID.Text + "' AND [S_Status] = 'Active' ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                dgvFollowUp_Comments.ItemsSource = ds.Tables[0].DefaultView;
                //}
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public bool FollowupComments_Validation()
        {
            bool result = false;
            if (txtFollowupViewID.Text == "")
            {
                result = true;
                lblFValidation.Visibility = System.Windows.Visibility.Visible;
                lblFValidation.Foreground = Brushes.Red;
                lblFValidation.Content = "Please Select Follow-up Details";
            }
            else if (txtFComments.Text == "")
            {
                result = true;
                lblFValidation.Visibility = System.Windows.Visibility.Visible;
                lblFValidation.Foreground = Brushes.Red;
                lblFValidation.Content = "Please Enter Comments";
            }
            
            return result;
        }

        #region Followup Comments Button Event
        private void hlAddComments_Click(object sender, RoutedEventArgs e)
        {
            grdFollup_Comments.Visibility = System.Windows.Visibility.Visible;
            ViewAllComments_Details();
            dgvFollowUp_Comments.CanUserAddRows = false;
        }

        private void btnFComments_Save_Click(object sender, RoutedEventArgs e)
        {
            if (FollowupComments_Validation() == true)
                return;

            try
            {
                balfollwpcomt.Flag = 1;
                balfollwpcomt.FollowupId = Convert.ToInt32(txtFollowupViewID.Text);
                balfollwpcomt.Comments = lblwalkin.Content.ToString();
                balfollwpcomt.S_Status = "Active";
                balfollwpcomt.C_Date = System.DateTime.Now.ToString();
                dalfollowcomt.AddComments_Insert_Update_Delete(balfollwpcomt);
                lblFValidation.Visibility = System.Windows.Visibility.Visible;
                lblFValidation.Foreground = Brushes.Green;
                lblFValidation.Content = "Data Save Successfully";
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            ViewAllComments_Details();
            txtFComments.Text = "";
        }

        private void btnFComments_Cancel_Click(object sender, RoutedEventArgs e)
        {
            grdFollup_Comments.Visibility = System.Windows.Visibility.Hidden;
            //ViewAllComments_Details();
            txtFComments.Text = "";
        }
        #endregion Followup Comments Button Event
        #endregion FollowupComments Function

        #region FollowupActivity Function
        public void ViewAllActivity_Details()
        {
            try
            {
                String str;
                //con.Open();
                DataSet ds = new DataSet();
                str = "SELECT [ID],[FollowupID],[ASubject],[ADate],[AEmployeeID],[ANotes] FROM [tlb_FollowUpActivity] WHERE [FollowupID]= '" + txtFollowupViewID.Text + "' AND [S_Status] = 'Active' ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                dgvFollowUp_Activities.ItemsSource = ds.Tables[0].DefaultView;
                //}
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void ActivityClear()
        {
            cmbFASubject.Text = "-None-";
            dtpFADate.Text = "";
            cmbFALeadOwner.SelectedItem = null;
            txtFANote.Text = "";
        }

        public bool FollowupActivity_Validation()
        {
            bool result = false;
            if (cmbFASubject.Text == "-None-")
            {
                result = true;
                lblFAValidation.Visibility = System.Windows.Visibility.Visible;
                lblFAValidation.Foreground = Brushes.Red;
                lblFAValidation.Content = "Please Select Subject";
            }
            else if(dtpFADate.Text == "")
            {
                result = true;
                lblFAValidation.Visibility = System.Windows.Visibility.Visible;
                lblFAValidation.Foreground = Brushes.Red;
                lblFAValidation.Content = "Please Select Date";
            }
            else if(cmbFALeadOwner.SelectedValue == null)
            {
                result = true;
                lblFAValidation.Visibility = System.Windows.Visibility.Visible;
                lblFAValidation.Foreground = Brushes.Red;
                lblFAValidation.Content = "Please Select Lead Owner";
            }
            return result;
        }

        private void btnFA_ActivitySave_Click(object sender, RoutedEventArgs e)
        {
            if (FollowupActivity_Validation() == true)
                return;

            try
            {
                balfollwpcomt.Flag = 1;
                balfollwpcomt.FollowupId = Convert.ToInt32(txtFollowupViewID.Text);
                balfollwpcomt.ASubject = cmbFASubject.Text;
                balfollwpcomt.ADate = dtpFADate.Text;
                balfollwpcomt.AEmployeeID = cmbFALeadOwner.SelectedValue.GetHashCode();
                balfollwpcomt.ANotes = txtFANote.Text;
                balfollwpcomt.S_Status = "Active";
                balfollwpcomt.C_Date = System.DateTime.Now.ToString();
                dalfollowcomt.AddActivity_Insert_Update_Delete(balfollwpcomt);
                lblFAValidation.Visibility = System.Windows.Visibility.Visible;
                lblFAValidation.Foreground = Brushes.Green;
                lblFAValidation.Content = "Data Save Successfully";
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            ViewAllActivity_Details();
            ActivityClear();
        }

        private void btnFA_ActivityCancel_Click(object sender, RoutedEventArgs e)
        {
            grdFollup_Activity.Visibility = System.Windows.Visibility.Hidden;
            ActivityClear();
        }

        private void hlAddAcivities_Click(object sender, RoutedEventArgs e)
        {
            grdFollup_Activity.Visibility = System.Windows.Visibility.Visible;
            dgvFollowUp_Activities.CanUserAddRows = false;
        }
        #endregion FollowupActivity Function

        
        private void btnFA_Attached_Click(object sender, RoutedEventArgs e)
        {
            
            //string filename = txt1.Text;
            //if (File.Exists(filename))
            //{
            //    // TODO: Show an error message box to user indicating destination file already uploaded
            //    return;
            //}

            ////string name = Path.GetFileName(filename);
            ////string destinationFilename = Path.Combine("C:\\temp\\uploaded files\\", name);

            //string path = AppDomain.CurrentDomain.BaseDirectory + '\\';
            //if (!(System.IO.Directory.Exists(path)))
            //{
            //    System.IO.Directory.CreateDirectory(path);
            //}
            //string path1 = path + "\\images\\WalkIns\\" + txt1 +".txt";

            //File.Copy(filename, path);


            //////////string imagepath = txt1.ToString();
            //////////string picname = imagepath.Substring(imagepath.LastIndexOf('\\'));

            //////////string path = AppDomain.CurrentDomain.BaseDirectory + '\\';
            //////////if (!(System.IO.Directory.Exists(path)))
            //////////{
            //////////    System.IO.Directory.CreateDirectory(path);
            //////////}
            //////////string path1 = path + "\\images\\FAttachmentFiles\\" + picname + ".docx";
            ///////////////
            //////////using (System.IO.FileStream filestream = new System.IO.FileStream(Convert.ToString(path1), System.IO.FileMode.))
            //////////{
            ////////////    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            ////////////    encoder.Frames.Add(BitmapFrame.Create(bmp));
            ////////////    encoder.QualityLevel = 100;
            ////////////    encoder.Save(filestream);
            //////////    //System.IO.Directory.CreateDirectory(path1);


            //////////}
            //File.Copy(imagepath, path);
            //MessageBox.Show("Image Successfully Saved :" + path + "'\'Image'\'" + picname);
            //frmValidationMessage obj = new frmValidationMessage();
            //obj.lblMessage.Content = "Image Save Successfully";
            //obj.ShowDialog();

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            //dlg.FileName = "Document"; // Default file name
            string imagepath = txt1.ToString();
            dlg.FileName = txt1.Text;
            string picname = imagepath.Substring(imagepath.LastIndexOf('\\'));
            string path = AppDomain.CurrentDomain.BaseDirectory + '\\';
            dlg.DefaultExt = ".text"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension 

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results 
            if (result == true)
            {
    // Save document 
                string filename = dlg.FileName;
                string path1 = path + "\\images\\FAttachmentFiles\\" + filename + ".docx";
            }
        }

        private void btnFA_AttachChoose_Click(object sender, RoutedEventArgs e)
        {
            //var fd = new Microsoft.Win32.OpenFileDialog();
            ////   fd.Filter = "*.jpeg";

            //fd.Filter = "All doc formats (*.docx; *.pdf; *.txt)|*.docx;*.pdf;*.txt";
            //var ret = fd.ShowDialog();

            //if (ret.GetValueOrDefault())
            //{

            //    //txtFollowup_PhotoPath.Text = fd.FileName;
            //    //filepath = fd.FileName;

            //    //try
            //    //{
            //        //string abc = new Document (new Uri(fd.FileName, UriKind.Absolute));
            //        //rtbAllDoc.Document = abc;
                         
            //    //}
            //    //catch (Exception)
            //    //{
            //    //    MessageBox.Show("Invalid image file.", "Browse", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //    //}
            //}

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "All doc formates (*.docx; *.pdf; *.txt)|*.docx;*.pdf;*.txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                txt1.Text = filename;
            }

            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Multiselect = true;
            //openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //if (openFileDialog.ShowDialog() == true)
            //{
            //    foreach (string filename in openFileDialog.FileNames)
            //        //lbFiles.Items.Add(Path.GetFileNFame(filename));
            //         string filename = openFileDialog.FileName;
            //         txt1.Text = filename;

            //}

        }

        private void btnViewInfo_Close_Click(object sender, RoutedEventArgs e)
        {
            grd_LeadInformation.Visibility = System.Windows.Visibility.Hidden;
        }

       
  }
}
