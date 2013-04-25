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
using System.IO;

namespace Doodle
{
    public partial class VIEWEDIT : PhoneApplicationPage
    {
        private string fileName = " ";
        public VIEWEDIT()
        {
            InitializeComponent();
        }

        private void AppBar_BACK_click(object sender, EventArgs e)
        {
            navigateBack();
        }

        private void AppBar_SAVE_click(object sender, EventArgs e)
        {

//SAVE
            if (editTextBox.Visibility == System.Windows.Visibility.Visible)
            {

                var appStorage = IsolatedStorageFile.GetUserStoreForApplication();
                using (var file = appStorage.OpenFile(fileName, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(file))
                    {
                        sw.WriteLine(editTextBox.Text);
                    }
                }



                DisplayTextBlock.Text = editTextBox.Text;
                DisplayTextBlock.Visibility = System.Windows.Visibility.Visible;
                editTextBox.Visibility = System.Windows.Visibility.Collapsed;
                

            }
        }

        private void AppBar_EDIT_click(object sender, EventArgs e)
        {
            //swap between view and edit version of file
            if (DisplayTextBlock.Visibility == System.Windows.Visibility.Visible)
            {
                editTextBox.Text = DisplayTextBlock.Text;
                DisplayTextBlock.Visibility = System.Windows.Visibility.Collapsed;
                editTextBox.Visibility = System.Windows.Visibility.Visible;
                editTextBox.Focus();
            }
        }

        private void AppBar_DELETE_click(object sender, EventArgs e)
        {
            //CONFIRM.Visibility = System.Windows.Visibility.Visible;
            MessageBox.Show("DOODLE BEING DELETED!!!!");
            var appStorage = IsolatedStorageFile.GetUserStoreForApplication();
            appStorage.DeleteFile(fileName);
            navigateBack();
        }

        private void navigateBack()
        {
            NavigationService.Navigate(new Uri("/Doodle;component/MainPage.xaml", UriKind.Relative));
        }
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
             fileName = NavigationContext.QueryString["id"];
            var appStorage = IsolatedStorageFile.GetUserStoreForApplication();
            using (var file = appStorage.OpenFile(fileName, System.IO.FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    DisplayTextBlock.Text = sr.ReadToEnd();
                }

            }
        }

        private void DELETEbutt_Click(object sender, RoutedEventArgs e)
        {
            navigateBack();
           

            //code for confirming deletion of note
        }

        private void CANCELbutt_Click(object sender, RoutedEventArgs e)
        {
            //cancel deleting note
            //CONFIRM.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void DisplayTextBlock_Hold(object sender, GestureEventArgs e)
        {
            //delete when held for long time
            MessageBox.Show("DOODLE DELETED");
            var appStorage = IsolatedStorageFile.GetUserStoreForApplication();
            appStorage.DeleteFile(fileName);
            navigateBack();
                

        }
    }
}
