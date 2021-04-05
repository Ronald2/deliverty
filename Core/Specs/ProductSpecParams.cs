namespace Core.Specs
{
    public class ProductSpecParams
    {
        private const int maxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int _pageSize = 6;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }


        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public string Sort { get; set; }
    }
}