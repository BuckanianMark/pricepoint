using product_catalog_api.Model.Dto;

namespace product_catalog_api.Data.Interface
{
    public interface IProduct
    {
          Task<bool> Add(ProductToAddDTO model);
    }
}