using ppedv.VollE.UI.WPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ppedv.VollE.UI.WPF.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<TabItem> Tabs { get; set; }
        private int _selectedTabIndex;

        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set { _selectedTabIndex = value; }
        }

        public MainWindowViewModel()
        {
            SelectedTabIndex = 0;
            Tabs = new ObservableCollection<TabItem>();
            
            Tabs.Add(new TabItem { Header = "Spieler", Content = new SpielerView() });
            Tabs.Add(new TabItem { Header = "Trainer", Content = new TrainerView() });
            Tabs.Add(new TabItem { Header = "Manschaft", Content = new MannschaftView() });
            Tabs.Add(new TabItem { Header = "Spiel", Content = new SpielerView() });
        }
    }
}
