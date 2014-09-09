using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CRM_BAL;

namespace CRM_DAL
{
    public class DAL_Followup
    {
        public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConstCRM"].ToString());
        SqlCommand cmd;

        public int Follwup_Save_Insert_Update_Delete(BAL_Followup balfp)
        {
            try
            {

                con.Open();
                cmd = new SqlCommand("SP_Followup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Flag", 1);
                cmd.Parameters.AddWithValue("@EmployeeID", balfp.EmployeeID);
                cmd.Parameters.AddWithValue("@Followup_ID", balfp.Followup_ID);
                cmd.Parameters.AddWithValue("@FTitle", balfp.FTitle);
                cmd.Parameters.AddWithValue("@FiratName", balfp.FiratName);
                cmd.Parameters.AddWithValue("@LastName", balfp.LastName);
                cmd.Parameters.AddWithValue("@Date_Of_Birth", balfp.Date_Of_Birth);
                cmd.Parameters.AddWithValue("@Mobile_No", balfp.Mobile_No);
                cmd.Parameters.AddWithValue("@PhoneNo", balfp.PhoneNo);
                cmd.Parameters.AddWithValue("@SourceOfEnquiry", balfp.SourceOfEnquiry);
                cmd.Parameters.AddWithValue("@SourceEnquiryID", balfp.SourceOfEnquiryID);
                cmd.Parameters.AddWithValue("@Occupation", balfp.Occupation);
                cmd.Parameters.AddWithValue("@AnnualRevenue", balfp.AnnualRevenue);
                cmd.Parameters.AddWithValue("@Email_ID", balfp.Email_ID);
                cmd.Parameters.AddWithValue("@FaxNo", balfp.FaxNo);
                cmd.Parameters.AddWithValue("@Wbsite", balfp.Wbsite);
                cmd.Parameters.AddWithValue("@Street", balfp.Street);
                cmd.Parameters.AddWithValue("@City", balfp.City);
                cmd.Parameters.AddWithValue("@State", balfp.State);
                cmd.Parameters.AddWithValue("@ZipNo", balfp.ZipNo);
                cmd.Parameters.AddWithValue("@Country", balfp.Country);
                cmd.Parameters.AddWithValue("@Description", balfp.Description);
                cmd.Parameters.AddWithValue("@F_Date", balfp.F_Date);
                cmd.Parameters.AddWithValue("@S_Status", balfp.S_Status);
                cmd.Parameters.AddWithValue("@C_Date", balfp.C_Date);
                int i = cmd.ExecuteNonQuery();
                return i;


            }
            catch (Exception)
            {

                throw;
            }
            finally { con.Close(); }
        }

        public int FollwupProducts_Save_Insert_Update_Delete(BAL_FollowUp_Products balfproduct)
        {
            try
            {

                con.Open();
                cmd = new SqlCommand("SP_FollowUpProducts", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Flag", 1);
                cmd.Parameters.AddWithValue("@FolloupProductID", balfproduct.FolloupProductID);
                cmd.Parameters.AddWithValue("@FProductID", balfproduct.FProductID);
                cmd.Parameters.AddWithValue("@S_Status", balfproduct.S_Status);
                cmd.Parameters.AddWithValue("@C_Date", balfproduct.C_Date);
                int i = cmd.ExecuteNonQuery();
                return i;
            }
            catch (Exception)
            {

                throw;
            }
            finally { con.Close(); }
        }
    }
}
