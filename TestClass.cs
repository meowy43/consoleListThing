
public interface ITestInterface
{
    void Update();
    int Count { get; }
}

public interface IEnemy
{
    int hp { get; }

    void Update();
}

public abstract class BaseEnemy : ITestInterface, IEnemy
{
    public int Count => 0;

    public int hp { protected set; get; }

    public virtual void Update()
    {        
    }

    public abstract void AddHp(int hp);
}

public class Enemy : BaseEnemy
{
    public override void Update()
    {
        Console.WriteLine("Damage");
    }

    public virtual void Damage(int damage)
    {
        hp -= damage;
    }

    public override void AddHp(int hp)
    {
        this.hp += hp;
    }
}

public class TestClass : Enemy
{
    public int Count { private set; get; }

    
    public override void Update()
    {
        //base.Update();
        Console.WriteLine("No Damage");
    }

    override public void Damage(int damage)
    {
        base.Damage(damage);
        //armor

        return;
    }

    public TestClass()
    {
        
    }

    public void SetCount(int count)
    {
        this.Count = count;
    }

    public int GetCount(bool b) => Count;
    
    public int OnAction(int param, bool param2)
    {
        return -1;
    }

    public void Func(System.Action<int> action, int[] array, int index)
    {
        action(array[index]);

        System.Action act;
        System.Func<bool, int, float, int> f = Test;
    }

    public int Test(bool b, int i, float f)
    {
        return -1;
    }
}