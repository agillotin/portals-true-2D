using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP1 : MonoBehaviour
{
    [SerializeField] Transform Respawn;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            collision.transform.position = Respawn.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))

    }

}

