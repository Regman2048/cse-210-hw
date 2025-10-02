using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // --- 1. SETUP DATA ---

        // Addresses (1 Domestic, 1 International)
        Address usaAddress = new Address("456 Technology Way", "Provo", "UT", "USA");
        Address intlAddress = new Address("15 Park Road", "London", "Greater London", "United Kingdom");

        // Customers
        Customer usaCustomer = new Customer("Mark Wilson", usaAddress);
        Customer intlCustomer = new Customer("Emily Davies", intlAddress);

        // Products Pool
        Product p1 = new Product("Smart Watch Gen 5", "SW005", 199.99, 1);
        Product p2 = new Product("Fast Charger Cable", "CBL10", 15.00, 3);
        Product p3 = new Product("Laptop Backpack", "BPK20", 89.50, 1);
        Product p4 = new Product("Portable Speaker", "SPK30", 45.99, 2);

        // --- 2. CREATE ORDERS ---

        // Order 1: Domestic Order (USA)
        List<Product> products1 = new List<Product> { p1, p2, p4 };
        Order order1 = new Order(products1, usaCustomer);
        
        // Order 2: International Order
        List<Product> products2 = new List<Product> { p3, p4 };
        Order order2 = new Order(products2, intlCustomer);

        // --- 3. DISPLAY RESULTS ---

        DisplayOrderDetails(order1, "DOMESTIC SHIPMENT");
        DisplayOrderDetails(order2, "INTERNATIONAL SHIPMENT");
    }

    /// <summary>
    /// Displays the shipping label, packing label, and total cost for a given order.
    /// </summary>
    static void DisplayOrderDetails(Order order, string shipmentType)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine($"ORDER DETAILS: {shipmentType}");
        Console.WriteLine("=================================================");
        
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine("\n-------------------------------------------------");
        
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("-------------------------------------------------");

        // Total cost calculation includes the correct shipping fee ($5.00 or $35.00)
        Console.WriteLine($"FINAL TOTAL COST: {order.GetTotalCost():C2}");
        Console.WriteLine("=================================================\n");
    }
}
