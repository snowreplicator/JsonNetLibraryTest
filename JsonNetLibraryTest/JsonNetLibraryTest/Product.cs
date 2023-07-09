using System;

namespace JsonNetLibraryTest;

public class Product
{
    public string Name { get; set; }
    public DateTime ExpiryDate { get; set; }
    public double Price { get; set; }
    public string[] Sizes { get; set; }
}