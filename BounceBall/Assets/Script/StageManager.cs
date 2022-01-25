using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    static public int GemCount;
    private int gem;
    Vector3 ballpos;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Awake()
    {
        ballpos = gameObject.transform.GetChild(0).transform.position;
        gem = GemCount;
    }
    private void OnEnable()
    {
        GemCount = gem;
        gameObject.transform.GetChild(0).transform.position = ballpos;
        for(int i=0;i<gem;i++)
        {
            gameObject.transform.GetChild(2).GetChild(i).gameObject.SetActive(true);
        }
    }
    void Update()
    {
        if(GemCount<=0)
        {
            clearTheGame();
        }
    }
    void clearTheGame()
    {
        GameManager.endMessage.gameObject.SetActive(true);
    }
}
