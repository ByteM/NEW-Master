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
    public  class DAL_CreateCampaign
    {
        public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConstCRM"].ToString());
        SqlCommand cmd;

        public int CreateCampaign_Insert_Update_Delete(BAL_CreateCampaign bcreatecamp)
        {
            try
            {

                con.Open();
                cmd = new SqlCommand("SP_CreateCampaign", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Flag", 1);
                cmd.Parameters.AddWithValue("@CampaignName", bcreatecamp.CampaignName);
                cmd.Parameters.AddWithValue("@CampaignType", bcreatecamp.CampaignType);
                cmd.Parameters.AddWithValue("@StartDate", bcreatecamp.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bcreatecamp.EndDate);
                cmd.Parameters.AddWithValue("@ExpectedRevenue", bcreatecamp.ExpectedRevenue);
                cmd.Parameters.AddWithValue("@BudgetedCost", bcreatecamp.BudgetedCost);
                cmd.Parameters.AddWithValue("@ActualCost", bcreatecamp.ActualCost);
                cmd.Parameters.AddWithValue("@ExpectedResponse", bcreatecamp.ExpectedResponse);
                cmd.Parameters.AddWithValue("@Description", bcreatecamp.Description);
                cmd.Parameters.AddWithValue("@S_Status", bcreatecamp.S_Status);
                cmd.Parameters.AddWithValue("@C_Date", bcreatecamp.C_Date);
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
