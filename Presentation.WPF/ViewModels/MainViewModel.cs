using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Presentation.WPF.ViewModels.Base;
using Presentation.WPF.Views;
using Presentation.WPF.Observables;
using System.Windows.Controls.Primitives;
using Core;
using System.Diagnostics;
using System.Windows;

namespace Presentation.WPF.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private MainReader _mainReader;
        private PortableReader _portableReader;

        private RegistrationViewModel _registrationViewModel;
        private RegistrationPage _registrationPage;
        private RegistrationFormViewModel _registrationFormViewModel;
        private RegistrationForm _registrationForm;
        private RacePageViewModel _racePageViewModel;
        private RacePage _racePage;
        private Page _activePage;

        public Page ActivePage
        {
            get { return _activePage; }
            set
            {
                if (value != _activePage)
                {
                    OnPropertyChanging(() => ActivePage);
                    _activePage = value;
                    OnPropertyChanged(() => ActivePage);
                }
            }
        }

        public MainViewModel()
        {
            //Инициализация вьюх и моделей
            _registrationViewModel = new RegistrationViewModel();
            _registrationViewModel.RegistrationStart += registrationStartHandler;
            _registrationViewModel.RegistrationFinish += registrationFinishHandler;
            _registrationPage = new RegistrationPage() { DataContext = _registrationViewModel };

            _registrationFormViewModel = new RegistrationFormViewModel();
            _registrationFormViewModel.PersonRegistred += ContestantRegistredHandler;
            _registrationFormViewModel.CancelPersonRegister += CancelContestantRegisterHandler;
            _registrationForm = new RegistrationForm() { DataContext = _registrationFormViewModel };

            _racePageViewModel = new RacePageViewModel();
            _racePageViewModel.RaceStart += raceStartHandler;
            _racePage = new RacePage() { DataContext = _racePageViewModel };

            

            //Меняй это поле для навигации
            ActivePage = _registrationPage;

            _mainReader = new MainReader();
            _mainReader.ConnectionStatusEvent += ReaderStatusHandler;
            _mainReader.TagCatchEvent += MainReaderTagCatchHandler;
            _mainReader.StartConnecting();

            _portableReader = new PortableReader();
            _portableReader.ConnectionStatusEvent += ReaderStatusHandler;
            _portableReader.TagCatchEvent += PortableReaderTagCatchHandler;
            _portableReader.StartConnecting();
        }

        public void registrationStartHandler(object sender, EventArgs e)
        {
            _portableReader.StartListening();
            MessageBox.Show("Регистрация начата. Приложите метку к приемнику.");
        }

        public void raceStartHandler(object sender, EventArgs e)
        {
            if (_mainReader.Status == DeviceStatus.Connected)
            {
                _mainReader.StartListening();
                MessageBox.Show("PONESLAS");
            }
            else
            {
                MessageBox.Show("Сначала подключите приемник");
            }
            
        }

        public void registrationFinishHandler(object sender, EventArgs e)
        {
            _portableReader.StopListening();
            ActivePage = _racePage;
        }

        public void ContestantRegistredHandler(object sender, EventArgs e)
        {
            AddPersonToDataGrid(GetPersonFromLoginForm());
            ClearLoginForm();

            ActivePage = _registrationPage;
            _portableReader.StartListening();
        }

        public void CancelContestantRegisterHandler(object sender, EventArgs e)
        {
            ActivePage = _registrationPage;
            _portableReader.StartListening();
        }

        public void ReaderStatusHandler(ConnectionStatusEventArgs args)
        {
            if (args.Type == DeviceType.MAIN)
            {
                _registrationViewModel.MainReaderStatus = args.GetStatusDescription();
                _registrationViewModel.MainReaderIp = args.GetHumanReadableIp();
            }

            if (args.Type == DeviceType.PORTABLE)
            {
                _registrationViewModel.PortableReaderStatus = args.GetStatusDescription();
                _registrationViewModel.PortableReaderPort = args.GetConnectionPort();
                _registrationViewModel.PortableReaderDeviceStatus = args.Status;
            }
        }

        public void MainReaderTagCatchHandler(TagCatchEventArgs args)
        {
            RFIDTag tag = args.Tag;
            Console.WriteLine(tag.UID);
        }

        public void PortableReaderTagCatchHandler(TagCatchEventArgs args)
        {
            RFIDTag tag = args.Tag;
            ActivePage = _registrationForm;
            _registrationFormViewModel.TagUid = tag.UID;
            _portableReader.StopListening();
        }

        public void AddPersonToDataGrid(PersonObservable person)
        {
            _registrationViewModel.Persons.Add(person);
        }

        public PersonObservable GetPersonFromLoginForm()
        {
            return new PersonObservable()
            {
                UID = _registrationFormViewModel.TagUid,
                FirstName = _registrationFormViewModel.FirstName,
                LastName = _registrationFormViewModel.LastName,
                Patronymic = _registrationFormViewModel.Patronymic,
                Class = _registrationFormViewModel.Class
            };
        }
        public void ClearLoginForm()
        {
            _registrationFormViewModel.TagUid = null;
            _registrationFormViewModel.FirstName = null;
            _registrationFormViewModel.LastName = null;
            _registrationFormViewModel.Patronymic = null;
            _registrationFormViewModel.Class = null;
        }
    }
}
