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
    public partial class BindDDLinlistview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                rtnInitialization();
        }

        private void rtnInitialization()
        {
            ViewState["dtDepartments"] = null;

             
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(" SELECT top 10 NationalIdNumber, JobTitle , HumanResources.Department.Name  FROM   HumanResources.Employee Inner Join HumanResources.EmployeeDepartmentHistory   ON  HumanResources.Employee.BusinessEntityId = HumanResources.EmployeeDepartmentHistory.BusinessEntityId   Inner Join HumanResources.Department on HumanResources.Department.DepartmentID =   HumanResources.EmployeeDepartmentHistory.DepartmentID"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.Connection = connection;
                        sda.Fill(dt);
                        ListView1.DataSource = dt;
                        ListView1.DataBind();
                      //  ViewState["dtDepartments"] = dt;
                        dtDepartments = dt;


                    }

                    //cmd.CommandType = CommandType.Text;
                    //cmd.Connection = connection;
                    //connection.Open();
                    // ListView1.DataSource = cmd.ExecuteReader();
                    // ListView1.DataBind();
                }
            }
        }
        protected void OnItemEditing(object sender, ListViewEditEventArgs e)
        {
            ListView1.EditIndex = e.NewEditIndex;
            rtnInitialization();
        }
     

        private DataTable dtDepartments
 
        {
            get { return ViewState["dtDepartments"] != null ? (DataTable)ViewState["dtDepartments"] : null; }
            set { ViewState["dtDepartments"] = value; }
        }
   
       

        protected void OnItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            string nino =     (ListView1.Items[e.ItemIndex].FindControl("lblNationalIdNumber") as Label).Text;
            string department = (ListView1.Items[e.ItemIndex].FindControl("ddlDepartment") as DropDownList).SelectedItem.Value;
            string departmen1t = (ListView1.Items[e.ItemIndex].FindControl("ddlDepartment") as DropDownList).SelectedValue.ToString();

            //DataTable dtd = (DataTable)ViewState["dtDepartments"];
            DataTable dtd = dtDepartments;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
            foreach (DataRow row in dtd.Rows)
            {
                if (row["NationalIdNumber"].ToString() == nino)
                {
                    row["Name"] = departmen1t;

                    SqlCommand cmd = new SqlCommand("SELECT BusinessEntityId From  HumanResources.Employee Where NationalIdNumber  = '" + nino +  " '", connection);
                    connection.Open();
                    var businessEntityId = cmd.ExecuteScalar().ToString();
                     
                    cmd = new SqlCommand("update HumanResources.EmployeeDepartmentHistory set DepartmentId='" + department + "'      where BusinessEntityId ='" + Convert.ToInt32(businessEntityId) + "'", connection);
                    cmd.ExecuteNonQuery();
                    break;
                }
            }


            ListView1.EditIndex = -1;
            rtnInitialization();
        }

        protected void OnItemCanceling(object sender, ListViewCancelEventArgs e)
        {

        }



        protected void OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (ListView1.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {

                DropDownList ddlDepartment = (e.Item.FindControl("ddlDepartment") as DropDownList);

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
                    ddlDepartment.Items.Insert(0, new ListItem("Select Name", "0"));
                    Label lblName = (e.Item.FindControl("lblName") as Label);
                    lblName.Text = ddlDepartment.SelectedItem.ToString();
                    
              //      ddlDepartment.Items.FindByValue(lblName.Text).Selected = true;
                    connection.Close();
                }
            }

        }
         protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}