using System;
using System.Collections.Generic;

namespace Fake {
    public class DBFake<T> : HashSet<T> {
        public void Update(T item) {
            if (this.Contains(item)) {
                this.Remove(item);
                this.Add(item);
                return;
            }
            throw new KeyNotFoundException();
        }
    }
}
