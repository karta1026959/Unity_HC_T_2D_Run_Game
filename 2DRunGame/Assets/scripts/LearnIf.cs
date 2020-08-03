using UnityEngine;

public class LearnIf : MonoBehaviour
{
    private void Start()
    {
        //if(bool){ }
        if (true)
        {
            print("i'm true");
        }
    }

    public bool open;

    public int score = 100;
    private void Update()
    {
        if(open)
        {
            print("OPEN!");
        }
        else
        {
            print("CLOSE!");
        }

        if (score >= 60)
        {
            print("pass");
        }
        else if (score >= 40) 
        {
            print("test");
        }
        else
        {
            print("false");
        }
    }

}
