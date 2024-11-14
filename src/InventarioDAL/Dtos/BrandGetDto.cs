namespace InventarioDAL.Dtos
{
    public class BrandGetDto
    {
        public BrandGetDto() { }

        public BrandGetDto(Brand brand)
        {
            IdBrand = brand.IdBrand;
            IdSupplier = brand.IdSupplier;
            BrandName = brand.BrandName;
            BrandStatus = brand.BrandStatus;
            BrandCountry = brand.BrandCountry;
        }

        public Brand ToDomain()
        {
            return new Brand
            {
                IdBrand = IdBrand,
                IdSupplier = IdSupplier,
                BrandName = BrandName ?? "",
                BrandStatus = BrandStatus,
                BrandCountry = BrandCountry ?? ""
            };
        }

        public int IdBrand { get; set; }

        public int IdSupplier { get; set; }

        public string? BrandName { get; set; }

        public bool BrandStatus { get; set; }

        public string? BrandCountry { get; set; }
    }
}
