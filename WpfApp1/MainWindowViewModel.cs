using EzCareTech.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
    class MainWindowViewModel:NotifyPropertyChangedBase
    {
        #region Variables
        #endregion

        #region Constructors
        public MainWindowViewModel()
        {
            PatientList.Add(new PatientData()
            {
                PatientName = "이선주",
                PatientNumber = "A20",
                PatientGender = "여",
                PatientAge = 10
            });

            PatientList.Add(new PatientData()
            {
                PatientName = "송재원",
                PatientNumber = "B30",
                PatientGender = "남",
                PatientAge = 20
            });

            PatientList.Add(new PatientData()
            {
                PatientName = "류다영",
                PatientNumber = "C40",
                PatientGender = "여",
                PatientAge = 30
            });

            PatientList.Add(new PatientData()
            {
                PatientName = "박종현",
                PatientNumber = "D50",
                PatientGender = "남",
                PatientAge = 40
            });

            PatientList.Add(new PatientData()
            {
                PatientName = "채민규",
                PatientNumber = "E60",
                PatientGender = "남",
                PatientAge = 50
            });
        }
        #endregion

        #region Properties
        private ObservableCollection<PatientData> _PatientList = new ObservableCollection<PatientData>();
        public ObservableCollection<PatientData> PatientList { get { return _PatientList; } set { _PatientList = value; OnPropertyChanged("PatientList"); } }

        private ObservableCollection<PatientData> _PatientSearchList = new ObservableCollection<PatientData>();
        public ObservableCollection<PatientData> PatientSearchList { get { return _PatientSearchList; } set { _PatientSearchList = value; OnPropertyChanged("PatientSearchList"); } }

        private ObservableCollection<PatientData> _PatientTempList = new ObservableCollection<PatientData>();
        public ObservableCollection<PatientData> PatientTempList { get { return _PatientTempList; } set { _PatientTempList = value; OnPropertyChanged("PatientTempList"); } }

        private string _PatientName;
        public string PatientName { get { return _PatientName; } set { _PatientName = value; OnPropertyChanged("PatientName"); } }

        private string _PatientNumber;
        public string PatientNumber { get { return _PatientNumber; } set { _PatientNumber = value; OnPropertyChanged("PatientNumber"); } }

        private string _PatientGender;
        public string PatientGender { get { return _PatientGender; } set { _PatientGender = value; OnPropertyChanged("PatientGender"); } }

        private int _PatientAge;
        public int PatientAge { get { return _PatientAge; } set { _PatientAge = value; OnPropertyChanged("PatientAge"); } }

        private string _SearchNameNumber;
        public string SearchNameNumber { get { return _SearchNameNumber; } set { _SearchNameNumber = value; OnPropertyChanged("_SearchNameNumber"); } }

        private bool _SearchMale;
        public bool SearchMale { get { return _SearchMale; } set { _SearchMale = value; OnPropertyChanged("SearchMale"); } }

        private bool _SearchFemale;
        public bool SearchFemale { get { return _SearchFemale; } set { _SearchFemale = value; OnPropertyChanged("SearchFemale"); } }
        #endregion

        #region Commands
        private ICommand _SearchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (_SearchCommand == null)
                    _SearchCommand = new RelayCommand(p => this.Search(p));
                return _SearchCommand;
            }
        }



        //private ICommand _AddCommand;
        //public ICommand AddCommand
        //{
        //    get
        //    {
        //        if (_AddCommand == null)
        //            _AddCommand = new RelayCommand(p => this.Add(p));
        //        return _AddCommand;
        //    }
        //}


        #endregion

        #region Methods
        private void Search(object p)
        {

            for (int i = 0; i < PatientList.Count; i++)
            {
                if (_SearchNameNumber == PatientList.ElementAt(i).PatientName ||
                    _SearchNameNumber == PatientList.ElementAt(i).PatientNumber)
                {
                    PatientData data = new PatientData()
                    {
                        PatientName = PatientList.ElementAt(i).PatientName,
                        PatientNumber = PatientList.ElementAt(i).PatientNumber,
                        PatientGender = PatientList.ElementAt(i).PatientGender,
                        PatientAge = PatientList.ElementAt(i).PatientAge
                    };
                    PatientSearchList.Add(data);
                }
            }
            PatientTempList = PatientList;
            PatientList = PatientSearchList;
            PatientSearchList = PatientTempList;
        }

        //private void Add(object p)
        //{
        //    if (PatientList != null && !string.IsNullOrEmpty(PatientName))
        //    {
        //        PatientData data = new PatientData
        //        {
        //            PatientName = PatientName,
        //            PatientNumber = PatientNumber,
        //            PatientGender = PatientGender,
        //            PatientAge = PatientAge
        //        };
        //        PatientList.Add(data);
        //    }
        //}
        #endregion
    }
}
