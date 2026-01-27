using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZetMove : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 200f)]
    public float moveSpeed;
    public float rotationSpeed;

    [SerializeField]
    [Range(-200f, 200f)]
    float frontUp;

    [SerializeField]
    [Range(-200f, 200f)]
    float frontUpAmount;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            transform.Rotate(new Vector3(frontUp, 0, 0), frontUpAmount * Time.deltaTime);
        }
            if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
            transform.position += -transform.forward * moveSpeed * 0.5f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0.5f, -0.5f), rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -0.5f, 0.5f), rotationSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
    }
}
