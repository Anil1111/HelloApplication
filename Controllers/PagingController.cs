using HelloApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloApplication.Controllers
{
    public class PagingController : Controller
    {
        [ChildActionOnly]
        public PartialViewResult Paging(int currentPage, int count, string controllerName)
        {
            var countPages = (int)Math.Ceiling((double)count / Constants.PageSize);
            if (currentPage > countPages && countPages > 0)
            {
                currentPage = countPages;
            }
            else if (currentPage < 1)
            {
                currentPage = 1;
            }
            var paging = new Paging
            {
                CurrentPage = currentPage,
                LastPage = countPages,
                ControllerName = controllerName
            };
            var pages = new List<int>();
            if (currentPage == 1)
            {
                pages.Add(currentPage);
                var minPage = Math.Min(Constants.MaxCountLinks, countPages);
                for (var i = 2; i <= minPage; i++)
                {
                    pages.Add(i);
                }
            }
            else if (currentPage == countPages)
            {
                var firstPage = Math.Max(1, (currentPage - Constants.MaxCountLinks) + 1);
                var i = firstPage;
                for (var j = 0; j < Constants.MaxCountLinks && i <= countPages; j++, i++)
                {
                    pages.Add(i);
                }
            }
            else
            {
                var halfCount = (int)Math.Floor((double)Constants.MaxCountLinks / 2);
                var firstLink = Math.Max(1, currentPage - halfCount);
                for (var i = firstLink; i <= currentPage; i++)
                {
                    pages.Add(i);
                }
                var otherHalfCount = Constants.MaxCountLinks - halfCount;
                var lastLink = Math.Min(currentPage + otherHalfCount, countPages);
                var j = pages.Count;
                for (var i = currentPage + 1; i <= lastLink && j < Constants.MaxCountLinks; i++, j++)
                {
                    pages.Add(i);
                }
            }
            paging.Pages = pages;
            return PartialView(paging);
        }
    }
}