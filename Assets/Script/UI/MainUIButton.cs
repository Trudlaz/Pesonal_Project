using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIButton : MonoBehaviour
{
    public void OnMainButton()
    {
        SceneManager.LoadScene("MainUI");
    }
}
