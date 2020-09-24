using Moq;
using MrozuDB.Model;
using MrozuDB.ViewModel;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MrozuDB.Tests
{
    public class FilmDetailsViewModelTests
    {
        private FilmsDetailsViewModel _filmDetailsViewModel;
        private Mock<IPageService> _pageService;
        private Mock<string> _filmID;

        [SetUp]
        public void SetUp()
        {
            _pageService = new Mock<IPageService>();
            _filmID = new Mock<string>();
            _filmDetailsViewModel = new FilmsDetailsViewModel(_pageService.Object,_filmID.Object);
        }

        [Test]
        public void GetListOfFilmsDetails_Test()
        {
            var expected = new ObservableCollection<FilmDetailsInfo>();
            _filmDetailsViewModel.GetListOfFilmsDetailsCommand.Execute(null);
            CollectionAssert.AreEqual(expected, _filmDetailsViewModel.FilmDetailsInfo);
        }

        [Test]
        public void SeeFilmTrailer_Test()
        {
            _filmDetailsViewModel.SeeFilmTrailerCommand.Execute(null);
            Assert.IsEmpty(Help.trailerSource);
        }
    }
}
