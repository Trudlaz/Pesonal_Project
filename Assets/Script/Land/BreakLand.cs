using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BreakLand : MonoBehaviour
{
     

    public float breakDelay = 3.0f;

    



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LandBreak());
        }
    }

    IEnumerator LandBreak()
    {
        yield return new WaitForSeconds(breakDelay);
        transform.gameObject.SetActive(false);
    }




}
