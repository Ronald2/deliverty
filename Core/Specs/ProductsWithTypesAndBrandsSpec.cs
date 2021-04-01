using Core.Entities;

namespace Core.Specs
{
    public class ProductsWithTypesAndBrandsSpec : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpec()
        {
            AddIncludes(p =>p.ProductBrand);
            AddIncludes(p => p.ProductType);
        }

        public ProductsWithTypesAndBrandsSpec(int id) : base(p =>p.Id == id)
        {
            AddIncludes(p =>p.ProductBrand);
            AddIncludes(p => p.ProductType);
        }
    }
}