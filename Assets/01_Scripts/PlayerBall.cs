using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{

    [SerializeField][Range(0f, 200f)] float speed; // 이동 스피드
    [SerializeField][Range(0f, 100f)] float jumpPower; // 점프 파워
    public int itemCount; // 아이템 갯수

    bool isJump;
    bool inputJumpKey;

    Rigidbody rb;

    private float inputH;
    private float inputV;

    void Awake()
    {
        itemCount = 0;
        isJump = false;
        inputJumpKey = false;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        inputH = Input.GetAxisRaw("Horizontal"); // 좌우 방향키에 따라 -1,0,1 의 값을 return한다.
        inputV = Input.GetAxisRaw("Vertical");   // 상하 방향키에 따라 -1,0,1 의 값을 return한다.

        if (Input.GetButtonDown("Jump") && isJump == false)
        {
            inputJumpKey = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {

        }
    }

    void FixedUpdate()
    {
        Vector3 moveVector = new Vector3(inputH, 0, inputV);
        rb.AddForce(moveVector * speed * Time.fixedDeltaTime, ForceMode.Impulse);

        if (inputJumpKey)
        {
            isJump = true;
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

            inputJumpKey = false;
        }
    }

    public void AddItem(int count = 1)
    {
        itemCount++;
        Debug.Log("Item Count:" + itemCount);
    }
}
