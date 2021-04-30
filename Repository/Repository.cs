using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Fake;

namespace Repository
{
    public class Context
    {
        public DBFake<Customer> Customers { get; set; }
        public DBFake<HeavyVehicle> HeavyVehicles { get; set; }
        public DBFake<LightVehicle> LightVehicles { get; set; }
        public DBFake<Rent> Rents { get; set; }
        public DBFake<RentHeavyVehicle> RentsHeavyVehicles { get; set; }
        public DBFake<RentLightVehicle> RentsLightVehicles { get; set; }

        public void SaveChanges() {
            string jsonCustomers = JsonSerializer.Serialize(this.Customers);
            File.WriteAllText(@"./Repository/json/customers.json", jsonCustomers);

            string jsonHeavyVehicles = JsonSerializer.Serialize(this.HeavyVehicles);
            File.WriteAllText(@"./Repository/json/heavyvehicles.json", jsonHeavyVehicles);

            string jsonLightVehicles = JsonSerializer.Serialize(this.LightVehicles);
            File.WriteAllText(@"./Repository/json/lightvehicles.json", jsonLightVehicles);

            string jsonRents = JsonSerializer.Serialize(this.Rents);
            File.WriteAllText(@"./Repository/json/rents.json", jsonRents);

            string jsonRentsHeavyVehicles = JsonSerializer.Serialize(this.RentsHeavyVehicles);
            File.WriteAllText(@"./Repository/json/rentsheavyvehicles.json", jsonRentsHeavyVehicles);

            string jsonRentsLightVehicles = JsonSerializer.Serialize(this.RentsLightVehicles);
            File.WriteAllText(@"./Repository/json/rentslightvehicles.json", jsonRentsLightVehicles);
        }

        public Context() {
            this.Customers = new DBFake<Customer>();
            this.HeavyVehicles = new DBFake<HeavyVehicle>();
            this.LightVehicles = new DBFake<LightVehicle>();
            this.Rents = new DBFake<Rent>();
            this.RentsHeavyVehicles = new DBFake<RentHeavyVehicle>();
            this.RentsLightVehicles = new DBFake<RentLightVehicle>();

            JsonElement.ArrayEnumerator customers = readJson(@"./Repository/json/customers.json");
            while (customers.MoveNext()) {
                JsonElement current = customers.Current;
                Customer customer = new Customer();
                customer.Id = Convert.ToInt32(current.GetProperty("Id").ToString());
                customer.Name = current.GetProperty("Name").ToString();
                customer.Birth = Convert.ToDateTime(current.GetProperty("Birth").ToString());
                customer.Identification = current.GetProperty("Identification").ToString();
                customer.ReturnDays = Convert.ToInt32(current.GetProperty("ReturnDays").ToString());
                this.Customers.Add(customer);
            }

            JsonElement.ArrayEnumerator heavyVehicles = readJson(@"./Repository/json/heavyvehicles.json");
            while (heavyVehicles.MoveNext()) {
                JsonElement current = heavyVehicles.Current;
                HeavyVehicle heavyVehicle = new HeavyVehicle();
                heavyVehicle.Id = Convert.ToInt32(current.GetProperty("Id").ToString());
                heavyVehicle.Brand = current.GetProperty("Brand").ToString();
                heavyVehicle.Model = current.GetProperty("Model").ToString();
                heavyVehicle.Year = Convert.ToInt32(current.GetProperty("Year").ToString());
                heavyVehicle.Price = Convert.ToDouble(current.GetProperty("Price").ToString());
                heavyVehicle.Restrictions = current.GetProperty("Restrictions").ToString();
                this.HeavyVehicles.Add(heavyVehicle);
            }

            JsonElement.ArrayEnumerator lightVehicles = readJson(@"./Repository/json/lightvehicles.json");
            while (lightVehicles.MoveNext()) {
                JsonElement current = lightVehicles.Current;
                LightVehicle lightVehicle = new LightVehicle();
                lightVehicle.Id = Convert.ToInt32(current.GetProperty("Id").ToString());
                lightVehicle.Brand = current.GetProperty("Brand").ToString();
                lightVehicle.Model = current.GetProperty("Model").ToString();
                lightVehicle.Year = Convert.ToInt32(current.GetProperty("Year").ToString());
                lightVehicle.Price = Convert.ToDouble(current.GetProperty("Price").ToString());
                lightVehicle.Color = current.GetProperty("Color").ToString();
                this.LightVehicles.Add(lightVehicle);
            }

            JsonElement.ArrayEnumerator rents = readJson(@"./Repository/json/rents.json");
            while (rents.MoveNext()) {
                JsonElement current = rents.Current;
                Rent customer = new Rent();
                customer.Id = Convert.ToInt32(current.GetProperty("Id").ToString());
                customer.CustomerId = Convert.ToInt32(current.GetProperty("CustomerId").ToString());
                customer.RentDate = Convert.ToDateTime(current.GetProperty("RentDate").ToString());
                this.Rents.Add(customer);
            }

            JsonElement.ArrayEnumerator rentsHeavyVehicles = readJson(@"./Repository/json/rentsheavyvehicles.json");
            while (rentsHeavyVehicles.MoveNext()) {
                JsonElement current = rentsHeavyVehicles.Current;
                RentHeavyVehicle rentHeavyVehicle = new RentHeavyVehicle();
                rentHeavyVehicle.Id = Convert.ToInt32(current.GetProperty("Id").ToString());
                rentHeavyVehicle.RentId = Convert.ToInt32(current.GetProperty("RentId").ToString());
                rentHeavyVehicle.HeavyVehicleId = Convert.ToInt32(current.GetProperty("HeavyVehicleId").ToString());
                this.RentsHeavyVehicles.Add(rentHeavyVehicle);
            }

            JsonElement.ArrayEnumerator rentsLightVehicles = readJson(@"./Repository/json/rentslightvehicles.json");
            while (rentsLightVehicles.MoveNext()) {
                JsonElement current = rentsLightVehicles.Current;
                RentLightVehicle rentLightVehicle = new RentLightVehicle();
                rentLightVehicle.Id = Convert.ToInt32(current.GetProperty("Id").ToString());
                rentLightVehicle.RentId = Convert.ToInt32(current.GetProperty("RentId").ToString());
                rentLightVehicle.LightVehicleId = Convert.ToInt32(current.GetProperty("LightVehicleId").ToString());
                this.RentsLightVehicles.Add(rentLightVehicle);
            }
        }

        private JsonElement.ArrayEnumerator readJson(string file) {
            string stringCustomers = File.ReadAllText(file);
            JsonDocument jsonCustomers = JsonDocument.Parse(stringCustomers);
            JsonElement root = jsonCustomers.RootElement;
            return root.EnumerateArray();
        }

    }
}
