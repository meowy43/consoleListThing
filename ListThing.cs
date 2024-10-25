using System.Xml;

public class MyList<TItem>
{
    private TItem[] _array;
    private int _count = 0;
    public int _capacity = 1;
    private TItem[] tempArray;

    public int Capacity
    {
        set
        {
            if (_capacity < value)
            {
                System.Array.Resize(ref _array, value);
                Console.WriteLine("cap: ", value);
                _capacity = value;
            }
            
        }
        get => _capacity;
    }

    public int Count => _count;

    public MyList()
    {
        _array = new TItem[_capacity];
        tempArray = new TItem[_capacity];
    }

    public MyList(int capacity)
    {
        _array = new TItem[capacity];
        tempArray = new TItem[_capacity];
        this.Capacity = capacity;
    }

    public void Add(TItem item) 
    {
        if (_count + 1 >= _capacity)
        {
            this.Capacity *= 2;
        }

        _array[_count++] = item;
    }

    public void RemoveAll(TItem item) 
    {
        tempArray = new TItem[_capacity];
        int j = 0;
        int i;
        for (i = 0; i < _count; i++)
        {
            if (Comparer<TItem>.Default.Compare(_array[i], item) != 0) 
            {
                tempArray[j] = _array[i];
                j++;
            }
        }
        _count-=i-j;
        _array = tempArray;
    }

    public void RemoveAt(int index) 
    {
        if(index<_count)
        {
            tempArray = new TItem[_capacity];
            int j = 0;
            for (int i = 0; i < _count; i++)
            {
                if (i!=index) 
                {
                    tempArray[j] = _array[i];
                    j++;
                }
            }
            _count--;
            _array = tempArray;
        }
    }

    public void Insert(int index, TItem item) 
    {
        if(index<_count)
        {
            tempArray = new TItem[_capacity];
            int j = 0;
            for (int i = 0; i < _count; i++)
            {
                if (i==index) 
                {
                    tempArray[j] = item;
                    j++;
                }

                tempArray[j] = _array[i];
                    j++;
            }
            _array = tempArray;
        }
    }

    public void Clear() 
    {
        _array = new TItem[_capacity];
        _count = 0;
    }

    public override string ToString() 
    { 
        string output = "";
        for(int i = 0; i < _count;)
        {
            output += _array[i++];
            if (i >= _count) break;
            output += ", ";
        }
        return output; 
    }

    public int IndexOf(TItem item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (Comparer<TItem>.Default.Compare(_array[i], item) == 0) 
            {
                return i;
            }
        }
        return -1;
    }

    public void ForEach(Action<TItem> action)
    {
        for (int i = 0; i < _count; i++)
        {
            action(_array[i]);
        }
    }

    public TItem Find(Func<TItem, bool>  predicate)
    {
        for (int i = 0; i < _count; i++)
        {
            if(predicate(_array[i]))
            {
                return _array[i];
            }
        }
        return default(TItem);
    }

    public void Sort(Func<TItem, TItem, int> compare)
    {
        int output = -1;
        for (int i = 0; i<_count;i++)
        {
            output = compare(_array[i+1], _array[i]);
            //Array.Sort(_array[i], _array[i+1]); //what do you do with 2 compared items?? how is this sorting if only 2 items?? help?? im confused
            //why only 2 items at a time??
        }
    }
}
