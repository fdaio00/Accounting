using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32; 

namespace AccountingPR.Global
{
    public class clsGlobal
    {

        public static bool SaveCredintail(string UserName , string Password)
        {
            bool successed = false;

            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\Accounting";
            string UserNameKey = "UserName";
            string PasswordKey = "Password";
            string UserNameValue = UserName;
            string PasswordValue = Password;

            try
            {
                Registry.SetValue(KeyPath, UserNameKey, UserNameValue);
                Registry.SetValue(KeyPath, PasswordKey, PasswordValue);

                successed = true; 
            }
            catch (Exception ex)
            {

                throw;
            }


                return successed; 
        }
    }
}
