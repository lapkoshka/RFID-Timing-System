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
        MainReader mainReader;
        DeviceManagerBase portableReader;
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

            mainReader = new MainReader();
            mainReader.StartConnection();
            mainReader.ConnectionStatusHandle += ReaderStatusHandler;

            portableReader = new PortableReader();
            portableReader.StartConnection();
            portableReader.ConnectionStatusHandle += ReaderStatusHandler;
        }

        public void registrationFinishHandler(object sender, EventArgs e)
        {
            
        }

        public void ReaderStatusHandler(object sender, ConnectionStatusEventArgs evt)
        {
            if (evt.Type == DeviceType.MAIN)
            {
                _registrationViewModel.MainReaderStatus = evt.getStatusDescription();
                _registrationViewModel.MainReaderIp = evt.getHumanReadableIp();

                if (evt.Status == DeviceStatus.CONNECTED)
                {
                    mainReader.TagCatchHandle += TagCatchHandler;
                    mainReader.StartListening();
                }
            }

            if (evt.Type == DeviceType.PORTABLE)
            {
                _registrationViewModel.PortableReaderStatus = evt.getStatusDescription();
                _registrationViewModel.PortableReaderPort = evt.getConnectionPort();

                if (evt.Status == DeviceStatus.CONNECTED)
                {
                    portableReader.TagCatchHandle += TagCatchHandler;
                    portableReader.StartListening();
                }
            }
        }

        public void TagCatchHandler(object sender, TagCatchEventArgs e)
        {
            RFIDTag tag = e.Tag;
            Console.WriteLine(tag.UID);
        }
    }
}
