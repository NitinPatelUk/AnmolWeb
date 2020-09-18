using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace _Anmol.Common
{
    public class SessionHelper
    {
        public static string AuthToken
        {
            get
            {
                return HttpContext.Current.Session["Token"] == null ? "" : (string)HttpContext.Current.Session["Token"];
            }
            set
            {
                HttpContext.Current.Session["Token"] = value;
            }
        }

        public static string DisplayName
        {
            get
            {
                return HttpContext.Current.Session["DisplayName"] == null ? string.Empty : (string)HttpContext.Current.Session["DisplayName"];
            }

            set
            {
                HttpContext.Current.Session["DisplayName"] = value;
            }
        }

        public static int ClientId
        {
            get
            {
                return HttpContext.Current.Session["ClientId"] == null ? 0 : (int)HttpContext.Current.Session["ClientId"];
            }

            set
            {
                HttpContext.Current.Session["ClientId"] = value;
            }
        }

        public static int UserId
        {
            get
            {
                return HttpContext.Current.Session["UserId"] == null ? 0 : (int)HttpContext.Current.Session["UserId"];
            }

            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }

        public static long UserType
        {
            get
            {
                return HttpContext.Current.Session["UserType"] == null ? 0 : (long)HttpContext.Current.Session["UserType"];
            }

            set
            {
                HttpContext.Current.Session["UserType"] = value;
            }
        }

        public static bool IsVerified
        {
            get
            {
                return HttpContext.Current.Session["IsVerified"] == null ? false : Convert.ToBoolean(HttpContext.Current.Session["IsVerified"]);
            }
            set
            {
                HttpContext.Current.Session["IsVerified"] = value;
            }
        }

        public static long ServiceProviderId
        {
            get
            {
                return HttpContext.Current.Session["ServiceProviderId"] == null ? 0 : (long)HttpContext.Current.Session["ServiceProviderId"];
            }

            set
            {
                HttpContext.Current.Session["ServiceProviderId"] = value;
            }
        }

        public static int UserRoleId
        {
            get
            {
                return HttpContext.Current.Session["UserRoleId"] == null ? 0 : (int)HttpContext.Current.Session["UserRoleId"];
            }

            set
            {
                HttpContext.Current.Session["UserRoleId"] = value;
            }
        }

        public static byte[] ProfilePhoto
        {
            get
            {
                return HttpContext.Current.Session["ProfilePhoto"] == null ? null : (byte[])(HttpContext.Current.Session["ProfilePhoto"]);
            }
            set
            {
                HttpContext.Current.Session["ProfilePhoto"] = value;
            }
        }

        public static bool Availablility
        {
            get
            {
                return HttpContext.Current.Session["Availablility"] == null ? false : Convert.ToBoolean(HttpContext.Current.Session["Availablility"]);
            }
            set
            {
                HttpContext.Current.Session["Availablility"] = value;
            }
        }

        public static string CurrentSiteUrl
        {
            get
            {
                if (HttpContext.Current.Request.ApplicationPath != null)
                {
                    var strUrl = HttpContext.Current.Request.Url.Scheme
                                    + "://" + HttpContext.Current.Request.Url.Authority
                                    + HttpContext.Current.Request.ApplicationPath.TrimEnd('/')
                                    + "/";
                    return strUrl;
                }

                return string.Empty;
            }
        }

        public static object UserAccessRights
        {
            get
            {
                return HttpContext.Current.Session["UserAccessRights"];
            }
            set
            {
                HttpContext.Current.Session["UserAccessRights"] = value;
            }
        }

        public static int RoleId
        {
            get
            {
                return HttpContext.Current.Session["UserRoleId"] == null ? 0 : (int)HttpContext.Current.Session["UserRoleId"];
            }
            set
            {
                HttpContext.Current.Session["UserRoleId"] = value;
            }
        }

        public static string Email
        {
            get
            {
                return HttpContext.Current.Session["Email"] == null ? "" : (string)HttpContext.Current.Session["Email"];
            }
            set
            {
                HttpContext.Current.Session["Email"] = value;
            }
        }

        public static string RoleName
        {
            get
            {
                return HttpContext.Current.Session["RoleName"] == null ? "" : (string)HttpContext.Current.Session["RoleName"];
            }
            set
            {
                HttpContext.Current.Session["RoleName"] = value;
            }
        }

        public static string Menu
        {
            get
            {
                return HttpContext.Current.Session["Menu"] == null ? "" : (string)HttpContext.Current.Session["Menu"];
            }
            set
            {
                HttpContext.Current.Session["Menu"] = value;
            }
        }

        public static string ActiveNav
        {
            get
            {
                return HttpContext.Current.Session["ActiveNav"] == null ? "" : (string)HttpContext.Current.Session["ActiveNav"];
            }
            set
            {
                HttpContext.Current.Session["ActiveNav"] = value;
            }
        }
        public static string DeviceType
        {
            get
            {
                return HttpContext.Current.Session["DeviceType"] == null ? "" : (string)HttpContext.Current.Session["DeviceType"];
            }
            set
            {
                HttpContext.Current.Session["DeviceType"] = value;
            }
        }
        public static string TokenKey
        {
            get
            {
                return HttpContext.Current.Session["TokenKey"] == null ? "" : (string)HttpContext.Current.Session["TokenKey"];
            }
            set
            {
                HttpContext.Current.Session["TokenKey"] = value;
            }
        }

        public static string WelcomeUser
        {
            get
            {
                return HttpContext.Current.Session["WelcomeUser"] == null
                    ? "Guest"
                    : (string)HttpContext.Current.Session["WelcomeUser"];
            }
            set { HttpContext.Current.Session["WelcomeUser"] = value; }
        }


        public static bool IsSuperAdmin
        {
            get
            {
                return HttpContext.Current.Session["IsSuperAdmin"] != null &&
                       (bool)HttpContext.Current.Session["IsSuperAdmin"];
            }
            set { HttpContext.Current.Session["IsSuperAdmin"] = value; }
        }
        public static long SubscriptionPaymentNot
        {
            get
            {
                return HttpContext.Current.Session["SubscriptionPaymentNot"] == null ? 0 : (long)HttpContext.Current.Session["SubscriptionPaymentNot"];
            }

            set
            {
                HttpContext.Current.Session["SubscriptionPaymentNot"] = value;
            }
        }

        public static string LoggedInUserName
        {
            get
            {
                return HttpContext.Current.Session["LoggedInUserName"] == null ? string.Empty : (string)HttpContext.Current.Session["LoggedInUserName"];
            }

            set
            {
                HttpContext.Current.Session["LoggedInUserName"] = value;
            }
        }

        public static string LoggedInInitials
        {
            get
            {
                if (string.IsNullOrEmpty(LoggedInUserName))
                    return "";
                string retVal = "";
                LoggedInUserName.Split(' ').ToList().ForEach(i => retVal = retVal + i[0]);
                return retVal.ToUpper();
            }
        }

    }
}
