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

            Console.WriteLine();
            Console.WriteLine("UC6 Retrieve Record By Name into DataTable AddressBook");
            string city = Console.ReadLine();
            string state = Console.ReadLine();
            AddressBook.RetrieveContactAccordingToCity(city);
            AddressBook.RetrieveContactAccordingToState(state);

            Console.WriteLine();
            Console.WriteLine("UC7 Get count of city and state from DataTable AddressBook");
            AddressBook.GetCountByCityState();

            Console.WriteLine();
            Console.WriteLine("UC8 Sort city alphabetically from DataTable AddressBook");
            string cityForSort = Console.ReadLine();
            AddressBook.SortContactAlphabetically(cityForSort);

            Console.WriteLine();
            Console.WriteLine("UC9 Add address book name and type of contact from DataTable AddressBook");
            AddressBook.DisplayDataTable();

            Console.WriteLine();
            Console.WriteLine("UC10 Get count by Type in DataTable AddressBook");
            AddressBook.GetCountByType();
        }
    }
}
