using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

//�쐬��:���R
//���݃W�����v���Ă��邩�̔���
public class JudgeJumpNow : MonoBehaviour
{
    public event Action<bool> SwitchJumpNowAction;//�W�����v�J�n�����true�A���n�����false�����Ă��ꂼ���񂾂��Ăяo��
    public event Action LandAction;//���n���ɌĂ�
    public event Action StartJumpAction;//�W�����v�J�n���ɌĂ�
    [SerializeField] OnCollisionActionEvent onCollisionActionEvent;
    private bool jumpNow = false;//���݃W�����v���Ă��邩

    private void Start()
    {
        onCollisionActionEvent.EnterAction += Landing;
    }

    public bool JumpNow()//���݃W�����v���Ă��邩��Ԃ�(���Ă���Ȃ�true)
    {
        return jumpNow;
    }

    public void StartJump()//�W�����v�J�n
    {
        jumpNow = true;
        SwitchJumpNowAction?.Invoke(true);
        StartJumpAction?.Invoke();
    }

    public void Landing(Collision collision)//���n
    {
        if (collision.gameObject.CompareTag("Ground"))//�G��Ă�����̂��n�ʂł���
        {
            jumpNow = false;//���݃W�����v���Ă��邩�̏�Ԃ�ς���
            SwitchJumpNowAction?.Invoke(false);
            LandAction?.Invoke();
        }
    }
}
