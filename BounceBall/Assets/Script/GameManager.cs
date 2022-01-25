using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public int currentStage;
    static public GameObject currentStageObject;
    static public GameObject MainMenuObject;
    static public GameObject endMessage;
    void Start()
    {
        MainMenuObject = GameObject.Find("MainMenu").gameObject;
        endMessage = GameObject.Find("EndMessage").gameObject;
    }
    void Update()
    {
        
    }
}
