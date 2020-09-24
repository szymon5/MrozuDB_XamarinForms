using MrozuDB.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MrozuDB.ViewModel
{
    public class FilmsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Film> Films { get; private set; } = new ObservableCollection<Film>();

        private IPageService pageService;
        public ICommand DisplayFilmsListCommand { get; private set; }
        public ICommand SelectedFilmCommand { get; private set; }

        private static Film _selectedFilm;

        public Film SelectedFilm
        {
            get
            {
                return _selectedFilm;
            }
            set
            {
                if (_selectedFilm == value) return;
                _selectedFilm = value;
                OnProrertyChanged();
            }
        }
        public FilmsViewModel(IPageService pageService)
        {
            this.pageService = pageService;
            DisplayFilmsListCommand = new Command(async () => await GetListOfFilms());
            SelectedFilmCommand = new Command<Film>(async sf => await FilmSelected(sf));
        }
        

        private async Task GetListOfFilms()
        {
            //var film = await App.MobileServiceClient.GetTable<Film>().ToListAsync();
            //for (int i = 0; i < film.Count; i++) Films.Add(film[i]);

            var response = await DataBaseConnection.GetList(URL.FILMS);
            var json = JsonConvert.DeserializeObject<List<Film>>(response).ToArray();

            for (int i = 0; i < json.Length; i++) Films.Add(json[i]);
        }
        private async Task FilmSelected(Film film)
        {
            if (film == null) return;
            string filmID = film.film_id;
            Help.filmTitle = film.film_title;
            SelectedFilm = null;
            await pageService.PushAsync(new FilmDetails(filmID));
        }
        protected void OnProrertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
