using MrozuDB.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MrozuDB.ViewModel
{
    public class GamesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Game> Games { get; set; } = new ObservableCollection<Game>();

        private readonly IPageService pageService;
        public ICommand DisplayGamesListCommand { get; private set; }
        public ICommand SelectedGameCommand { get; private set; }

        private Game _selectedGame;
        public Game SelectedGame
        {
            get
            {
                return _selectedGame;
            }
            set
            {
                if (_selectedGame == value) return;

                _selectedGame = value;

                OnProrertyChanged();
            }
        }
        public GamesViewModel(IPageService pageService)
        {
            this.pageService = pageService;
            DisplayGamesListCommand = new Command(async () => await GetListOfGames());
            SelectedGameCommand = new Command<Game>(async sg => await GameSelected(sg));
        }

        private async Task GetListOfGames()
        {
            //var game = await App.MobileServiceClient.GetTable<Game>().ToListAsync();
            //for (int i = 0; i < game.Count; i++) Games.Add(game[i]);

            var response = await DataBaseConnection.GetList(URL.GAMES);

            var json = JsonConvert.DeserializeObject<List<Game>>(response).ToArray();
            for (int i = 0; i < json.Length; i++) Games.Add(json[i]);
        }
        private async Task GameSelected(Game game)
        {
            if (game == null) return;
            string gameID = game.game_id;
            SelectedGame = null;
            await pageService.PushAsync(new GameDetails(gameID));
        }
        protected void OnProrertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
