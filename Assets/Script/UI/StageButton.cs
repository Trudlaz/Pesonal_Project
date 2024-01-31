using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    public void OnStageButton()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;

        SceneManager.LoadScene(buttonName);
    }
}
