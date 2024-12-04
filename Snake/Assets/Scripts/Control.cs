using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] private float _jumpPower = 6f;
    private float _speed = 3f, _fastSpeed = 6f, _lungeSpeed = 5000f, _realSpeed;
    private Rigidbody2D rb;
    private Vector2 moveVector;

    private void Start()    
    {
        rb = GetComponent<Rigidbody2D>();
        _realSpeed = _speed;
    }   

    private void Update()
    {
        Walk();
        Run();
        Lunge();
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }
    
    private void Walk() 
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");
        //rb.position = new Vector2(moveVector.x * _realSpeed, moveVector.y * _realSpeed);
        rb.AddForce(Vector2.left * _realSpeed);
    }

    private void Jump()
    {
        moveVector.y = Input.GetAxisRaw("Jump");
        rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
    }

    private void Run()
    {
        _realSpeed = Input.GetKey(KeyCode.LeftShift) ? _fastSpeed : _speed;
    }

    private void Lunge()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        { 
            if (moveVector.x < 0)
                rb.AddForce(Vector2.left * _lungeSpeed);
            else if (moveVector.x > 0)
                rb.AddForce(Vector2.right * _lungeSpeed);
        }
    }

}