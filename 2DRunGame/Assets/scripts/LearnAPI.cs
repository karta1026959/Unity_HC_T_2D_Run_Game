using UnityEngine;

public class LearnAPI : MonoBehaviour
{

    public GameObject sphere;
    public Transform tra;
    public Transform cube;
    public Light DirectionalLight;
    private void Start()
    {
        print(sphere.layer);
        print("ballxyz: " + tra.position);
        tra.localScale = new Vector3(7, 7, 7);
        DirectionalLight.color = Color.red;

    }

    private void Update()
    {

        cube.Rotate(0, 0, 15);
        cube.Translate(1, 0, 0);
    }
}
