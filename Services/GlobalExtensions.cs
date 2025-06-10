using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Services
{
    public static class GlobalExtensions
    {
        public static string FROMOBJECTVALUETOSTRING(this object pObject,
                                                    bool pblnemptyisnull = false)
        {
            if (pObject == null
                || pObject is DBNull
                || pObject.ToString().Trim() == "")
                return (pblnemptyisnull == true ? null : "");
            else
                return pObject.ToString();
        }
    }
}
