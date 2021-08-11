using System;
using static System.Console;
using Packt.Shared; // Customer
using System.Collections.Generic; // List<T>
using System.Xml.Serialization; // XmlSerializer
using System.IO; // Filestream
using static System.Environment;
using static System.IO.Path;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            string savePath = Combine(Directory.GetParent(CurrentDirectory).FullName, "customers.xml");
            string fixedSalt = "goodMorningMfers";
            var customers = new List<Customer>();

            WriteLine("Enter customer name: ");
            string customerName = ReadLine();
            WriteLine("Enter customer credit card: ");
            string customerCard = ReadLine();
            WriteLine("Enter customer password: ");
            string customerPassword = ReadLine();

            string saltHashPassword = Protector.SaltAndHashPassword(customerPassword, fixedSalt);
            string encryptedCard = Protector.Encrypt(customerCard, saltHashPassword);

            customers.Add(new Customer { Name = customerName,
                                         CreditCard = encryptedCard,
                                         Password = saltHashPassword });

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Customer>));
            using (FileStream fileStream = File.Create(savePath)) {
                xmlSerializer.Serialize(fileStream, customers);
            }
        }
    }
}
