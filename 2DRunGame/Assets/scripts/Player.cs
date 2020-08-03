﻿using UnityEngine;

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

    [Header("音效")]
    public AudioClip soundHit;
    public AudioClip soundSlide;
    public AudioClip soundJump;
    public AudioClip soundCoin;

    public Animator ani;
    public Rigidbody2D rid;
    public CapsuleCollider2D cap;

    #endregion

    #region 方法
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {

    }
    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        //bool = 輸入.按鈕狀態(按鈕表.按鈕)
        bool Space = Input.GetKeyDown(KeyCode.Space);
        //動畫控制器,設定bool("參數名稱",值)
        ani.SetBool("跳躍開關",Space);
    }
    /// <summary>
    /// 滑行
    /// </summary>
    private void Slide()
    {
        bool Ctrl = Input.GetKey(KeyCode.LeftControl);
        ani.SetBool("滑行開關", Ctrl);
        //站立  -0.1 -0.4 1 3.2
        //滑行  -0.1 -1.5 1 1.4
        if (Ctrl)
        {
            
        }
        else
        {

        }
    }
    /// <summary>
    /// 吃金幣
    /// </summary>
    private void Eatcoin()
    {

    }
    /// <summary>
    /// 受傷
    /// </summary>
    private void Hit()
    {

    }
    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {

    }
    /// <summary>
    /// 過關
    /// </summary>
    private void Pass()
    {

    }

    #endregion

    #region 事件
    private void Start()
    {
        
    }
    private void Update()
    {
        Jump();
        Slide();
    }
    #endregion

}
