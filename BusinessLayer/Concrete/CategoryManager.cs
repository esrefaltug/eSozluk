using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal;
        
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categorydal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categorydal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categorydal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categorydal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categorydal.Get(x => x.CategoryID == id);
        }



        #region
        //GenericRepository<Category> repo = new GenericRepository<Category>();
        //public List<Category> GetALLBL()
        //{
        //    return repo.List();
        //}
        //public void CategoryAddBL(Category p)
        //{
        //    if(p.CategoryName==""|| p.CategoryName.Length<=3 ||
        //        p.CategoryDescription == "" || p.CategoryName.Length >= 51)
        //    {
        //        //hata mesajı
        //    }
        //    else
        //    {
        //    repo.Insert(p);
        //    }
        //}
        #endregion eskiyontem
        public List<Category> GetCategoryList()
        {
            return _categorydal.List();
        }

    }
}
