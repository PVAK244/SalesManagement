using BusinessObject;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public class CategoryDAO : DatabaseAcess
    {
        // Using Singleton pattern
        private static CategoryDAO instance = null;
        private static readonly object instanceLock = new object();

        private CategoryDAO() { }
        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<CategoryObject> GetCategoryList()
        {
            try
            {
                OpenConnection();
                SqlCommand command = new("SELECT CategoryId, CategoryName FROM Category", conn);
                SqlDataReader reader = command.ExecuteReader();
                var categories = new List<CategoryObject>();
            
                while (reader.Read())
                {
                    categories.Add(new CategoryObject
                    {
                        CategoryId = reader.GetInt32(0),
                        CategoryName = reader.GetString(1)
                    });
                }
                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
