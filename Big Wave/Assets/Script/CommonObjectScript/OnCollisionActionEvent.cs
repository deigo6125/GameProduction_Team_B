using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//����I�u�W�F�N�g���Փ˂����u�ԂɌĂт����֐���o�^���ČĂяo�����Ƃ��o����
//�����蔻��̂��Ă���I�u�W�F�N�g�ɃA�^�b�`���Ă��g����������
public class OnCollisionActionEvent : MonoBehaviour
{
    public event Action<Collision> EnterAction;
    public event Action<Collision> StayAction;
    public event Action<Collision> ExitAction;

    void OnCollisionEnter(Collision other)
    {
        EnterAction?.Invoke(other);
    }

    void OnCollisionStay(Collision other)
    {
        StayAction?.Invoke(other);
    }

    void OnCollisionExit(Collision other)
    {
        ExitAction?.Invoke(other);
    }
}
