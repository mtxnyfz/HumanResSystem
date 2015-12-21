using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Web.Security;
using System.Text;
using FineUI;
using DotNetCasClient;
using System.Xml.Serialization;
using DotNetCasClient.Validation.Schema.Cas20;
using DotNetCasClient.Security;
using System.Configuration;
using System.Net;
using System.IO;

namespace EmptyProjectNet20
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                string cookieName = FormsAuthentication.FormsCookieName;
                HttpCookie authCookie = Request.Cookies[cookieName];
                if (authCookie == null)
                {
                    Login2(GetUser());
                }
                else
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("login.aspx");
                   
                }

            }
        }


        //private void LoadData()
        //{
        //    InitCaptchaCode();
        //}

        /// <summary>
        /// 初始化验证码
        /// </summary>
        //private void InitCaptchaCode()
        //{
        //    // 创建一个 6 位的随机数并保存在 Session 对象中
        //    Session["CaptchaImageText"] = GenerateRandomCode();
        //    imgCaptcha.ImageUrl = "~/captcha/captcha.ashx?w=150&h=30&t=" + DateTime.Now.Ticks;
        //}

        /// <summary>
        /// 创建一个 6 位的随机数
        /// </summary>
        /// <returns></returns>
        private string GenerateRandomCode()
        {
            string s = String.Empty;
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                s += random.Next(10).ToString();
            }
            return s;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string userName = tbxUserName.Text.Trim();
            string password = tbxPassword.Text.Trim();
            Login1(userName, password);
        }

        private void Login1(string userName, string password)
        {
            string userid = "", roleid = "";
            string name = "";
            string mobile = "";
            //string sqlstr = "SELECT   Users.UserId, Users.Name, RoleUser.RoleId FROM      Users INNER JOIN RoleUser ON Users.UserId = RoleUser.UserId where Users.Name='" + userName + "' and Users.Password='" + password + "'";
            string sqlstr = "SELECT   Users.user_uid, Users.ActualName,Users.mobile FROM      Users  where Users.Name=@Name and Users.Password=@Password";
            //string sqlstr = "SELECT   Users.user_uid, Users.ActualName,Users.mobile FROM      Users  where Users.Name='" + userName + "' and Users.Password='" + password + "'";
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NChar,10)
					};
            parameters[0].Value = userName;
            parameters[1].Value = password;

            SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr, parameters);

            //GridRow gr = Grid1.Rows[e.RowIndex];
            if (sdr.Read())
            {
                userid = sdr["user_uid"].ToString().Trim();
                Session["user_uid"] = userid;
                mobile = sdr["mobile"].ToString().Trim();
                sdr.Dispose();
                //sdr.Close();

            }
            else
            {
                sdr.Dispose();
                Alert.Show("用户名或密码错误！");
              
                return;
            }



            sqlstr = "SELECT   Users.user_uid, Users.Name, Users.mobile, Users.Ssxb_dm, Users.Ssxb_mc, RoleUser.RoleId FROM      Users INNER JOIN RoleUser ON Users.user_uid = RoleUser.UserId where Users.Name='" + userName + "' and Users.Password='" + password + "'";
            sdr = DbHelperSQL.ExecuteReader(sqlstr);

          
            if (sdr.Read())
            {
                string Ssxb_dm = sdr["Ssxb_dm"].ToString().Trim();


                name = sdr["Name"].ToString().Trim();
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
           sdr["Name"].ToString().Trim(),
           DateTime.Now,
           DateTime.Now.AddMinutes(120),
           true,
           sdr["user_uid"].ToString().Trim() + "," + sdr["RoleId"].ToString().Trim() + "," + sdr["mobile"].ToString().Trim() + "," + Ssxb_dm + "," + sdr["Ssxb_mc"].ToString().Trim(),
           FormsAuthentication.FormsCookiePath);
                string hashTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashTicket);
                //HttpCookie userCookie = new HttpCookie("aa", hashTicket);
                userCookie.HttpOnly = true;
                userCookie.Expires = DateTime.Now.AddMinutes(120);
                Response.Cookies.Add(userCookie);
                sdr.Dispose();

            }
            else
            {
                sdr.Dispose();
                Alert.Show("该用户没有任何角色权限，请联系管理员分配角色权限！");
              
                return;
            }

            Response.Redirect("index.aspx");

        }

        private void Login2(string userName)
        {
            string userid = "", roleid = "";
            string name = "";
            string mobile = "";
            //string sqlstr = "SELECT   Users.UserId, Users.Name, RoleUser.RoleId FROM      Users INNER JOIN RoleUser ON Users.UserId = RoleUser.UserId where Users.Name='" + userName + "' and Users.Password='" + password + "'";
            string sqlstr = "SELECT   Users.user_uid, Users.ActualName,Users.mobile FROM      Users  where Users.Name=@Name";
            //string sqlstr = "SELECT   Users.user_uid, Users.ActualName,Users.mobile FROM      Users  where Users.Name='" + userName + "' and Users.Password='" + password + "'";
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50)
					
					};
            parameters[0].Value = userName;
          

            SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr, parameters);
            //SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);

            //GridRow gr = Grid1.Rows[e.RowIndex];
            if (sdr.Read())
            {
                userid = sdr["user_uid"].ToString().Trim();
                Session["user_uid"] = userid;
                mobile = sdr["mobile"].ToString().Trim();
                sdr.Dispose();
                //sdr.Close();

            }
            else
            {
                sdr.Dispose();
                Alert.Show("用户名或密码错误！");
                //Alert.Show(userName);

                return;
            }



            sqlstr = "SELECT   Users.user_uid, Users.Name, Users.mobile, Users.Ssxb_dm, Users.Ssxb_mc, RoleUser.RoleId FROM      Users INNER JOIN RoleUser ON Users.user_uid = RoleUser.UserId where Users.Name='" + userName + "'";
            sdr = DbHelperSQL.ExecuteReader(sqlstr);


            if (sdr.Read())
            {
                string Ssxb_dm = sdr["Ssxb_dm"].ToString().Trim();


                name = sdr["Name"].ToString().Trim();
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
           sdr["Name"].ToString().Trim(),
           DateTime.Now,
           DateTime.Now.AddMinutes(120),
           true,
           sdr["user_uid"].ToString().Trim() + "," + sdr["RoleId"].ToString().Trim() + "," + sdr["mobile"].ToString().Trim() + "," + Ssxb_dm + "," + sdr["Ssxb_mc"].ToString().Trim(),
           FormsAuthentication.FormsCookiePath);
                string hashTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashTicket);
                //HttpCookie userCookie = new HttpCookie("aa", hashTicket);
                userCookie.HttpOnly = true;
                userCookie.Expires = DateTime.Now.AddMinutes(120);
                Response.Cookies.Add(userCookie);
                sdr.Dispose();

            }
            else
            {
                sdr.Dispose();
                Alert.Show("该用户没有任何角色权限，请联系管理员分配角色权限！");

                return;
            }
            //Alert.Show(userName);
            Response.Redirect("index.aspx");

        }



        private string GetUser()
        {
            string userName = "";
            string isStartCas = ConfigurationManager.AppSettings.Get("IsStartCas");
            if (isStartCas == "true")
            {
                string casLogin = ConfigurationManager.AppSettings.Get("casLoginURL");
                string casValidate = ConfigurationManager.AppSettings.Get("casValidateURL");
                if (casLogin == null || casLogin.Length < 1 || casValidate == null || casValidate.Length < 1)
                {
                    // trigger a server error if cashost is not set in the web.config
                    Response.StatusCode = 500;
                    return "";
                }
                string cookieName = FormsAuthentication.FormsCookieName;
                HttpCookie authCookie = Request.Cookies[cookieName];
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = null;
                    try
                    {
                        authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    }
                    catch
                    {
                        // TODO: Make a 500 error or go back to authentication
                        return "";
                    }

                    if (authTicket == null)
                    {
                        // TODO: Make a 500 error or go back to authentication
                        return "";
                    }
                    // create an identity objet
                    FormsIdentity identity = new FormsIdentity(authTicket);
                    userName = identity.Name;
                }
                else
                {
                    // Check if we are back from CAS Authentication
                    // Look for the "ticket=" string after the "?" in the URL when back from CAS
                    string casTicket = Request.QueryString["ticket"];
                    // The CAS service name is the page URL for CAS Server call back
                    // so any query string is discard.
                    string service = Request.Url.GetLeftPart(UriPartial.Path);
                    if (casTicket == null || casTicket.Length == 0)
                    {
                        // redirect to cas server
                        string redir = casLogin + "?service=" + service;
                        Response.Redirect(redir);
                        return "";
                    }
                    else
                    {
                        // Second pass (return from CAS server) because there is a ticket in the query string to validate
                        string validateurl = casValidate + "?ticket=" + casTicket + "&" + "service=" + service;


                        string netid = null;

                        // A very dumb use of XML by looping in all tags.
                        // Just scan for the "user". If it isn't there, its an error.
                        Uri validateUrl = new Uri(validateurl);
                        ValidateProxyTicket(validateUrl, ref netid);

                        // If there was a problem, leave the message on the screen. Otherwise, return to original page.
                        if (string.IsNullOrWhiteSpace(netid))
                        {
                            string redir = casLogin + "?service=" + service;
                            Response.Redirect(redir);
                            return "";
                        }
                        else
                        {
                            userName = netid;
                        }
                    }
                }
            }

            return userName;
        }


        private void ValidateProxyTicket(Uri validateUrl, ref string User)
        {
            try
            {
                string xml;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(validateUrl);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        xml = reader.ReadToEnd();
                        var ServerResponseFieldText = xml.Replace("\n\n\n", "\n").Replace("\n\n", "\n").Replace("\n", Environment.NewLine).Replace("\t", "  ");

                        StringReader sr = new StringReader(xml);

                        XmlSerializer serializer = new XmlSerializer(typeof(ServiceResponse));
                        ServiceResponse serviceResponse = serializer.Deserialize(sr) as ServiceResponse;

                        if (serviceResponse != null)
                        {
                            if (serviceResponse.IsAuthenticationSuccess)
                            {
                                AuthenticationSuccess successResponse = (AuthenticationSuccess)serviceResponse.Item;


                                User = successResponse.User;

                            }
                            else if (serviceResponse.IsAuthenticationFailure)
                            {
                                AuthenticationFailure failureResponse = (AuthenticationFailure)serviceResponse.Item;

                                User = string.Empty;
                                //var MessageLabelText = failureResponse.Message;
                            }
                            else
                            {
                                User = string.Empty;
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {

                var ServerResponseFieldText = exc.ToString();

            }
        }



    }
}
