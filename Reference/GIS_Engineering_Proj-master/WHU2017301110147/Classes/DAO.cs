using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WHU2017301110147.Classes
{
    class DAO
    {

        private static string connectionString = "User ID=postgres;Password=xiong123;Server=47.94.150.127;Port=5432;Database=GIS_engine;";
        public DAO()
        {

        }
        public static Byte[] executeRouteQuery(string sqlstr)
        {
            NpgsqlConnection sqlConn = new NpgsqlConnection(connectionString);
            try
            {
                sqlConn.Open();
                NpgsqlCommand objCommand = new NpgsqlCommand(sqlstr, sqlConn);
                Byte[] routeWKB = (byte[])objCommand.ExecuteScalar();
                return routeWKB;
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
                return null;
            }
            finally
            {
                sqlConn.Close();
            }
            
        }

    }
}
