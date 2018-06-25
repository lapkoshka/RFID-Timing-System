using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.WPF.ViewModels.Base;
using System.Windows.Input;
using System.Diagnostics;

namespace Presentation.WPF.ViewModels
{
    public class RegistrationFormViewModel : ObservableObject
    {
        public event EventHandler PersonRegistred;
        public event EventHandler CancelPersonRegister;
        #region Properties

        private string _tagUid;
        public string TagUid
        {
            get { return _tagUid; }
            set
            {
                if (_tagUid != value)
                {
                    OnPropertyChanging(() => TagUid);
                    _tagUid = value;
                    OnPropertyChanged(() => TagUid);
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    OnPropertyChanging(() => LastName);
                    _lastName = value;
                    OnPropertyChanged(() => LastName);
                }
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    OnPropertyChanging(() => FirstName);
                    _firstName = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }

        private string _patronymic;
        public string Patronymic
        {
            get { return _patronymic; }
            set
            {
                if (_patronymic != value)
                {
                    OnPropertyChanging(() => Patronymic);
                    _patronymic = value;
                    OnPropertyChanged(() => Patronymic);
                }
            }
        }

        private string _class;
        public string Class
        {
            get { return _class; }
            set
            {
                if (_class != value)
                {
                    OnPropertyChanging(() => Class);
                    _class = value;
                    OnPropertyChanged(() => Class);
                }
            }
        }

        #endregion

        public ICommand RegisterPerson { get; set; }
        public ICommand CancelRegisterPerson { get; set; }

        public RegistrationFormViewModel()
        {
            RegisterPerson = new AutoCanExecuteCommandWrapper(
                new DelegateCommand(RegisterExecute, RegisterCanExecute));
            CancelRegisterPerson = new AutoCanExecuteCommandWrapper(
                new DelegateCommand(CancelRegisterExecute, CancelRegisterCanExecute));
        }

        private void RegisterExecute(object param)
        {
            EventArgs e = new EventArgs();
            PersonRegistred(this, e);
        }

        private bool RegisterCanExecute(object param)
        {
            //TODO: validate
            return true;
        }

        private void CancelRegisterExecute(object param)
        {
            EventArgs e = new EventArgs();
            CancelPersonRegister(this, e);
        }

        private bool CancelRegisterCanExecute(object param)
        {
            return true;
        }
    }
}