using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace BlockView
{
    class TestQuery
    {
        static public DataTable dtUsers = new DataTable();
        static public DataTable dtCurrentUser = new DataTable();
        static public bool TestSelectForCards()
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT FIO,PHONE,iduser FROM USERS";
                dtUsers.Clear();
                DBConnection.msDataAdapter.Fill(dtUsers);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        static public bool TestSelectForCardsCurrentUser(string idUser)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT FIO,PHONE,iduser FROM USERS WHERE IDUSER='"+idUser+"'";
                dtCurrentUser.Clear();
                DBConnection.msDataAdapter.Fill(dtCurrentUser);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        static public bool TestDeleteForCards(string idUser)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"Delete from users where iduser='"+idUser+"'";
                DBConnection.msCommand.ExecuteNonQuery();
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
