using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReload : MonoBehaviour
{
    public void ReloadStage()
    {
        GameManager.currentStageObject.gameObject.SetActive(false);

        GameManager.currentStageObject.gameObject.SetActive(true);
    }
}
