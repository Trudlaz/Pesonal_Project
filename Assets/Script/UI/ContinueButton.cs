using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    Transform con;
    

    public void OnContinueButton()
    {
        con = gameObject.transform.parent;
        con.gameObject.SetActive(false);
    }
}
