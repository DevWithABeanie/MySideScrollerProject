using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Character Movement Varibles")]
    public float characterMoveSpeed;
    public float characterJumpHight;
    private bool characterDoubleJump;
    private float characterMoveVelocity; 

    [Header("Ground Check Varibles")]
    public Transform groundCheck;
    public float groundCheckRadious;
    public LayerMask whatIsGround;
    private bool characterIsGrounded;

    private Animator animator; 

	void Start () {
        animator = GetComponent<Animator>(); 
	}
	
	
	void Update () {

        CharacterMovement();

	}

    void FixedUpdate()
    {
        characterIsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadious, whatIsGround);  
    }

    public void CharacterMovement()
    {

        ////////////////////
        //Jumping Controls//
        ////////////////////

        if (characterIsGrounded)
        {
            characterDoubleJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && characterIsGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, characterJumpHight);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !characterDoubleJump && !characterIsGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, characterJumpHight);
            characterDoubleJump = true;
        }

        animator.SetBool("Grounded", characterIsGrounded);

        /////////////////////
        //Movement Controls//
        /////////////////////

        characterMoveVelocity = 0f; 

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(characterMoveSpeed, GetComponent<Rigidbody2D>().velocity.y);//
            characterMoveVelocity = characterMoveSpeed; 
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-characterMoveSpeed, GetComponent<Rigidbody2D>().velocity.y);//
            characterMoveVelocity = -characterMoveSpeed; 
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(characterMoveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        if(GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            transform.localScale = new Vector3(2, 2, 3); 
        }else if(GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            transform.localScale = new Vector3(-2, 2, 3);
        }

        animator.SetFloat("moveSpeed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x)); 
    }
}
