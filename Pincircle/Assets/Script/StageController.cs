using System.Collections;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private PinSpawner pinSpawner;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Rotator rotatorTarget;
    [SerializeField]
    private Rotator rotatorIndexPanel;
    [SerializeField]
    private MainMenuUI mainMenuUI;
    [SerializeField]
    private int throwablePinCount;
    [SerializeField]
    private int stuckPinCount;

    [SerializeField]
    private AudioClip audioGameOver;
    [SerializeField]
    private AudioClip audioGameClear;

    private AudioSource audioSource;

    private Vector3 firstTPinPosition = Vector3.down * 2;
    public float TPinDistance { private set; get; } = 1;

    private Color failBackgroundColor = new Color(0.4f, 0.1f, 0.1f);
    private Color clearBackgroundColor = new Color(0,0.5f,0.25f);
    public bool IsGameOver { set; get; } = false;
    public bool IsGameStart { set; get; } = false;

    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        pinSpawner.Setup();
        for(int i = 0;i<throwablePinCount; i++)
        {
            pinSpawner.SpawnThrowablePin(firstTPinPosition + Vector3.down * TPinDistance * i, throwablePinCount - i);
        }
        for(int i = 0;i< stuckPinCount;i++)
        {
            float angle = (360/stuckPinCount)*i;
            pinSpawner.SpawnStuckPin(angle, throwablePinCount + 1 + i);
        }
    }

    public void GameOver()
    {
        IsGameOver = true;

        mainCamera.backgroundColor = failBackgroundColor;

        rotatorTarget.Stop();

        audioSource.clip = audioGameOver;
        audioSource.Play();

        StartCoroutine("StageExit", 0.5f);
    }
    public void DecreaseThrowablePin()
    {
        throwablePinCount--;

        if(throwablePinCount==0)
        {
            StartCoroutine("GameClear");
        }
    }

    private IEnumerator GameClear()
    {
        yield return new WaitForSeconds(0.1f);

        if(IsGameOver == true)
        {
            yield break;
        }

        mainCamera.backgroundColor = clearBackgroundColor;
        rotatorTarget.RotateFast();
        rotatorIndexPanel.RotateFast();

        int index = PlayerPrefs.GetInt("StageLevel");
        PlayerPrefs.SetInt("StageLevel", index + 1);

        audioSource.clip = audioGameClear;
        audioSource.Play();

        StartCoroutine("StageExit", 1);
    }

    private IEnumerator StageExit(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        mainMenuUI.StageExit();
    }
}
