using LibVLCSharp.Forms.Shared;
using Moq;
using MrozuDB.Model;
using MrozuDB.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.ObjectModel;
using System.Text;

namespace MrozuDB.Tests
{
    public class GamesDetailsViewModelTests
    {
        private GamesDetailsViewModel _gamesDetailsViewModel;
        private Mock<IPageService> _pageService;
        private Mock<string> _gameID;

        [SetUp]
        public void SetUp()
        {
            _pageService = new Mock<IPageService>();
            _gameID = new Mock<string>();
            _gamesDetailsViewModel = new GamesDetailsViewModel(_pageService.Object,_gameID.Object);
        }

        [Test]
        public void GetListOfGamesDetails_Test()
        {
            var expected = new ObservableCollection<GameDetailsInfo>();
            _gamesDetailsViewModel.GetListOfGamesDetailsCommand.Execute(null);
            CollectionAssert.AreEqual(expected, _gamesDetailsViewModel.GameDetailsInfo);
        }

        [Test]
        public void SeeGameTrailer_Test()
        {
            _gamesDetailsViewModel.SeeGameTrailerCommand.Execute(null);
            Assert.IsEmpty(Help.trailerSource);
        }
    }
}
