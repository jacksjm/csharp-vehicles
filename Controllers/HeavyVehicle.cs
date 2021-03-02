using System;
using System.Collections.Generic;

namespace Controller
{
    public class HeavyVehicle
    {
        public static void CreateHeavyVehicle(
            string Brand,
            string Model,
            string Year,
            string Price,
            string Restrictions
        )
        {
            int ConvertYear = Convert.ToInt32(Year);
            double ConvertPrice = Convert.ToDouble(Price);

            if (ConvertYear < 1990) {
                throw new Exception("Carro muito antigo");
            }

            if (ConvertPrice < 0) {
                throw new Exception("Valor não pode ser negativo");
            }

            new Model.HeavyVehicle(
                Brand,
                Model,
                ConvertYear,
                ConvertPrice,
                Restrictions
            );
        }

        public static List<Model.HeavyVehicle> GetHeavyVehicles() {
            return Model.HeavyVehicle.GetHeavyVehicles();
        }
    }
}