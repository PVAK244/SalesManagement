using System.Collections.Generic;
using BusinessObject;


namespace DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<CategoryObject> GetCategories()
            => CategoryDAO.Instance.GetCategoryList();
    }
}
