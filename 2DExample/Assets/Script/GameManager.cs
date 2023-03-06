using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    public int health;
    public PlayerMove player;
    public GameObject[] Stages;

    public Image[] UIhealth;
    public TextMeshProUGUI UIPoint;
    public TextMeshProUGUI UIStage;
    public GameObject UIRestartBtn;

    public void NextStage()
    {
        //ChangeStage
        if(stageIndex < Stages.Length)
        {
            Stages[stageIndex].SetActive(false);
            stageIndex++;
            Stages[stageIndex].SetActive(true);
            PlayerReposition();

            UIStage.text = "STAGE " + (stageIndex + 1);
        }
        else //Game Clear
        {
            //Player Control Lock
            Time.timeScale = 0;
            //Result UI
            Debug.Log("게임 클리어!");
            //Restart Button UI
            TextMeshProUGUI btnText = UIRestartBtn.GetComponentInChildren<TextMeshProUGUI>();
            btnText.text = "Game Clear";
            UIRestartBtn.SetActive(true);
        }
        

        //calculate point
        totalPoint += stagePoint;
        stagePoint = 0;
    }

    void Update()
    {
        UIPoint.text = (totalPoint + stagePoint).ToString();
    }
    public void HealthDown()
    {
        if (health > 1)
        {
            health--;
            UIhealth[health].color = new Color(1, 0, 0, 0.4f);
        }
        else
        {
            //All Health UI off
            UIhealth[0].color = new Color(1, 0, 0, 0.4f);
            //Player die effect
            player.OnDie();
            //Retry Button UI
            UIRestartBtn.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            

            //Player Reposition
            if(health > 1)
            {
                PlayerReposition();
            }
            //health Down
            HealthDown();
        }
    }

    void PlayerReposition()
    {
        player.transform.position = new Vector3(0, 0, -1);
        player.VelocityZero();
    }

    public void Restart()
    {
        Time.timeScale= 1;
        SceneManager.LoadScene(0);
    }
}
