using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�W�����v�ҋ@���[�V�����̑J��
public class WaitingForJumpAnim : MonoBehaviour
{
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] Animator animator;
    [SerializeField] ControllerOfJump controllerOfJump;
    [SerializeField] JudgeJumpable judgeJumpable;

    void Update()
    {
        WaitingForJumpBool();
    }

    void WaitingForJumpBool()
    {
        //�W�����v�ł��邩�W�����v�̃{�^���������Ă鎞�̂݃W�����v�������[�V����������
        animator?.SetBool("WaitingForJump", judgeJumpable.Jumpable&&controllerOfJump.Pushing);
    }
}
