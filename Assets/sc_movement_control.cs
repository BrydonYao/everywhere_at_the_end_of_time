using UnityEngine;

public class sc_movement_control : MonoBehaviour
{
    public SpriteRenderer thisSprite;
    public Rigidbody2D thisRigid2D;
    public float force = 10;
    public float jumpForce = 10;
    public sc_isGrounded groundCheckScript;
    public bool onPlatform;
    public float gravityInAir = 2f;

    public Vector3 movementVector;


    void Start()
    {
        GetComponent<Rigidbody2D>();
    }

    public bool moving;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            thisRigid2D.AddForce(Vector2.right * force * Time.fixedDeltaTime, ForceMode2D.Impulse);
            if (thisSprite.flipX == false)
            {
                thisSprite.flipX = true;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            thisRigid2D.AddForce(-Vector2.right * force * Time.fixedDeltaTime, ForceMode2D.Impulse);
            if (thisSprite.flipX == true)
            {
                thisSprite.flipX = false;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)){
            if (groundCheckScript.isGrounded){
                thisRigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
          }
            if (groundCheckScript.isGrounded == true){
                thisRigid2D.gravityScale = 1;
            }
            else {
                thisRigid2D.gravityScale = gravityInAir;
            }
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Mushrooms")){

            Destroy(other.gameObject);
        }
    }
}