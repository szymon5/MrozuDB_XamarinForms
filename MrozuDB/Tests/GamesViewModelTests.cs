using Moq;
using MrozuDB.Model;
using MrozuDB.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MrozuDB.Tests
{
    public class GamesViewModelTests
    {
        private GamesViewModel _gamesViewModel;
        private Mock<IPageService> _pageService;
        [SetUp]
        public void Setup()
        {
            _pageService = new Mock<IPageService>();
            _gamesViewModel = new GamesViewModel(_pageService.Object);
        }

        [Test]
        public void GetListOfGames_Test()
        {
            var expected = new ObservableCollection<Game>();
            _gamesViewModel.DisplayGamesListCommand.Execute(null);
            CollectionAssert.AreEqual(expected, _gamesViewModel.Games);
        }

        [Test]
        public void GameSelected_Test()
        {
            var game = new Game();
            _gamesViewModel.Games.Add(game);
            _gamesViewModel.SelectedGameCommand.Execute(game);

            var id = Help.filmID;
            var title = Help.filmTitle;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(game.game_id, id);
                Assert.AreEqual(game.game_title, title);
                Assert.IsNull(_gamesViewModel.SelectedGame);
            });
        }
    }
}
