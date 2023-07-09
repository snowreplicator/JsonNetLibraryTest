using System;
using Newtonsoft.Json;

namespace JsonNetLibraryTest;

public class JsonNetLibraryTests
{
    public static void Test1()
    {
        Console.WriteLine("\nTest1 - serialize:");
        
        Product product = new Product()
        {
            Name = "Apple",
            ExpiryDate = new DateTime(2008, 12, 28),
            Price = 3.99d,
            Sizes = new[] { "Small", "Medium", "Large" }
        };
        
        string output = JsonConvert.SerializeObject(product);
        Console.WriteLine($"output: {output}");

        Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);
        Console.WriteLine($"deserializedProduct: {deserializedProduct?.Name}");
    }
}