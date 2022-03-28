using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryObject> GetCategories()
            => CategoryDAO.Instance.GetCategoryList();
    }
}
