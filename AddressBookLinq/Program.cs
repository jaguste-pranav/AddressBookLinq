using System;

namespace AddressBookLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book LINQ!");

            Console.WriteLine();
            Console.WriteLine("UC2 Created DataTable for AddressBook");
            AddressBook.CreateTable();

            Console.WriteLine();
            Console.WriteLine("UC3 Insert Row into DataTable AddressBook");
            AddressBook.InsertColumnIntoTable();

            Console.WriteLine();
            Console.WriteLine("UC4 Edit Record By Name into DataTable AddressBook");
            AddressBook.EditContactsByName();

            Console.WriteLine();
            Console.WriteLine("UC5 Delete Record By Name into DataTable AddressBook");
            string name = Console.ReadLine();
            AddressBook.DeleteContact(name);
        }
    }
}
