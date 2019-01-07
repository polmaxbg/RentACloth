using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentACloth.Models.ProductsViewModel;
using RentACloth.Services.Models.Home;
using X.PagedList;

namespace RentACloth.Models.Home
{
    public class IndexViewModel
    {
        public IPagedList<IndexProductViewModel> ProductViewModel { get; set; }
        public IList<IndexCategoryViewModel> CategoriesViewModel { get; set; }
        public IEnumerable<IndexProductViewModel> Products { get; set; }

        public int? ChildCategoryId { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
