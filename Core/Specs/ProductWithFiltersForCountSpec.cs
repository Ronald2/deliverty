using Core.Entities;

namespace Core.Specs
{
    public class ProductWithFiltersForCountSpec : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpec(ProductSpecParams productParam)
        : base(p =>
       (!productParam.BrandId.HasValue || p.ProductBrandId == productParam.BrandId) &&
       (!productParam.TypeId.HasValue || p.ProductTypeId == productParam.TypeId))
        {
        }
    }
}