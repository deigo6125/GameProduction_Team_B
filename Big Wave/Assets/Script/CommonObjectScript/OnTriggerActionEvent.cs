using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�쐬��:���R
//����I�u�W�F�N�g���ڐG�����u�ԂɌĂт����֐���o�^���ČĂяo�����Ƃ��o����
//�����蔻��̂��Ă���I�u�W�F�N�g�ɃA�^�b�`���Ă��g����������
public class OnTriggerActionEvent : MonoBehaviour
{
    public event Action<Collider> EnterAction;
    public event Action<Collider> StayAction;
    public event Action<Collider> ExitAction;

    void OnTriggerEnter(Collider other)
    {
        EnterAction?.Invoke(other);
    }

    void OnTriggerStay(Collider other)
    {
        StayAction?.Invoke(other);
    }

    void OnTriggerExit(Collider other)
    {
        ExitAction?.Invoke(other);
    }
}
