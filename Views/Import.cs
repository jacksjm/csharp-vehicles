using System;

namespace Views {
    public static class Import {
        public static void DBImport () {
            Console.WriteLine ("\n---------------------------");
            Console.WriteLine ("Importação Iniciada");
            Controller.Import.DBImport ();
            Console.WriteLine ("Importação Concluída");
            Console.WriteLine ("---------------------------\n");
        }
    }
}
