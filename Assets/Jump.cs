using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Jump : MonoBehaviour
{
    //private Animator animator; 
    public Animator animator;
    public int jumpSpeed; 
    public string jumpKey; 
    public Rigidbody rb;
    public bool isGrounded;
    public bool isJumping;
    public bool isFalling;


    // Start is called before the first frame update
    void Start()
    {

     //animator = GetComponent<Animator>();
     rb = this.GetComponent<Rigidbody>();
     animator = this.GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        //update animators
        animator.SetBool("Jump", isJumping);
        animator.SetBool("Grounded", isGrounded);
        animator.SetBool("FreeFall", isFalling);
       

        if ((Input.GetKey(jumpKey))){
            isJumping = true;
            rb.AddForce(new Vector3(0, jumpSpeed, 0));
            isGrounded = false;
        }
    }

    void OnCollisionEnter() {
        isGrounded = true;
        isJumping = false;
        //Debug.Log("collision");
    }
    
        
    
}
