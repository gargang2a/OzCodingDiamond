using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zet : MonoBehaviour
{
    GameObject player;

    void Awake()
    {
        player = null;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            player = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            player = null;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (player != null)
            {
                player.SetActive(false);
            }
            player = null;
        }
    }
}
