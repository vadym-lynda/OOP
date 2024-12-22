using System;
using System.Collections.Generic;
using System.IO;

namespace DisciplineInfoApp
{
    enum SubscriberType
    {
        Regular,
        VIP
    }

    class PhoneBill
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CallDate { get; set; }
        public double RatePerMinute { get; set; }
        public double CallDuration { get; set; }
        public double Discount { get; set; }
        public SubscriberType SubscriberType { get; set; }

        public double CalculateBill()
        {
            double totalCost = CallDuration * RatePerMinute;
            double discountAmount = (totalCost * Discount) / 100;
            return totalCost - discountAmount;
        }

        public override string ToString()
        {
            return $"{FullName}, {PhoneNumber}, {CallDate}, {RatePerMinute}, {CallDuration}, {Discount}, {SubscriberType}";
        }
    }

    class PhoneBillManager
    {
        private string filePath;

        public PhoneBillManager(string path)
        {
            filePath = path;
        }

        public void WriteBillToFile(PhoneBill bill)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(bill.ToString());
            }
        }

        public List<PhoneBill> ReadBillsFromFile()
        {
            List<PhoneBill> bills = new List<PhoneBill>();
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(new char[] { ',' });
                        if (parts.Length == 7)
                        {
                            bills.Add(new PhoneBill
                            {
                                FullName = parts[0].Trim(),
                                PhoneNumber = parts[1].Trim(),
                                CallDate = DateTime.Parse(parts[2].Trim()),
                                RatePerMinute = double.Parse(parts[3].Trim()),
                                CallDuration = double.Parse(parts[4].Trim()),
                                Discount = double.Parse(parts[5].Trim()),
                                SubscriberType = (SubscriberType)Enum.Parse(typeof(SubscriberType), parts[6].Trim())
                            });
                        }
                    }
                }
            }
            return bills;
        }

        public List<PhoneBill> SearchByFullName(string fullName)
        {
            List<PhoneBill> bills = ReadBillsFromFile();
            return bills.FindAll(b => b.FullName.IndexOf(fullName, StringComparison.OrdinalIgnoreCase) >= 0);

        }

        public List<PhoneBill> SearchByPhoneNumber(string phoneNumber)
        {
            List<PhoneBill> bills = ReadBillsFromFile();
            return bills.FindAll(b => b.PhoneNumber.Contains(phoneNumber));
        }

        public List<PhoneBill> SearchByCallDate(DateTime date)
        {
            List<PhoneBill> bills = ReadBillsFromFile();
            return bills.FindAll(b => b.CallDate.Date == date.Date);
        }
    }

    internal class Program
    {
        static void Main()
        {
            string filePath = "phone_bills.txt";
            PhoneBillManager manager = new PhoneBillManager(filePath);

            Console.WriteLine("Enter the full name of the subscriber:");
            string fullName = Console.ReadLine();

            Console.WriteLine("Enter the phone number:");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter the call date (yyyy-MM-dd):");
            DateTime callDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the rate per minute:");
            double rate = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the call duration in minutes:");
            double duration = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the discount percentage:");
            double discount = double.Parse(Console.ReadLine());

            Console.WriteLine("Select subscriber type (0 - Regular, 1 - VIP):");
            SubscriberType subscriberType = (SubscriberType)Enum.Parse(typeof(SubscriberType), Console.ReadLine());

            PhoneBill bill = new PhoneBill
            {
                FullName = fullName,
                PhoneNumber = phoneNumber,
                CallDate = callDate,
                RatePerMinute = rate,
                CallDuration = duration,
                Discount = discount,
                SubscriberType = subscriberType
            };

            manager.WriteBillToFile(bill);

            Console.WriteLine("\nAll records from file:");
            var bills = manager.ReadBillsFromFile();
            foreach (var b in bills)
            {
                Console.WriteLine(b.ToString());
            }

            Console.WriteLine("\nEnter the full name to search:");
            string searchName = Console.ReadLine();
            var foundByName = manager.SearchByFullName(searchName);
            Console.WriteLine("Search results by full name:");
            foreach (var b in foundByName)
            {
                Console.WriteLine(b.ToString());
            }
        }
    }
}
