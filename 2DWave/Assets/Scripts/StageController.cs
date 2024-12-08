using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private CameraController cameraController;
    [SerializeField]
    private GameObject textTitle;
    [SerializeField]
    private GameObject textTapToPlay;
    [SerializeField]
    private TextMeshProUGUI textCurrentScore;
    [SerializeField]
    private TextMeshProUGUI textBestScore;

    [SerializeField]
    private GameObject buttonContinue;
    [SerializeField]
    private GameObject textScoreText;

    private int currentScore = 0;
    private int bestScore = 0;

    public bool IsGameOver { private set; get; } = false;

    private IEnumerator Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
        textBestScore.text = $"<size=50>BEST</size>\n<size=100>{bestScore}</size>";


        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
                yield break;
            }
            yield return null;
        }
        

        
    }

    private void GameStart()
    {
        textTitle.SetActive(false);
        textTapToPlay.SetActive(false);

        textCurrentScore.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        IsGameOver = true;

        if(currentScore == bestScore)
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
        }
        buttonContinue.SetActive(true);
        textScoreText.SetActive(true);
    }

    public void IncreaseScore(int score)
    {
        currentScore += score;
        textCurrentScore.text = currentScore.ToString();

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            textBestScore.text = $"<size=50>BEST</size>\n<size=100>{bestScore}</size>";
        }
        cameraController.ChangeBackgroundColor();

    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
