using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public    ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams):
        base(x =>
        (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
        (!productParams.brandId.HasValue || x.ProductBrandId ==productParams.brandId) &&
        (!productParams.typeId.HasValue || x.ProductTypeId == productParams.typeId))
        {
            AddIncude(x => x.ProductType);
            AddIncude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex -1),
            productParams.PageSize);  

            if(!string.IsNullOrEmpty(productParams.sort))
            {
                switch(productParams.sort){
                    case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                    case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                    default:
                    AddOrderBy(n => n.Name);
                    break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x =>x.id == id)
        {
            AddIncude(x => x.ProductType);
            AddIncude(x => x.ProductBrand);
        }
    }
}