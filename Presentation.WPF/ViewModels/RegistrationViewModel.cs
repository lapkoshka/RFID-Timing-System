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
            //выполни комманду
            Console.WriteLine("Регистрация на соревнование '{0}' на '{1}' зевeршена", ChallengeName, ChallengeDate);
        }
      

        #endregion


    }
}
