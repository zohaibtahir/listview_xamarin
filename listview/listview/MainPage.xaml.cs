using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using listview.Models;

namespace listview
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            list.ItemsSource = new List<Contact>
            {
                new Contact{name="Saim",status="Hello I am their",imageUrl="http://lorempixel.com/100/100/people/1"},
                new Contact{name="Naveed",status="Bussy",imageUrl="http://lorempixel.com/100/100/people/2"},
                new Contact{name="Furqan",status="Active",imageUrl="http://lorempixel.com/100/100/people/3"},
                new Contact{name="Muneeb",status="School",imageUrl="http://lorempixel.com/100/100/people/4"}  
            };
        }

        private void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contact = e.SelectedItem as Contact;
            DisplayAlert("Selected", contact.name, "ok");
        }

        private void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var contact = e.Item as Contact;
            DisplayAlert("Tapped", contact.name, "Ok");
        }
    }
}
