using System;

namespace Model {
    public static class Import {
        public static void DBImport() {
            new Customer("Kaique Augusto Benedito da Paz", Convert.ToDateTime("14/02/1989"), "940.073.426-36", 5 );
            new Customer("Joana Liz Assis",                Convert.ToDateTime("24/10/1995"), "011.692.914-65", 15);
            new Customer("Pietro Hugo da Rocha",           Convert.ToDateTime("21/04/1988"), "278.544.066-85", 10);
            new Customer("Kauê José Gabriel Ramos",        Convert.ToDateTime("02/10/1955"), "602.912.005-08", 20);
            new Customer("Benício Breno da Mota",          Convert.ToDateTime("04/12/1982"), "519.336.908-10", 25);

            new LightVehicle("Chevrolet",  "Onix",      2019, 150.0, "Preta"    );
            new LightVehicle("Chevrolet",  "Onix Plus", 2019, 200.0, "Preta"    );
            new LightVehicle("Ford",       "Ka",        2019, 120.0, "Vermelho" );
            new LightVehicle("Renault",    "Kwid",      2019, 150.0, "Branco"   );
            new LightVehicle("Hyundai",    "HB20",      2019, 150.0, "Preta"    );
            new LightVehicle("Volkswagen", "Gol",       2019, 120.0, "Prata"    );
            new LightVehicle("Volkswagen", "Polo",      2019, 200.0, "Prata"    );
            new LightVehicle("Fiat",       "Argo",      2019, 200.0, "Vermelho" );
            new LightVehicle("Jeep",       "Renegade",  2019, 300.0, "Laranja"  );
            new LightVehicle("Fiat",       "Mobi",      2019, 120.0, "Verde"    );

            new HeavyVehicle("Volvo",         "FH540",        2019, 350.0, "Carteira C" );
            new HeavyVehicle("Volvo",         "FH 460",       2019, 300.0, "Carteira D" );
            new HeavyVehicle("DAF",           "XF105",        2019, 400.0, "Carteira C" );
            new HeavyVehicle("Scania",        "R450",         2019, 250.0, "Carteira C" );
            new HeavyVehicle("Mercedez-Benz", "Actros 2651 ", 2019, 450.0, "Carteira D" );
            new HeavyVehicle("Scania",        "R500",         2019, 200.0, "Carteira C" );
            new HeavyVehicle("Mercedez-Benz", "Axor 3344",    2019, 400.0, "Carteira C" );
            new HeavyVehicle("Mercedez-Benz", "Axor 2544",    2019, 450.0, "Carteira D" );
            new HeavyVehicle("Mercedez-Benz", "Actros 2546",  2019, 450.0, "Carteira C" );
            new HeavyVehicle("MAN",           "TGX 28.440",   2019, 150.0, "Carteira D" );
        }
    }
}
