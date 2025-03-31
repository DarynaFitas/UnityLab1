using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 5f; 
    public float sideSpeed = 5f;   
    public float jumpForce = 7f;    
    public float boostSpeed = 10f;  
    public float boostDuration = 2f; 
    private Rigidbody rb;
    private bool isGrounded = true;
    private bool isBoosting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Рух вліво-вправо
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * moveHorizontal * sideSpeed * Time.deltaTime);

        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isBoosting)
        {
            StartCoroutine(BoostSpeed());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private System.Collections.IEnumerator BoostSpeed()
    {
        isBoosting = true;
        forwardSpeed = boostSpeed;
        yield return new WaitForSeconds(boostDuration);
        forwardSpeed = 5f;
        isBoosting = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Фініш! Гра завершена!");
            Time.timeScale = 0; 
        }
    }

}
