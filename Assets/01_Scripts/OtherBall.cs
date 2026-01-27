using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBall : MonoBehaviour
{
    MeshRenderer mesh;
    Material mat;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Sphere")
        mat.color = new Color(1, 1, 1);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Sphere")
            mat.color = new Color(0.5f, 0.5f, 1);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Sphere")
            mat.color = new Color(0, 0, 0);
    }
}
