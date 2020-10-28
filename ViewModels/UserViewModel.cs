using System;
using System.Collections.Generic;
using System.Printing;
using System.Text;
using System.Windows;

namespace AlfaTask2.ViewModels
{
   public class UserViewModel:DependencyObject
    {
       
        public string Filter
        {
            get { return (string)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }

        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.Register("Filterilter", typeof(string), typeof(UserViewModel), new PropertyMetadata(""));




        public string Name { get; set; }
        public string SName { get; set; }
        public string Status { get; set; }

        
    }
}
