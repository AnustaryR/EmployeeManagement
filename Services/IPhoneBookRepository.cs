using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public interface IPhoneBookRepository
    {
       
        public PhoneBook GetPhoneBook(string ID);
        public PhoneBook InsertPhoneBook(PhoneBook PhoneBook);
        public PhoneBook UpdatePhoneBook(PhoneBook PhoneBook);
        public string DeletePhoneBook(string ID);
       
    }
}
