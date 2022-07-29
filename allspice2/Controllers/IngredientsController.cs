using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allspice2.Models;
using allspice2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CodeWorks.Auth0Provider;

namespace allspice2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {

        private readonly IngredientsService _iserv;
        public IngredientsController(IngredientsService iserv)
        {
            _iserv = iserv;
        }

        [HttpPost]
        [Authorize]
        public  ActionResult<Ingredient> Create([FromBody]Ingredient ingredientData)
        {
            try
            {
                return Ok(_iserv.Create(ingredientData));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }

        }
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<Ingredient> Delete(int id)
        {
            try
            {
                return Ok(_iserv.Delete(id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        
    }
}