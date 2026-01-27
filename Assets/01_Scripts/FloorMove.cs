using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FloorMove : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 100f)]
    float speed;
    bool movingFront;
    const float MinZ = -7f;
    const float MaxZ = 11f;


    void Awake()
    {
        movingFront = false;
    }

    void Update()
    {
        float direction = movingFront ? 1f : -1f;

        transform.position += new Vector3(0, 0, direction) * speed * Time.deltaTime;

        if (transform.position.z >= MaxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, MaxZ);
            movingFront = false;
        }
        else if (transform.position.z <= MinZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, MinZ);
            movingFront = true;
        }
    }
}
