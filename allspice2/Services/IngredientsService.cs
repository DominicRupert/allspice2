using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allspice2.Models;
using allspice2.Repositories;

namespace allspice2.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _ir;
        public IngredientsService(IngredientsRepository ir)
        {
            _ir = ir;
        }
        public Ingredient Create(Ingredient ingredientData)
        {
            return _ir.Create(ingredientData);
        }
        public List<Ingredient> GetByRecipe(int recipeId)
        {
            return _ir.GetByRecipe(recipeId);
        }
        internal Ingredient Delete(int id)
        {
            return _ir.Delete(id);
        }

        
        
    }
}