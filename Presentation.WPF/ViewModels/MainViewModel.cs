using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Presentation.WPF.ViewModels.Base;
using Presentation.WPF.Views;

namespace Presentation.WPF.ViewModels
{
    public class MainViewModel : ObservableObject
    {

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
            _registrationPage = new RegistrationPage() { DataContext = _registrationViewModel };

            //Меняй это поле для навигации
            ActivePage = _registrationPage;
        }
        
    }
}
