using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allspice2.Models;
using allspice2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace allspice2.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _rr;

        public RecipesService(RecipesRepository rr)
        {
            _rr = rr;
        }

        public List<Recipe> Get()
        {
            return _rr.Get();
        }

        public Recipe Get(int id)
        {
            return _rr.Get(id);
        }


        public Recipe Create(Recipe recipeData)
        {
            return _rr.Create(recipeData);
        }

        public Recipe Update(Recipe recipeData)
        {
            return _rr.Update(recipeData);
        }


        internal ActionResult<Recipe> Update(int id, Recipe recipeData)
        {
            throw new NotImplementedException();
        }
        internal void Delete(int id)
        {
            _rr.Delete(id);
        }
     
}}