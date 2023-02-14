using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("플레이어 데이터가 준비.");
    }

    void OnEnable()
    {
        Debug.Log("활성화");
    }

    void Start()
    {
        Debug.Log("사냥 장비 챙겼음");
    }

    void FixedUpdate()
    {
        Debug.Log("이동");
    }

    void Update()
    {
        Debug.Log("사냥");
    }

    void LateUpdate()
    {
        Debug.Log("경험치 획득");
    }
    void OnDisable()
    {
        Debug.Log("로그아웃");
    }
    void OnDestroy()
    {
        Debug.Log("데이터 해제");
    }
}
