using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBalls : MonoBehaviour
{
    MeshRenderer mesh;
    Material mat;
    void Start()
    {
        mesh= GetComponent<MeshRenderer>();
        mat = mesh.material;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "myBall")
            mat.color = new Color(0,0,0);
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "myBall")
            mat.color = new Color(1, 1, 1);
    }

}
