using ConsoleSql.Models;
using System;

namespace ConsoleSql.Services;

internal class MenuService(CustomerService customerService)
{
    private readonly CustomerService _customerService = customerService;


    public void CreateNewCustomerMenu()
    {
        var form = new CustomersRegistrationForm();

        Console.Write("Förnamn: ");
        form.FirstName = Console.ReadLine()!;

        Console.Write("Efternamn: ");
        form.LastName = Console.ReadLine()!;

        Console.Write("E.post: ");
        form.Email = Console.ReadLine()!;

        Console.Write("Telefonnummer: ");
        form.PhoneNumber = Console.ReadLine()!;

        Console.Write("Gatuadress: ");
        form.StreetName = Console.ReadLine()!;

        Console.Write("Postnummer: ");
        form.PostalCode = Console.ReadLine()!;


        Console.Write("Stad: ");
        form.City = Console.ReadLine()!;

        Console.Clear();

        var result =    _customerService.CreateCustomer(form);
        if (result)
            Console.WriteLine($"Kunden {form.FirstName} {form.LastName} Skapades   ");
        else
            Console.WriteLine("Kunde inte skapa, Det kan finnas en kund som har samma E.postadress.");
        Console.ReadKey();
    }
}
