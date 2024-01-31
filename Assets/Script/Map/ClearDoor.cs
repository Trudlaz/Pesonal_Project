using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDoor : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject clearPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pauseButton.gameObject.SetActive(false);
            clearPanel.gameObject.SetActive(true);
        }
    }
}
