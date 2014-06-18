using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Linq;
using UnitEdit.ViewModels;
using UnitEdit.Models;

namespace UnitEdit.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SortUnitMeasures(object sender, RoutedEventArgs e)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(UnitGrid.ItemsSource);
            dataView.Refresh();
        }

        private void ShowDeleteConfirm(object sender, RoutedEventArgs e)
        {
            UnitMeasure um = (UnitMeasure)this.UnitGrid.SelectedItem;
            MessageBoxResult result = MessageBox.Show(this, "Вы уверенны, что хотите удалить единицу измерения \""+um.Name+"\"?", "Подтверждение", MessageBoxButton.YesNo);
            
            if (result == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;
                MainWindowViewModel context = (MainWindowViewModel)btn.DataContext;
                context.DeleteUnitCommand.Execute(um);
                SortUnitMeasures(sender, e);
            }
        }

        private void ShowEditUnitWindow(object sender, RoutedEventArgs e)
        {
            EditUnitWindow editUnitWindow = new EditUnitWindow();
            editUnitWindow.Owner = this;

            editUnitWindow.DataContext = this.ListGrid.DataContext;

            Button btn = (Button)e.Source;

            switch (btn.Name)
            {
                case "AddBtn":
                    editUnitWindow.UnitEdit.DataContext = new UnitMeasure(0,"");
                    break;
                case "EditBtn":
                    editUnitWindow.UnitEdit.DataContext = new UnitMeasure((UnitMeasure)this.UnitGrid.SelectedItem);
                    break;
            }
            
            editUnitWindow.ShowDialog();
            if (editUnitWindow.DialogResult == true)
            {
                SortUnitMeasures(sender, e);
            }
        }
    }
}
