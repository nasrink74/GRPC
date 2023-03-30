using Grpc.Core;
using grpcServer.Protos;

namespace grpcServer.GRPC
{
    public class ProductWebService : ProductService.ProductServiceBase
    {
        static List<Products> products = new List<Products>() {
        new Products{
            Name="test1",
            Brand="test1",
            Price=12,
        } };
        public override Task<ResponseAddProduct> AddNewProduct(RequestAddProductDTO request, ServerCallContext context)
        {
            products.Add(new Products
            {
                Name = "name",
                Brand = "Brand",
                Price = 12,
            });

            Console.WriteLine($"Name is: {request.Name}");
            Console.WriteLine($"Brand is: {request.Brand}");
            Console.WriteLine($"Price is: {request.Price}");


            return Task.FromResult(new ResponseAddProduct
            {
                IsSuccess = true,
            });
        }


        public override Task<ResponseAllProduct> GetAllProduct(RequestAllProduct request, ServerCallContext context)
        {
            ResponseAllProduct response = new ResponseAllProduct();
            foreach (var item in products)
            {
                response.Items.Add(new ProductItem
                {
                    Brand = item.Brand,
                    Price = item.Price,
                    Name = item.Name
                });
            }
            return Task.FromResult(response);
        }

        public class Products
        {
            public string Name { get; set; }
            public string Brand { get; set; }
            public int Price { get; set; }
        }
    }
}
