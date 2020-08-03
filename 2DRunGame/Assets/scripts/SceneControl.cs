using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    /// <summary>
    /// 切換場景
    /// </summary>
    private void ChangeScene()
    {   
        //函式庫.語法
        SceneManager.LoadScene("遊戲場景");
    }
    /// <summary>
    /// 離開遊戲
    /// </summary>
    private void Quit()
    {
        Application.Quit();
    }

    //Invoke("方法名稱",秒數)
    /// <summary>
    /// 延遲切換場景
    /// </summary>
    public void DelayChangeScene()
    {
        Invoke("ChangeScene", 0.6f);
    }
    /// <summary>
    /// 延遲離開遊戲
    /// </summary>
    public void DelayQuitScene()
    {
        Invoke("Quit", 0.6f);
    }
}
