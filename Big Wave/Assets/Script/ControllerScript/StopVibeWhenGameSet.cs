using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�R���g���[�����o�C�u������
public class StopVibeWhenGameSet : MonoBehaviour
{
    [Header("�Q�[���I���𔻒f����R���|�[�l���g")]
    [SerializeField] JudgeGameSet judgeGameSet;//�Q�[���I���𔻒f����R���|�[�l���g
    const float stopSpeed = 0;
    private Gamepad gamepad = Gamepad.current;

    private void Start()
    {
        judgeGameSet.GameSetCommonAction += StopVibe;
    }

    public void StopVibe()
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(stopSpeed, stopSpeed);
        }
    }
}
