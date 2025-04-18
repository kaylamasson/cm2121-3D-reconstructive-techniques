using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Jump : MonoBehaviour
{
    public Animator animator;
    public int jumpSpeed; 
    public string jumpKey; 
    public Rigidbody rb;
    public bool isGrounded;
    public bool isJumping;
    public bool isFalling;

    public bool doubleJump = true; 
    public int jumpCount = 0; 

    public AudioSource jumpSound;


    //movement

    //public int characterSpeed = 2; 


    // Start is called before the first frame update
    void Start()
    {

     rb = this.GetComponent<Rigidbody>();
     animator = this.GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isGrounded);


        //update animators
        animator.SetBool("Jump", isJumping);
        animator.SetBool("Grounded", isGrounded);
        //animator.SetBool("FreeFall", isFalling);
       
         Debug.Log(jumpCount);
    

        //character can only jump when they are grounded
        if ((Input.GetKeyDown(jumpKey)) && doubleJump){
            isJumping = true;
            rb.velocity = new Vector3(0, jumpSpeed, 0);
            isGrounded = false;

            //play 'jump' sound effect
            jumpSound.Play();

            jumpCount ++; 
            

            if (jumpCount == 2)
            {
                doubleJump = false;
            } 
        }
    }


    void FixedUpdate()
    {

       

        //rb.velocity = Input.GetAxis("Vertical") * transform.forward * characterSpeed;

    }

    void OnCollisionEnter() {
        isGrounded = true;
        isJumping = false;
        //Debug.Log("collision");

        doubleJump = true;
        jumpCount = 0; 
    }

    void OnCollisionExit(){
        //isJumping = true;
    }
}