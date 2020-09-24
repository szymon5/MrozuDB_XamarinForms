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
    public class FilmsViewModelTests
    {
        private FilmsViewModel _filmsViewModel;
        private Mock<IPageService> _pageService;

        [SetUp]
        public void SetUp()
        {
            _pageService = new Mock<IPageService>();
            _filmsViewModel = new FilmsViewModel(_pageService.Object);
        }
        [Test]
        public void GetListOfFilms_test()
        {
            var films = new ObservableCollection<Film>();
            _filmsViewModel.DisplayFilmsListCommand.Execute(null);
            CollectionAssert.AreEqual(films, _filmsViewModel.Films);
        }

        [Test]
        public void FilmSelected_Test()
        {
            var film = new Film();
            _filmsViewModel.Films.Add(film);
            _filmsViewModel.SelectedFilmCommand.Execute(film);

            Assert.IsNull(_filmsViewModel.SelectedFilm);
        }
    }
}
