using System;
using System.Collections.Generic;

namespace Controller {
    public class LightVehicle {
        public static Model.LightVehicle CreateLightVehicle (
            string Brand,
            string Model,
            string Year,
            string Price,
            string Color
        ) {
            int ConvertYear = Convert.ToInt32 (Year);
            double ConvertPrice = Convert.ToDouble (Price);

            if (ConvertYear < 1990) {
                throw new Exception ("Carro muito antigo");
            }

            if (ConvertPrice < 0) {
                throw new Exception ("Valor não pode ser negativo");
            }

            return new Model.LightVehicle (
                Brand,
                Model,
                ConvertYear,
                ConvertPrice,
                Color
            );
        }

        public static IEnumerable<Model.LightVehicle> GetLightVehicles () {
            return Model.LightVehicle.GetLightVehicles ();
        }

        public static Model.LightVehicle GetLightVehicle (int Id) {
            int ListLenght = Model.LightVehicle.GetCount();

            if (Id < 0 || ListLenght <= Id) {
                throw new Exception ("Id informado é inválido.");
            }

            return Model.LightVehicle.GetLightVehicle (Id);
        }
    }
}
