using UnityEngine;

public class LearnAPIStatic : MonoBehaviour
{

    void Start()
    {
        print(Random.value);
        print(Mathf.PI);
        Time.timeScale = 10;
        float r = Random.Range(100.1F, 200.2F);
        print("隨機值: " + r);
        int ri = Random.Range(1,3);
        print("隨機值: " + ri);
        Cursor.visible = false;
        print(Mathf.Abs(-9));
    }
    private void Update()
    {

        print("遊戲時間: " + Time.time);
        print("按任意鍵" + Input.anyKeyDown);

    }

}
