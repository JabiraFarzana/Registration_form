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
    public partial class RegForm : System.Web.UI.Page
    {
        Concls conobj = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.Visible = false;
            }
        }  

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strins = "Insert into tb_StudentReg values('" + TextBox1.Text + "','" + TextBox2.Text + "'," + TextBox3.Text + ",'" + TextBox4.Text + "', '" + RadioButtonList1.SelectedValue + "','" + TextBox5.Text + "'," + TextBox6.Text + ",'" + TextBox7.Text + "','" + TextBox8.Text + "')";
            int i = conobj.Fn_Nonquery(strins);

            if (i == 1)
            {

                string selectStudentId = "SELECT IDENT_CURRENT('tb_StudentReg')";
                int studentId = Convert.ToInt32(conobj.Fn_Scalar(selectStudentId));

                foreach (GridViewRow row in GridView1.Rows)
                {
                    string courseName = row.Cells[0].Text;
                    string university = row.Cells[1].Text;
                    int year = int.Parse(row.Cells[2].Text);
                    decimal percentage = decimal.Parse(row.Cells[3].Text);

                    string insert = "Insert into tb_Qualification values(" + studentId + ",'" + TextBox12.Text + "','" + TextBox9.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "')";
                    int j = conobj.Fn_Nonquery(insert);

                    Label15.Text = "Successfully Inserted";
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var courseName = TextBox12.Text;
            var university = TextBox9.Text;
            var year = TextBox10.Text;
            var percentage= TextBox11.Text;

            GridView1.Visible = true;
            var dt = (GridView1.DataSource as System.Data.DataTable) ?? new System.Data.DataTable();
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Course");
                dt.Columns.Add("University");
                dt.Columns.Add("Year");
                dt.Columns.Add("Percentage");
            }

            dt.Rows.Add(courseName, university, year, percentage);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}