using System;
using MySql.Data.MySqlClient;

namespace ProductApp
{
    class ManageProduct
    {
        private string connString = "Server=localhost;Database=products;User ID=root;Password=;";

        public void InsertProduct(string productName, int productPrice, string productDescription)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO products (productName, productPrice, productDescription) VALUES (@name, @price, @description)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", productName);
                        cmd.Parameters.AddWithValue("@price", productPrice);
                        cmd.Parameters.AddWithValue("@description", productDescription);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0
                            ? $"Product '{productName}' inserted successfully!"
                            : "Failed to insert product.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }

    class MainProgram
    {
        public static void Main()
        {
            ManageProduct productManager = new ManageProduct();

            Console.Write(@"                                                 _____ _   _ _____ ___________       ____________ ___________ _   _ _____ _____       _____ _   _  _____ ___________ _____ 
                                                |  ___| \ | |_   _|  ___| ___ \      | ___ \ ___ \  _  |  _  \ | | /  __ \_   _|     |_   _| \ | |/  ___|  ___| ___ \_   _|
                                                | |__ |  \| | | | | |__ | |_/ /      | |_/ / |_/ / | | | | | | | | | /  \/ | |         | | |  \| |\ `--.| |__ | |_/ / | |  
                                                |  __|| . ` | | | |  __||    /       |  __/|    /| | | | | | | | | | |     | |         | | | . ` | `--. \  __||    /  | |  
                                                | |___| |\  | | | | |___| |\ \       | |   | |\ \\ \_/ / |/ /| |_| | \__/\ | |        _| |_| |\  |/\__/ / |___| |\ \  | |  
                                                \____/\_| \_/ \_/ \____/\_| \_|      \_|   \_| \_|\___/|___/  \___/ \____/ \_/        \___/\_| \_/\____/\____/\_| \_| \_/  
                                                                                                                           
                                                                                                                           
                                                                                                                           
                                                                                                                           
                                                                                                                           
                                                                                                                           
                                                                                                                           
                                                                                                                           
                                                                                                                           
                                                                                                                           ");
           
            
            Console.WriteLine();
            Console.Write("=============================================================================================================================================================================================================================================" + "============ ENTER THE NUMBER ======================");
            Console.WriteLine();












            if (!int.TryParse(Console.ReadLine(), out int productCount) || productCount <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                return;
            }

            for (int i = 1; i <= productCount; i++)
            {
                Console.WriteLine($"\n\n\n=========== Enter details for Product {i} ============");

                Console.Write("Enter Product Name: ");
                string productName = Console.ReadLine();

                Console.Write("Enter Product Price: ");
                if (!int.TryParse(Console.ReadLine(), out int productPrice) || productPrice <= 0)
                {
                    Console.WriteLine("Invalid price. Please enter a positive integer.");
                    i--; // retry current product
                    continue;
                }

                Console.Write("Enter Product Description: ");
                string productDescription = Console.ReadLine();

                productManager.InsertProduct(productName, productPrice, productDescription);
            }
        }
    }
}

