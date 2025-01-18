using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straight : PathBase
{
    [Header("�O���ړ����x")]
    [SerializeField] float speed = 40f;//�O���ړ����x
    [SerializeField] GameObject target;
    // Update is called once per frame
   
    public override void OnUpdate()
    {
        Move();
    }

    //�O���ړ�
    //speed�̑����őO�ɐi��
    void Move()
    {
        Vector3 move = Vector3.forward;
        transform.Translate(move * Time.deltaTime * speed);
    }
}
