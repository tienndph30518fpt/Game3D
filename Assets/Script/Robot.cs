using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Robot : MonoBehaviour
{
    [SerializeField] Text located;
    
    public AudioSource collidedBox;
    public AudioSource collidedCoin;
    public AudioSource jump;
    public AudioSource fall;
    private bool grounded;
    // public static bool alive = true;
    [SerializeField] private Rigidbody rb;

    public float speed;
    private float horizontalInput;
    [SerializeField]float horizontalMutiplier = 1.5f;
    public float speedIncresePerPonit = 0.1f;
    [SerializeField]float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;
    
    private void Start()
    {
        grounded = true;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // if(!alive)return;
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * speed * horizontalInput * Time.fixedDeltaTime * horizontalMutiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        if (transform.position.y < -1f)
        {
            Debug.Log("fall");
            fall.Play();
        }

        if (transform.position.y < -5f)
        {
            GameManager.inst.Fall();
        }
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            collidedBox.Play();
            located.text = "Collided with box";
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
    
    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        if (isGrounded)
        {
            jump.Play();
            rb.AddForce(Vector3.up * jumpForce);
            grounded = false;

        }
       
            
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            collidedCoin.Play();
            located.text = "Collided with coin";
        }
    }
}
