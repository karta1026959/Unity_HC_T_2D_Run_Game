using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region 欄位

    [Header ("移動速度"),Range(0,1000)]
    public float speed = 5;
    [Header("跳躍高度"), Range(0, 1000)]
    public int jump = 350;
    [Header("血量"), Range(0, 2000)]
    public float hp = 500;

    public bool isGround;
    public int coin = 0;
    public float hpMax;
    [Header("音效")]
    public AudioClip soundHit;
    public AudioClip soundSlide;
    public AudioClip soundJump;
    public AudioClip soundCoin;

    [Header("金幣數量")]
    public Text textCoin;
    [Header("血條")]
    public Image imagehp;
    [Header("結束畫面")]
    public GameObject final;
    [Header("過關標題與金幣")]
    public Text Texttitle;
    public Text TextFinalCoin;


    public Animator ani;
    public Rigidbody2D rig;
    public CapsuleCollider2D cap;
    public AudioSource aud;
    private bool dead;
    #endregion

    #region 方法
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        // Time.deltaTime 一禎的時間
        // Update  內移動、旋轉、運動 * Time.deltaTime
        // 避免不同裝置執行速度不同
        // 變形.位移(x,y,z)
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        //bool = 輸入.按鈕狀態(按鈕表.按鈕)
        bool Space = Input.GetKeyDown(KeyCode.Space);

        // 2D射線碰撞物件 = 2D 物理.射線碰撞(起點，方向，長度，圖層)
        // 圖曾語法 : 1 << 圖層編號
        RaycastHit2D hit =  Physics2D.Raycast(transform.position + new Vector3(-0.055f, -1.319f), -transform.up , 0.01f, 1 << 8);

        if (hit)
        {
            // 如果 碰到地板 是否在地板上 = 是
            isGround = true;
            ani.SetBool("跳躍開關", false);
        }
        else
        {
            // 否則 是否在地板上 = 否
            isGround = false;
        }


        if (isGround)
        {
            if (Space)
            {
                // 動畫控制器,設定bool("參數名稱",布林值)
                ani.SetBool("跳躍開關", true);
                // 剛體.增加2維推力
                rig.AddForce(new Vector2(0, jump));
                // 音效來源.播放一次(音效，音量)
                aud.PlayOneShot(soundJump,0.6f);
            }
        }
    }
    /// <summary>
    /// 滑行
    /// </summary>
    private void Slide()
    {
        bool Ctrl = Input.GetKey(KeyCode.LeftControl);
        ani.SetBool("滑行開關", Ctrl);

        // 如果按下左邊ctrl播放一次音效
        // 判斷是如果只有一行可以省略大括號
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            aud.PlayOneShot(soundSlide, 0.8f);
        }

        if (Ctrl)
        {
            //滑行  -0.1 -1.5 1.35 1.35
            cap.offset = new Vector2(-0.1f, -1.5f);
            cap.size = new Vector2(1.35f, 1.35f);
        }
        else
        {
            //站立  -0.1 -0.4 1.35 3.6
            cap.offset = new Vector2(-0.1f, -0.4f);
            cap.size = new Vector2(1.35f, 3.6f);
        }
    }
    /// <summary>
    /// 吃金幣
    /// </summary>
    private void Eatcoin(GameObject obj)
    {
        coin++;  // 遞增
        aud.PlayOneShot(soundCoin, 1.2f); //播放音效
        textCoin.text = "金幣數量： " + coin;
        Destroy(obj,0); // 刪除(金幣物件，延遲時間)
    }
    /// <summary>
    /// 受傷
    /// </summary>
    private void Hit(GameObject obj)
    {
        hp -= 200;
        aud.PlayOneShot(soundHit);
        Destroy(obj, 0);
        imagehp.fillAmount = hp / hpMax;//更新血條

        if (hp <= 0) Dead();
    }
    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        ani.SetTrigger("死亡觸發");  //死亡動畫
        final.SetActive(true);  //顯示結束畫面
        speed = 0;
        dead = true;
        Texttitle.text = "已死亡";
    }
    /// <summary>
    /// 過關
    /// </summary>
    private void Pass()
    {
        speed = 0;
        final.SetActive(true);
        Texttitle.text = "恭喜貓咪已火化";
        TextFinalCoin.text = "本次金幣數量： " + coin;
    }

    #endregion

    #region 事件
    private void Start()
    {
        hpMax = hp;
    }
    private void Update()
    {
        if (dead) return; //死亡 跳出
        if (transform.position.y <= -5) Dead();

        Jump();
        Slide();
        Move();
    }

    //碰撞事件：
    // 兩個物件必須有一個物件勾選 is trigger
    // enter 進入執行一次
    // stay  碰撞時執行一秒約60次 
    // exit  離開執行一次
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin") Eatcoin(collision.gameObject);
        if (collision.tag == "障礙物") Hit(collision.gameObject);
        if (collision.name == "傳送門") Pass();
    }

    // 繪製圖式的事件;繪製輔助線條，只在Scence看得到
    private void OnDrawGizmos()
    {
        // 指定顏色 
        // 圖示.顏色 = 顏色紅色
        Gizmos.color = Color.red;
        // 圖示.繪製射線(起點，方向)
        // transform 此物件的變形元件
        // transform.position 此物件的座標 
        // transform.up 此物件的上方      Y 預設為1
        // transform.right 此物件的右方   X 預設為1
        // transform.forward 此物件的前方 Z 預設為1
        Gizmos.DrawRay(transform.position + new Vector3(-0.055f,-1.319f), -transform.up*0.01f);
    }
    #endregion

}
