using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [Header("�e�̓�������(0��1�̂ݓ��͂��Ă�������)")]
    [SerializeField] Vector3 Direction;
    [Header("�e�̓����X�s�[�h")]
    [SerializeField] float moveSpeed;
    [Header("���]���邩�ǂ���")]
    [SerializeField] bool directionTurn;
    [Header("���]����^�C�~���O")]
    [SerializeField] float timingTurn;
    float countTime;
    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if (directionTurn && countTime > timingTurn)
        {
            countTime = 0;
            Direction = -Direction;
        }
        transform.position += Direction * moveSpeed * Time.deltaTime;
    }
}
