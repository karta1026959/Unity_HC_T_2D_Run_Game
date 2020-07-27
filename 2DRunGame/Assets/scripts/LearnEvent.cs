using UnityEngine;

public class LearnEvent : MonoBehaviour
{
    private void Start()
    {
        print("hello world");
        Shoot("火");
        Drive(50,"後方");
        Drive(500);
        Drive(123,sound:"繃");
    }

    private void Update()
    {
        print("re");
    }

    public void Test()
    {
        print("test");
    }

    public void Shoot(string prop)
    {
        print("施放" + prop + "球");
        print("執行動畫");

    }

    public void Drive(int speed,string direction = "前方",string sound = "咻")
    {
        print(speed + "km/hr");
        print("開車方向" + direction);
        print("開車音效" + sound);
    }

}
