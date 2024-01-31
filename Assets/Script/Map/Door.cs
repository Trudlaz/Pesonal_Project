using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    void LoadNextScean()
    {
        Scene scene = SceneManager.GetActiveScene();

        int curScean = scene.buildIndex;

        int nextScean = curScean + 1;   

        SceneManager.LoadScene(nextScean);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LoadNextScean();
        }
    }
}
