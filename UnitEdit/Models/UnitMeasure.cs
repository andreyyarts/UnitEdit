using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using UnitEdit.Helpers;

namespace UnitEdit.Models
{
    public class UnitMeasure : NotificationObject, IDataErrorInfo
    {
        public UnitMeasure(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public UnitMeasure(UnitMeasure unitMeasure)
        {
            Update(unitMeasure);
        }

        private int _id;
        private string _name;

        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(() => ID);
                }
            }
        }
        
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }

        public void Update(UnitMeasure unitMeasure)
        {
            ID = unitMeasure.ID;
            Name = unitMeasure.Name;
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string name]
        {
            get
            {
                string result = null;

                if (name == "Name")
                {
                    if (string.IsNullOrWhiteSpace(this.Name))
                    {
                        result = "Обязательно для заполнения";
                    }
                }
                return result;
            }
        }
    }

    public class UnitIdComparer : IEqualityComparer<UnitMeasure>
    {
        public bool Equals(UnitMeasure x, UnitMeasure y)
        {
            if (x.ID == y.ID)
                return true;
            else
                return false;
        }

        public int GetHashCode(UnitMeasure um)
        {
            return um.ID.GetHashCode();
        }
    }
}
