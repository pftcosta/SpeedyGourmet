﻿using SpeedyGourmet.Model;
using System.Data.SqlClient;

namespace SpeedyGourmet.Repository
{
    public class IngredientLineRepository : IIngredientLineRepository
    {
        private readonly string _tableName = "recipe_ingredients";

        public IngredientLine Create(IngredientLine ingredientLine)
        {
            string sql = $"INSERT INTO {_tableName} (id_recipe, id_ingredient, quantity, id_measure) VALUES " +
                $"({ingredientLine.Recipe.Id}, " +
                $"{ingredientLine.Ingredient.Id}, " +
                $"{ingredientLine.Quantity}, " +
                $"{ingredientLine.Measure.Id});";
            SQL.ExecuteNonQuery(sql);
            int maxId = SQL.GetMax("id", _tableName);
            return GetById(maxId);
        }

        public IngredientLine GetById(int ingredientId)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id = {ingredientId};";
            SqlDataReader reader = SQL.Execute(sql);

            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception($"{_tableName} Id: {ingredientId} not found.");
        }

        public List<IngredientLine> GetAll()
        {
            string sql = $"SELECT * FROM {_tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<IngredientLine> ingredientLines = new List<IngredientLine>();

            while (reader.Read())
            {
                ingredientLines.Add(Parse(reader));
            }
            return ingredientLines;
        }

        public List<IngredientLine> GetAllByRecipeId(int recipeId)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id_recipe = {recipeId} ORDER BY id ASC;";
            SqlDataReader reader = SQL.Execute(sql);
            List<IngredientLine> ingredientLines = new List<IngredientLine>();
            while (reader.Read())
            {
                ingredientLines.Add(Parse(reader));
            }
            return ingredientLines;
        }
        
        public void Delete(int ingredientId)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id = {ingredientId};";
            SQL.ExecuteNonQuery(sql);
        }

        public void DeleteAllByRecipeId(int recipeId)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id_recipe = {recipeId};";
            SQL.ExecuteNonQuery(sql);
        }
        
        public IngredientLine Parse(SqlDataReader reader)
        {
            IngredientLine ingredientLine = new IngredientLine();
            ingredientLine.Id = Convert.ToInt32(reader["id"]);
            ingredientLine.Quantity = Convert.ToInt64(reader["quantity"]);

            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(reader["id_ingredient"]);
            ingredientLine.Ingredient = ingredient;

            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(reader["id_measure"]);
            ingredientLine.Measure = measure;

            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(reader["id_recipe"]);
            ingredientLine.Recipe = recipe;

            return ingredientLine;
        }
    }
}
