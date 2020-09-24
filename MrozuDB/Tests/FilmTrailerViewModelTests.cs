using LibVLCSharp.Forms.Shared;
using LibVLCSharp.Shared;
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
    public class FilmTrailerViewModelTests
    {
        private FilmTrailerViewModel _filmTrailerViewModel;
        private Mock<IPageService> _pageService;
        [SetUp]
        public void SetUp()
        {
            _pageService = new Mock<IPageService>();
            _filmTrailerViewModel = new FilmTrailerViewModel(_pageService.Object);
        }

        [Test]
        public void PlayFilmTrailer_Test()
        {
            var mediaPlayerElement = new MediaPlayerElement();
            var indicator = new ActivityIndicator();
            _filmTrailerViewModel.PlayFilmTrailerCommand.Execute(mediaPlayerElement);

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(mediaPlayerElement);
                Assert.IsNotNull(indicator);
            });
        }

        [Test]
        public void StopFilmTrailerAndBackToTheFilmDetails_Test()
        {
            MediaPlayerElement mediaPlayerElement = new MediaPlayerElement();
            _filmTrailerViewModel.StopFilmTrailerAndBackToTheFilmDetailsCommand.Execute(mediaPlayerElement);
            Assert.IsNull(mediaPlayerElement.MediaPlayer);
        }
    }
}
