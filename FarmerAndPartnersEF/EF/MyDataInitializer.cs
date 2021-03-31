using FarmerAndPartnersModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace FarmerAndPartnersEF.EF
{
    /// <summary>
    /// класс для локального тестирования приложения без применения миграций,
    /// в производственной среде применяться не будет
    /// </summary>
    //public class MyDataInitializer : DropCreateDatabaseAlways<FarmerAndPartnersEntities>
    public class MyDataInitializer : DropCreateDatabaseIfModelChanges<FarmerAndPartnersEntities>
    {
        protected override void Seed(FarmerAndPartnersEntities context)
        {
            var contractStatuses = new List<ContractStatus>
            {
                new ContractStatus { Id = 1, Definition = "Заключен" },
                new ContractStatus { Id = 2, Definition = "Ещё не заключен" },
                new ContractStatus { Id = 3, Definition = "Расторгнут" }
            };

            contractStatuses.ForEach(c => context.ContractStatuses.AddOrUpdate(d => new { d.Id, d.Definition }, c));

            var companies = new List<Company>
            {
                new Company { Id = 1, Name = "Лодочка", ContractStatus = contractStatuses[0] },
                new Company { Id = 2, Name = "Зверушка", ContractStatus = contractStatuses[1] },
                new Company { Id = 3, Name = "Поедатель", ContractStatus = contractStatuses[2] }
            };

            companies.ForEach(c => context.Companies.AddOrUpdate(d => new { d.Id, d.Name, d.ContractStatusId }, c));

            var users = new List<User>
            {
                new User { Id = 1, Name = "Сергей", Login = "Serg_37", Password = "12322w@", Company = companies[0]},
                new User { Id = 2, Name = "Михаил", Login = "Mih_12", Password = "52622w@", Company = companies[1]},
                new User { Id = 3, Name = "Екатерина", Login = "Kat_31", Password = "78822w@", Company = companies[0]},
                new User { Id = 4, Name = "Светлана", Login = "Svet_15", Password = "66822w@", Company = companies[2]},
                new User { Id = 5, Name = "Дмитрий", Login = "Dima_39", Password = "41522w@", Company = companies[2]},
                new User { Id = 6, Name = "Александра", Login = "Sashka_35", Password = "98522w@", Company = companies[1]},
                new User { Id = 7, Name = "Алекс", Login = "Aleks_36", Password = "77892ww@w@", Company = companies[0]},
                new User { Id = 8, Name = "Макс", Login = "Maks_17", Password = "963772ww@w@", Company = companies[1]},
                new User { Id = 9, Name = "Вероника", Login = "Veronika_18+", Password = "96388ww@w@", Company = companies[2]},
                new User { Id = 10, Name = "Влад", Login = "Vlad_1987", Password = "9159763ww@w@", Company = companies[1]},
                new User { Id = 11, Name = "Николай", Login = "Nikolas_36", Password = "968796ww@w@", Company = companies[0]}
            };

            context.Users.AddOrUpdate(d => new { d.Id, d.Name, d.Login, d.Password, d.CompanyId }, users.ToArray());

            context.SaveChanges();
        }
    }
}
