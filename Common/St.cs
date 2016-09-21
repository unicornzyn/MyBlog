using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class St
    {
        /// <summary>
        /// 时间串格式化
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string GetDateTimeString(object obj, string format = "yyyy-MM-dd HH:mm:ss") 
        {
            return DateTime.Parse(obj.ToString()).ToString(format);
        }
        /// <summary>
        /// 获取md5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5").ToLower();        
        }

        #region 操作Cookie
        /// 设置COOKIE
        /// </summary>
        /// <param name="CookieName"></param>
        /// <param name="CookieValue"></param>
        /// <param name="ExpireTime"></param>
        public static void SetCookie(string CookieName, string CookieValue, DateTime ExpireTime)
        {
            System.Web.HttpContext.Current.Response.Cookies[CookieName].Expires = ExpireTime;
            System.Web.HttpContext.Current.Response.Cookies[CookieName].Value = CookieValue;
            //System.Web.HttpContext.Current.Response.Cookies[CookieName].Domain = "puddingz.com";
        }
        /// <summary>
        /// 删除COOKIE
        /// </summary>
        /// <param name="CookieName"></param>
        public static void DelCookie(string CookieName)
        {
            SetCookie(CookieName, "", DateTime.Now.AddYears(-1));
        }
        /// <summary>
        /// 读取COOKIE
        /// </summary>
        /// <param name="CookieName"></param>
        /// <returns></returns>
        public static string GetCookie(string CookieName)
        {
            string CookieValue = string.Empty;
            if (System.Web.HttpContext.Current.Request.Cookies[CookieName] != null)
            {
                CookieValue = System.Web.HttpContext.Current.Request.Cookies[CookieName].Value;
            }
            return CookieValue;
        }
        /// <summary>
        /// 读取COOKIE
        /// </summary>
        /// <param name="CookieName"></param>
        /// <returns></returns>
        public static string GetCookie(string CookieName,System.Web.HttpRequest request)
        {
            string CookieValue = string.Empty;
            if (request.Cookies[CookieName] != null)
            {
                CookieValue = request.Cookies[CookieName].Value;
            }
            return CookieValue;
        }

        #endregion
    }
}
