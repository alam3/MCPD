using System;
using static System.Console;
using Packt.Shared; // Customer
using System.Collections.Generic; // List<T>
using System.Xml.Serialization; // XmlSerializer
using System.IO; // Filestream
using static System.Environment;
using static System.IO.Path;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            string savePath = Combine(Directory.GetParent(CurrentDirectory).FullName, "customers.xml");
            string fixedSalt = "goodMorningMfers";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Customer>));

            WriteLine("Which user's card do you want to access? ");
            string username = ReadLine();
            WriteLine("Enter user's password: ");
            string password = ReadLine();
            string saltHashPassword = Protector.SaltAndHashPassword(password, fixedSalt);

            using (FileStream xmlLoad = File.Open(savePath, FileMode.Open)) {
                var loadedCustomers = (List<Customer>) xmlSerializer.Deserialize(xmlLoad);
                foreach (var user in loadedCustomers) {
                    if (user.Name.Equals(username)) {
                        if (user.Password.Equals(saltHashPassword)) {
                            string decryptedCard = Protector.Decrypt(user.CreditCard, saltHashPassword);
                            WriteLine($"{user.Name}'s credit card is: {decryptedCard}");
                        } else {
                            WriteLine("Password is incorrect.");
                        }
                    } else {
                        WriteLine("User not found.");
                    }
                }
            }
        }
    }
}
