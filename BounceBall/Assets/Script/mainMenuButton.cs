using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuButton : MonoBehaviour
{
    public void gotoMainMenu()
    {
        GameManager.currentStageObject.gameObject.SetActive(false);
        GameManager.MainMenuObject.gameObject.SetActive(true);
    }
}
