using System.Collections.Generic;
using System.Windows;
using DevExpress.Mvvm;
using TestApp.Models;

namespace TestApp
{
    public partial class MainWindow : Window
    {
        private Repository rep;
        public MainWindow()
        {
            InitializeComponent();

            rep = Repository.GetRepos();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            rep.Dispose();
        }
    }

    public class MainWindowViewModel : ViewModelBase
    {
        private Repository rep = Repository.GetRepos();
        public List<CatalogLevel> CatalogLevels
        { 
            get 
            {
                return rep.CatalogLevels;
            } 
        }

    }
}
