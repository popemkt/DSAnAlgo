using System.Runtime.InteropServices.ComTypes;
using Xunit.Abstractions;

namespace All;

public class Implementation
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Implementation(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test()
    {
        //string array of 1000 items
        //fill it with "nemo"
        var data = new string[] { "one", "two", "three" };
        var input = new DynamicArray<string>();
        foreach (var datum in data)
            input.Push(datum);

        input.Insert(2, "two and a half");
        input.Remove(2);
        _testOutputHelper.WriteLine(input.ToString());
    }

    private class DynamicArray<T>
    {
        public int Length { get; private set; } = 0;
        private T[] Items { get; set; } = new T[100];

        public T? Get(int index)
        {
            return index >= Length ? default : Items[index];
        }

        public void Set(int index, T item)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Length);
            Items[index] = item;
        }

        public void Push(T item)
        {
            IncreaseLength();
            Items[Length - 1] = item;
        }

        public T Pop()
        {
            Length--;
            return Items[Length];
        }

        public T Remove(int index)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Length);
            T item = Items[index];
            Shift(index, true);
            return item;
        }

        public void Insert(int index, T value)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Length);
            Shift(index, false);
            Items[index] = value;
        }

        private void Shift(int index, bool left, int shiftAmount = 1)
        {
            if (!left)
            {
                IncreaseLength(shiftAmount);
                for (int i = index; i < Length; i++)
                {
                    Items[Length - 1 + shiftAmount + index - i] = Items[Length - 1 + index - i];
                }
            }
            else
            {
                Length -= shiftAmount;//Should have own method like IncreaseLength()
                for (int i = index; i < Length; i++)
                {
                    Items[i] = Items[i + shiftAmount];
                }
            }
        }

        private void IncreaseLength(int amount = 1)
        {
            Length += amount;
            if (Length <= Items.Length) return;

            //Or could use Array.Resize()
            var newArray = new T[Items.Length * 2];
            Array.Copy(Items, newArray, Items.Length);
        }
    }
}