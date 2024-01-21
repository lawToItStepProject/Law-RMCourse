using LawСRM.Data;
using LawСRM.Data.Entities;
using LawСRM.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LawСRM
{
    public partial class MainWindow : Window
    {
        //DataContext db = new DataContext();
        public MainWindow()
        {
            InitializeComponent();

            // Admin admin = new Admin() { Login = "admin", Password = "admin" };
            // db.Admins.Add(admin);
            // db.SaveChanges();
            // AdminProfile adminProfile = new AdminProfile() { Email = "admin@gmail.com", AdminId = admin.Id };
            // db.AdminProfiles.Add(adminProfile);
            //db.SaveChanges();
            //DataContext = new MainWindowViewModel();
        }
        
    }
}