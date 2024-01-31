using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){

        }
        else
        {
           Destroy(collision.gameObject);
        }
    }
}
