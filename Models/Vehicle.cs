using System;

namespace Model {
    public abstract class Vehicle {
        protected string Brand { set; get; } // Marca
        protected string Model { set; get; } // Modelo
        protected int Year { set; get; } // Ano
        protected double Price { set; get; } // Valor para locação

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
                "\nModelo: " + this.Model +
                "\nAno: " + this.Year +
                "\nPreço de Locação: " + String.Format ("{0:C}", this.Price);
        }
    }
}
