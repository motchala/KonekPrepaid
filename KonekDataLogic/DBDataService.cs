using KonekCommon;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;

namespace KonekDataServices
{
    class DBDataService : IKonekDataService
    {

        //connectionString
        static string connectionString
        = "Data Source =ASUS-FREDERICK\\SQLEXPRESS01; Initial Catalog = KonekDB; Integrated Security = True; TrustServerCertificate=True;";

        static SqlConnection sqlConnection;

        public DBDataService()
        {  
            sqlConnection = new SqlConnection(connectionString);
        }

        public void CreateAccount(KonekAccount konekAccount) // pang initialize 'to
        {
            var insertStatement = "INSERT INTO AccountDetails VALUES (@PhoneNumber, @Pin, @AccountName, @LoadBalance, @RewardPoints)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@PhoneNumber", konekAccount.PhoneNumber);
            insertCommand.Parameters.AddWithValue("@Pin", konekAccount.Pin);
            insertCommand.Parameters.AddWithValue("@Email", konekAccount.Email);
            insertCommand.Parameters.AddWithValue("@AccountName", konekAccount.AccountName);
            insertCommand.Parameters.AddWithValue("@LoadBalance", konekAccount.LoadBalance);
            insertCommand.Parameters.AddWithValue("@RewardPoints", konekAccount.TotalRewardPoints);

            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }


        public List<KonekAccount> GetAccounts() // pang read lang basically ng data sa database
        {
            string selectStatement = "SELECT PhoneNumber, Pin, Email, AccountName, LoadBalance, RewardPoints FROM AccountDetails";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var konekAccounts = new List<KonekAccount>();

            while (reader.Read())
            {
                //deserialize or deserialization 'to

                KonekAccount konekAccount = new KonekAccount();
                konekAccount.PhoneNumber = reader["PhoneNumber"].ToString();
                konekAccount.Pin = reader["Pin"].ToString();
                konekAccount.Email = reader["Email"].ToString();
                konekAccount.AccountName = reader["AccountName"].ToString();
                konekAccount.LoadBalance = Convert.ToDouble(reader["LoadBalance"].ToString());
                konekAccount.TotalRewardPoints = Convert.ToDouble(reader["RewardPoints"].ToString());

                konekAccounts.Add(konekAccount);
            }

            sqlConnection.Close();
            return konekAccounts;
        }


        public void RemoveAccount(KonekAccount konekAccount) // this one naman, hindi ko pa sya ma implement hehe
        {
            sqlConnection.Open();

            var deleteStatement = $"DELETE FROM AccountDetails WHERE PhoneNumber = @PhoneNumber";
            SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@PhoneNumber", konekAccount.PhoneNumber);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }


        public void UpdateAccount(KonekAccount konekAccount) // so this updates the data base on the transactions you made
        {
            sqlConnection.Open();

            var updateStatement = $"UPDATE AccountDetails SET AccountName = @AccountName, LoadBalance = @LoadBalance, RewardPoints = @RewardPoints WHERE PhoneNumber = @PhoneNumber";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@AccountName", konekAccount.AccountName);
            updateCommand.Parameters.AddWithValue("@LoadBalance", konekAccount.LoadBalance);
            updateCommand.Parameters.AddWithValue("@RewardPoints", konekAccount.TotalRewardPoints);
            updateCommand.Parameters.AddWithValue("@PhoneNumber", konekAccount.PhoneNumber);
            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
