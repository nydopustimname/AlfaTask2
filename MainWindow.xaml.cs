using AlfaTask2.ViewModels;

using System.Threading;
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
using AutoItX3Lib;

namespace AlfaTask2
{
    
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new UserViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var VP = new VkParser();

            string s= VP.ParseAsync(textBox1.Text);
            textBox2.Text = s;
            UpdCheck(sender, e);
        }
        
        private void UpdCheck(object s, RoutedEventArgs e)
        {
            if ((bool)Check.IsChecked && textBox2.Text=="Invalid link")
            {
                
                Thread.Sleep(3000);
                var upd = new AutoUpd();
                    upd.Upd();
            }
        }
        private void UpdButton_Click (object s, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            
        }

        private void Text_Changed(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
