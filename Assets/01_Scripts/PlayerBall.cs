using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public Joystick joystick; // 조이스틱 입력 받기 위한 변수

    [SerializeField][Range(0f, 200f)] float speed; // 이동 스피드
    [SerializeField][Range(0f, 100f)] float jumpPower; // 점프 파워

    public int itemCount = 0; // 아이템 갯수

    private Rigidbody rb;
    private bool isGrounded;
    private bool jumpRequested;

    private void Reset()
    {
        joystick = FindObjectOfType<Joystick>();
        speed = 5f;
        jumpPower = 5.5f;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //inputH = Input.GetAxisRaw("Horizontal"); // 좌우 방향키에 따라 -1,0,1 의 값을 return한다.
        //inputV = Input.GetAxisRaw("Vertical");   // 상하 방향키에 따라 -1,0,1 의 값을 return한다.

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }
    }

    void FixedUpdate()
    {
        //h = Input.GetAxisRaw("Horizontal");
        //v = Input.GetAxisRaw("Vertical");

        // 조이스틱 입력 받기
        float h = joystick.Direction.x;
        float v = joystick.Direction.y;

        Vector3 moveVector = new Vector3(h, 0, v);
        rb.AddForce(moveVector * speed * Time.fixedDeltaTime, ForceMode.Impulse);

        if (jumpRequested && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

            isGrounded = false;
            jumpRequested = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {

        }
    }

    public void AddItem(int count = 1)
    {
        itemCount++;
        Debug.Log("Item Count:" + itemCount);
    }

    // 모바일 점프 버튼
    public void OnJumpButton()
    {
        if (isGrounded)
        {
            jumpRequested = true;
        }
    }
}
