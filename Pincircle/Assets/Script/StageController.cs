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
    private int throwablePinCount;
    [SerializeField]
    private int stuckPinCount;

    private Vector3 firstTPinPosition = Vector3.down * 2;
    public float TPinDistance { private set; get; } = 1;

    private Color failBackgroundColor = new Color(0.4f, 0.1f, 0.1f);
    public bool IsGameOver { set; get; } = false;

    private void Awake()
    {
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
    }
}
