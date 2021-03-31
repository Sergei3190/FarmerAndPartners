using FarmerAndPartnersEF.EF;
using System.Data.Entity;
using System.Windows;

namespace FarmerAndPartners
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
#if DEBUG
            #region Readme for Test
            // Данный метод использовался для тсетирования БД до включения миграций, после включения миграций каждое изменение модели
            // должно сопровождаться новой миграцией и обновлением базы данных, в этом случаи при отладке приложения данный метод ошибок не выведет,
            // при условии, что  MyDataInitializer : DropCreateDatabaseIfModelChanges<FarmerAndPartnersEntities>, иначе лови ошибки..
            #endregion
            Database.SetInitializer(new MyDataInitializer());
#endif
        }
    }
}
