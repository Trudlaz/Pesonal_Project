using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StageNumButton : MonoBehaviour
{

    public void ONSelectStageButton()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;

        SceneManager.LoadScene(buttonName);
    }
}
