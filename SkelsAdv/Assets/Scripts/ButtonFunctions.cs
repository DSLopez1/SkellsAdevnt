using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public void ResumeGame()
    {
        GameManager.instance.StateUnpaused();
    }
}
