using Core.Entities;

namespace Core.Specs
{
    public class ProductsWithTypesAndBrandsSpec : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpec(ProductSpecParams productParam)
        : base(p =>
       (string.IsNullOrEmpty(productParam.Search) || p.Name.ToLower().Contains(productParam.Search))&&
        (!productParam.BrandId.HasValue || p.ProductBrandId == productParam.BrandId) &&
       (!productParam.TypeId.HasValue || p.ProductTypeId == productParam.TypeId))
        {
            AddIncludes(p => p.ProductBrand);
            AddIncludes(p => p.ProductType);
            AddOrderBy(p => p.Name);
            ApplyPaging(productParam.PageSize * (productParam.PageIndex - 1), productParam.PageSize);

            switch (productParam.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Name);
                    break;
            }
        }

        public ProductsWithTypesAndBrandsSpec(int id) : base(p => p.Id == id)
        {
            AddIncludes(p => p.ProductBrand);
            AddIncludes(p => p.ProductType);
        }
    }
}