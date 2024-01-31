using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject pause;
    
    public void OnPauseButton()
    {
        pause.SetActive(true);
    }



}
