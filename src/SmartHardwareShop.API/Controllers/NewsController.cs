using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHardwareShop.API.Infrastructure;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System;
using System.Threading.Tasks;

namespace SmartHardwareShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IAddNews _addNews;
        private readonly IDeleteAllNews _deleteAllNews;
        private readonly IDeleteNews _deleteNews;
        private readonly IGetAllNews _getAllNews;
        private readonly IGetNews _getNews;
        private readonly IUpdateNews _updateNews;

        public NewsController(
            IAddNews addNews,
            IDeleteAllNews deleteAllNews,
            IDeleteNews deleteNews,
            IGetAllNews getAllNews,
            IGetNews getNews,
            IUpdateNews updateNews)
        {
            _addNews = addNews;
            _deleteAllNews = deleteAllNews;
            _deleteNews = deleteNews;
            _getAllNews = getAllNews;
            _getNews = getNews;
            _updateNews = updateNews;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllNews()
        {
            try
            {
                var _newsResponse = await _getAllNews.Execute();
                return Ok(_newsResponse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{newsId}")]
        public async Task<IActionResult> GetNewsById(Guid newsId)
        {
            try
            {
                var _newsResponse = await _getNews.Execute(newsId);
                return Ok(_newsResponse);
            } 
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize(Policy = "ADMIN")]
        [HttpPut]
        public async Task<IActionResult> AddNews([FromBody] News news)
        {
            try
            {
                await _addNews.Execute(news);
                return Ok($"News {news.NewsId} added successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [Authorize(Policy = "ADMIN")]
        [HttpPatch]
        public async Task<IActionResult> UpdateNews([FromBody] News news)
        {
            try
            {
                await _updateNews.Execute(news);
                return Ok($"News {news.NewsId} updated successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [Authorize(Policy = "ADMIN")]
        [HttpDelete("newsId")]
        public async Task<IActionResult> DeleteProduct(Guid newsId)
        {
            try
            {
                await _deleteNews.Execute(newsId);
                return Ok($"News {newsId} deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [Authorize(Policy = "ADMIN")]
        [HttpDelete("all")]
        public async Task<IActionResult> DeleteAll()
        {
            try
            {
                await _deleteAllNews.Execute();
                return Ok("All news deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
