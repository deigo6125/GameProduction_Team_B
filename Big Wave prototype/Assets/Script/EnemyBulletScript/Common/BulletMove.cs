using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [Header("弾の動く方向(0か1のみ入力してください)")]
    [SerializeField] Vector3 Direction;
    [Header("弾の動くスピード")]
    [SerializeField] float moveSpeed;
    [Header("反転するかどうか")]
    [SerializeField] bool directionTurn;
    [Header("反転するタイミング")]
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
