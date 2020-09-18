using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace _Anmol.Common
{
    public class Enums
    {
        public enum UserType
        {
            [Description("Admin")]
            Admin = 1,
        }
        public enum NotificationType
        {
            [Description("Client Register")]
            ClientRegister = 1,
        }

        public enum InvestorType
        {
            [Description("Entity")]
            Entity = 'E',
            [Description("Investor")]
            Investor = 'I'

        }

        public enum FormValid
        {
            [Description("YES")]
            YES = 'Y',
            [Description("NO")]
            NO = 'N'

        }

        public enum FormValidityStatus
        {
            [Description("Valid")]
            Valid = 'V',
            [Description("InValid")]
            InValid = 'I',
            [Description("TBD")]
            TBD = 'T'
        }

        public enum ReportingStatus
        {
            [Description("Full Returns Required")]
            FullRequired = 'F',
            [Description("Nil Returns Required")]
            NilRequired = 'N',
        }

        public string GetEnumDescription(Enum value)
        {
            return value
                       .GetType()
                       .GetMember(value.ToString())
                       .FirstOrDefault()
                       ?.GetCustomAttribute<DescriptionAttribute>()
                       ?.Description
                   ?? value.ToString();
        }


    }
}

