using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using Newtonsoft.Json;

class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        string url = "https://jsonplaceholder.typicode.com/users";

        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetStringAsync(url);
            var users = JsonConvert.DeserializeObject<List<User>>(response);

            if (users.Count > 0)
            {
                foreach (var user in users)
                {
                    string phoneNumber = user.Phone.Length > 13 ? user.Phone.Substring(0, 13) : user.Phone;
                    Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
                    Console.WriteLine($"│   Subsemnat(ul/a) {user.Name}, din orasul {user.Address.City}, strada {user.Address.Street}, numar de telefon {phoneNumber} cu adresa de email {user.Email}, lucreaza la compania {user.Company.Name}");
                    Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Nu s-au găsit utilizatori.");
            }
        }
    }
}

class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public Address Address { get; set; }
    public string Phone { get; set; }
    public Company Company { get; set; }
    
}

class Address
{
    public string Street { get; set; }
    public string City { get; set; }
}

class Company
{
    public string Name { get; set; }
}
