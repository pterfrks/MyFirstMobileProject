using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobilAlkalmazas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class ObservableObject : INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanged;

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
        }
    }

    public class PersonModel : ObservableObject
    {
        private string _id;

        public string Id
        {
            get { return _id; }

            set { _id = value; NotifyPropertyChanged(nameof(Id)); }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(nameof(Name)); }
        }

        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; NotifyPropertyChanged(nameof(Age)); }
        }


        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", _id,_name,_age);
        }
    }

    public class FormModel : ObservableObject
    {
        public FormModel()
        {
            CurrentPerson = new PersonModel();
            People = new ObservableCollection<PersonModel>();
            AddCommand = new Command(ExecuteAddCommand);
        }

        public ICommand AddCommand { get; set; }
        private PersonModel _currentPerson;
        public PersonModel CurrentPerson
        {
            get { return _currentPerson; }
            set { _currentPerson = value; NotifyPropertyChanged(nameof(CurrentPerson)); }
        }

        public ObservableCollection<PersonModel> People { get; set; }

        private void ExecuteAddCommand(object obj)
        {
            People.Add(CurrentPerson);
            CurrentPerson = new PersonModel();
        }
    }
}
