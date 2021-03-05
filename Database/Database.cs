using System.Collections.Generic;

namespace Database
{
    public class Database<T> {
        protected static readonly List<T> DataBase = new ();

        protected int GetNewId() {
            return DataBase.Count;
        }

        public void AddItem(T item) {
            DataBase.Add(item);
        }

        public static T GetItem(int id) {
            return DataBase[id];
        }

        public static List<T> GetList() {
            return DataBase;
        }
    }
}
