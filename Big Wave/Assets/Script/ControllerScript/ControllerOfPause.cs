using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�|�[�Y(���)�̑���
public class ControllerOfPause : MonoBehaviour
{
    JudgePauseNow judgePauseNow;

    private void Start()
    {
        judgePauseNow = GameObject.FindWithTag("PauseManager").GetComponentInChildren<JudgePauseNow>();
    }

    public void SwitchPause(InputAction.CallbackContext context)//�|�[�Y��Ԃɂ���
    {
        if (!context.performed) return;

        judgePauseNow.SwitchPause();// �|�[�Y�̐؂�ւ�
    }
}
