using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using System.Text;
using System.IO;

namespace Doodle
{
    public partial class ADD : PhoneApplicationPage
    {
        public ADD()
        {
            InitializeComponent();
        }

        private void AppBar_cancel_click(object sender, EventArgs e)
        {
            MessageBox.Show("CANCEL SAVING DOODLE");
            navigateBack();
        }

        private void AppBar_save_click(object sender, EventArgs e)
        { 
            //title should be saved here
            var appStorage = IsolatedStorageFile.GetUserStoreForApplication();
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.Year);
            sb.Append("_");
            sb.Append(String.Format("{0:00}",DateTime.Now.Month));
            sb.Append("_");
            sb.Append(String.Format("{0:00}", DateTime.Now.Day));
            sb.Append("_");
            sb.Append(String.Format("{0:00}", DateTime.Now.Hour));
            sb.Append("_");
            sb.Append(String.Format("{0:00}", DateTime.Now.Minute));
            sb.Append("_");
            sb.Append(String.Format("{0:00}", DateTime.Now.Second));

            sb.Append("_");
            using (var fileStream = appStorage.OpenFile(sb.ToString(), System.IO.FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fileStream))
                {
                    sw.WriteLine(EDITtextbox.Text);
                }
            }
            
            navigateBack();
        }
        private void navigateBack()
        {
            NavigationService.Navigate(new Uri("/Doodle;component/MainPage.xaml",UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            EDITtextbox.Focus();
            
        }
    }
}
