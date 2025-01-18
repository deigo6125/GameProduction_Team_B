using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

//�쐬��:���R
//�g���b�N�̔�����(�o�^���ꂽ)�g���b�N���̏������Ă�
public partial class Trick : MonoBehaviour
{
    //���쐬��:���R
    [Header("�g���b�N���̏���(���\�b�h)")]
    [SerializeField] UnityEvent eventsWhenTrick;//�g���b�N���̏���(���\�b�h)
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] JudgeJumpNow judgeJumpNow;
    [SerializeField] TrickPoint player_TrickPoint;
    [SerializeField] PushedButton_CurrentTrickPattern pushedButton_TrickPattern;
    [SerializeField] Critical critical;
    [SerializeField] Count_Trick_Critical countTrickCombo;
    [SerializeField] CountTrickWhileJump countTrickWhileJump;
    public event Action TrickAction;//�g���b�N���ɌĂԃC�x���g

    //�g���b�N����
    public void TrickTrigger(TrickButton button)
    {
        pushedButton_TrickPattern.SetTrickPattern(button);//�����ꂽ�{�^���̎�ނ�ݒ�

        if (JudgeSuccessOfTrick())//�g���b�N������
        {
            critical.SetCriticalNow();//�����ꂽ�{�^������N���e�B�J���̔���
            countTrickWhileJump.AddTrickCount();//�W�����v���̃g���b�N�񐔂̉��Z
            countTrickCombo.Count();//�g���b�N�R���{�񐔂̉��Z

            //�o�^���ꂽ�S�C�x���g���Ă�
            eventsWhenTrick.Invoke();
            TrickAction?.Invoke();
        }
    }

     bool JudgeSuccessOfTrick()//�g���b�N�������̔���(�����ł����true��Ԃ�)
    {
        int trickCost = pushedButton_TrickPattern.TrickCost;//�g���b�N����ʁA�����ꂽ�{�^���ɑΉ������g���b�N�p�^�[���̃g���b�N�����

        //�W�����v���Ă��違����g���b�N�������(�����Ńg���b�N����̏���������)
        //�ȏ�̏����𖞂����΃g���b�N����
        bool trickIsSuccess = judgeJumpNow.JumpNow() == true && player_TrickPoint.Consume(trickCost);

        return trickIsSuccess;
    }

    //�쐬��:�K��

    //private bool tricked;//�g���b�N���������Ă��Ȃ����̔���

    //public bool Tricked
    //{
    //    get { return tricked; }
    //}

    //void Start()
    //{
    //tricked = false;
    //}

    //void Update()
    //{
    //TrickedtoFalseNoJump();//�W�����v���Ă��Ȃ����U�����Ă��Ȃ�����ɂ���
    //}

    //�W�����v���Ă��Ȃ����U�����Ă��Ȃ�����ɂ���
    //void TrickedtoFalseNoJump()
    //{
    //    if (jumpcontrol.JumpNow == false)//���ʂɐڒn���Ă���Ȃ�
    //    {
    //        tricked = false;//�U�����Ă��Ȃ�
    //    }
    //}
}

