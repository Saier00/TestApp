using System.Windows;
using TestApp.Models;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        private Repository rep;
        public StartupWindow()
        {
            InitializeComponent();

            rep = Repository.GetRepos();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            Initializer.SeedDB(new TestSeeder());
            SwapToMainW();
        }

        private void RndButton_Click(object sender, RoutedEventArgs e)
        {
            Initializer.SeedDB(new RandomSeeder());
            SwapToMainW();
        }

        private void SwapToMainW()
        {
            MainWindow mw = new MainWindow();

            mw.Show();
            this.Close();
        }
    }
}
