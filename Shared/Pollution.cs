using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;

namespace EcoMonitor.Shared
{
    public class Object : ViewModel
    {
        private int _id = 0;
        [Key]
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _objectName = string.Empty;
        public string ObjectName
        {
            get => _objectName;
            set
            {
                _objectName = value;
                OnPropertyChanged(nameof(ObjectName));
            }
        }

        private string _objectDesc = string.Empty;
        public string ObjectDesc
        {
            get => _objectDesc;
            set
            {
                _objectDesc = value;
                OnPropertyChanged(nameof(ObjectDesc));
            }
        }
        private float _latitude = 0;
        public float Latitude
        {
            get => _latitude;
            set
            {
                _latitude = value;
                OnPropertyChanged(nameof(Latitude));
            }
        }

        private float _longitude = 0;
        public float Longitude
        {
            get => _longitude;
            set
            {
                _longitude = value;
                OnPropertyChanged(nameof(Longitude));
            }
        }
    }

    public class Pollutant : ViewModel
    {
        private int _id = 0;
        [Key]
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private string _pollutantName = string.Empty;
        public string PollutantName
        {
            get => _pollutantName;
            set
            {
                _pollutantName = value;
                OnPropertyChanged(nameof(PollutantName));
            }
        }
        private int _dangerClass = 1;
        public int DangerClass
        {
            get => _dangerClass;
            set
            {
                _dangerClass = value;
                OnPropertyChanged(nameof(DangerClass));
            }
        }
        private int _maxAmount = 1;
        public int MaxAmount
        {
            get => _maxAmount;
            set
            {
                _maxAmount = value;
                OnPropertyChanged(nameof(MaxAmount));
            }
        }

        private float _rfc = 1;
        public float RFC
        {
            get => _rfc;
            set
            {
                _rfc = value;
                OnPropertyChanged(nameof(RFC));
            }
        }

        private float _sf = 1;
        public float SF
        {
            get => _sf;
            set
            {
                _sf = value;
                OnPropertyChanged(nameof(SF));
            }
        }

        private float _tax = 0;
        public float Tax
        {
            get => _tax;
            set
            {
                _tax = value;
                OnPropertyChanged(nameof(Tax));
            }
        }
    }

    public class Record : ViewModel
    {
        private int _id = 0;
        [Key]
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private int _objectId = 0;
        [ForeignKey("Objects")]
        public int ObjectId
        {
            get => _objectId;
            set
            {
                _objectId = value;
                OnPropertyChanged(nameof(ObjectId));
            }
        }

        private Object _object = null;
        public Object Object
        {
            get => _object;
            set
            {
                _object = value;
                OnPropertyChanged(nameof(Object));
            }
        }

        private int _pollutantId = 0;
        [ForeignKey("Pollutant")]
        public int PollutantId
        {
            get => _pollutantId;
            set
            {
                _pollutantId = value;
                OnPropertyChanged(nameof(PollutantId));
            }
        }

        private Pollutant _pollutant = null;
        public Pollutant Pollutant
        {
            get => _pollutant;
            set
            {
                _pollutant = value;
                OnPropertyChanged(nameof(Pollutant));
            }
        }

        private float _pollutionValue = 0;
        public float PollutionValue
        {
            get => _pollutionValue;
            set
            {
                _pollutionValue = value;
                OnPropertyChanged(nameof(PollutionValue));
            }
        }
        private int _recordYear = 0;
        public int RecordYear
        {
            get => _recordYear;
            set
            {
                _recordYear = value;
                OnPropertyChanged(nameof(RecordYear));
            }
        }
    }
}
