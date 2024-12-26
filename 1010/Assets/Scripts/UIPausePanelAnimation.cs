using UnityEngine;

public class UIPausePanelAnimation : MonoBehaviour
{
    [SerializeField]
    private GameObject imageBackgroundOverlay;
    [SerializeField]
    private Animator animator;

    public void OnAppear()
    {
        imageBackgroundOverlay.SetActive(true);
        gameObject.SetActive(true);
        animator.SetTrigger("OnAppear");
    }

    public void OnDisappear()
    {
        animator.SetTrigger("OnDisappear");
    }

    public void EndOfDisappear()
    {
        imageBackgroundOverlay.SetActive(false);
        gameObject.SetActive(false);
    }
}
