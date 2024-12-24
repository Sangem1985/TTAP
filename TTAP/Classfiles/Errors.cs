using System;
using System.Collections.Generic;
using System.Web;

public class Errors
{

    public static void  ErrorLog(Exception ex)
    {
        try
        {
            string mg, fnm, myHost;
            myHost = System.Net.Dns.GetHostName();
            string req=HttpContext.Current.Request.UserHostAddress;
            string eid = (HttpContext.Current.Session["uid"] == null ? "Session Expired" : HttpContext.Current.Session["uid"].ToString());
            fnm = PageName.GetCurrentPageName();
            mg = "Error Message:" + ex.Message;
            mg += "\r\nUser:" + eid + "\r\nForm Name:" + fnm;
            mg += "\r\nDate:" + DateTime.Now.ToString("dd-MMM-yy") + "\r\nTime:" + DateTime.Now.ToString("HH:mm:ss");
            mg += "\r\nIP Address:" + req + "\r\nHostName: " + myHost;
            mg += "\r\nInnerException: " + ex.InnerException;
            mg += "\r\nStatckTrace: " + ex.StackTrace;
            string path = HttpContext.Current.Server.MapPath("") + "\\ErrorLog\\" + DateTime.Now.ToString("ddMMyyyy") + "\\";
            if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
            //System.IO.File.WriteAllLines(path + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".txt", mg);
            System.IO.File.WriteAllText(path + DateTime.Now.ToString("HHmmss") + ".txt", mg);
        }
        catch (Exception) { }
    }

    public static void ErrorLog_Name(Exception ex,string Name)
    {
        try
        {
            string mg, fnm, myHost;
            myHost = System.Net.Dns.GetHostName();
            string req = HttpContext.Current.Request.UserHostAddress;
            string eid = (Name);
            fnm = PageName.GetCurrentPageName();
            mg = "Error Message:" + ex.Message;
            mg += "\r\nUser:" + eid + "\r\nForm Name:" + fnm;
            mg += "\r\nDate:" + DateTime.Now.ToString("dd-MMM-yy") + "\r\nTime:" + DateTime.Now.ToString("HH:mm:ss");
            mg += "\r\nIP Address:" + req + "\r\nHostName: " + myHost;
            mg += "\r\nInnerException: " + ex.InnerException;
            mg += "\r\nStatckTrace: " + ex.StackTrace;
            string path = HttpContext.Current.Server.MapPath("") + "\\ErrorLog\\" + DateTime.Now.ToString("ddMMyyyy") + "\\";
            if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
            //System.IO.File.WriteAllLines(path + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".txt", mg);
            System.IO.File.WriteAllText(path + DateTime.Now.ToString("HHmmss") + ".txt", mg);
        }
        catch (Exception) { }
    }

    public static void ErrorLog_Vat(Exception ex)
    {
        try{ ErrorLog_Name(ex, "VAT"); }
        catch (Exception) { }
    }

    public static void ErrorLog_MeeSeva(Exception ex)
    {
        try { ErrorLog_Name(ex, (HttpContext.Current.Session["StrMeesevaUserId"] == null ? "MeeSeva - Session Expired" : HttpContext.Current.Session["StrMeesevaUserId"].ToString())); }
        catch (Exception) { }
    }
}