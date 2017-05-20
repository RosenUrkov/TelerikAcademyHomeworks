namespace Cars
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var json = File.ReadAllText("../../data.number.json", System.Text.Encoding.UTF8);

            var result = JsonConvert.DeserializeObject<IEnumerable<CarJsonModel>>(json);

            result
                .Select(car =>
                {
                    return new Car(car.Year, car.TransmissionType, car.ManufacturerName, car.Model, car.Price, car.Dealer);
                })
                .ToList()
                .ForEach(car =>
                {
                    using (var writer = new StreamWriter("../../data.number.txt", true, System.Text.Encoding.UTF8))
                    {
                        writer.WriteLine(car);
                    }
                });
        }
    }
}
