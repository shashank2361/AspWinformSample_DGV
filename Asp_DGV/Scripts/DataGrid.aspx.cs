using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp_DGV.Scripts
{
    public partial class DataGrid : System.Web.UI.Page
    {

        protected void ColorSelector_IndexChanged(object sender, EventArgs e)
        {
            form1.Style["background-color"] = ColorSelector.SelectedValue;
            HttpCookie cookie = new HttpCookie("BackgroundColor");
            cookie.Value = ColorSelector.SelectedValue;
            cookie.Expires = DateTime.Now.AddHours(1);
            Response.SetCookie(cookie);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MyUserInfoBoxControl.UserName = "Jane Doe";
            MyUserInfoBoxControl.UserAge = 33;
            MyUserInfoBoxControl.UserCountry = "Germany";


            if (Request.Cookies["BackgroundColor"] != null)
            {
                ColorSelector.SelectedValue = Request.Cookies["BackgroundColor"].Value;
                form1.Style["background-color"] = ColorSelector.SelectedValue;
            }





            if (!IsPostBack)
                rtnInitialization();
        }

        private void rtnInitialization()
        {
            HelloWorldLabel.Text = "My label";
            UserInfoBoxControl userInfoBoxControl = (UserInfoBoxControl)LoadControl("~/UserInfoBoxControl.ascx");
            userInfoBoxControl.UserName = "John Doe";
            userInfoBoxControl.UserAge = 78;
            userInfoBoxControl.UserCountry = "Spain";
            phUserInfoBox.Controls.Add(userInfoBoxControl);


            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SELECT BusinessEntityId, FirstName  FROM Person.Person"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    connection.Open();
                    ddlperson.DataSource = cmd.ExecuteReader();
                    ddlperson.DataTextField = "FirstName";
                    ddlperson.DataValueField = "BusinessEntityId";
                    ddlperson.DataBind();
                }
                connection.Close();
            }

            string sql = "SELECT Top 10 Persontype, FirstName,LastName from Person.Person";
         
            GridView1.DataSource = this.GetData(sql);
            GridView1.DataBind();


            // phUserInfoBox.Controls.Add(LoadControl("~/UserInfoBoxControl.ascx"));

        }


        private DataTable GetData(string sql)
        {
            string constr = ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.Connection = con;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HelloWorldLabel.Text = "Hello, " + TextInput.Text;

        }

        protected void GreetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            HelloWorldLabel.Text = "Hello, " + GreetList.SelectedValue;
        }

        protected void MyEventUserControl_PageTitleUpdated(object sender, EventArgs e)
        {
            this.Title = MyEventUserControl.PageTitle;
        }

        protected void btnSubmitForm_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                btnSubmitForm.Text = "My form is valid!";
            }
        }

        protected void ddlperson_IndexChanged(object sender, EventArgs e)
        {
            TextInput.Text = ddlperson.SelectedItem.ToString();
        }
    }
}