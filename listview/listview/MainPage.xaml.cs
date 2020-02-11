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
        private IEnumerable<Contact> ss;
        public MainPage()
        {
            InitializeComponent();

            contacts = getContact();
            list.ItemsSource = contacts;
        }
        ObservableCollection<Contact> getContact()
        {
            var myContact = new ObservableCollection<Contact>
            {
                new Contact{name="Saim",status="Hello I am their",imageUrl="http://lorempixel.com/100/100/people/1"},
                new Contact{name="Naveed",status="Bussy",imageUrl="http://lorempixel.com/100/100/people/2"},
                new Contact{name="Furqan",status="Active",imageUrl="http://lorempixel.com/100/100/people/3"},
                new Contact{name="Muneeb",status="School",imageUrl="http://lorempixel.com/100/100/people/4"}
            };
            
             return myContact;
            
        }
        IEnumerable<Contact> getsearch(string searchtext = null)
        {
            var searchlist = new List<Contact>
            {
                new Contact{name="Saim",status="Hello I am their",imageUrl="http://lorempixel.com/100/100/people/1"},
                new Contact{name="Naveed",status="Bussy",imageUrl="http://lorempixel.com/100/100/people/2"},
                new Contact{name="Furqan",status="Active",imageUrl="http://lorempixel.com/100/100/people/3"},
                new Contact{name="Muneeb",status="School",imageUrl="http://lorempixel.com/100/100/people/4"}
            };
            if (string.IsNullOrWhiteSpace(searchtext))
            {
                return searchlist;
            }
            return searchlist.Where(c => c.name.StartsWith(searchtext));
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

        private void list_Refreshing(object sender, EventArgs e)
        {
            contacts = getContact();
            list.ItemsSource = contacts;
            list.EndRefresh();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ss= getsearch(e.NewTextValue);
            list.ItemsSource = ss;
        }

       async private void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem==null)
            {
                return;
            }
            var contact = e.SelectedItem as Contact;
            await Navigation.PushAsync(new DetailPage(contact));
            list.SelectedItem = null;
        } 
    }
}
