using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBryanKevin.DAO
{
    class DAO_Loan : DAO<Loan>
    {
        public DAO_Loan()
        {

        }
        public override bool Create(Loan loan)
        {
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

                    if(result < 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }catch(SqlException e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public override bool Delete(Loan obj)
        {
            throw new NotImplementedException();
        }

        public override List<Loan> DisplayAll()
        {
            throw new NotImplementedException();
        }

        public override Loan Find(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Loan obj)
        {
            throw new NotImplementedException();
        }
    }
}
