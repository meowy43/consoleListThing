internal class Program
{
    private static void Main(string[] args)
    {
        MyList<int> myList= new MyList<int>(2);
        myList.Add(0);
        myList.Add(1);
        myList.Add(3);
        myList.Add(2);
        myList.Add(2);
        myList.Insert(0, -1);
        Console.WriteLine(myList.IndexOf(2));
        myList.RemoveAll(2);
        myList.RemoveAt(2);
        Console.WriteLine(myList.ToString());

        var it = myList.Find(item=>item == 1);

        myList.Sort((x1, x2)=> x1.CompareTo(x2));

        // List<BaseEnemy> list = new List<BaseEnemy>();
        

        // TestClass testClass = new TestClass();
        // Enemy enemy = new Enemy();


        // testClass.AddHp(0);

        // list.Add(enemy);
        // list.Add(testClass);
        // list.ForEach(en => en.Update());
        
        // ITestInterface test = enemy;
        // test.Update();
    }
}