using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using listview.Models;
using System.Collections.ObjectModel;

namespace listview
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Contact> contacts;
        public MainPage()
        {
            InitializeComponent();
            
           contacts= new ObservableCollection<Contact>
            {
                new Contact{name="Saim",status="Hello I am their",imageUrl="http://lorempixel.com/100/100/people/1"},
                new Contact{name="Naveed",status="Bussy",imageUrl="http://lorempixel.com/100/100/people/2"},
                new Contact{name="Furqan",status="Active",imageUrl="http://lorempixel.com/100/100/people/3"},
                new Contact{name="Muneeb",status="School",imageUrl="http://lorempixel.com/100/100/people/4"}  
            };
            list.ItemsSource = contacts;
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuitem = sender as MenuItem;
            var contact = menuitem.CommandParameter as Contact;
            DisplayAlert("Call", contact.name, "Ok");
        }

        private void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            contacts.Remove(contact);
        }
    }
}
