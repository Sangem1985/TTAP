//Developed By: Harshini MVS - 116840
//Developed On: 24-SEP-13

using System;
using System.Collections.Generic;
using System.Web;

public class PageName
{

    public static string GetCurrentPageName()
    {
        try
        {
            string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;
            return sRet;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }
    public string ValidateUser(string PageUserID, string SessionUserID)
    {
        string Valid = "0";
        if (PageUserID != "" && SessionUserID != "")
        {
            if (PageUserID != SessionUserID)
            {
                Valid = "1";
            }
        }

        return Valid;
    }

}