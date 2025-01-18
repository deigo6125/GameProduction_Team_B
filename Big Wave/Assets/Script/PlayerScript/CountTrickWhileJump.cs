using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�W�����v���̃g���b�N�񐔂𐔂���
public class CountTrickWhileJump : MonoBehaviour
{
    private int trickCount = 0;//���̃W�����v�ɂ����g���b�N�̉�
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] JudgeJumpNow judgeJumpNow;
    [SerializeField] Critical critical;
    public int TrickCount
    {
        get { return trickCount; }
    }

    void Update()
    {
        ResetTrickCount();
    }

    void ResetTrickCount()//�g���b�N�񐔂����Z�b�g(update)
    {
        if (!judgeJumpNow.JumpNow())//���n������(�W�����v���Ă��Ȃ��Ȃ�)
        {
            trickCount = 0;//1�W�����v���̃g���b�N�񐔂����Z�b�g
        }
    }

    public void AddTrickCount()//�g���b�N�񐔂̉��Z(1�񂸂�)�A�g���b�N���Ƀg���b�N�񐔂�1����Z����悤�ɂ���
    {
        if (critical.CriticalNow)
        {
            trickCount++;
        }
        else
        {
            trickCount = 0;
        }
    }
}
