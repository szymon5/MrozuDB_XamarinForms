using LibVLCSharp.Forms.Shared;
using LibVLCSharp.Shared;
using Microsoft.WindowsAzure.Storage;
using MrozuDB.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MrozuDB.ViewModel
{
    public class GameTrailerViewModel
    {
        //private string connectionString = "DefaultEndpointsProtocol=https;AccountName=imagestorageforxamarin;AccountKey=CLnEpuhMkTZVqh+Y/SESouUfpqBcdURcActv2atSpq1CFI8eGI9/qDgOPyKrbQjvj1R5EShdCK+movNZlNApxw==;EndpointSuffix=core.windows.net";
        //private string CloudContainer = "imagecontainer";
        public ICommand PlayGameTrailerCommand { get; private set; }
        public ICommand StopGameTrailerAndBackToTheGameDetailsCommand { get; private set; }

        public IPageService pageService;

        public GameTrailerViewModel(IPageService pageService)
        {
            this.pageService = pageService;
            PlayGameTrailerCommand = new Command<MediaPlayerElement>((v) => PlayGameTrailer(v));
            StopGameTrailerAndBackToTheGameDetailsCommand = new Command<MediaPlayerElement>(async v => await StopGameTrailerAndBackToTheGameDetails(v));
        }
        private void PlayGameTrailer(MediaPlayerElement mediaPlayerElement)
        {
            Core.Initialize();

            LibVLC libVLC = new LibVLC();

            Media media = new Media(libVLC, Lists.MP4.FilmsAndGames[1][Help.gameTitle], FromType.FromLocation);

            mediaPlayerElement.MediaPlayer = new MediaPlayer(media) { EnableHardwareDecoding = true };

            mediaPlayerElement.MediaPlayer.Play();

            //var account = CloudStorageAccount.Parse(connectionString);
            //var client = account.CreateCloudBlobClient();
            //var container = client.GetContainerReference(CloudContainer);
            //await container.CreateIfNotExistsAsync();
            //var blockBlob = container.GetBlockBlobReference(Help.PrepareMP4(Help.gameTitle));
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
        private async Task StopGameTrailerAndBackToTheGameDetails(MediaPlayerElement mediaPlayerElement)
        {
            mediaPlayerElement.MediaPlayer.Stop();
            mediaPlayerElement.MediaPlayer = null;
            await pageService.PopAsync();
        }
    }
}
