using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.WPF.ViewModels.Base;

namespace Presentation.WPF.Observables
{
    public class RankingObservable : ObservableObject
    {
        private string _place;
        public string Place
        {
            get { return _place; }
            set
            {
                if (value != _place)
                {
                    OnPropertyChanging(() => Place);
                    _place = value;
                    OnPropertyChanged(() => Place);
                }

            }
        }

        private string _shortName;
        public string ShortName
        {
            get { return _shortName; }
            set
            {
                if (value != _shortName)
                {
                    OnPropertyChanging(() => ShortName);
                    _shortName = value;
                    OnPropertyChanged(() => ShortName);
                }

            }
        }

        private string _laps;
        public string Laps
        {
            get { return _laps; }
            set
            {
                if (value != _laps)
                {
                    OnPropertyChanging(() => Laps);
                    _laps = value;
                    OnPropertyChanged(() => Laps);
                }

            }
        }

        private string _uid;
        public string UID
        {
            get { return _uid; }
            set
            {
                if (value != _laps)
                {
                    OnPropertyChanging(() => UID);
                    _uid = value;
                    OnPropertyChanged(() => UID);
                }

            }
        }

    }
}
