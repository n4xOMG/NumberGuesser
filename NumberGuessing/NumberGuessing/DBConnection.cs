using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberGuessing
{
    public class DBConnection
    {
        SqlConnection conn = new SqlConnection(NumberGuessing.Properties.Settings.Default.cnnStr);
        public DataTable LoadList(string sqlStr)
        {
            DataTable dtUser = new DataTable();
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                adapter.Fill(dtUser);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
            return dtUser;

        }
        public void Process(string sqlStr)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    //MessageBox.Show("Process successed");
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Process failed" + ex);
            }
            finally
            {
                conn.Close();
            }
        }
        public int GetID(string sqlStr)
        {
            int newGameID = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                newGameID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Process failed" + ex);
            }
            finally
            {
                conn.Close();
            }
            return newGameID;
        }
    }
}
