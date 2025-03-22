using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests"), InternalsVisibleTo("GUI")]

namespace Lab1;

// Struktura opisujaca pojedynczy przedmiot : jego id, wartosc oraz wage
public struct Item
{
        private int _id,_value, _weight;
        public int Id { get => _id; set => _id = value; }
        public int Value { get => _value; set => _value = value; }
        public int Weight { get => _weight; set => _weight = value; }
}

// Klasa opisujaca problem plecakowy i implementujaca interfejs jego rozwiazania
public class Problem
{
        // lista przedmiotow w "plecaku"
        private readonly List<Item> _itemList;

        // Konstruktor klasy implementujacy problem plecakowy - zapelnienie listy n elementami o losowych wagach
        // oraz wartosciach z zakresu 1-10
        public Problem(int n, int seed)
        {
                _itemList = new List<Item>();
                Random rand = new Random(seed);
                for (int i = 0; i < n; i++)
                        _itemList!.Add(new Item {Id = i, Value = rand.Next(1,10), Weight = rand.Next(1,10) });
        }

        // Pomocniczy konstruktor do mock testow
        public Problem(List<Item> items)
        {
         _itemList = items;       
        }

        // Przeciazona metoda ToString, pozwalajaca na reprezentacje klasy w formie napisu (stringa)
        public new string ToString()
        {
                string returnString = "";
                foreach (var item in _itemList)
                        returnString += $"{item.Id}. Wartosc : {item.Value} | Waga : {item.Weight}\r\n";
                return returnString;
        }

        // Metoda implementujaca rozwiazanie problemu plecakowego metodą zachlanna - sortowanie 
        // po wspolczynniku wartosc/waga od wartosci najwiekszej i pobieranie elementow z listy
        // o ile jest na nie miejsce w liscie reprezentujacej "plecak"
        public Result Solve(int capacity)
        {
                Result result = new Result();
                _itemList.Sort((i1, i2) => ((float)i2.Value/i2.Weight).CompareTo((float)i1.Value/i1.Weight) );
                
                while (capacity > 0)
                {
                        if (_itemList.Count == 0)
                                break;
                        if (_itemList.ElementAt(0).Weight <= capacity)
                        {
                                var firstElement = _itemList.ElementAt(0);
                                result.Backpack.Add(firstElement.Id);
                                result.SumValue += firstElement.Value;
                                result.SumWeight += firstElement.Weight;
                                capacity -= firstElement.Weight;
                        }
                        _itemList.RemoveAt(0);
                }
                return result;
        }
}