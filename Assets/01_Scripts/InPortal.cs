using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InPortal : MonoBehaviour
{
    Rigidbody rb;
    public GameObject outPortal;
    public AudioClip portalSound;

    [SerializeField][Range(0f, 20f)] float movePower;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (transform.position.y > 2)
            rb.velocity = Vector3.down * movePower;
        if (transform.position.y < 1)
            rb.velocity = Vector3.up * movePower;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(portalSound, transform.position);
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            playerRb.transform.position = outPortal.transform.position + new Vector3(0, 0, -3f);
        }
    }
}
