using UnityEngine;

public class ObjectAutoDestroyerByTime : MonoBehaviour
{
    [SerializeField]
    private float destroyTime;

    private void Awake()
    {
        Destroy(gameObject, destroyTime);
    }

}
