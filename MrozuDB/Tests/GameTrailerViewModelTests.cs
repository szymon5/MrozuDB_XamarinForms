using LibVLCSharp.Forms.Shared;
using Moq;
using MrozuDB.Model;
using MrozuDB.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MrozuDB.Tests
{
    public class GameTrailerViewModelTests
    {
        private GameTrailerViewModel _gameTrailerViewModel;
        private Mock<IPageService> _pageService;
        [SetUp]
        public void SetUp()
        {
            _pageService = new Mock<IPageService>();
            _gameTrailerViewModel = new GameTrailerViewModel(_pageService.Object);
        }

        [Test]
        public void PlayGameTrailer_Test()
        {
            var mediaPlayerElement = new MediaPlayerElement();
            var indicator = new ActivityIndicator();
            _gameTrailerViewModel.PlayGameTrailerCommand.Execute(mediaPlayerElement);

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(mediaPlayerElement);
                Assert.IsNotNull(indicator);
            });
        }

        [Test]
        public void StopGameTrailerAndBackToTheGameDetails_Test()
        {
            MediaPlayerElement mediaPlayerElement = new MediaPlayerElement();
            _gameTrailerViewModel.StopGameTrailerAndBackToTheGameDetailsCommand.Execute(mediaPlayerElement);
            Assert.IsNull(mediaPlayerElement.MediaPlayer);
        }
    }
}
