using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JEC.MoviesDirectory.MoviesController;

namespace JEC.MovieDirectoryTests
{
    [TestClass]
    public class MovieControllerTests
    {
        [TestMethod]
        public void MovieGetSuccess()
        {
            var controller = new MoviesController();

            var response = controller.Get("Titanic",1)
            var contentResult = response asOkNegotiatedContentResult<SearchResult>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNulle(contentResult.Content);
            Asset.AreEqual("Titanic",1, contentResult.Content.SearchResult);
        }


        [TestMethod]
        public void MovieGetByIdSuccess()
        {
            var controller = new MoviesController();

            var response = controller.Get("tt3896198")
            var contentResult = response asOkNegotiatedContentResult<Movie>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNulle(contentResult.Content);
            Asset.AreEqual("tt3896198", contentResult.Content.Movie);
        }
    }
}
