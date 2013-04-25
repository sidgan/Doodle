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
    public partial class MainPage : PhoneApplicationPage
    {
        string location = " ";
        string temp = " ";
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

     
        private void AppBar_Add_Click(object sender, EventArgs e)
        {

            
            //take input for title 
            //use canvas
            //takeTitle();
            //NavigationService.Navigate(new Uri("/Doodle;component/ADD.xaml", UriKind.Relative));
            //we have the title 
           // if(titlebox.)
           // if (titlebox.Text != "")
           // {
                //make sure we have the title only then go to the other page
                //so on double tap get the input and then navigate

              //  NavigationService.Navigate(new Uri("/Doodle;component/ADD.xaml", UriKind.Relative));
           // }
            //else
            //{
            //    MessageBox.Show("PLEASE ENTER TITLE");
            //}
            NavigationService.Navigate(new Uri("/Doodle;component/ADD.xaml", UriKind.Relative)); 
        }
        //private void takeTitle()
        //{
        //    titlecanvas.Visibility = System.Windows.Visibility.Collapsed;
        //    //make sure that the user enters the title here 
        //    //only then make sure that the title is saved
        //    location = titlebox.Text;
        //    MessageBox.Show("title in taketitle" + location);
        //}

        

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            bindList();
        }

        private void bindList()
        {
            var appStorage = IsolatedStorageFile.GetUserStoreForApplication();
            string[] fileList = appStorage.GetFileNames();
           
            List<Doodle> doodles = new List<Doodle>();
            foreach (string file in fileList)
            {
                //retrive file
                string fileName = file;
                //pluck out date and time parts
               
                string year = file.Substring(0, 4);
                string month = file.Substring(5, 2);
                string day = file.Substring(8, 2);
                string hour = file.Substring(11, 2);
                string minute = file.Substring(14, 2);
                string second = file.Substring(17, 2);
                
              

              DateTime dateCreated = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), int.Parse(hour), int.Parse(minute), int.Parse(second));
                
                //parse out the location 
               // location = "TITLE OF DOODLE";
                //need a different title for each doodle 
                //save code in location variable
              location = "DOODLE";
              //MessageBox.Show("the title is in bindlist " + location);
                doodles.Add(new Doodle() {Location = location , DateCreated= dateCreated.ToLongDateString(), FileName = fileName });
               
                //not working

            }
            doodleListBox.ItemsSource = doodles;
        }

        private void AppBar_help_click(object sender, EventArgs e)
        {
            HELP_CANVAS.Visibility = System.Windows.Visibility.Visible;
            //MessageBox.Show("helpppp");
        }

        private void doodleList_Click(object sender, RoutedEventArgs e)
        {
            HyperlinkButton clickedLink = (HyperlinkButton)sender;
            string uri = String.Format("/Doodle;component/VIEWEDIT.xaml?id={0}",clickedLink.Tag);
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }

        private void closeHELP_Click(object sender, RoutedEventArgs e)
        {
            HELP_CANVAS.Visibility = System.Windows.Visibility.Collapsed;
        }

        //private void titlebox_DoubleTap(object sender, GestureEventArgs e)
        //{
        //    titlebox.Text = "new";
        //    titlebox.Focus();
        //    if (titlebox.Text !="")
        //    {
        //        MessageBox.Show("we have text in if");
        //        location = titlebox.Text;
                
                
        //    }
        //    else
        //    {
        //        MessageBox.Show("in else");
        //         location = titlebox.Text;
        //    }

        //}

        private void titleclose_Click(object sender, RoutedEventArgs e)
        {
        //   //temp = "TITLE:" +titlebox.Text;
        //    MessageBox.Show(temp);
        //    titlecanvas.Visibility = System.Windows.Visibility.Collapsed;
        //    bindList();
        //    //NavigationService.Navigate(new Uri("/Doodle;component/ADD.xaml", UriKind.Relative));
           
        }

        private void savetitle_Click(object sender, RoutedEventArgs e)
        {
        //    //when save button is clicked then take the title form the user
        //    temp = titlebox.Text;
        //    MessageBox.Show(temp);
        //    bindList();
        }



    }

}
