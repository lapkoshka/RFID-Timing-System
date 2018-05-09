using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFID_Timing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            EnableForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //try to connect with device
            //try to fill datagrid from local db

        }

        private void EnableForm()
        {
            string lang = "ru";
            I18n translations = new I18n(lang);

            regTitle.Text = translations.get("reg.regTitle");
            id.HeaderText = translations.get("reg.idColumnName");
            name.HeaderText = translations.get("reg.nameColumnName");
            classname.HeaderText = translations.get("reg.classColumnName");
            tag.HeaderText = translations.get("reg.tagColumnName");
            confTitle.Text = translations.get("reg.confTitle");
            mainInfoBox.Text = translations.get("reg.mainInfoBoxText");
            matchName.Text = translations.get("reg.matchNameText");
            matchTime.Text = translations.get("reg.matchTimeText");
            raceCount.Text = translations.get("reg.raceCountText");
            addLaps.Text = translations.get("reg.addLapsText");
            addInfo.Text = translations.get("reg.addInfoText");
            regButton.Text = translations.get("reg.regButtonText");
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
