using Grpc.Net.Client;
using grpcServer.Protos;
// See https://aka.ms/new-console-template for more information

var channel = GrpcChannel.ForAddress("https://localhost:7145/");
var productClient = new ProductService.ProductServiceClient(channel);
var response=productClient.AddNewProduct(new RequestAddProductDTO
{
    Brand = "",
    Name = "",
    Price = 12
});
Console.WriteLine("IsSuccess"+response.IsSuccess);
