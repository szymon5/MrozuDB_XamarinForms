using MrozuDB.Model;
using MrozuDB.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MrozuDB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Films : ContentPage
    {
        public FilmsViewModel FilmsViewModel
        {
            get { return BindingContext as FilmsViewModel; }
            set { BindingContext = value; }
        }
        public Films()
        {
            BindingContext = new FilmsViewModel(new PageService());
            InitializeComponent();
            FilmsViewModel.DisplayFilmsListCommand.Execute(null);
        }

        private void LVFilms_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            FilmsViewModel.SelectedFilmCommand.Execute(e.SelectedItem);
        }
    }
}