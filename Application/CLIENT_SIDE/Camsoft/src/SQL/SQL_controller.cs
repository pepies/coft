using MySql.Data.MySqlClient;
using System;

namespace Camsoft
{
    public static class sqlController
    {
        public static bool isSqlOn
        {
            get { 
                return send_online_state();
            }
        }

        public static bool upload()
        {
            try
            {
                if (SQL_Buffer_list.data.Count != 0)
                {
                    if (!uploadScript(SQL_Buffer_list.data[0].id, SQL_Buffer_list.data[0].cas, SQL_Buffer_list.data[0].vaha))
                    {
                        return false;
                    }
                    SQL_Buffer_list.urez();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool uploadScript(string id, DateTime cas, int vaha)
        {


            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = Achp.i.data.ser_server_ip;
            conn_string.UserID = Achp.i.data.ser_sql_id;
            conn_string.Password = Achp.i.data.ser_sql_pw;
            conn_string.Database = "forsesk";
            conn_string.Port = 3306;

            MySqlConnection dbConn = new MySqlConnection(conn_string.ToString());
            MySqlCommand cmd = dbConn.CreateCommand();
            cmd.CommandText = "INSERT INTO `forsesk`.`zaznamy` (`id_stredisko`, `id`, `datetime`, `vaha`) VALUES (@id_stredisko, @id, @datetime, @vaha)";
            cmd.Parameters.AddWithValue("?id_stredisko", Achp.i.data.ser_id);
            cmd.Parameters.AddWithValue("?id", id);
            cmd.Parameters.AddWithValue("?datetime", cas.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("?vaha", vaha);
            //'2015-07-08 00:00:00'

            try
            {
                dbConn.Open();
                Achp.i.myConsoleWrite("Odosielam do databázy");
                cmd.ExecuteNonQuery();
                dbConn.Close();
            }
            catch (MySqlException mysqlExc)
            {
                Achp.i.myConsoleWrite("ERROR - " + mysqlExc.Message);
                return false;
            }
            catch (Exception)
            {
                Achp.i.myConsoleWrite("ERROR ! Nepodarilo sa pripojiť do databázy, skontrolujte údaje");
                return false;
            }

            return true;
        }

        private static bool send_online_state()
        {
            DateTime cas = DateTime.Now;
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = Achp.i.data.ser_server_ip;
            conn_string.UserID = Achp.i.data.ser_sql_id;
            conn_string.Password = Achp.i.data.ser_sql_pw;
            conn_string.Database = "forsesk";
            conn_string.Port = 3306;
            MySqlConnection dbConn = new MySqlConnection(conn_string.ToString());
            try
            {
                MySqlCommand cmd = dbConn.CreateCommand();
                cmd.CommandText = "UPDATE `stredisko` SET `status` = '" + cas.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE `id_strediska` = '" + Achp.i.data.ser_id + "';";
                dbConn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                dbConn.Close();
            }
            return true;
        }
    }
}
