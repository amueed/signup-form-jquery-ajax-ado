using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.Script.Services;

public partial class SignUp : System.Web.UI.Page
{

    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
    
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblUser", conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        conn.Open();
        cmd.ExecuteNonQuery();
        da.Fill(dt);
        gvUsers.DataSource = dt;
        gvUsers.DataBind();
        conn.Close();
    }

    [WebMethod]
    [ScriptMethod]

    public static string InsertData(string Fname, string Lname, string Gender, string Address, string Email, string Username, string Password)
    {
        string constr = ConfigurationManager.ConnectionStrings["con"].ToString();
        using (SqlConnection conn = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("INSERT INTO tblUser(fname, lname, gender, address, email, username, password) VALUES(@FNAME, @LNAME, @GENDER, @ADDRESS, @EMAIL, @USERNAME, @PASSWORD);", conn))
            {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@FNAME", Fname);
                    cmd.Parameters.AddWithValue("@LNAME", Lname);
                    cmd.Parameters.AddWithValue("@GENDER", Gender);
                    cmd.Parameters.AddWithValue("@ADDRESS", Address);
                    cmd.Parameters.AddWithValue("@EMAIL", Email);
                    cmd.Parameters.AddWithValue("@USERNAME", Username);
                    cmd.Parameters.AddWithValue("@PASSWORD", Password);
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                        return "Inserted";
                    else
                        return "Not Inserted";
                    conn.Close();
                    
  
            }
        }
    }

    [WebMethod]
    [ScriptMethod]

    public static bool CheckUsername(string Username)
    {
        string constr = ConfigurationManager.ConnectionStrings["con"].ToString();
        using (SqlConnection conn = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblUser WHERE username=@USERNAME;", conn))
            {

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@USERNAME", Username);
                conn.Open();
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                conn.Close();

            }
        }
    }
}