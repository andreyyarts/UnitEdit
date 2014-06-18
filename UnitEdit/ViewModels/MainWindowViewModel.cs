using System;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;
using System.Linq;
using System.ComponentModel;
using UnitEdit.Helpers;
using UnitEdit.Models;

namespace UnitEdit.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            UnitMeasures = new ObservableCollection<UnitMeasure>();
            RandomizeData();

            SortDescription sortName = new SortDescription("Name", ListSortDirection.Ascending);
            ICollectionView dataView = CollectionViewSource.GetDefaultView(UnitMeasures);
            dataView.SortDescriptions.Clear();
            dataView.SortDescriptions.Add(sortName);
            dataView.Refresh();
        }

        private ObservableCollection<UnitMeasure> _unitMeasures;
        private UnitMeasure _currentUnit;

        public UnitMeasure CurrentUnit
        {
            get { return _currentUnit; }
            set
            {
                if (_currentUnit != value)
                {
                    _currentUnit = value;
                    OnPropertyChanged(() => CurrentUnit);
                }
            }
        }
        public ObservableCollection<UnitMeasure> UnitMeasures
        {
            get { return _unitMeasures; }
            set
            {
                if (_unitMeasures != value)
                {
                    _unitMeasures = value;
                    OnPropertyChanged(() => UnitMeasures);
                }
            }
        }

        #region Commands

        //public ICommand CreateUnitCommand { get { return new DelegateCommand<UnitMeasure>(OnCreateUnit, CanSaveUnit); } }
        public ICommand SaveUnitCommand { get { return new DelegateCommand<UnitMeasure>(OnSaveUnit, CanSaveUnit); } }
        public ICommand DeleteUnitCommand { get { return new DelegateCommand<UnitMeasure>(OnDeleteUnit, CanEditUnit); } }
        
        private void OnCreateUnit(UnitMeasure um)
        {
            if (um.ID < 1)
                um.ID = UnitMeasures.Max(u => u.ID) + 1;

            UnitMeasure umNew = new UnitMeasure(um);
            UnitMeasures.Add(umNew);
            ICollectionView dataView = CollectionViewSource.GetDefaultView(UnitMeasures);
            dataView.MoveCurrentTo(umNew);
        }
        
        private bool CanSaveUnit(UnitMeasure um)
        {
            return (um != null) && !string.IsNullOrWhiteSpace(um.Name);
        }

        private void OnSaveUnit(UnitMeasure um)
        {
            if (UnitMeasures.Contains(um, new UnitIdComparer()))
                UnitMeasures.FirstOrDefault(p => p.ID == um.ID).Update(um);
            else
            {
                OnCreateUnit(um);
            }
        }

        private void OnDeleteUnit(UnitMeasure um)
        {
            UnitMeasures.Remove(um);
        }

        private bool CanEditUnit(UnitMeasure um)
        {
            return (um != null) && UnitMeasures.Contains(um);
        }

        #endregion

        private void RandomizeData()
        {
            for (var i = 0; i < 10; i++)
            {
                UnitMeasures.Add(new UnitMeasure(
                    (i + 1),
                    RandomHelper.RandomString(10, true))
                );
            }
        }
    }
}