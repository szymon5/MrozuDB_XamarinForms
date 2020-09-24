using LibVLCSharp.Forms.Shared;
using LibVLCSharp.Shared;
using Microsoft.WindowsAzure.Storage;
using MrozuDB.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MrozuDB.ViewModel
{
    public class FilmTrailerViewModel
    {
        //private string connectionString = "DefaultEndpointsProtocol=https;AccountName=imagestorageforxamarin;AccountKey=CLnEpuhMkTZVqh+Y/SESouUfpqBcdURcActv2atSpq1CFI8eGI9/qDgOPyKrbQjvj1R5EShdCK+movNZlNApxw==;EndpointSuffix=core.windows.net";
        //private string CloudContainer = "imagecontainer";
        public ICommand PlayFilmTrailerCommand { get; private set; }
        public ICommand StopFilmTrailerAndBackToTheFilmDetailsCommand { get; private set; }

        public IPageService pageService;
        public FilmTrailerViewModel(IPageService pageService)
        {
            this.pageService = pageService;
            PlayFilmTrailerCommand = new Command<MediaPlayerElement>((v) => PlayFilmTrailer(v));
            StopFilmTrailerAndBackToTheFilmDetailsCommand = new Command<MediaPlayerElement>(async (v) => await StopFilmTrailerAndBackToTheFilmDetails(v));
        }
        private void PlayFilmTrailer(MediaPlayerElement mediaPlayerElement)
        {
            Core.Initialize();

            LibVLC libVLC = new LibVLC();

            Media media = new Media(libVLC, Lists.MP4.FilmsAndGames[0][Help.filmTitle], FromType.FromLocation);

            mediaPlayerElement.MediaPlayer = new MediaPlayer(media) { EnableHardwareDecoding = true };

            mediaPlayerElement.MediaPlayer.Play();

            //var account = CloudStorageAccount.Parse(connectionString);
            //var client = account.CreateCloudBlobClient();
            //var container = client.GetContainerReference(CloudContainer);
            //await container.CreateIfNotExistsAsync();
            //var blockBlob = container.GetBlockBlobReference(Help.PrepareMP4(Help.filmTitle));
            //using (var fileStream = new MemoryStream())
            //{
            //    await blockBlob.DownloadToStreamAsync(fileStream);
            //    string trailerURI = blockBlob.Uri.OriginalString;

            //    LibVLC libVLC = new LibVLC();

            //    Media media = new Media(libVLC, trailerURI, FromType.FromLocation);

            //    mediaPlayerElement.MediaPlayer = new MediaPlayer(media) { EnableHardwareDecoding = true };
            //    mediaPlayerElement.IsVisible = true;

            //    indicator.IsVisible = false;
            //    indicator.IsRunning = false;

            //    mediaPlayerElement.MediaPlayer.Play();
            //}


        }
        private async Task StopFilmTrailerAndBackToTheFilmDetails(MediaPlayerElement mediaPlayerElement)
        {
            mediaPlayerElement.MediaPlayer.Stop();
            mediaPlayerElement.MediaPlayer = null;
            await pageService.PopAsync();
        }
    }
}
