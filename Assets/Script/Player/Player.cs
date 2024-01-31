using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    Rigidbody2D rigid;

    PlayerInputAction inputActions;

    Vector3 inputDir = Vector3.zero;

    Animator anim;


    public float moveSpeed = 5.0f;
    public float jumpPower = 5.0f;

    public float spawnDelay = 1.5f;

    bool isJump;
    bool isWalking;
    public bool isLadder;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        inputActions = new PlayerInputAction();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();                       
        inputActions.Player.Jump.performed += OnJump;  
        inputActions.Player.Jump.canceled += OnJump; 
        inputActions.Player.Move.performed += OnMoveStart;
        inputActions.Player.Move.canceled += OnMoveEnd;
        inputActions.Player.Ledder.performed += OnLedder;
        inputActions.Player.Ledder.canceled += OnLedder;
    }

    private void OnDisable()
    {
        inputActions.Player.Ledder.canceled -= OnLedder;
        inputActions.Player.Ledder.performed -= OnLedder;
        inputActions.Player.Move.canceled -= OnMoveEnd;
        inputActions.Player.Move.performed -= OnMoveStart;
        inputActions.Player.Jump.canceled -= OnJump;  
        inputActions.Player.Jump.performed -= OnJump;  
        inputActions.Player.Disable();                     
    }


    void FixedUpdate()
    {
        transform.Translate(Time.deltaTime * moveSpeed * inputDir);
    }

    private void OnLedder(InputAction.CallbackContext context)
    {
        if (isLadder)
        {
            inputDir = context.ReadValue<Vector2>();
            

        }
        
    }


    private void OnJump(InputAction.CallbackContext context)
    {
        if (!isJump)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }

        anim.SetBool("isJumping", isJump);
    }

    private void OnMoveStart(InputAction.CallbackContext context)
    {
        inputDir = context.ReadValue<Vector2>();
        isWalking = true;

        anim.SetBool("isWalking", isWalking);
    }

    private void OnMoveEnd(InputAction.CallbackContext context)
    {
        inputDir = context.ReadValue<Vector2>();
        isWalking = false;
        anim.SetBool("isWalking", isWalking);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (isJump)
        {
            isJump = false;
            anim.SetBool("isJumping", isJump);
        }

        

        if (collision.gameObject.CompareTag("Border"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isLadder = true;
            rigid.gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isLadder = false;
            rigid.gravityScale = 1;
        }
    }
}

