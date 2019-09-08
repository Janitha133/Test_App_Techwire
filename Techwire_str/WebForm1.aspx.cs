using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_SITE;
using RFF_SITE_;
using System.Data;
using System.Data.SqlClient;

namespace Techwire_str
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        public string _str;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["uid"]))
                {
                    LoadRow(Request.QueryString["uid"]);
                }

                if (!String.IsNullOrEmpty(Request.QueryString["Dlt_uid"]))
                {
                    //Delete_User(Request.QueryString["Dlt_uid"]);
                    //string sa = Request.QueryString["Dlt_uid"];
                }

                LoadTable();
                getCar();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                REF_Client oREF_Client = new REF_Client();

                oREF_Client.CLIENT_ID = Convert.ToInt32(TextBox1.Text);
                oREF_Client.CLIENT_NAME = TextBox2.Text;
                oREF_Client.CAR_NAME = DropDownList1.SelectedValue.ToString();
                oREF_Client.DATE = Date1.Value;

                BL_Client oBL_Client = new BL_Client();

                oBL_Client.Insert(oREF_Client, null);

                //saved
                LoadTable();

            }
            catch (Exception ex)
            {
                //pls try again
                Label1.Text = ex.Message.ToString();
            }
        }

        protected void LoadTable()
        {
            BL_Client oBL_Client = new BL_Client();
            DataTable dt = oBL_Client.Select(null);

            try
            {
                //display table
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        _str = _str + "<tr>" +

                           "<td>" + dt.Rows[i]["CLIENT_ID"].ToString() + "</td>" +
                           "<td>" + dt.Rows[i]["CLIENT_NAME"].ToString() + "</td>" +
                           "<td>" + dt.Rows[i]["CAR_NAME"].ToString() + "</td>" +
                           "<td>" + dt.Rows[i]["DATE"].ToString() + "</td>" +
                           "<td><a href='WebForm1.aspx?uid=" + dt.Rows[i]["CLIENT_ID"].ToString() + "'>edit</a></td>" +
                           "<td><a href='WebForm1.aspx?Dlt_uid=" + dt.Rows[i]["CLIENT_ID"].ToString() + "'>delete</a></td>" +
                           "</tr>";
                    }
                }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message.ToString();
            }
        }

        protected void LoadRow(string _uid)
        {
            BL_Client oBL_Client = new BL_Client();
            DataTable dt = oBL_Client.SelectOne(_uid, null);

            try
            {
                //display table
                if (dt.Rows.Count > 0)
                {
                    TextBox1.Text = dt.Rows[0]["CLIENT_ID"].ToString();
                    TextBox2.Text = dt.Rows[0]["CLIENT_NAME"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["CAR_NAME"].ToString();
                    Date1.Value = dt.Rows[0]["DATE"].ToString();
                }

            }
            catch (Exception ex)
            {

                Label1.Text = ex.Message.ToString();
            }
        }

        protected void getCar()
        {
            BL_Client oBL_Client = new BL_Client();
            DataTable dt = oBL_Client.SelectCar(null);

            try
            {
                if(dt.Rows.Count != 0)
                {
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataTextField = "CAR_NAME";
                    DropDownList1.DataValueField = "CAR_NAME";
                    DropDownList1.DataBind();
                }

            }
            catch (Exception ex)
            {
                //pls try again
                Label1.Text = ex.Message.ToString();
            }
        }
    }
}