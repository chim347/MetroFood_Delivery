using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetroDelivery.Identity.Configurations.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = Guid.Parse("45DA4260-BA13-489B-995A-1F6ADB13AB75"),
                    CategoryID = Guid.Parse("175D4C8D-D2F0-441B-85CB-45A1CB0B6756"),
                    ProductName = "Keo bông gòn",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/k%E1%BA%B9o%20b%C3%B4ng%20g%C3%B2n.jpg?alt=media&token=bfa15235-90f4-498e-b305-68ca0d0c9943&_gl=1*1bh2z2a*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE3NTEuNDAuMC4w",
                    ProductDescription = "Kẹo thơm ngon được tạo ra từ các loại đường, được làm nóng và tạo nên hương vị ngọt ngào",
                    Price = 5000.500
                },
                new Product

                {
                    Id = Guid.Parse("7D661A30-E180-498C-9A77-CB6112A7CB22"),
                    CategoryID = Guid.Parse("175D4C8D-D2F0-441B-85CB-45A1CB0B6756"),
                    ProductName = "Kẹo lạc",
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRgRlQzLWTXBOHfbDD7NnZleCaXH0xyMjPdQQ&usqp=CAU",
                    ProductDescription = "Kẹo lạc thơm ngon, giòn tan",
                    Price = 3000
                },
                new Product

                {
                    Id = Guid.Parse("7DA34092-5747-42B7-B059-4A5AAD57E740"),
                    CategoryID = Guid.Parse("175D4C8D-D2F0-441B-85CB-45A1CB0B6756"),
                    ProductName = "Kẹo chup",
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT4WKJkaumJIGoZ2SdHjV_gOlqBc1BRCgacPQ&usqp=CAU",
                    ProductDescription = "Kẹo lạc thơm ngon, giòn tan",
                    Price = 3000
                },
                new Product
                {
                    Id = Guid.Parse("B834CF11-CC28-4E7D-9846-2ACC8AD33D8C"),
                    CategoryID = Guid.Parse("8908EA98-B421-420B-9634-03ED356BB921"),
                    ProductName = "Khoai tây chiên",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/khoai%20t%C3%A2y%20chi%C3%AAn.jpg?alt=media&token=2d6af011-8f6b-4f6f-9749-7c2885ef00d3&_gl=1*165nmqq*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE3MzEuNjAuMC4w",
                    ProductDescription = "Khoai tây chiên giòn tan",
                    Price = 10000
                },
                new Product
                {
                    Id = Guid.Parse("6D60BF44-B775-4D87-BB47-AACE85D49AC4"),
                    CategoryID = Guid.Parse("175D4C8D-D2F0-441B-85CB-45A1CB0B6756"),
                    ProductName = "Kẹo dẻo",
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR8-8BIO05l5p1gp2W5sgCgVLLr1YG6dt4gvw&usqp=CAU",
                    ProductDescription = "Kẹo dẻo mềm, đàn hồi",
                    Price = 2500

                }, new Product
                {
                    Id = Guid.Parse("1616CC05-8C82-4F8B-A6E0-F60AB3DE0D38"),

                    CategoryID = Guid.Parse("9AFCDFAC-1A27-496B-84E5-0C8E5804E40E"),
                    ProductName = "vịt nướng",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/v%E1%BB%8Bt%20n%C6%B0%E1%BB%9Bng.jpg?alt=media&token=b040622b-edac-4823-9a54-0b1aac95dddc&_gl=1*ykk2i6*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE5NDYuNDQuMC4w",
                    ProductDescription = "vịt nướng thơm ngon",
                    Price = 230000
                },
                new Product
                {
                    Id = Guid.Parse("D4FE048D-FF12-4715-93E7-3250F49C15C8"),
                    CategoryID = Guid.Parse("9B2CCCB2-F5FA-4358-8265-0FE4F7A52253"),
                    ProductName = "trái cây sấy",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/tr%C3%A1i%20c%C3%A2y%20s%E1%BA%A5y.jpg?alt=media&token=934c1049-364c-4947-985b-688b06bd2451&_gl=1*1rimqyr*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE5NDEuNDkuMC4w",
                    ProductDescription = "trái cây sấy giòn tan trong miệng",
                    Price = 5000
                },
                new Product
                {
                    Id = Guid.Parse("F31C789C-4A46-45C7-9009-D36681D788C5"),
                    CategoryID = Guid.Parse("4078EF19-BA53-481D-9C5A-1C37DFE0E0DC"),
                    ProductName = "trà sữa",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/tr%C3%A0%20s%E1%BB%AFa%20tr%C3%A2n%20ch%C3%A2u%20%C4%91%C6%B0%E1%BB%9Dng%20%C4%91en.jpg?alt=media&token=d88eae6c-2da9-40c1-9a1a-3ce1cffeddc1&_gl=1*dhxzv6*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE5MTcuMTAuMC4w",
                    ProductDescription = "trà sữa sô cô la ngọt thanh",
                    Price = 10000

                },
                new Product
                {
                    Id = Guid.Parse("4ECD72E3-F43D-490F-8B46-8E92EA29F85C"),
                    CategoryID = Guid.Parse("4078EF19-BA53-481D-9C5A-1C37DFE0E0DC"),
                    ProductName = "sinh tố bơ",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/sinh%20t%E1%BB%91%20b%C6%A1.jpg?alt=media&token=790ace46-99c9-4c33-b179-3778a1a2b9e8&_gl=1*1dyuw6p*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE4NDEuMTkuMC4w",
                    ProductDescription = "sinh tố bơ dâu tây thơm ngon",
                    Price = 15000
                },
                new Product

                {
                    Id = Guid.Parse("0C308B93-B26A-4224-9D63-28294711AA15"),
                    CategoryID = Guid.Parse("9AFCDFAC-1A27-496B-84E5-0C8E5804E40E"),
                    ProductName = "Gà rán",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/g%C3%A0%20r%C3%A1n.jpg?alt=media&token=7124c118-a77e-49b7-b589-bff2880072c6&_gl=1*10iygcf*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE3MTIuMTAuMC4w",
                    ProductDescription = "Gà rán giòn tan thơm ngon",
                    Price = 50000
                },
                new Product
                {
                    Id = Guid.Parse("107F1F75-B23B-4BC4-92D7-F2E90D067D1F"),
                    CategoryID = Guid.Parse("9AFCDFAC-1A27-496B-84E5-0C8E5804E40E"),
                    ProductName = "sandwich",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/sandwich.jpg?alt=media&token=da94c867-c82b-4f87-9d71-9a42d7720e04&_gl=1*1eghpk1*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE4NDguMTIuMC4w",
                    ProductDescription = "sandwich ngon ngon",
                    Price = 25000

                },
                new Product

                {
                    Id = Guid.Parse("55265D3B-FA02-4E09-84DB-D4E8C8A9A9B5"),
                    CategoryID = Guid.Parse("4078EF19-BA53-481D-9C5A-1C37DFE0E0DC"),
                    ProductName = "sinh tố mãng cầu",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/sinh%20t%E1%BB%91%20m%C3%A3ng%20c%E1%BA%A7u.jpg?alt=media&token=50c23ce0-ec9e-45bf-a1d6-7839d9b72966&_gl=1*1ek709c*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE4MjAuNDAuMC4w",
                    ProductDescription = "sinh tố mãng cầu mát lạnh",
                    Price = 25000
                },
                new Product

                {
                    Id = Guid.Parse("FFB05663-954D-4AF3-8A41-91AF39446F81"),
                    CategoryID = Guid.Parse("175D4C8D-D2F0-441B-85CB-45A1CB0B6756"),
                    ProductName = "Kẹo mút",
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQxu7OGjZjXXrJHyR6o_v7PSl4Q9PEGKxOfEQ&usqp=CAU",
                    ProductDescription = "Kẹo mút mềm dẻo",
                    Price = 2500

                },
                new Product
                {
                    Id = Guid.Parse("4C9EC4B9-1C16-4C7A-90BF-D620AAB257B6"),
                    CategoryID = Guid.Parse("9AFCDFAC-1A27-496B-84E5-0C8E5804E40E"),
                    ProductName = "gà nướng muối ớt",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/g%C3%A0%20n%C6%B0%E1%BB%9Bng%20mu%E1%BB%91i%20%E1%BB%9Bt.jpg?alt=media&token=b0ee7b37-0c08-4275-8b4d-52113060cce1&_gl=1*jik9qm*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE2NzguNDQuMC4w",
                    ProductDescription = "gà nướng muối ớt thơm phức",
                    Price = 80000
                },
                new Product
                {
                    Id = Guid.Parse("35819F39-BCA6-49DF-828D-F861F888B985"),
                    CategoryID = Guid.Parse("9AFCDFAC-1A27-496B-84E5-0C8E5804E40E"),
                    ProductName = "gà quay",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/g%C3%A0%20quay.jpg?alt=media&token=92dd0724-9117-41db-9129-ff9198ee957b&_gl=1*1rost1c*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE2OTMuMjkuMC4w",
                    ProductDescription = "gà quay thơm phức",
                    Price = 90000
                },
                new Product
                {
                    Id = Guid.Parse("43203CE4-D82C-4C78-8794-2AEF22D7EC5B"),
                    CategoryID = Guid.Parse("9AFCDFAC-1A27-496B-84E5-0C8E5804E40E"),
                    ProductName = "Cơm chiên dương châu",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/c%C6%A1m%20chi%C3%AAn.jpg?alt=media&token=566c478b-4b30-4ba1-b33b-c79b48979b2a&_gl=1*1ffrh5g*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE2MzMuMjkuMC4w",
                    ProductDescription = "Cơm chiên dương châu thơm ngon",
                    Price = 25000
                },
                new Product
                {
                    Id = Guid.Parse("9F7798D8-10DF-4783-B825-B27D2023D347"),
                    CategoryID = Guid.Parse("9AFCDFAC-1A27-496B-84E5-0C8E5804E40E"),
                    ProductName = "cơm nấm",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/c%C6%A1m%20n%E1%BA%A5m.jpg?alt=media&token=b8a9cf42-0a22-4336-8a84-cabac450f5fa&_gl=1*1d5cihv*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE2NDguMTQuMC4w",
                    ProductDescription = "cơm nấm thơm ngon",
                    Price = 19000
                },
                new Product
                {
                    Id = Guid.Parse("E802B6C5-F08E-4EFF-B7E7-AF95514B4341"),
                    CategoryID = Guid.Parse("4078EF19-BA53-481D-9C5A-1C37DFE0E0DC"),
                    ProductName = "trà chanh",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/tr%C3%A0%20chanh%20.jpg?alt=media&token=531d6da6-9098-4532-a547-96ce4a376f2f&_gl=1*1v8uv0r*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE4NjcuNjAuMC4w",
                    ProductDescription = "Trà chanh, uống là ghiền!!!",
                    Price = 25000
                },
                new Product
                {
                    Id = Guid.Parse("315B5B06-546C-45C5-BE94-62E7B08965B9"),
                    CategoryID = Guid.Parse("B7A3A853-73C6-4F02-913B-9765019E9BD0"),
                    ProductName = "bánh cuốn",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/b%C3%A1nh%20cu%E1%BB%91n.jpg?alt=media&token=04ae26bd-7eb5-472b-acdf-1c1644f05908&_gl=1*ntrrnv*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODEwNTQuNS4wLjA.",
                    ProductDescription = "Bánh cuốn siêu topping thịt trứng cút, ăn là ghiền!!!",
                    Price = 25000
                },
                new Product
                {
                    Id = Guid.Parse("09955444-1D34-43CB-AEB4-2AF974F05847"),
                    CategoryID = Guid.Parse("B7A3A853-73C6-4F02-913B-9765019E9BD0"),
                    ProductName = "bánh mì chả lụa",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/b%C3%A1nh%20m%C3%AC%20ch%E1%BA%A3%20l%E1%BB%A5a.jpg?alt=media&token=939bb3f4-7236-4a33-99d2-2fda0843c529&_gl=1*1leh2mz*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODEzODEuNTIuMC4w",
                    ProductDescription = "bánh mì chả lụa siêu topping thịt trứng cút, ăn là ghiền!!!",
                    Price = 25000
                },
                new Product
                {
                    Id = Guid.Parse("2F2C8C92-E8FE-4687-8B07-A3266EDCEC95"),
                    CategoryID = Guid.Parse("B7A3A853-73C6-4F02-913B-9765019E9BD0"),
                    ProductName = "bánh mì khô gà",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/b%C3%A1nh%20m%C3%AC%20kh%C3%B4%20g%C3%A0.jpg?alt=media&token=ed098e6f-cdd6-4073-9e54-18246793bcb5&_gl=1*17fps7l*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE0MjcuNi4wLjA.",
                    ProductDescription = "bánh mì khô gà siêu topping thịt trứng cút, ăn là ghiền!!!",
                    Price = 25000
                },
                new Product
                {
                    Id = Guid.Parse("6D9D1080-424E-435E-91EE-7D094DBAE04B"),
                    CategoryID = Guid.Parse("B7A3A853-73C6-4F02-913B-9765019E9BD0"),
                    ProductName = "bánh mì thịt",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/b%C3%A1nh%20m%C3%AC%20nh%E1%BA%ADn.jpg?alt=media&token=ab5d5464-752e-4eaf-9a53-8a8ed21a472b&_gl=1*133ff4j*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE0NDQuNjAuMC4w",
                    ProductDescription = "bánh mì thịt siêu topping thịt trứng cút, ăn là ghiền!!!",
                    Price = 25000
                },
                new Product
                {
                    Id = Guid.Parse("DD1655DE-7493-4B65-8C92-FAD2275A3EC9"),
                    CategoryID = Guid.Parse("B7A3A853-73C6-4F02-913B-9765019E9BD0"),
                    ProductName = "bánh mì trứng",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/b%C3%A1nh%20m%C3%AC%20tr%E1%BB%A9ng.jpg?alt=media&token=67e9bd91-80d8-49cd-8413-166c99806d5c&_gl=1*ajhxeb*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE1MzUuNjAuMC4w",
                    ProductDescription = "bánh mì trứng topping thịt trứng cút, ăn là ghiền!!!",
                    Price = 25000
                },
                new Product
                {
                    Id = Guid.Parse("1D8BD70C-7EEC-4630-B297-729D81467D28"),
                    CategoryID = Guid.Parse("B7A3A853-73C6-4F02-913B-9765019E9BD0"),
                    ProductName = "bánh mì xá xiu",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/b%C3%A1nh%20m%C3%AC%20x%C3%A1%20x%C3%ADu.jpg?alt=media&token=f6baaee9-fdc2-42bb-93e6-d25426686461&_gl=1*stg2d2*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE1NDcuNDguMC4w",
                    ProductDescription = "bánh mì xá xiu topping thịt trứng cút, ăn là ghiền!!!",
                    Price = 25000
                },
                new Product
                {
                    Id = Guid.Parse("18D806C4-C26F-4042-8254-C2FC8AF3A3FC"),
                    CategoryID = Guid.Parse("9AFCDFAC-1A27-496B-84E5-0C8E5804E40E"),
                    ProductName = "bánh ướt",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/b%C3%A1nh%20%C6%B0%E1%BB%9Bt.jpg?alt=media&token=81f658b4-bf13-4f9e-8eea-59d2eaf42b6d&_gl=1*1b4idwu*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE1NjMuMzIuMC4w",
                    ProductDescription = "bánh ướt topping thịt trứng cút, ăn là ghiền!!!",
                    Price = 25000
                },
                new Product
                {
                    Id = Guid.Parse("7292EFB8-15BF-404C-BAD0-128991819F7A"),
                    CategoryID = Guid.Parse("4078EF19-BA53-481D-9C5A-1C37DFE0E0DC"),
                    ProductName = "bạc xỉu",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/b%E1%BA%A1c%20x%E1%BB%89u.jpg?alt=media&token=c638c3a8-b5e5-4a53-8b43-2444e6759b4e&_gl=1*z64tep*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE1ODkuNi4wLjA.",
                    ProductDescription = "bạc xỉu thơm phức, uống là ghiền!!!",
                    Price = 20000
                },
                new Product
                {
                    Id = Guid.Parse("8108E3CA-E67A-415C-94A8-673917E29B1B"),
                    CategoryID = Guid.Parse("4078EF19-BA53-481D-9C5A-1C37DFE0E0DC"),
                    ProductName = "cà phê muối",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/c%C3%A0%20ph%C3%AA%20mu%E1%BB%91i.jpg?alt=media&token=fbd2e24d-9db6-45ed-b641-04f42576d46c&_gl=1*1qr7ux3*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE2MDIuNjAuMC4w",
                    ProductDescription = "cà phê muối thơm phức, uống là ghiền!!!",
                    Price = 18000
                },
                new Product
                {
                    Id = Guid.Parse("9CA658D0-F207-43B4-9ADB-946F5C0506D5"),
                    CategoryID = Guid.Parse("4078EF19-BA53-481D-9C5A-1C37DFE0E0DC"),
                    ProductName = "cà phê sữa",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/c%C3%A0%20ph%C3%AA%20s%E1%BB%AFa.jpg?alt=media&token=9bd6dae8-b648-41a7-a2ee-7929dc4cb906&_gl=1*o2kslq*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE2MjAuNDIuMC4w",
                    ProductDescription = "cà phê sữa thơm phức, uống là ghiền!!!",
                    Price = 15000
                },
                new Product
                {
                    Id = Guid.Parse("AC9F9657-E5ED-4E92-8EE7-3028DF33F98B"),
                    CategoryID = Guid.Parse("4078EF19-BA53-481D-9C5A-1C37DFE0E0DC"),
                    ProductName = "expresso",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/expresso.jpg?alt=media&token=c5d7f433-e733-4c7e-b1ff-2a3496145a9e&_gl=1*adgji4*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE2NjIuNjAuMC4w",
                    ProductDescription = "expresso thơm phức, uống là ghiền!!!",
                    Price = 15000
                },
                new Product
                {
                    Id = Guid.Parse("AC5A5D34-5A6B-4013-A850-D19A5BF9A659"),
                    CategoryID = Guid.Parse("4078EF19-BA53-481D-9C5A-1C37DFE0E0DC"),
                    ProductName = "nước ép cam",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/n%C6%B0%E1%BB%9Bc%20%C3%A9p%20cam.jpg?alt=media&token=d0fbb985-ca14-488c-99e2-2663e0306676&_gl=1*1bdx014*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE3NzguMTMuMC4w",
                    ProductDescription = "nước ép cam thơm phức, uống là ghiền!!!",
                    Price = 15000
                },
                new Product
                {
                    Id = Guid.Parse("E1FE83D3-270F-408E-98B2-0AF436C510B9"),
                    CategoryID = Guid.Parse("4078EF19-BA53-481D-9C5A-1C37DFE0E0DC"),
                    ProductName = "nước ep dưa hấu",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/n%C6%B0%E1%BB%9Bc%20%C3%A9p%20d%C6%B0a%20h%E1%BA%A5u.jpg?alt=media&token=91ce4a1c-4db6-43e0-af43-ee62e0a0d492&_gl=1*14wa5cu*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE3ODcuNC4wLjA.",
                    ProductDescription = "nước ep dưa hấu thơm phức, uống là ghiền!!!",
                    Price = 15000
                },
                new Product
                {
                    Id = Guid.Parse("23149DDA-19B1-40CF-9023-2AB388F4E2E7"),
                    CategoryID = Guid.Parse("4078EF19-BA53-481D-9C5A-1C37DFE0E0DC"),
                    ProductName = "sinh tố dâu",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/sinh%20t%E1%BB%91%20d%C3%A2u.jpg?alt=media&token=00b7feac-3084-443b-82b7-25ce815abb06&_gl=1*1yabqww*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE4MDAuNjAuMC4w",
                    ProductDescription = "sinh tố dâu thơm phức, uống là ghiền!!!",
                    Price = 15000
                },
                new Product
                {
                    Id = Guid.Parse("61A3D1AC-3785-4185-B880-5C92EB995C04"),
                    CategoryID = Guid.Parse("4078EF19-BA53-481D-9C5A-1C37DFE0E0DC"),
                    ProductName = "trà trái cây",
                    Image = "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/tr%C3%A0%20tr%C3%A1i%20c%C3%A2y.jpg?alt=media&token=1c94927e-1591-40df-9b19-cbfdea2ab617&_gl=1*1o9pywy*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE5MzAuNjAuMC4w",
                    ProductDescription = "trà trái cây thơm phức, uống là ghiền!!!",
                    Price = 15000
                }
                );
        }
    }


}
