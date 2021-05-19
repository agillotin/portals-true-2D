using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class player2 : MonoBehaviour
{
    //On créé des variables sérialisées afin de pouvoir les changer à notre grés de manière plus simple
    [SerializeField] private float speed;
    [SerializeField] private float maxspeed;
    [SerializeField] private float rollForce;
    [SerializeField] private Transform RaycastStartTransform;

    private SpriteRenderer spriterenderer;
    private Animator animator;
    private Rigidbody2D rb2D;
    private Controls controls;
    private float direction;
    private void OnEnable()
    {
        controls = new Controls();
        controls.Enable();
        controls.Main.Move.performed += MovePerformed;
        
        controls.Main.Move.canceled += MoveCanceled;
        
    }
    private void MoveCanceled(InputAction.CallbackContext obj)
    {
        direction = 0;
    }
    private void MovePerformed(InputAction.CallbackContext obj)
    {
        direction = obj.ReadValue<float>();
        if (direction > 0)
        {
            spriterenderer.flipX = true;
            //ChangeAnimationState(RUN_RIGHT);
        }
        else //(direction<0)
        {
            spriterenderer.flipX = false;
            //ChangeAnimationState(RUN_LEFT);
        }
    }   
        void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
            spriterenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }
        void FixedUpdate()
        {
            var horizontalSpeed = Mathf.Abs(rb2D.velocity.x);
            if (horizontalSpeed < maxspeed)
            {
                rb2D.AddForce(new Vector2(speed * direction, 0));
            }
        }
    }
