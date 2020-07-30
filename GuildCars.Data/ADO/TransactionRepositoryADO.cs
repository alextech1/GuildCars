using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class TransactionRepositoryADO : ITransactionRepository
    {
        public Transaction GetTransactionById(int? id)
        {
            Transaction transaction = null;

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransactionsSelect", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TransactionID", id);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        transaction = new Transaction();
                        transaction.TransactionID = (int)dr["TransactionID"];
                        transaction.CarID = (int)dr["CarID"];
                        transaction.UserID = dr["UserID"].ToString();
                        transaction.PurchaseDate = dr["PurchaseDate"].ToString();
                        transaction.FirstName = dr["FirstName"].ToString();
                        transaction.LastName = dr["LastName"].ToString();
                        transaction.Role = dr["Role"].ToString();
                        transaction.Email = dr["Email"].ToString();
                        transaction.AddressStreet1 = dr["AddressStreet1"].ToString();
                        transaction.AddressStreet2 = dr["AddressStreet2"].ToString();
                        transaction.City = dr["City"].ToString();
                        transaction.StateID = (int)dr["StateID"];
                        transaction.ZipCode = (int)dr["ZipCode"];
                        transaction.PurchasePrice = (decimal)dr["PurchasePrice"];
                        transaction.PurchaseTypeID = (int)dr["PurchaseTypeID"];
                    }
                }

                return transaction;
            }
        }

        public List<Transaction> GetTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransactionsSelectAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Transaction transaction = new Transaction();

                        transaction = new Transaction();
                        transaction.TransactionID = (int)dr["TransactionID"];
                        transaction.CarID = (int)dr["CarID"];
                        transaction.UserID = dr["UserID"].ToString();
                        transaction.PurchaseDate = dr["PurchaseDate"].ToString();
                        transaction.FirstName = dr["FirstName"].ToString();
                        transaction.LastName = dr["LastName"].ToString();
                        transaction.Role = dr["Role"].ToString();
                        transaction.Email = dr["Email"].ToString();
                        transaction.AddressStreet1 = dr["AddressStreet1"].ToString();
                        transaction.AddressStreet2 = dr["AddressStreet2"].ToString();
                        transaction.City = dr["City"].ToString();
                        transaction.StateID = (int)dr["StateID"];
                        transaction.ZipCode = (int)dr["ZipCode"];
                        transaction.PurchasePrice = (decimal)dr["PurchasePrice"];
                        transaction.PurchaseTypeID = (int)dr["PurchaseTypeID"];


                        transactions.Add(transaction);
                    }
                }
            }

            return transactions;
        }

        public void InsertTransaction(Transaction transaction)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransactionsInsert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@TransactionID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@TransactionID", transaction.TransactionID);
                cmd.Parameters.AddWithValue("@CarID", transaction.CarID);
                cmd.Parameters.AddWithValue("@UserID", transaction.UserID);
                cmd.Parameters.AddWithValue("@PurchaseDate", transaction.PurchaseDate);
                cmd.Parameters.AddWithValue("@FirstName", transaction.FirstName);
                cmd.Parameters.AddWithValue("@LastName", transaction.LastName);
                cmd.Parameters.AddWithValue("@Role", transaction.Role);
                cmd.Parameters.AddWithValue("@Email", transaction.Email);
                cmd.Parameters.AddWithValue("@AddressStreet1", transaction.AddressStreet1);
                cmd.Parameters.AddWithValue("@AddressStreet2", transaction.AddressStreet2);
                cmd.Parameters.AddWithValue("@City", transaction.City);
                cmd.Parameters.AddWithValue("@StateID", transaction.StateID);
                cmd.Parameters.AddWithValue("@ZipCode", transaction.ZipCode);
                cmd.Parameters.AddWithValue("@PurchasePrice", transaction.PurchasePrice);
                cmd.Parameters.AddWithValue("@PurchaseTypeID", transaction.PurchaseTypeID);


                conn.Open();

                cmd.ExecuteNonQuery();

                transaction.TransactionID = (int)param.Value;
            }
        }
    }
}
