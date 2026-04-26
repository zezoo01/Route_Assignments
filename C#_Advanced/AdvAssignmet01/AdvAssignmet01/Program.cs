namespace AdvAssignmet01
{
    internal class Program
    {
        static void Main(string[] args)
        { }

        // Q1:
        // A generic class uses a type parameter <T> so it works with any type.
        // We use it to avoid writing duplicate code for each type and get compile-time type safety.

        // Q2:
        public class Container<T>
        {
            private T item;
            public void Add(T value) { item = value; }
            public T Get() { return item; }
        }

        // Q3:
        // Multiple type parameters means a class/method takes more than one type like <TKey, TValue>.
        public class Pair<TKey, TValue>
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public Pair(TKey k, TValue v) { Key = k; Value = v; }
        }

        // Q4:
        // A generic method has its own type parameter, independent of the class.
        public class Utilities
        {
            public static void Swap<T>(ref T a, ref T b)
            {
                T temp = a; a = b; b = temp;
            }
        }

        // Q5:
        public class SearchHelper
        {
            public static T FindMax<T>(T[] arr) where T : IComparable<T>
            {
                T max = arr[0];
                foreach (T item in arr)
                    if (item.CompareTo(max) > 0) max = item;
                return max;
            }
        }

        // Q6:
        // A generic interface defines a contract that works with any type.
        public interface IRepository<T>
        {
            void Add(T entity);
            T GetById(int id);
            void Delete(int id);
            List<T> GetAll();
        }

        // Q7:
        // 'struct' constraint means T must be a value type (int, double, etc.), cannot be null.
        public class ValueBox<T> where T : struct
        {
            public T Value { get; set; }
            public bool IsDefault() { return Value.Equals(default(T)); }
        }

        // Q8:
        // 'class' constraint means T must be a reference type, so it can be null.
        public class NullChecker<T> where T : class
        {
            public bool IsNull(T obj) { return obj == null; }
        }

        // Q9:
        // 'new()' constraint means T must have a public parameterless constructor so we can do new T().
        public class Factory<T> where T : new()
        {
            public T Create() { return new T(); }
        }

        // Q10:
        // Interface constraint means T must implement a specific interface.
        public interface IAnimal { void Speak(); }

        public class AnimalHandler<T> where T : IAnimal
        {
            public void MakeSpeak(T a) { a.Speak(); }
        }

        // Q11:
        // Base class constraint means T must inherit from a specific class.
        public class Shape { public virtual double Area() { return 0; } }

        public class ShapeProcessor<T> where T : Shape
        {
            public void Print(T s) { Console.WriteLine(s.Area()); }
        }

        // Q12:
        // Multiple constraints are applied with comma separation. 'class' must come first.
        public class SmartBox<T> where T : class, IAnimal, new()
        {
            private T obj = new T();
            public void Use() { obj.Speak(); }
        }

        // Q13:
        // 'default' returns the default value of T: 0 for value types, null for reference types.
        public class DefaultDemo<T>
        {
            public T GetDefault() { return default(T); }
        }

        // Q14:
        public class SafeList<T>
        {
            private List<T> list = new List<T>();
            public void Add(T item) { list.Add(item); }
            public T Get(int index)
            {
                if (index < 0 || index >= list.Count) return default(T);
                return list[index];
            }
        }

        // Q15:
        // Covariance allows using a more derived type. 'out' means T is only returned (output).
        public interface IProducer<out T> { T Produce(); }
        // IProducer<Cat> can be assigned to IProducer<IAnimal>

        // Q16:
        // Contravariance allows using a more general type. 'in' means T is only a parameter (input).
        public interface IConsumer<in T> { void Consume(T item); }
        // IConsumer<IAnimal> can be assigned to IConsumer<Cat>

        // Q17:
        // Covariance (out) = type flows out (return) => more specific type allowed
        // Contravariance (in) = type flows in (parameter) => more general type allowed

        // Q18:
        // Each closed type (e.g. Counter<int>, Counter<string>) has its own separate static members.
        public class Counter<T>
        {
            public static int Count = 0;
            public Counter() { Count++; }
        }
        // Counter<int>.Count and Counter<string>.Count are independent

        // Q19:
        // You can keep it generic or fix the type parameter when inheriting.
        public class BaseClass<T> { public T Data { get; set; } }

        public class DerivedGeneric<T> : BaseClass<T> { }   // stays generic
        public class DerivedFixed : BaseClass<int> { }       // type is fixed to int

        // Q20:
        public class CacheItem<TValue>
        {
            public TValue Value { get; set; }
            public DateTime ExpiresAt { get; set; }
            public bool IsExpired() { return DateTime.Now > ExpiresAt; }
        }

        public class Cache<TKey, TValue>
        {
            private Dictionary<TKey, CacheItem<TValue>> cache = new Dictionary<TKey, CacheItem<TValue>>();

            public void Add(TKey key, TValue value, int seconds = 60)
            {
                cache[key] = new CacheItem<TValue> { Value = value, ExpiresAt = DateTime.Now.AddSeconds(seconds) };
            }

            public TValue Get(TKey key)
            {
                if (!Contains(key)) return default(TValue);
                return cache[key].Value;
            }

            public void Remove(TKey key) { cache.Remove(key); }

            public bool Contains(TKey key)
            {
                if (!cache.ContainsKey(key)) return false;
                if (cache[key].IsExpired()) { cache.Remove(key); return false; }
                return true;
            }

            public void Cleanup()
            {
                var expired = new List<TKey>();
                foreach (var entry in cache)
                    if (entry.Value.IsExpired()) expired.Add(entry.Key);
                foreach (var key in expired) cache.Remove(key);
            }
        }
    }
}


