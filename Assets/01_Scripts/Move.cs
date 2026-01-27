using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    private bool shouldJump = false;

    public Vector3 vec;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            shouldJump = true;
            Debug.Log(rb.velocity);
            Debug.Log(rb.velocity.magnitude);
        }
    }

    void FixedUpdate()
    {
        if (shouldJump)
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            shouldJump = false;
        }

        vec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rb.AddForce(vec, ForceMode.Impulse);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Cube")
        {
            rb.AddForce(Vector3.up * 2, ForceMode.Impulse);
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * 20, ForceMode.Impulse);
    }
}
