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
       
        
    }


    void FixedUpdate()
    {
    
        //character can only jump when they are grounded
        if ((Input.GetKey(jumpKey)) && isGrounded){
            isJumping = true;
            rb.velocity = new Vector3(0, jumpSpeed, 0);
            isGrounded = false;
        }

        //rb.velocity = Input.GetAxis("Vertical") * transform.forward * characterSpeed;

    }

    void OnCollisionEnter() {
        isGrounded = true;
        isJumping = false;
        //Debug.Log("collision");
    }

    void OnCollisionExit(){
        isJumping = true;
    }
}