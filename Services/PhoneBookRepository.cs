using EmployeeManagement.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using EmployeeManagement.Data;

namespace EmployeeManagement.Services
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly string _connectionString;
        private readonly EmployeeManagementDBContext _dbContext;
        public PhoneBookRepository(IConfiguration configuration, EmployeeManagementDBContext dbContext)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _dbContext = dbContext;
        }

        public PhoneBook GetPhoneBook(string ID)
        {
            PhoneBook PhoneBook = new PhoneBook();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SelectPhoneBookID";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", ID);
                SqlDataReader rdr;
                connection.Open();
                rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    PhoneBook.ID = rdr["ID"].ToString();
                    PhoneBook.ContactName = rdr["BloodGroupName"].ToString();
                    PhoneBook.PhoneNumber = rdr["TransactionType"].ToString();
                    PhoneBook.ContactName = rdr["IsActive"].ToString();
                    PhoneBook.UserId = rdr["CreatedBy"].ToString();
                    PhoneBook.Email = rdr["CreatedDate"].ToString();
                }
            }

            return PhoneBook;
        }

        public PhoneBook InsertPhoneBook(PhoneBook PhoneBook)
        {
            try
            {
                var phBook = new PhoneBook
                {
                    ContactName = PhoneBook.ContactName
                    ,
                    PhoneNumber = PhoneBook.PhoneNumber
                    ,
                    NickName = PhoneBook.NickName
                    ,
                    UserId = PhoneBook.UserId,
                    Email = PhoneBook.Email
                };

                _dbContext.PhoneBook.Add(phBook);
                _dbContext.SaveChanges(); // Save changes to the database
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PhoneBook;

        }

        public PhoneBook UpdatePhoneBook(PhoneBook PhoneBook)
        {
            try
            {
                var phBook = new PhoneBook
                {
                    ContactName = PhoneBook.ContactName
                    ,
                    PhoneNumber = PhoneBook.PhoneNumber
                    ,
                    NickName = PhoneBook.NickName
                    ,
                    UserId = PhoneBook.UserId,
                    Email = PhoneBook.Email,
                    ID = PhoneBook.ID
                };

                _dbContext.PhoneBook.Update(phBook);
                _dbContext.SaveChanges(); // Save changes to the database
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PhoneBook;
        }

        public string DeletePhoneBook(string ID)
        {

            try
            {
                var phBook = _dbContext.PhoneBook.Find(ID);
                if (phBook == null)
                {
                    return "Not Found"; 
                }
                _dbContext.PhoneBook.Remove(phBook);
                _dbContext.SaveChanges(); // Save changes to the database
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Deleted";
        }

    }
}
