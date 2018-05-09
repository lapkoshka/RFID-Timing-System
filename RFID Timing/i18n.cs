using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID_Timing
{
    class I18n
    {
        private string lang;
        private Dictionary<string, string> tranlations;

        public I18n()
        {
            lang = "ru";
        }

        public I18n(string lang)
        {
            this.lang = lang;
            loadTranslations();
        }

        private void loadTranslations()
        {
            //TODO: add assertion test, dictionaries should be the same
            //
            if (this.lang == "ru")
            {
                this.tranlations = this.getRuDict();
            }
            else if (this.lang == "en")
            {
                this.tranlations = this.getEnDict();
            }
        }

        private Dictionary<string, string> getRuDict()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("reg.regTitle", "Регистрация");
            dict.Add("reg.idColumnName", "ID");
            dict.Add("reg.nameColumnName", "ФИО");
            dict.Add("reg.classColumnName", "Класс");
            dict.Add("reg.tagColumnName", "Метка");
            dict.Add("reg.confTitle", "Конфигурация гонки");
            dict.Add("reg.mainInfoBoxText", "Основная информация");
            dict.Add("reg.matchNameText", "Имя гонки");
            dict.Add("reg.matchTimeText", "Время гонки");
            dict.Add("reg.raceCountText", "Количество заездов");
            dict.Add("reg.addLapsText", "Дополнительные круги");
            dict.Add("reg.addInfoText", "Дополнительная информация");
            dict.Add("reg.regButtonText", "Завершить регистрацию");

            return dict;
        }

        private Dictionary<string, string> getEnDict()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("reg.regTitle", "Registration");
            dict.Add("reg.idColumnName", "ID");
            dict.Add("reg.nameColumnName", "Full name");
            dict.Add("reg.classColumnName", "Class");
            dict.Add("reg.tagColumnName", "EPC Tag");
            dict.Add("reg.confTitle", "Match configuration");
            dict.Add("reg.mainInfoBoxText", "Main info");
            dict.Add("reg.matchNameText", "Match name");
            dict.Add("reg.matchTimeText", "Match time");
            dict.Add("reg.raceCountText", "Race count");
            dict.Add("reg.addLapsText", "Additional laps");
            dict.Add("reg.addInfoText", "Additional info");
            dict.Add("reg.regButtonText", "Finish registration");

            return dict;
        }

        public string get(string key)
        {
            try
            {
                return this.tranlations[key];
            }
            catch(KeyNotFoundException)
            {
                //TODO: ERROR ENUM
                return "NO_TRANSLATE";
            }
        }
    }
}
