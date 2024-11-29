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
    public partial class StudentList : System.Web.UI.Page
    {
        Concls conobj = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridBind_fun();
            }
        }
        public void GridBind_fun()
        {
           string query = "SELECT Student_firstname, Student_lastname,Age,DOB,Gender,Email_id,Phone_number FROM tb_StudentReg Where Student_id=" + Session["uid"] + "";

            DataSet ds =conobj.Fn_DataSet(query);
            
            GridView1.DataSource = ds;
            GridView1.DataBind();
              
        }
    }
}