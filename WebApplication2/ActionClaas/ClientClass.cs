using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Numerics;
using System.Reflection;
using WebApplication2.ActionClaas.Account;
using WebApplication2.ActionClaas.HelperClass.DTO;
using WebApplication2.Interfes;
using WebApplication2.Models;

namespace WebApplication2.ActionClaas
{
    public class ClientClass : IClient
    {
        private readonly CoffeHouseContext _context;
        public ClientClass(CoffeHouseContext context) => _context = context;

        public List<AccountDTO> GetClient()
        {
            try
            {
                var data = _context.Clients.Select(
                x => new AccountDTO()
                {
                    Id = x.Id,
                    Login = x.Login,
                    Password = x.Password,
                    BasketId = x.BasketId,
                    ZakazId = x.ZakazId,
                    CatalogueId = x.CatalogueId,

                }
                ).ToList();



                return data;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }


        }


        public List<AccountDTO> GetClient(long id)
        {
            try
            {
                var data = _context.Clients.Where(e => e.Id == id).Select(
                x => new AccountDTO()
                {
                    Id = x.Id,
                    Login = x.Login,
                    Password = x.Password,
                    BasketId = x.BasketId,
                    ZakazId = x.ZakazId,
                    CatalogueId = x.CatalogueId,

                }
                ).ToList();

                return (List<AccountDTO>)data;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }

        public List<string> AddAccount(AccountCreate account)
        {
            try 
            {
            Client createClient = new Client()
            
                {
                    Id = account.Id,
                    Login = account.Login,
                    Password = account.Password,
                    BasketId = account.BasketId,
                    ZakazId= account.ZakazId,
                    CatalogueId = account.CatalogueId,
                };

                _context.Clients.Add(createClient);
                _context.SaveChanges();

                long clientId = createClient.Id;

                Results. Created();
                return [$"Пользователь успешно создан Id -n{clientId}"];
        }
            catch (Exception)
            {
                Results.BadRequest(new List<string> { "Ошибка в выполнении запроса" }); 
                throw;
            }
        }

        public List<AccountDTO> UpdateUser(string login, AccountDTO user)
        {
            throw new NotImplementedException();
        }

        public List<string> DeleteUser(long id)
        {
            try
            {
                var client = _context.Clients.Find(id);
                if (client == null)
                    return new List<string> { "Пользователь не найден" };
                var userSessions = _context.Pays.Where(us => us.ClientId == id).ToList();
                if (userSessions.Any())
                    _context.RemoveRange(userSessions);
                _context.SaveChanges();
                if (client != null)
                {
                    _context.Clients.Remove(client);
                    _context.SaveChanges();

                    return new List<string> { "Пользователь успешно удален" };
                }
                
                Results.NoContent();
                return new List<string> { "операция завершена" };
            }
            catch
            {
                Results.BadRequest(new List<string> { "Ошибка в выполнении запроса" }); throw;
            }
            }
    }
}
