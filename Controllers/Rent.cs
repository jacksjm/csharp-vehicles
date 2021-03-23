using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Controller {
    public class Rent {
        public static Model.Rent CreateRent (
            string IdCustomer,
            string StringRentDate,
            List<Model.LightVehicle> LightVehicles,
            List<Model.HeavyVehicle> HeavyVehicles
        ) {
            Model.Customer Customer = Controller.Customer
                .GetCustomer (Convert.ToInt32 (IdCustomer));
            // Regex rgxDate = new ("^\\d{2}\\/\\d{2}\\/\\d{4}$");
            // if (!rgxDate.IsMatch (StringRentDate)) {
            //     throw new Exception ("Data de Locação em formato inválido");
            // }
            DateTime RentDate;

            try {
                RentDate = Convert.ToDateTime (StringRentDate);
            } catch {
                RentDate = DateTime.Now;
            }

            if (RentDate > DateTime.Now) {
                throw new Exception ("Data de Locação não pode ser maior que a data atual");
            }

            return new Model.Rent (Customer, RentDate, LightVehicles, HeavyVehicles);
        }

        public static IEnumerable<Model.Rent> GetRents () {
            return Model.Rent.GetRents ();
        }
    }
}
