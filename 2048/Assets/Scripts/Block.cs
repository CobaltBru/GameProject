using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;


public class Block : MonoBehaviour
{
    [SerializeField]
    private Color[] blockColors;
    [SerializeField]
    private Image imageBlock;
    [SerializeField]
    private TextMeshProUGUI textBlockNumeric;

    private int numeric;

    public Node Target { private set; get; }

    public int Numeric
    {
        set
        {
            numeric = value;
            textBlockNumeric.text = value.ToString();
            imageBlock.color = blockColors[(int)Mathf.Log(value, 2) - 1];
        }
        get => numeric;
    }

    public void Setup()
    {
        Numeric = Random.Range(0, 100) < 80 ? 2 : 4;

        StartCoroutine(OnScaleAnimation(Vector3.one * 0.5f, Vector3.one, 0.15f));
    }

    public void MoveToNode(Node to)
    {
        Target = to;
    }

    public void StartMove()
    {
        float moveTime = 0.1f;
        StartCoroutine(OnLocalMoveAnimation(Target.localPosition, moveTime, OnAfterMove));
    }

    private void OnAfterMove()
    {
        if(Target != null)
        {
            Target = null;
        }
    }

    private IEnumerator OnScaleAnimation(Vector3 start, Vector3 end, float time)
    {
        float current = 0;
        float percent = 0;

        while(percent<1)
        {
            current += Time.deltaTime;
            percent = current / time;
            transform.localScale = Vector3.Lerp(start, end, percent);

            yield return null;
        }
    }

    private IEnumerator OnLocalMoveAnimation(Vector2 end, float time, UnityAction action)
    {
        float current = 0;
        float percent = 0;
        Vector3 start = GetComponent<RectTransform>().localPosition;

        while(percent<1)
        {
            current += Time.deltaTime;
            percent = current / time;
            transform.localPosition = Vector3.Lerp(start,end,percent);
            yield return null;
        }

        if (action != null) action.Invoke();
    }
}
