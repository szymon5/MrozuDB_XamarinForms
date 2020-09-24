using LibVLCSharp.Forms.Shared;
using LibVLCSharp.Shared;
using Microsoft.WindowsAzure.Storage;
using MrozuDB.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MrozuDB.ViewModel
{
    public class FilmsDetailsViewModel
    {
        public ObservableCollection<FilmDetailsInfo> FilmDetailsInfo { get; private set; } = new ObservableCollection<FilmDetailsInfo>();

        private IPageService pageService;
        public ICommand GetListOfFilmsDetailsCommand { get; private set; }
        public ICommand SeeFilmTrailerCommand { get; private set; }

        private string filmID;
        public FilmsDetailsViewModel(IPageService pageService, string filmID)
        {
            this.pageService = pageService;
            this.filmID = filmID;
            GetListOfFilmsDetailsCommand = new Command(GetListOfFilmsDetails);
            SeeFilmTrailerCommand = new Command(async () => await SeeFilmTrailer());
        }
        private async void GetListOfFilmsDetails()
        {
            var json = JsonConvert.DeserializeObject<List<FilmDetailsInfo>>(
                await DataBaseConnection.GetDetails(URL.FILM_DETAILS, "film_id", filmID)).ToArray();

            for (int i = 0; i < json.Length; i++) FilmDetailsInfo.Add(json[i]);
        }
        private async Task SeeFilmTrailer()
        {
            Help.trailerSource = await pageService.DisplayActionSheet("Choose the source that trailer will be loaded from",
                                                    "Cancel", null,
                                                    "Video",
                                                    "YouTube");
            if(Help.trailerSource == "Video")
                await pageService.PushAsync(new FilmTrailer());
            else if(Help.trailerSource == "YouTube")
                await Launcher.OpenAsync(Lists.YouTube.RecordsFilmsGames[1][Help.filmTitle]);
            Help.trailerSource = string.Empty;
        }
    }
}
