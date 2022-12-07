using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBryanKevin.DAO
{
    
    class DAO_Loan : DAO<Loan>
    {
        DAO_Copy DAO_Copy = new DAO_Copy();
        DAO_Player DAO_Player = new DAO_Player();
        public DAO_Loan()
        {
        }
        public override bool Create(Loan loan)
        {
            bool success;
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Loan(startDate, endDate,ongoing, IdCopy,IdBorrower,IdLender) VALUES (@startDate,@endDate,@ongoing,@idCopy,@IdBorrower,@IdLender)",connection);
                    cmd.Parameters.AddWithValue("startDate", loan.StartDate);
                    cmd.Parameters.AddWithValue("endDate", loan.EndDate);
                    cmd.Parameters.AddWithValue("ongoing", loan.OnGoing);
                    cmd.Parameters.AddWithValue("IdCopy", loan.Copy.IdCopy);
                    cmd.Parameters.AddWithValue("IdBorrower", loan.Borrower.Id);
                    cmd.Parameters.AddWithValue("IdLender", loan.Lender.Id);

                    connection.Open();

                    int result = cmd.ExecuteNonQuery();
                    success = result > 0;
                }
                return success;

            }catch(SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public override bool Delete(Loan loan)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Loan WHERE idLoan=@id", connection);
                    cmd.Parameters.AddWithValue("id", loan.IdLoan);

                    connection.Open();

                    int result = cmd.ExecuteNonQuery();

                    if (result < 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public override List<Loan> DisplayAll()
        {
            List<Loan> loans = new List<Loan>();
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.Loan", connection);
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Loan temporaryLoan = new Loan(
                                reader.GetInt32("idLoan"),
                                reader.GetDateTime("startData"),
                                reader.GetDateTime("endData"),
                                reader.GetBoolean("ongoing"),
                                DAO_Player.Find(reader.GetInt32("idLender")),
                                DAO_Player.Find(reader.GetInt32("idBorrower")),
                                DAO_Copy.Find(reader.GetInt32("idCopy"))
                                ); 
                            loans.Add(temporaryLoan);
                        }
                    }
                }

            }catch(SqlException e) 
            { 
                throw new Exception(e.Message); 
            }  
            return loans;
        }


        public override Loan Find(int id)
        {
            Loan loan = null;
            try
            {
                using(SqlConnection connection =new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.Loan WHERE idLoan = @idLoan", connection);
                    command.Parameters.AddWithValue("idLoan", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            loan = new Loan(
                                reader.GetInt32("idLoan"),
                                reader.GetDateTime("startData"),
                                reader.GetDateTime("endData"),
                                reader.GetBoolean("ongoing"),
                                DAO_Player.Find(reader.GetInt32("idLender")),
                                DAO_Player.Find(reader.GetInt32("idBorrower")),
                                DAO_Copy.Find(reader.GetInt32("idCopy"))
                                );
                        }
                    }

                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            return loan;

        }

        public override List<Loan> FindBookingsByIdPlayer(Player play)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Loan updatedLoan)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE dbo.Copy SET startDate = @startDate, endDate = @endDate, " +
                        "ongoing = @ongoing, idCopy = @idCopy, idBorrower = @idBorrower, idLender = @idLender WHERE idLoan = @idLoan");
                    command.Parameters.AddWithValue("idLoan", updatedLoan.IdLoan);
                    command.Parameters.AddWithValue("startDate", updatedLoan.StartDate);
                    command.Parameters.AddWithValue("endDate", updatedLoan.EndDate);
                    command.Parameters.AddWithValue("ongoing", updatedLoan.OnGoing);
                    command.Parameters.AddWithValue("idCopy", updatedLoan.Copy.IdCopy);
                    command.Parameters.AddWithValue("idBorrower", updatedLoan.Borrower.Id);
                    command.Parameters.AddWithValue("idLender", updatedLoan.Lender.Id);
                    connection.Open();
                    bool isUpdated = command.ExecuteNonQuery() > 0 ? true : false;
                    return isUpdated;
                }
            }
            catch (SqlException e)
            { throw new Exception(e.Message); }
        }

        public override Loan VerificationConnection(string username, string password)
        {
            return null;
        }
    }
}
