using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.WPF.ViewModels.Base;
using System.Collections.ObjectModel;
using Presentation.WPF.Observables;
using System.Windows.Input;

namespace Presentation.WPF.ViewModels
{
    public class RacePageViewModel : ObservableObject
    {
        public event EventHandler RaceStart;
        #region Properties;
        private ObservableCollection<RankingObservable> _ranking;
        public ObservableCollection<RankingObservable> Ranking
        {
            get { return _ranking; }
            set
            {
                OnPropertyChanging(() => Ranking);
                _ranking = value;
                OnPropertyChanged(() => Ranking);
            }
        }


        #endregion

        public ICommand StartHandler { get; set; }
        public RacePageViewModel()
        {
            StartHandler = new AutoCanExecuteCommandWrapper(
                new DelegateCommand(RaceStartExecute, RaceStartCanExecute));
        }

        private void RaceStartExecute(object param)
        {
            EventArgs e = new EventArgs();
            RaceStart(this, e);
        }

        private bool RaceStartCanExecute(object param)
        {
            return true;
        }

    }
}
