using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WeatherApp.Models
{
    public class Metric
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial
    {
        public int Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class TemperatureReading : INotifyPropertyChanged
    {
        float _value;

        public float Value
        {
            get => _value;

            set
            {
                _value = Value;
                OnPropertyChanged(nameof(Value));
            }
        }

        private string _unit;

        public string Unit
        {
            get { return _unit; }
            set
            {
                _unit = value;
                OnPropertyChanged(nameof(Unit));
            }
        }

        private int _unitType;

        public int UnitType
        {
            get { return _unitType; }
            set
            {
                _unitType = value;
                OnPropertyChanged(nameof(UnitType));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Temperature : INotifyPropertyChanged
    {
        TemperatureReading _metric;
        TemperatureReading _imperial;

        // TODO this could be refactored for the different class structures in this case.
        // This one could be a TemperatureReading class instead.
        public TemperatureReading Metric
        {
            get { return _metric; }
            set
            {
                _metric = value;
                OnPropertyChanged(nameof(Metric));
            }
        }

        public TemperatureReading Imperial
        {
            get
            {
                return _imperial;
            }
            set
            {
                _imperial = value;
                OnPropertyChanged(nameof(Imperial));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class AccuWeather : INotifyPropertyChanged
    {
        private DateTime _localObservationDateAndTime;

        public DateTime LocalObservationDateTime
        {
            get { return _localObservationDateAndTime; }

            set
            {
                _localObservationDateAndTime = value;
                OnPropertyChanged(nameof(LocalObservationDateTime));
            }
        }

        private int _epochTime;

        public int EpochTime
        {
            get
            {
                return _epochTime;
            }
            set
            {
                _epochTime = value;
                OnPropertyChanged(nameof(EpochTime));
            }
        }

        private string _weatherText;
        public string WeatherText
        {
            get
            {
                return _weatherText;
            }
            set
            {
                _weatherText = value;
                OnPropertyChanged(nameof(WeatherText));
            }
        }

        private int _weatherIcon;
        public int WeatherIcon
        {
            get { return _weatherIcon; }
            set
            {
                _weatherIcon = value;
                OnPropertyChanged(nameof(WeatherIcon));
            }
        }

        private bool _hasPrecipitation;

        public bool HasPrecipitation
        {
            get { return _hasPrecipitation; }
            set { _hasPrecipitation = value;
                OnPropertyChanged(nameof(HasPrecipitation));
            }
        }

        private object _precipitationType;

        public object PrecipitationType
        {
            get { return _precipitationType; }
            set
            {
                _precipitationType = value;
                OnPropertyChanged(nameof(PrecipitationType));
            }
        }

        private bool _isDayTime;

        public bool IsDayTime
        {
            get { return _isDayTime; }
            set { _isDayTime = value; OnPropertyChanged(nameof(IsDayTime)); }
        }

        private Temperature _temperature;

        public Temperature Temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                OnPropertyChanged(nameof(Temperature));
            }
        }


        private string _mobileLink;

        public string MobileLink
        {
            get { return _mobileLink; }
            set
            {
                _mobileLink = value;
                OnPropertyChanged(nameof(MobileLink));
            }
        }

        private string _link;

        public string Link
        {
            get { return _link; }
            set
            {
                _link = value;
                OnPropertyChanged(nameof(Link));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
