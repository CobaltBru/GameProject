using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotoStageButton : MonoBehaviour
{
    public int stagenumber=0;
    private void Start()
    {
        GameManager.currentStageObject = GameObject.Find("StagePreset").transform.GetChild(stagenumber).gameObject;
        GameManager.currentStage = stagenumber;
    }
    public void intotheStage()
    {
        gameObject.transform.parent.parent.parent.parent.gameObject.SetActive(false);
        GameManager.currentStageObject.gameObject.SetActive(true);
    }
}
