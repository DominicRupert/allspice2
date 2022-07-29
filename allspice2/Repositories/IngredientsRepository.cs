using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allspice2.Models;
using Dapper;
using System.Data;

namespace allspice2.Repositories
{
    public class IngredientsRepository
    {

        private readonly IDbConnection _db;
        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }
        public Ingredient Create(Ingredient ingredientData)
        {
            string sql = @"INSERT INTO ingredients
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, ingredientData);
            ingredientData.Id = id;
            return ingredientData;
        }

        internal Ingredient Delete(int id)
        {
            string sql = "DELETE FROM ingredients WHERE id = @id Limit 1";
            return _db.QueryFirstOrDefault<Ingredient>(sql, new { id });
        }

        public List<Ingredient> GetByRecipe(int recipeId)
        {
            string sql = "SELECT * FROM ingredients WHERE recipe_id = @recipeId";
            return _db.Query<Ingredient>(sql, new { recipeId }).ToList();
        }
   
        
    }
}