using System;
using System.Collections.Generic;

namespace Controller {
    public class HeavyVehicle {
        public static Model.HeavyVehicle CreateHeavyVehicle (
            string Brand,
            string Model,
            string Year,
            string Price,
            string Restrictions
        ) {
            int ConvertYear = Convert.ToInt32 (Year);
            double ConvertPrice = Convert.ToDouble (Price);

            if (ConvertYear < 1990) {
                throw new Exception ("Carro muito antigo");
            }

            if (ConvertPrice < 0) {
                throw new Exception ("Valor não pode ser negativo");
            }

            return new Model.HeavyVehicle (
                Brand,
                Model,
                ConvertYear,
                ConvertPrice,
                Restrictions
            );
        }

        public static List<Model.HeavyVehicle> GetHeavyVehicles () {
            return Model.HeavyVehicle.GetHeavyVehicles ();
        }

        public static Model.HeavyVehicle GetHeavyVehicle (int Id) {
            int ListLenght = Model.HeavyVehicle.GetHeavyVehicles ().Count;

            if (Id < 0 || ListLenght <= Id) {
                throw new Exception ("Id informado é inválido.");
            }

            return Model.HeavyVehicle.GetHeavyVehicle (Id);
        }
    }
}
