using Api3.Migrations;
using Api3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Movie = Api3.Models.Movie;

namespace Api3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

                
    public class MoviesController : ControllerBase
    {
                 //Using Dependency Injection

        private readonly MovieContext _dbContext;
        public MoviesController(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

                    //get all values
        [HttpGet]
        public IEnumerable<Movie> Get_All_Values()
        {
            return _dbContext.Movies.ToList();
        }
                 //get single value using id
        
        [HttpGet("{id}")]
        public IActionResult Get_Single_Value_Using_Id(int id)
        {
            var movie = _dbContext.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
                     //post method
        [HttpPost]
        public IActionResult Add_Movie([FromBody] Movie mov)
        {
            _dbContext.Movies.Add(mov);
            _dbContext.SaveChanges();
            return Ok(mov);
        }
                     //Put Mehtod
        [HttpPut("{id}")]
        public IActionResult Update_Movie(int id, [FromBody] Movie mov)
        {

            //var movie = _dbContext.Movies.Where(a => a.Id == id).FirstOrDefault();

            _dbContext.Entry(mov).State= EntityState.Modified;

            _dbContext.SaveChanges();
           
            return Ok(mov);
        }
                     //Delete Method

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _dbContext.Movies.Find(id);

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();

            return Ok(movie);

        }


    }
}
