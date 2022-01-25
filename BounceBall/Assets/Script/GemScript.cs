using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GemScript : MonoBehaviour
{
    public int count;
    private void Start()
    {
        count = gameObject.transform.childCount;
        StageManager.GemCount = count;
    }

}
