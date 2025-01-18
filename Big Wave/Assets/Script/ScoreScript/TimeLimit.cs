using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�쐬��:���R
//��������
public class TimeLimit : MonoBehaviour
{
    [Header("���������ԁi�b�j")]
    [SerializeField] float _timeLimit = 120;//��������(�b)
    private float _remainingTime;//�c�莞��
    bool _timeUp=false;//���Ԑ؂ꂩ
    const float _timeUpRemainingTime = 0;//���Ԑ؂�����c�莞��

    public bool TimeUp { get { return _timeUp; } }//���Ԑ؂ꂩ

    public float RemainingTime { get { return _remainingTime; } }//�c�莞��

    public float ElapsedTime { get { return _timeLimit - _remainingTime; } }//�o�ߎ���

    void Awake()
    {
        _remainingTime = _timeLimit;
    }

    void Update()
    {
       UpdateTime();
    }

    void UpdateTime()//���Ԃ̍X�V(�X�C�b�`���I�t�̎��͎��Ԃ��~�߂�)
    {
        if (_timeUp) return;//���Ԑ؂�̎��͎c�莞�Ԃ�����Ȃ��悤�ɂ���

        _remainingTime -= Time.deltaTime;

        if(_remainingTime<=_timeUpRemainingTime)//���Ԑ؂ꎞ
        {
            _timeUp = true;
        }
    }
}
