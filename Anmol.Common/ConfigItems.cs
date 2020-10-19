using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace _Anmol.Common
{

    public static class ConfigItems
    {
        public const string DateFormat = "DD/MM/YYYY";
        public const string DateFormatforOrder = "dd/MM/yyyy";
        /// <summary>
        /// Numeric Validation
        /// </summary>
        public const string NumericExpression = @"^[0-9]*$";

        /// <summary>
        /// allow multiple email address with comma(,) speperation
        /// </summary>
        public const string MultipleEmailRegularExpression = @"(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)(\s*,\s*|\s*$))*";
        /// <summary>
        /// The text box regular expression
        /// </summary>
        public const string TextBoxRegularExpression = @"[^<>]*";

        /// <summary>
        /// The regular expression for file name
        /// </summary>
        public const string RegularExpressionForFileName = @"[<>?/\|*:]*";

        /// <summary>
        /// The name validation expression
        /// </summary>
        public const string NameValidationExpression = @"([a-zA-Z0-9&#32;.&amp;amp;&amp;#39;-]+)";

        /// <summary>
        /// The special character validation expression
        /// </summary>
        public const string SpecialCharacterValidationExpression = @"^[^<>.!@#%/']+$";

        /// <summary>
        /// The decimal validation expression
        /// </summary>
        public const string RegularExprssionForDecimal = @"\d+(\.\d{1,2})?";

        /// <summary>
        /// The website validation expression
        /// </summary>
        /// 

        public const string RegularExprssionForWebsite = @"^(http|http(s)?://)?([\w-]+\.)+[\w-]+[.com|.in|.org]+(\[\?%&=]*)?";
        //public const string RegularExprssionForWebsite = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)";

        /// <summary>
        /// The longitude validation expression
        /// </summary>

        public const string RegularExprssionForLongitude = @"^-?([1]?[0-7][0-9]|[1]?[1-8][0]|[1-9]?[0-9])\.{1}\d{1,6}";

        /// <summary>
        /// The Latitude validation expression
        /// </summary>

        public const string RegularExprssionForLatitude = @"^-?([0-8]?[0-9]|[0-9]0)\.{1}\d{1,6}";
        /// <summary>
        /// The Date Time Format Without Second
        /// </summary>


        /// <summary>
        /// Maximum Amount Price
        /// </summary>
        public const double MaxAmount = 999999999.99;

        public const string DateFormate = "dd/MM/yyyy";

        public static readonly Dictionary<string, object> CenterColumnStyle = new Dictionary<string, object> { { "align", "center" }, { "style", "text-align:center;vertical-align:middle !important;" } };

        /// <summary>
        /// Minimum Amount Price
        /// </summary>
        public const double MinAmount = 1.0;

        public static string ProductName
        {
            get
            {
                return ConfigurationManager.AppSettings["PRODUCTNAME"];
            }
        }

        public static string mvcUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["mvcUrl"];
            }
        }

        public static string RateAutoRefreshInterval
        {
            get
            {
                return ConfigurationManager.AppSettings["RateAutoRefreshInterval"];
            }
        }
        public static string DateFormatGrid
        {
            get
            {
                return "{0: " + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + "}";
            }
        }
        public static string DateTimeFormat
        {
            get
            {
                return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern;
            }
        }

        public static string DateTimeFormatGrid
        {
            get
            {
                return "{0: " + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern + "}";
            }
        }
        public static string DateTimeFormatSingleDigit
        {
            get
            {
                return ConfigurationManager.AppSettings["DateTimeFormat"].Replace(":ss", string.Empty).Replace("hh", "h").Replace("MM", "M").Replace("dd", "d");
            }
        }
        public static string DateFormatForDatePicker
        {
            get
            {
                return ConfigurationManager.AppSettings["DateFormatForDatePicker"];
            }
        }

        public static string CompanyName
        {
            get
            {
                return ConfigurationManager.AppSettings["CompanyName"];
            }
        }

        /// <summary>
        /// Gets the current site URL.
        /// </summary>
        /// <value>
        /// The current site URL.
        /// </value>
        public static string CurrentSiteUrl
        {
            get
            {
                var strUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + System.Web.HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";
                return strUrl;
            }
        }

        #region Oanda

        /// <summary>
        /// Gets Oanda api server key
        /// </summary>
        /// <value>
        /// </value>
        public static string HammerApiServer
        {
            get
            {
                return ConfigurationManager.AppSettings["HammerApiServer"];
            }
        }

        #endregion


        /// <summary>
        /// Gets the brain tree custom field subscription identifier.
        /// </summary>
        /// <value>The brain tree custom field subscription identifier.</value>
        public static string BrainTreeCustomFieldSubscriptionID
        {
            get
            {
                return string.Format(ConfigurationManager.AppSettings["BrainTreeCustomFieldSubscriptionID"]);
            }
        }

        /// <summary>
        /// Gets the number of login attempts.
        /// </summary>
        /// <value>
        /// The number of login attempts.
        /// </value>
        public static string NumberOfLoginAttempts
        {
            get
            {
                return string.Format(ConfigurationManager.AppSettings["NumberOfLoginAttempts"]);
            }
        }


        /// <summary>
        /// Converts the UTC to local.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="timeDifference">The time difference.</param>
        /// <returns>Return DateTime</returns>
        public static DateTime? ConvertUtcToLocal(DateTime? date, string timeDifference)
        {
            if (date != null)
            {
                var hourDifference = Convert.ToInt32(timeDifference.Split(':')[0]);
                var minDifference = Convert.ToInt32(timeDifference.Split(':')[1]);
                return date.Value.AddHours(-hourDifference).AddMinutes(-minDifference);
            }
            else
            {
                return null;
            }
        }

        public static DateTime DateTimezone(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    DateTime dateReturn;
                    if (DateTime.TryParse(Convert.ToString(readField), out dateReturn))
                    {
                        TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
                        if (tzi != null)
                        {
                            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(dateReturn, tzi);

                            return localTime;
                        }
                    }
                    else
                    {
                        return DateTime.UtcNow;
                    }
                }
            }
            return DateTime.UtcNow;
        }

        public static string CowImagePath
        {
            get
            {
                return string.Format(ConfigurationManager.AppSettings["ImagePath"]);
            }
        }

        public static string HostingUrl
        {
            get
            {

                var request = HttpContext.Current.Request;
                var appUrl = HttpRuntime.AppDomainAppVirtualPath;

                if (appUrl != "/")
                    appUrl = "/" + appUrl;

                var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

                return baseUrl;
            }
        }

    }
}
