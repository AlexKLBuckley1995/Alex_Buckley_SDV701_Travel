using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace TravelItemAppSelfHost
{

    // Author: Alex Buckley
    // Date: 16/06/2017
    // Summary: This class contains the mechanical functions to query in this case the SQL Server database using SQL queries. This facilitates the
    // TravelShopController by letting it run SQL queries against the database. 

    static class clsDbConnection
    {
        private static ConnectionStringSettings ConnectionStringSettings = ConfigurationManager.ConnectionStrings["TravelItemAppDB"];
        private static DbProviderFactory ProviderFactory = DbProviderFactories.GetFactory(ConnectionStringSettings.ProviderName);
        private static string ConnectionStr = ConnectionStringSettings.ConnectionString;
        public static DataTable GetDataTable(string prSQL, Dictionary<string, Object> prPars)
        {
            using (DataTable lcDataTable = new DataTable("TheTable"))
            using (DbConnection lcDataConnection = ProviderFactory.CreateConnection())
            using (DbCommand lcCommand = lcDataConnection.CreateCommand())
            {
                lcDataConnection.ConnectionString = ConnectionStr;
                lcDataConnection.Open();
                lcCommand.CommandText = prSQL;
                setPars(lcCommand, prPars);
                using (DbDataReader lcDataReader = lcCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    lcDataTable.Load(lcDataReader); return lcDataTable;
            }
        }
        public static int Execute(string prSQL, Dictionary<string, Object> prPars)
        {
            using (DbConnection lcDataConnection = ProviderFactory.CreateConnection())
            using (DbCommand lcCommand = lcDataConnection.CreateCommand())
            {
                lcDataConnection.ConnectionString = ConnectionStr;
                lcDataConnection.Open();
                lcCommand.CommandText = prSQL;
                setPars(lcCommand, prPars);
                return lcCommand.ExecuteNonQuery();
            }
        }
        private static void setPars(DbCommand prCommand, Dictionary<string, Object> prPars)
        { // For most DBMS using @Name1, @Name2, @Name3 etc. 
            if (prPars != null)
                foreach (KeyValuePair<string, Object> lcItem in prPars)
                {
                    DbParameter lcPar = ProviderFactory.CreateParameter();
                    lcPar.Value = lcItem.Value == null ? DBNull.Value : lcItem.Value;
                    lcPar.ParameterName = '@' + lcItem.Key;
                    prCommand.Parameters.Add(lcPar);
                }
        }
    }
}

