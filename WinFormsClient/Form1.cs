using Grpc.Net.Client;
using grpcServer.Protos;

namespace WinFormsClient
{
    public partial class Form1 : Form
    {
        GrpcChannel channel;
        ProductService.ProductServiceClient client;
        public Form1()
        {
            InitializeComponent();
            channel = GrpcChannel.ForAddress("https://localhost:7145/");
            client = new ProductService.ProductServiceClient(channel);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var response = client.GetAllProduct(new RequestAllProduct
            {
                Page = 1,
                PageSize = 10,
            });
            dataGridView1.DataSource = response.Items;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var response = client.AddNewProduct(new RequestAddProductDTO
            {
                Name = textBrand.Text,
                Brand = textBrand.Text,
                Price = int.Parse(textPrice.Text)
            });
            if (response.IsSuccess)
            {
                MessageBox.Show("????? ???? ?? ?????? ?? ???? ????? ??");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBrand_TextChanged(object sender, EventArgs e)
        {

        }
    }
}