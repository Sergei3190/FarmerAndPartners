using FarmerAndPartnersModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmerAndPartnersEF.Repository
{
    public interface IAsyncRepository
    {
        Task<int> AddCompanyAsync(Company company);
        Task<int> DeleteCompanyAsync(Company company);
        Task<int> SaveCompanyAsync(Company company);
        Task<int> AddUserAsync(User user);
        Task<int> DeleteUserAsync(User user);
        Task<int> SaveUserAsync(User user);
        Task<int> ExecuteQueryAsync(string sql, params object[] sqlParameters);
        Task<List<Company>> GetCompaniesAsync();
        IList<ContractStatus> GetContractStatuses();
        IEnumerable<Company> GetCompanies();
        IEnumerable<User> GetUsers();
        int GetCompaniesCount();
        int GetUsersCount();
    }
}
