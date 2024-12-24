using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class frmChangePassword : System.Web.UI.Page
    {
        General Gen = new General();
        DataRetrivalClass Objret = new DataRetrivalClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/LoginReg.aspx");
            }
            UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
            ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

            if (!IsPostBack)
            {
                FillCapctha();
                txtuserName.Text = ObjLoginvo.username;
            }
            lbluserid.Text = ObjLoginvo.user_id;
            //chkpwd();
        }


        protected void btnOrgLookup_Click(object sender, EventArgs e)
        {

        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            CAFClass objCAFClass = new CAFClass();
            UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
            ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

            //String UserID = "", Password = "", Newpassword = "";
            //int retval = 0;
            if (ViewState["captcha"].ToString() != txtCaptcha.Text.Trim().TrimStart())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid Captcha Code !!.');", true);
                FillCapctha();
                lblmsg.Text = "Invalid Captcha Code !!.";
                success.Visible = false;
                Failure.Visible = true;
                txtCaptcha.Text = "";
                return;
            }
            //else if (txtuserName.Text.TrimStart().TrimEnd() == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter User Name !!.');", true);
            //    return;
            //}

            if (BtnSave1.Text == "Submit")
            {
                if (txtPwd.Text.Trim() != TxtNpwd.Text.Trim())
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('New Password and Confirm Password should be same.');", true);
                    lblmsg.Text = "New Password and Confirm Password should be same";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }


                string strStatus = string.Empty;
                string encpassword = Objret.Encrypt(txtPwd.Text.Trim().TrimStart(), "SYSTIME");
                strStatus = Objret.UpdatePasswordAfterLogin(encpassword, ObjLoginvo.user_id, txtuserName.Text.Trim().TrimStart());
                if (strStatus == "Success")
                {
                    ObjLoginvo.username = txtuserName.Text.Trim().TrimStart();
                    Session["ObjLoginvo"] = ObjLoginvo;
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password Successfully Changed.Please login again with new passwod');", true);
                    lblmsg.Text = "Password Successfully Changed";
                    success.Visible = true;
                    Failure.Visible = false;
                    clear();
                    // hidetable.Visible = false;
                    // trsubmittion.Visible = false;
                    trchangepewmessage.Visible = true;
                    hidetablepassword.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password Successfully Changed.');", true);
                }
                else
                {
                    string message = "alert('" + strStatus + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }
            else
            {
                success.Visible = false;
                Failure.Visible = true;
            }
        }



        void FillCapctha()
        {
            try
            {
                ViewState["captcha"] = "";

                Random random = new Random();
                string combination = "123456789ABCDEFGHJKLMNPQRSTUVWXYZ";
                StringBuilder captcha = new StringBuilder();

                for (int i = 0; i < 4; i++)
                    captcha.Append(combination[random.Next(combination.Length)]);
                ViewState["captcha"] = captcha.ToString();
                imgCaptcha.ImageUrl = "CaptchaHandler.ashx?query=" + captcha.ToString();
            }
            catch
            {
                throw;
            }
        }
        void clear()
        {
            BtnSave1.Text = "Submit";
            TxtNpwd.Text = "";
            txtPwd.Text = "";
        }
        protected void BtnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmChangePassword.aspx");
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCaptcha.Text = "";
            FillCapctha();
        }
    }
}