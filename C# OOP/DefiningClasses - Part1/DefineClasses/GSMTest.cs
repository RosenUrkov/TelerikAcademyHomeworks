namespace Phones
{
    using System;
    using System.Collections.Generic;
    using Phones.PhoneParts;
    static class GSMTest
    {
        public static void TestPhone()
        {
            List<Phone> tester = new List<Phone>();
            tester.Add(new Phone("Samsung", "Samsung mobile", 500, batteryModel: BatteryType.NiMH, displaySize: 5.5));
            tester.Add(new Phone("Nokia", "Nokia mobile", displayColors: 50000000, price: 800, idleHours:8));
            tester.Add(new Phone("Lenovo", "Lenovo mobile", owner: "Bai Ivan", price: 950, talkedHours: 9));

            Console.WriteLine("Create phones and print their information:");
            Console.WriteLine();
            foreach (var item in tester)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }

    }
}
