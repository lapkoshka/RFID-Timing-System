using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHF;
using System.Diagnostics;

namespace RFID_Timing
{
    public partial class Form1 : Form
    {
        DeviceManager manager = new DeviceManager();

        public Form1()
        {
            InitializeComponent();
            manager.connectDevice();
            manager.tagCatch += manager_tagCatchHandler;

            //TODO: try to fill datagrid from local db
        }

        static void manager_tagCatchHandler(object sender, TagCatchEventArgs e)
        {
            RFIDTag tag = e.Tag;
            Console.WriteLine(tag.UID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            manager.start();
        }

    }
}
