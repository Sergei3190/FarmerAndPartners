﻿using FarmerAndPartnersModels;
using FarmerAndPartners.ViewModels;
using NLog;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace FarmerAndPartners.Helpers.Interfaces
{
    public interface IAsyncRepositoryService
    {
        ILogger Logger { get; }
        Task<int> AddCompanyAsync(Company company);
        Task<int> SaveCompanyAsync(Company company);
        Task<int> DeleteCompanyAsync(Company company);
        Task<int> AddUserAsync(User user);
        Task<int> SaveUserAsync(User user);
        Task<int> DeleteUserAsync(User user);
        Task<int> ExecuteSqlQueryAsync(string sqlQuery, params object[] sqlQueryParameters);
        Task<ObservableCollection<CompanyViewModel>> GetCompanyViewModelsAsync();
        ObservableCollection<ContractStatus> GetContractStatuses();
        ObservableCollection<CompanyViewModel> GetCompanyViewModels(BackgroundWorker backgroundWorker, IEnumerable<Company> companies, int count);
        ObservableCollection<UserViewModel> GetUserViewModels(BackgroundWorker backgroundWorker, IEnumerable<User> users, int count);
        IEnumerable<Company> GetCompanies();
        IEnumerable<User> GetUsers();
        void UpdateDbContaext();
        void DisposeDbContext();
        int GetCompaniesCount();
        int GetUsersCount();
    }
}
