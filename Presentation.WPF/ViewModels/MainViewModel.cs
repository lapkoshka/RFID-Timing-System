using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Presentation.WPF.ViewModels.Base;
using Presentation.WPF.Views;
using Core;

namespace Presentation.WPF.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private MainReader _mainReader;
        private PortableReader _portableReader;
        private RegistrationViewModel _registrationViewModel;
        private RegistrationPage _registrationPage;
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
            _registrationViewModel.RegistrationFinish += registrationFinishHandler;
            _registrationPage = new RegistrationPage() { DataContext = _registrationViewModel };

            //Меняй это поле для навигации
            ActivePage = _registrationPage;

            _mainReader = new MainReader();
            _mainReader.ConnectionStatusEvent += ReaderStatusHandler;
            _mainReader.StartConnecting();

            _portableReader = new PortableReader();
            _portableReader.ConnectionStatusEvent += ReaderStatusHandler;
            _portableReader.StartListening();
        }

        public void registrationFinishHandler(object sender, EventArgs e)
        {
            
        }

        public void ReaderStatusHandler(ConnectionStatusEventArgs args)
        {
            if (args.Type == DeviceType.MAIN)
            {
                _registrationViewModel.MainReaderStatus = args.GetStatusDescription();
                _registrationViewModel.MainReaderIp = args.GetHumanReadableIp();

                if (args.Status == DeviceStatus.Connected)
                {
                    _mainReader.TagCatchEvent += TagCatchHandler;
                    _mainReader.StartListening();
                }
            }

            if (args.Type == DeviceType.PORTABLE)
            {
                _registrationViewModel.PortableReaderStatus = args.GetStatusDescription();
                _registrationViewModel.PortableReaderPort = args.GetConnectionPort();

                if (args.Status == DeviceStatus.Connected)
                {
                    _portableReader.TagCatchEvent += TagCatchHandler;
                    _portableReader.StartListening();
                }
            }
        }

        public void TagCatchHandler(TagCatchEventArgs args)
        {
            RFIDTag tag = args.Tag;
            Console.WriteLine(tag.UID);
        }
    }
}
