using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.WPF.ViewModels.Base;

namespace Presentation.WPF.Observables
{
    public class PersonObservable : ObservableObject
    {
        private string _uid;
        public string UID
        {
            get { return _uid; }
            set
            {
                if (value != _uid)
                {
                    OnPropertyChanging(() => UID);
                    _uid = value;
                    OnPropertyChanged(() => UID);
                }

            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != _firstName)
                {
                    OnPropertyChanging(() => FirstName);
                    _firstName = value;
                    OnPropertyChanged(() => FirstName);
                }

            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value != _lastName)
                {
                    OnPropertyChanging(() => LastName);
                    _lastName = value;
                    OnPropertyChanged(() => LastName);
                }

            }
        }

        private string _patronymic;
        public string Patronymic
        {
            get { return _patronymic; }
            set
            {
                if (value != _patronymic)
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
                if (value != _class)
                {
                    OnPropertyChanging(() => Class);
                    _class = value;
                    OnPropertyChanged(() => Class);
                }

            }
        }
    }
}

