using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP1 : MonoBehaviour
{
    [SerializeField] Transform Respawn;
    [SerializeField] GameObject Player;

    private Rigidbody2D rb2D;
    private Vector3 tpspeed;


    private void Start()
    {
        rb2D = Player.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            collision.transform.position = Respawn.position;
            var savedspeed = collision.transform.right;
        tpspeed = savedspeed;
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.right = tpspeed;
        }
    }
}

