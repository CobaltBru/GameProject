using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 50;
    [SerializeField]
    private Vector3 rotateAngle = Vector3.forward;

    public void Stop()
    {
        rotateSpeed = 0;
    }
    private void Update()
    {
        transform.Rotate(rotateAngle * rotateSpeed * Time.deltaTime);
    }
}
