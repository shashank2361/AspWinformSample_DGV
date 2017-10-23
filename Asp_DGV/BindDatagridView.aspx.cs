using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp_DGV
{
    public partial class BindDatagridView : System.Web.UI.Page
    {
        private DataTable dtDepartments;

        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                    rtnInitialization();
            }
        }

        private void rtnInitialization()
        {
            DataTable dtD = dtDepartments;
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(" SELECT top 10 NationalIdNumber, JobTitle ,  MaritalStatus, Birthdate,SalariedFlag ,HumanResources.Department.Name  FROM   HumanResources.Employee Inner Join HumanResources.EmployeeDepartmentHistory   ON  HumanResources.Employee.BusinessEntityId = HumanResources.EmployeeDepartmentHistory.BusinessEntityId   Inner Join HumanResources.Department on HumanResources.Department.DepartmentID =   HumanResources.EmployeeDepartmentHistory.DepartmentID"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.Connection = connection;
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        ViewState["dtDepartments"] = dt;
                        dtD = dt;

                    }

                    //cmd.CommandType = CommandType.Text;
                    //cmd.Connection = connection;
                    //connection.Open();
                    // ListView1.DataSource = cmd.ExecuteReader();
                    // ListView1.DataBind();
                }
            }
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState & DataControlRowState.Edit) > 0))
            {


                DropDownList ddlDepartment = (DropDownList)(e.Row.FindControl("ddlDepartment"));
                DataRowView drv = e.Row.DataItem as DataRowView;
               

                // DropDownList ddlDepartment = (e.Row.FindControl("ddlDepartment") as DropDownList);

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT DepartmentID , Name  FROM HumanResources.Department"))
                    {
                        connection.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = connection;
                        ddlDepartment.DataSource = cmd.ExecuteReader();
                        ddlDepartment.DataTextField = "Name";
                        ddlDepartment.DataValueField = "DepartmentId";
                        ddlDepartment.DataBind();
                    }
                       ddlDepartment.Items.Insert(0, new ListItem("Select Department ", "0"));
                         ddlDepartment.Items.FindByText(drv[5].ToString()).Selected = true;

                    //ddlDepartment.SelectedValue =  drv[5].ToString();
                    //Label lblName = (e.Row.FindControl("lblName") as Label);
                    //lblName.Text = ddlDepartment.SelectedItem.ToString();
                    RadioButtonList rblMaritalstatus = (RadioButtonList)(e.Row.FindControl("rblMaritalstatus"));
                    rblMaritalstatus.SelectedValue = drv[2].ToString();

                    CheckBox  chkSalaried = (CheckBox )(e.Row.FindControl("chkSalaried"));
                    chkSalaried.Checked = Convert.ToBoolean(drv[4].ToString());

             
                    TextBox txtBirthdate = (TextBox)(e.Row.FindControl("txtBirthdate"));
                    txtBirthdate.Text = drv[3].ToString();


                    //      ddlDepartment.Items.FindByValue(lblName.Text).Selected = true;
                    connection.Close();
                }
            }

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            rtnInitialization();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
             GridView1.EditIndex = e.NewEditIndex;
            // GridView1.EditIndex = -1;
            rtnInitialization();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            Label lblNationalIdNumber = (Label)GridView1.Rows[e.RowIndex].FindControl("lblNationalIdNumber");
            DropDownList ddlDepartment = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlDepartment");
            RadioButtonList rblMaritalstatus =   (RadioButtonList)GridView1.Rows[e.RowIndex].FindControl("rblMaritalstatus");
            CheckBox chkSalaried = (CheckBox)GridView1.Rows[e.RowIndex].FindControl("chkSalaried");
            TextBox txtJobTitle = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtJobTitle");

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT BusinessEntityId From  HumanResources.Employee Where NationalIdNumber  = '" + lblNationalIdNumber.Text + " '", connection);
                 
                var businessEntityId = cmd.ExecuteScalar().ToString();
                 
                using ( SqlCommand cmd1 = new SqlCommand("update HumanResources.EmployeeDepartmentHistory " +
                    "set DepartmentId='" + ddlDepartment.SelectedValue +
                    "'      where BusinessEntityId ='" + Convert.ToInt32(businessEntityId) + "'",connection))
                {
                    cmd1.ExecuteNonQuery();
                    
                }
            }
            GridView1.EditIndex = -1;
            rtnInitialization();
        }
    }
}