using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocity;
    public Rigidbody2D playerRB;
    public float jumpForce;
    public Animator animator;
    public Transform cam;

    private bool isJumping; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam.position = new Vector3 (transform.position.x, transform.position.y, cam.position.z);
        Move();
        Jump();
    }

    void Move(){
        float direction = Input.GetAxis("Horizontal");
        playerRB.velocity = new Vector2( direction * velocity, playerRB.velocity.y );

        Flip(direction);
    }

    void Flip(float direction){
        if (direction > 0f ){
            transform.eulerAngles = new Vector2(0f, 0f);

            if(!isJumping)
                animator.SetInteger("Transition", 1);
        }

        if (direction < 0f ){
            transform.eulerAngles = new Vector2(0f, 180f);

            if(!isJumping)
                animator.SetInteger("Transition", 1);        
        }

        if (direction == 0f){
            if(!isJumping)
                animator.SetInteger("Transition", 0);
        }
    }
    void Jump(){
        if (Input.GetButtonDown("Jump") && !isJumping){
            isJumping = true;
            playerRB.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            animator.SetInteger("Transition", 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 8){
            isJumping = false;
            animator.SetInteger("Transition", 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Bee")){

        }

        if (collision.CompareTag("BeeHead")){
            Destroy(collision.transform.parent.gameObject);
            playerRB.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
