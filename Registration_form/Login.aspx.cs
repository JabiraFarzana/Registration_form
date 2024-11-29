using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Registration_form
{
    public partial class Login : System.Web.UI.Page
    {
        Concls conobj = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select count(Student_id) from tb_StudentReg  where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
            string cid = conobj.Fn_Scalar(s);
            if (cid == "1")
            {
                int id1 = 0;
                string str = "select Student_id from tb_StudentReg where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                SqlDataReader dr = conobj.Fn_Reader(str);
                while (dr.Read())
                {
                    id1 = Convert.ToInt32(dr["Student_id"].ToString());
                }

                Session["uid"] = id1;
                Response.Redirect("StudentList.aspx");
            }
        }
    }
}