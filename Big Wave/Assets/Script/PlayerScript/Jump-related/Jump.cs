using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

//�쐬��:���R
//�W�����v�̏���
public class Jump : MonoBehaviour
{
    [Header("�W�����v��")]
    [SerializeField] JumpPower jumpPower;
    [Header("�W�����v�֌W�̃R���g���[������")]
    [SerializeField] ControllerOfJump controllerOfJump;//�W�����v�֌W�̃R���g���[������
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] Rigidbody rb;
    [SerializeField] JudgeJumpNow judgeJumpNow;
    [SerializeField] JudgeOnceReachedHighestPoint_Jumping judgeOnceReachedHighestPoint_Jumping;
    [SerializeField] JudgeJumpable judgeJumpable;

    void Start()
    {
        controllerOfJump.ExitAction += JumpTrigger;
       
    }

    void JumpTrigger()//�W�����v����
    {
        if (judgeJumpable.Jumpable)//�W�����v�ł��邩����
        {
            //�W�����v����
            judgeJumpNow.StartJump();
            judgeOnceReachedHighestPoint_Jumping.StartJump();
            rb.AddForce(transform.up * jumpPower.Power, ForceMode.Impulse);
            jumpPower.MemorizeJumpPowerLastJump();//����̃W�����v�͂��L�^
        }
    }
    
}
