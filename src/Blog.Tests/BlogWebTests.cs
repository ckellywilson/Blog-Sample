using Blog.Domain;
using Blog.Repository.Interfaces;
using Blog.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace Blog.Tests
{
    /// <summary>
    /// Tests configured as per documentation https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing?view=aspnetcore-3.1#test-actionresultt
    /// </summary>
    public class BlogWebTests
    {
        [Fact]
        public async Task Blog_controller_get_blog_returns_ok_result()
        {
            //ARRANGE
            var Id = 1;
            var mockSelectRepository = new Mock<ISelectRepository<BlogEntry>>();
            mockSelectRepository.Setup(t => t.GetAsync(Id, t => t.BlogPosts)).ReturnsAsync(PopulateBlogEntries().FirstOrDefault(t => t.Id == Id));
            BlogController blogController = new BlogController(mockSelectRepository.Object);


            //ACT
            var result = await blogController.Get(Id);

            //ASSERT
            var actionResult = Assert.IsType<ActionResult<BlogEntry>>(result);
            var returnValue = Assert.IsType<OkObjectResult>(actionResult.Result);
            var blogEntry = returnValue.Value as BlogEntry;
            Assert.Equal(Id, blogEntry.Id);
        }

        [Fact]
        public async Task Blog_controller_get_blog_returns_nocontent_result()
        {
            //ARRANGE
            var Id = -99;
            var mockSelectRepository = new Mock<ISelectRepository<BlogEntry>>();
            mockSelectRepository.Setup(t => t.GetAsync(Id, t => t.BlogPosts)).ReturnsAsync(PopulateBlogEntries().FirstOrDefault(t => t.Id == Id));
            BlogController blogController = new BlogController(mockSelectRepository.Object);


            //ACT
            var result = await blogController.Get(Id);

            //ASSERT
            var actionResult = Assert.IsType<ActionResult<BlogEntry>>(result);
            Assert.IsType<NoContentResult>(actionResult.Result);

        }

        private IEnumerable<BlogEntry> PopulateBlogEntries()
        {
            return new List<BlogEntry>()
            {
                new BlogEntry()
                {
                    Id = 1,
                    BlogEntryName = "Blog 1",
                    BlogEntryDate = DateTime.Now
                },
                new BlogEntry()
                {
                    Id = 2,
                    BlogEntryName = "Blog 2",
                    BlogEntryDate = DateTime.Now.AddMinutes(2)
                }
            };
        }
    }
}