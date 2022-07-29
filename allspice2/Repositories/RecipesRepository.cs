using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allspice2.Models;
using Dapper;
using System.Data;


namespace allspice2.Repositories
{
    public class RecipesRepository
    {


        private readonly IDbConnection _db;
        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }
        internal List<Recipe> Get()
        {

            string sql = "SELECT * FROM recipes";
            return _db.Query<Recipe>(sql).ToList();
        }
        internal Recipe Get(int id)
        {
            string sql = "SELECT * FROM recipes WHERE Id = @id";
            return _db.QueryFirstOrDefault<Recipe>(sql, new { id });

        }
        internal Recipe Create(Recipe recipeData)
        {
            string sql = @"INSERT INTO recipes
            (Name, Description, Category)
            VALUES
            (@Name, @Description, @Category);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, recipeData);
            recipeData.Id = id;
            return recipeData;
        }
        internal Recipe Update(Recipe recipeData)
        {
            string sql = @"UPDATE recipes SET
            Name = @Name,
            Description = @Description,
            Category = @Category
            WHERE Id = @Id;
            SELECT * FROM recipes WHERE Id = @Id;";
            _db.Execute(sql, recipeData);
            return recipeData;
        }



        internal void Delete(int id)
        {
            string sql = "DELETE FROM recipes WHERE id = @id Limit 1";
            _db.Execute(sql, new { id });

        }
    }
}