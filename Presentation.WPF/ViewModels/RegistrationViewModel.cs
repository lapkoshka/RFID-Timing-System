using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Presentation.WPF.ViewModels.Base;

namespace Presentation.WPF.ViewModels
{
    public class RegistrationViewModel : ObservableObject
    {

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

        public ICommand CompleteRegistration { get; set; }

        #endregion

        public RegistrationViewModel()
        {
            CompleteRegistration = new DelegateCommand(CompleteRegistrationExecute, CompleteRegistrationCanExecute);
            _challengeName = "Новое соревнование";
            _challengeDate = DateTime.Now;
        }

        #region Commands
        private bool CompleteRegistrationCanExecute(object param)
        {
            //Проверь условие и верни может ли выполнятся комманда
            return true;
        }
        private void CompleteRegistrationExecute(object param)
        {
            EventArgs e = new EventArgs();
            RegistrationFinish(this, e);
        }
      

        #endregion


    }
}
