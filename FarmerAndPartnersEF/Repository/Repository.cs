using FarmerAndPartnersEF.EF;
using FarmerAndPartnersModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerAndPartnersEF.Repository
{
    public class Repository : IDisposable, IAsyncRepository
    {
        private readonly FarmerAndPartnersEntities _db;
        private readonly ILogger _log;

        public Repository(ILogger log)
        {
            _db = new FarmerAndPartnersEntities();
            _log = log;
        }

        protected FarmerAndPartnersEntities Context => _db;

        public void Dispose() => _db.Dispose();

        public async Task<int> AddCompanyAsync(Company company)
        {
            _db.Companies.Add(company);
            return await SaveChangesAsync();
        }

        public async Task<int> AddUserAsync(User user)
        {
            _db.Users.Add(user);
            return await SaveChangesAsync();
        }

        public async Task<int> DeleteCompanyAsync(Company company)
        {
            _db.Companies.Remove(company);
            return await SaveChangesAsync();
        }

        public async Task<int> DeleteUserAsync(User user)
        {
            _db.Users.Remove(user);
            return await SaveChangesAsync();
        }

        public async Task<int> SaveCompanyAsync(Company company)
        {
            _db.Entry(company).State = EntityState.Modified;
            return await SaveChangesAsync();
        }

        public async Task<int> SaveUserAsync(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
            return await SaveChangesAsync();
        }

        public int GetCompaniesCount() => Context.Companies.Include(c => c.ContractStatus).Include(c => c.Users).Count();
        public int GetUsersCount() => Context.Users.Count();

        public async Task<int> ExecuteQueryAsync(string sql, params object[] sqlParameters)
        {
            try
            {
                return await _db.Database.ExecuteSqlCommandAsync(sql, sqlParameters);
            }
            catch (Exception ex)
            {
                _log.Error($"Ошибка при выполнении метода ExecuteQueryAsync\r\n{ex}");
                return -1;
            }
        }

        public async Task<List<Company>> GetCompaniesAsync() => await Context.Companies.Include(c => c.ContractStatus).Include(c => c.Users).ToListAsync();
        public IList<ContractStatus> GetContractStatuses() => Context.ContractStatuses.ToList();
        public IEnumerable<Company> GetCompanies() => Context.Companies.Include(c => c.ContractStatus).Include(c => c.Users);
        public IEnumerable<User> GetUsers() => Context.Users.Include(u => u.Company);

        protected async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                _log.Error($"Ошибка параллелизма\r\n{ex}\rn{entry.Entity}");

                return -1;
            }
            catch (DbUpdateException ex)
            {
                _log.Error($"Ошибка при обновлении базы данных\r\n{ex}");
                return -1;
            }
            catch (CommitFailedException ex)
            {
                _log.Error($"Ошибка при выполнении транзакции\r\n{ex}");
                return -1;
            }
            catch (Exception ex)
            {
                _log.Error($"Ошибка при выполнении метода SaveChanges\r\n{ex}");
                return -1;
            }
        }
    }
}
