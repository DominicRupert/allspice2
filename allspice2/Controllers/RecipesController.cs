using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using allspice2.Models;
using allspice2.Services;
using Microsoft.AspNetCore.Authorization;
using CodeWorks.Auth0Provider;

namespace allspice2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _rs;
        private readonly IngredientsService _iserv;


        public RecipesController(RecipesService rs, IngredientsService iserv)
        {
            _rs = rs;
            _iserv = iserv;
        }
     

        [HttpGet]
        public ActionResult<List<Recipe>> Get()
        {
            return _rs.Get();


        }

        [HttpGet("{id}")]
        public ActionResult<Recipe> Get(int id)
        {
            return _rs.Get(id);
        }

        [HttpGet("{id}/ingredients")]
        public ActionResult<List<Ingredient>> GetIngredients(int id)
        {
            return _iserv.GetByRecipe(id);
        }

        // [HttpGet("{id}/favorites")]

        [HttpPost]
        public ActionResult<Recipe> Create(Recipe recipeData)
        {
            return _rs.Create(recipeData);
        }

        [HttpPut("{id}")]
        public ActionResult<Recipe> Update(int id, Recipe recipeData)
        {
            return _rs.Update(id, recipeData);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<Recipe> Delete(int id)
        {
            try
            {
                _rs.Delete(id);
                return Ok("Recipe deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
    }
}

