using AccountingPR_DataAccsessLA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPR_BusinessLA
{
    public class clsConnection
    {

        public static void SetServerSettings(string Mode, string ServerName, string databaseName, string UserId = "", string Password = "")
        {
            clsConnectionData.SetServerSettings(Mode, ServerName, databaseName, UserId, Password);
        }

    }
}
