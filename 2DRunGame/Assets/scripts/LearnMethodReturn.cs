using UnityEngine;

public class LearnMethodReturn : MonoBehaviour
{

    private void Start()
    {
        Method();
        int a = Ten();
        print(a);

        string n = Name();
        print(n);
        print(Speed());
        print("補血: " + HpAdd(90));
    }

    public void Method()
    {
        print("一般方法");
    }
    public int Ten()
    {
        return 10;

    }

    public string Name()
    {
        return "KID";
    }
    public float Speed()
    {

        return 1.5f;
    }

    public float HpAdd(float hp)
    {
        hp += 10;
        return hp;

    }
}
