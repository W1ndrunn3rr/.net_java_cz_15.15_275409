using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests")]
namespace Lab1;

public struct Item
{
        private int _id,_value, _weight;
        public int Id { get => _id; set => _id = value; }
        public int Value { get => _value; set => _value = value; }
        public int Weight { get => _weight; set => _weight = value; }
}

public class Problem
{
        private readonly List<Item> _itemList;

        public Problem(int n, int seed)
        {
                _itemList = new List<Item>();
                Random rand = new Random(seed);
                for (int i = 0; i < n; i++)
                        _itemList!.Add(new Item {Id = i, Value = rand.Next(1,10), Weight = rand.Next(1,10) });
        }

        public Problem(List<Item> items)
        {
         _itemList = items;       
        }

        public new string ToString()
        {
                string returnString = "";
                foreach (var item in _itemList)
                        returnString += $"{item.Id}. Item value: {item.Value} | Item wage: {item.Weight}\n";
                return returnString;
        }

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