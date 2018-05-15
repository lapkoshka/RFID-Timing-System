using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DeviceManager manager = new DeviceManager();

        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new Registration();
            manager.ConnectDevice();
            manager.TagCatch += manager_tagCatchHandler;
        }

        static void manager_tagCatchHandler(object sender, TagCatchEventArgs e)
        {
            RFIDTag tag = e.Tag;
            Console.WriteLine(tag.UID);
        }
    }
}
