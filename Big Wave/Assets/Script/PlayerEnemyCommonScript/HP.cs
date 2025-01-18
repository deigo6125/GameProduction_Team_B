using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

//�쐬��:���R
//HP
public class HP : MonoBehaviour
{
    [Header("�ő�̗�")]
    [SerializeField] float hpMax = 500;//�ő�̗�
    private float hp = 500;//���݂̗̑�
    bool _dead=false;//���S����
    bool _fix=false;//�̗͂��������Ȃ��悤�Œ�
    const float _deadHp = 0;//���S�����c��̗�
    
    public bool Fix
    {
        get { return _fix; }
        set { _fix = value; }
    }

    public float Hp
    {
        get { return hp; }
        set 
        {
            if (_fix||_dead) return;//�Œ莞�܂��͎��S���̗͑͂�ϓ������Ȃ�

            hp = value;
           
            if (hp <= _deadHp && !_dead)//���S��
            {
                _dead = true;
            }

            hp = Mathf.Clamp(hp, _deadHp, hpMax);//�̗͂����E�˔j���Ȃ��悤��
        }
    }

    public float HpMax
    {
        get { return hpMax; }
        set { hpMax = value; }
    }

    void Start()
    {
        //Hp�̏�����
        hp = hpMax;   
    }
}
