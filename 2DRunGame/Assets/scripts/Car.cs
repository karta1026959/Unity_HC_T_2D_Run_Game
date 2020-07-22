using UnityEngine;

public class Car : MonoBehaviour
{
    /*
     int.float.string.bool
     */

    [Header("品牌")]
    public string brand = "Ford";

    [Tooltip("排氣量")]
    public int cc = 2300;

    [Range(0, 100)]
    public float weight = 20.5F;

    [Header("是否有天窗"), Tooltip("是否有天窗")]
    public bool window = true;

    [Header("最高時速"), Tooltip("最高時速"), Range(0, 999)]
    public float speed = 250F;

    [Header("顏色"), Tooltip("顏色")]
    public Color blue = Color.blue;
    [Header("顏色色盤"), Tooltip("顏色色盤")]
    public Color myblue = new Color(0.5f, 0.6f, 0.9f);

    [Header("座標"), Tooltip("座標")]
    public Vector2 posZero = Vector2.zero;
    public Vector2 posOne = Vector2.one;

    [Header("指定多維座標"), Tooltip("指定多維座標")]
    public Vector2 posCustom = new Vector2(9,20);
    public Vector3 pos3 = new Vector3(1,2,3);
    public Vector4 pos4 = new Vector4(4,3,2,1);

    public GameObject cam;
    public Transform tracam;
    public Camera cam1;




}
