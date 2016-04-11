using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.Web.Services;

public partial class SignUp : System.Web.UI.Page
{
    private readonly SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        var cmd = new SqlCommand("SELECT * FROM tblUser", _con);
        var da = new SqlDataAdapter(cmd);
        var dt = new DataTable();
        _con.Open();
        cmd.ExecuteNonQuery();
        da.Fill(dt);
        gvUsers.DataSource = dt;
        gvUsers.DataBind();
        _con.Close();
    }

    [WebMethod]
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
                if (cmd.ExecuteNonQuery() > 0)
                    return "Inserted";
                else
                    return "Not Inserted";
                conn.Close();
            }
        }
    }

    [WebMethod]
    public static bool CheckUsername(string Username)
    {
        string constr = ConfigurationManager.ConnectionStrings["con"].ToString();
        using (var conn = new SqlConnection(constr))
        {
            var cmd = new SqlCommand
            {
                Connection = conn,
                CommandText = "SELECT COUNT(*) FROM tblUser WHERE username=@USERNAME",
                CommandType = CommandType.Text
            };

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