using System;

namespace Model {
    public abstract class Vehicle {
        public string Brand { set; get; } // Marca
        public string Model { set; get; } // Modelo
        public int Year { set; get; } // Ano
        public double Price { set; get; } // Valor para locação

        protected Vehicle (
            string Brand,
            string Model,
            int Year,
            double Price
        ) {
            this.Brand = Brand;
            this.Model = Model;
            this.Year = Year;
            this.Price = Price;
        }

        public override string ToString () {
            return "Marca: " + this.Brand +
                " - Modelo: " + this.Model +
                " - Ano: " + this.Year +
                " - Preço de Locação: " + String.Format ("{0:C}", this.Price);
        }
    }
}
