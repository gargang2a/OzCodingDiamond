using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField][Range(0f, 100f)] float speed;
    [SerializeField] AudioClip colletSound;

    public GameManager manager;
    private bool isCollected = false; // 버그 수정

    private void Awake()
    {
    }

    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCollected) return;

        if (other.gameObject.name == "Player")
        {
            PlayerBall player = other.GetComponent<PlayerBall>();
            AudioSource.PlayClipAtPoint(colletSound, transform.position);
            manager.GetItem(player.itemCount + 1);
            player.AddItem();
            Destroy(gameObject);
        }
    }
}