using MrozuDB.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MrozuDB.ViewModel
{
    public class GamesDetailsViewModel
    {
        public ObservableCollection<GameDetailsInfo> GameDetailsInfo { get; private set; } = new ObservableCollection<GameDetailsInfo>();

        private IPageService pageService;
        public ICommand GetListOfGamesDetailsCommand { get; private set; }
        public ICommand SeeGameTrailerCommand { get; private set; }

        private string gameID;
        public GamesDetailsViewModel(IPageService pageService,string gameID)
        {
            this.pageService = pageService;
            this.gameID = gameID;
            GetListOfGamesDetailsCommand = new Command(GetListOfGamesDetails);
            SeeGameTrailerCommand = new Command(async () => await SeeGameTrailer());
        }
        private async void GetListOfGamesDetails()
        {
            var json = JsonConvert.DeserializeObject<List<GameDetailsInfo>>(await DataBaseConnection.GetDetails(URL.GAME_DETAILS, "game_id", gameID)).ToArray();

            for (int i = 0; i < json.Length; i++) GameDetailsInfo.Add(json[i]);
        }
        private async Task SeeGameTrailer()
        {
            Help.trailerSource = await pageService.DisplayActionSheet("Choose the source that trailer will be loaded from",
                                                 "Cancel", null,
                                                 "Video",
                                                 "YouTube");
            if (Help.trailerSource == "Video") 
                await pageService.PushAsync(new GameTrailer());
            else if (Help.trailerSource == "YouTube")
                await Launcher.OpenAsync(Lists.YouTube.RecordsFilmsGames[2][Help.gameTitle]);
            Help.trailerSource = string.Empty;
        }
    }
}
