using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Presentation.WPF.ViewModels.Base;
using Core;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Presentation.WPF.Observables;

namespace Presentation.WPF.ViewModels
{
    public class RegistrationViewModel : ObservableObject
    {

        public event EventHandler RegistrationStart;
        public event EventHandler RegistrationFinish;


        #region Properties

        private string _challengeName;
        public string ChallengeName
        {
            get { return _challengeName; }
            set
            {
                if (_challengeName != value)
                {
                    OnPropertyChanging(() => ChallengeName);
                    _challengeName = value;
                    OnPropertyChanged(() => ChallengeName);
                }
            }
        }

        private DateTime _challengeDate;
        public DateTime ChallengeDate
        {
            get { return _challengeDate; }
            set
            {
                if (_challengeDate != value)
                {
                    OnPropertyChanging(() => ChallengeDate);
                    _challengeDate = value;
                    OnPropertyChanged(() => ChallengeDate);
                }
            }
        }

        private string _mainReaderStatus;
        public string MainReaderStatus
        {
            get { return _mainReaderStatus; }
            set
            {
                if (_mainReaderStatus != value)
                {
                    OnPropertyChanging(() => MainReaderStatus);
                    _mainReaderStatus = value;
                    OnPropertyChanged(() => MainReaderStatus);
                }
            }
        }

        private string _mainReaderIp;
        public string MainReaderIp
        {
            get { return _mainReaderIp; }
            set
            {
                if (_mainReaderIp != value)
                {
                    OnPropertyChanging(() => MainReaderIp);
                    _mainReaderIp = value;
                    OnPropertyChanged(() => MainReaderIp);
                }
            }
        }

        private string _portableReaderStatus;
        public string PortableReaderStatus
        {
            get { return _portableReaderStatus; }
            set
            {
                if (_portableReaderStatus != value)
                {
                    OnPropertyChanging(() => PortableReaderStatus);
                    _portableReaderStatus = value;
                    OnPropertyChanged(() => PortableReaderStatus);
                }
            }
        }

        private string _portableReaderPort;
        public string PortableReaderPort
        {
            get { return _portableReaderPort; }
            set
            {
                if (_portableReaderPort != value)
                {
                    OnPropertyChanging(() => PortableReaderPort);
                    _portableReaderPort = value;
                    OnPropertyChanged(() => PortableReaderPort);
                }
            }
        }

        private DeviceStatus _portableReaderDeviceStatus;
        public DeviceStatus PortableReaderDeviceStatus
        {
            get { return _portableReaderDeviceStatus; }
            set
            {
                if (_portableReaderDeviceStatus != value)
                {
                    OnPropertyChanging(() => PortableReaderDeviceStatus);
                    _portableReaderDeviceStatus = value;
                    OnPropertyChanged(() => PortableReaderDeviceStatus);
                }
            }
        }

        private ObservableCollection<PersonObservable> _persons;
        public ObservableCollection<PersonObservable> Persons
        {
            get { return _persons; }
            set
            {
                OnPropertyChanging(() => Persons);
                _persons = value;
                OnPropertyChanged(() => Persons);
            }
        }
        #endregion

        public ICommand StartRegistration { get; set; }
        public ICommand CompleteRegistration { get; set; }
        public RegistrationViewModel()
        {
            StartRegistration = new AutoCanExecuteCommandWrapper(
                new DelegateCommand(RegistrationStartExecute, RegistrationStartCanExecute));
            CompleteRegistration = new AutoCanExecuteCommandWrapper(
                new DelegateCommand(RegistrationFinishExecute, RegistrationFinishCanExecute));
            _persons = new ObservableCollection<PersonObservable>();
            _challengeName = "Новое соревнование";
            _challengeDate = DateTime.Now;
        }

        #region Commands
        private void RegistrationStartExecute(object param)
        {
            EventArgs e = new EventArgs();
            RegistrationStart(this, e);
        }

        private bool RegistrationStartCanExecute(object param)
        {
            return PortableReaderDeviceStatus == DeviceStatus.Connected;
        }

        private void RegistrationFinishExecute(object param)
        {
            EventArgs e = new EventArgs();
            RegistrationFinish(this, e);
        }

        private bool RegistrationFinishCanExecute(object param)
        {
            return true;
        }

        #endregion
    }
}
