using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace BlockView
{
    public class DBConnection
    {
        static private string connenctionString;

        static public MySqlConnection msConnect;
        static public MySqlCommand msCommand;
        static public MySqlDataAdapter msDataAdapter=new MySqlDataAdapter();

        static public bool ConnectDB()
        {
            try
            {
                connenctionString = "database=stationary;datasource=localhost;user=root;password=Ilin00121212;sslmode=none";
                msConnect = new MySqlConnection(connenctionString);
                msConnect.Open();
                msCommand = new MySqlCommand();
                msCommand.Connection = msConnect;
                msDataAdapter = new MySqlDataAdapter(msCommand);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

    }
}
