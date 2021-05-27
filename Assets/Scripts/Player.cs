using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;







public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxspeed;
    [SerializeField] private Transform RaycastStartTransform;
    [SerializeField] private float jumpForce;

    private Controls controls;
    private Rigidbody2D rb2D;
    private SpriteRenderer spriterenderer;
    private Animator animator;
    private float direction;
    private bool canJump = false;
    private bool moving = false;


    private void OnEnable()
    {
        controls = new Controls();
        controls.Enable();
        controls.Main.Move.performed += MovePerformed;
        controls.Main.Move.canceled += MoveCanceled;
        controls.Main.Jump.performed += JumpOnperformed;

    }

    private void MoveCanceled(InputAction.CallbackContext obj)
    {
        direction = 0;
        animator.SetBool("moving", false);
    }

    private void MovePerformed(InputAction.CallbackContext obj)
    {
        direction = obj.ReadValue<float>();
        if (direction > 0)
        {
            spriterenderer.flipX = false;
        }
        else
        {
            spriterenderer.flipX = true;
        }
        animator.SetBool("moving", true);
    }

    private void JumpOnperformed(InputAction.CallbackContext obj)
    {
        if (canJump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void Update()
    {
        
        var hit = Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.001f);
        if (hit.collider != null)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }



    private void FixedUpdate()
    {
        var horizontalSpeed = Mathf.Abs(rb2D.velocity.x);
        if (horizontalSpeed < maxspeed)
        {
            rb2D.AddForce(new Vector2(speed * direction, 0));
        }
    }
}






   
