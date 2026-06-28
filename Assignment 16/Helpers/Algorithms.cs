using Assignment_16.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_16.Helpers
{
    internal class Algorithms
    {
        
        public static IEnumerable<T> Where <T> (IEnumerable<T> collection, Predicate<T> predicate)
        {
            
            foreach (T item in collection)
            {
                if (predicate (item))
                {
                    yield return item;
                }
            }
            
        }

        public static List<T> OrderBy <T> (IEnumerable<T> collection) where T : IComparable<T>  
        {                                                                                            
            List<T> list = collection.ToList(); // list-ში გადავიყვანე რომ ინდექსებით შევადარო
            bool switched = true;
            while (switched)
            {
                switched = false;
                for (int i=1; i < list.Count; i++)
                {
                    if (list[i].CompareTo(list[i-1])<0) // მეტობა-ნაკლებობა აქ არ გვაწყობს და CompareTo გამოვიყენე,
                                                        // ამიტომ generic-საც გავუკეთე შეზღუდვა რომ მხოლოდ IComparable-იანებზე იმუშაოს
                    {
                        T item = list[i];
                        list[i] = list[i-1];
                        list[i - 1] = item;
                        switched = true;
                    }
                }
            }
            return list;
        }

        public static T First <T>(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                return item; // პირველივეს როგორც კი დააბრუნებს შეწყდება მეთოდი 
            }
            throw new ElementDoesntExist(); // თუ ცარიელია კოლექცია foreach-ში რაც წერია ვერ შესრულდება და ეს ხაზი წაიკითხება
        }

        public static T FirstOrDefault<T>(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                return item; 
            }
            return default;
        }

        public static T Single <T>(IEnumerable<T> collection, Predicate<T> predicate)
        {

            foreach (T item in collection)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            throw new ElementDoesntExist();
        }

        public static T SingleOrDefault<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {

            foreach (T item in collection)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default;
        }

        public static bool Any <T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (T item in collection)
            {
                if (predicate(item)) return true;
            }
            return false;
        }

        public static bool All<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (T item in collection)
            {
                if (!predicate(item)) return false;
            }
            return true;
        }

        public static int Count <T> (IEnumerable<T> collection, Predicate<T> predicate = null)
        {
            int count = 0;
            foreach (T item in collection)
            {
                if (predicate == null || predicate(item)) // თუ პრედიკატი არ გვაქვს ან თუ პრედიკატის პირობა სრულდება
                {
                    count++;
                }
            }
            return count;
        }

        public static List<T> Distinct <T> (IEnumerable<T> collection)
        {
            List<T> result = new List<T>(); // ან ლისტით დავაბრუნებდი ან yield return 

            foreach (T item in collection)
            {
                bool isPresent = false;
                foreach (T item1 in result)
                {
                    if (item.Equals(item1))
                    { 
                        isPresent = true; break; 
                    }
                }
                if (!isPresent)
                {
                    result.Add(item);
                }
                   
            }
            return result;
        }
    }
}
