using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float destroyTime = 3;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        
    }
}
