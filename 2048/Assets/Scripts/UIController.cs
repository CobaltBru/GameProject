using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textCurrentScore;

    public void UpdateCurrentScore(int score)
    {
        textCurrentScore.text = score.ToString();
    }
}
