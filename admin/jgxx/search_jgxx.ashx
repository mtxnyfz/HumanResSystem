<%@ WebHandler Language="C#" Class="search_jgxx" %>

using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;
public class search_jgxx : IHttpHandler
{
    private static readonly string[] LANGUAGES = new string[]{
                "ActionScript",
                "AppleScript",
                "Asp",
                "BASIC",
                "C",
                "C++",
                "Clojure",
                "COBOL",
                "ColdFusion",
                "Erlang",
                "Fortran",
                "Groovy",
                "Haskell",
                "Java",
                "JavaScript",
                "Lisp",
                "Perl",
                "PHP",
                "Python",
                "Ruby",
                "Scala",
                "Scheme"
        };
    public void ProcessRequest (HttpContext context) {
        String term = context.Request.QueryString["term"].Trim();
        if (!String.IsNullOrEmpty(term))
        {
            //term = term.ToLower();


            string sqlstr = " select uid,XM,GH,b.text as xb,c.text as xz,d.DWMC from (select GUID as uid,XM,XBM,GH,DWH,XJRYXZ,Version from gxjg0101 as n where Version = (select MAX(Version) from gxjg0101 where GH = n.GH and XJSFSC!=1 and XJSFYX=1)) as a  left join [HumanResSystemCode].[dbo].[xbm] as b on a.XBM=b.code left join [HumanResSystemCode].[dbo].xjryxzm as c on a.XJRYXZ=c.code left join jctb0103 as d on a.DWH=d.DWH where d.XJSFYX=1 and (a.GH like '%" + term + "%' or a.XM like '%" + term + "%' or d.DWMC like '%" + term + "%') order by a.XM";
            DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];


            string jsonstr = "[";
            for (int i = 0; i < dt.Rows.Count; i++)
            {





                if (i < dt.Rows.Count - 1)
                    jsonstr = jsonstr + "{\"xm\":\"" + dt.Rows[i]["XM"].ToString().Trim() + "\",\"gh\":\"" + dt.Rows[i]["GH"].ToString().Trim() + "\",\"dwmc\":\"" + dt.Rows[i]["DWMC"].ToString().Trim() + "\"},";
                else
                    jsonstr = jsonstr + "{\"xm\":\"" + dt.Rows[i]["XM"].ToString().Trim() + "\",\"gh\":\"" + dt.Rows[i]["GH"].ToString().Trim() + "\",\"dwmc\":\"" + dt.Rows[i]["DWMC"].ToString().Trim() + "\"}";

                //if (i < dt.Rows.Count - 1)
                //    jsonstr = jsonstr + "{\"label\":\"项目名称：" + dt.Rows[i]["XMLB_MC"] + "\",\"value\":\"" + dt.Rows[i]["XMLB_MC"] + "\",\"xmbh\":\"" + dt.Rows[i]["XMLB_BH"] + "\",\"fzr\":\"" + dt.Rows[i]["XMLB_BH"] + "\",\"ye\":\"" + dt.Rows[i]["XMLB_RYJFYE"] + "\"},";
                //else
                //    jsonstr = jsonstr + "{\"label\":\"项目名称：" + dt.Rows[i]["XMLB_MC"] + "\",\"value\":\"" + dt.Rows[i]["XMLB_MC"] + "\",\"xmbh\":\"" + dt.Rows[i]["XMLB_BH"] + "\",\"fzr\":\"" + dt.Rows[i]["XMLB_BH"] + "\",\"ye\":\"" + dt.Rows[i]["XMLB_RYJFYE"] + "\"}";
            }
            jsonstr = jsonstr + "]";

            context.Response.ContentType = "text/plain";
            string aa = jsonstr;
            context.Response.Write(jsonstr);
        }
        else
        {
            //string jsonstr = "[{\"xm\":\"falseorerro\"}]";
            string jsonstr = "[]";
            context.Response.ContentType = "text/plain";

            context.Response.Write(jsonstr);
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}