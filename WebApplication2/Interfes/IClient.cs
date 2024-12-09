using WebApplication2.ActionClaas.Account;
using WebApplication2.ActionClaas.HelperClass.DTO;

namespace WebApplication2.Interfes
{
    public interface IClient
    {
        public List<AccountDTO> GetClient();

        public List<AccountDTO> GetClient(long id);
       
        public List<string> AddAccount(AccountCreate account);
        
        public List<AccountDTO> UpdateUser(string login, AccountDTO user);

        public List<string> DeleteUser(long id);
    }
}
