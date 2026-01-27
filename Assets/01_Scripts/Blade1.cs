using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade1 : MonoBehaviour
{
    [SerializeField][Range(0f, 200f)] float rotateSpeed;

    void Awake()
    {
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
