using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("�÷��̾� �����Ͱ� �غ�.");
    }

    void OnEnable()
    {
        Debug.Log("Ȱ��ȭ");
    }

    void Start()
    {
        Debug.Log("��� ��� ì����");
    }

    void FixedUpdate()
    {
        Debug.Log("�̵�");
    }

    void Update()
    {
        Debug.Log("���");
    }

    void LateUpdate()
    {
        Debug.Log("����ġ ȹ��");
    }
    void OnDisable()
    {
        Debug.Log("�α׾ƿ�");
    }
    void OnDestroy()
    {
        Debug.Log("������ ����");
    }
}
