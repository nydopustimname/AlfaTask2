using System.Threading;
using System.Windows;

namespace AlfaTask2
{
  
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
        }

       private void UpdButton_Click(object s, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var VP = new VkParser();

            string s= VP.ParseAsync(textBox1.Text);
            textBox2.Text = s;
        }

       
    }
}
