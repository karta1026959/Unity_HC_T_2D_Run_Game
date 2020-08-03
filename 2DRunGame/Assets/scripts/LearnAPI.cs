using UnityEngine;

public class LearnAPI : MonoBehaviour
{

    public GameObject sphere;
    public Transform tra;
    public Transform cube;
    public Light DirectionalLight;
    public Camera C;
    private void Start()
    {
        print(sphere.layer);
        print("ballxyz: " + tra.position);
        tra.localScale = new Vector3(7, 7, 7);
        DirectionalLight.color = new Color(0.8f,0,0);
        DirectionalLight.Reset();
        C.orthographicSize = 3 ;
    }

    private void Update()
    {

        cube.Rotate(0, 0, 15);
        cube.Translate(1, 0, 0);
    }
}
