using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

//�쐬��:���R
//�W�����v�̑���
public class ControllerOfJump : MonoBehaviour
{
    public event Action EnterAction;
    public event Action ExitAction;
    bool pushing=false;

    public bool Pushing { get { return pushing; }  }

    public void PrepareJump(InputAction.CallbackContext context)//�����n�߂ɐݒ�
    {
        if (!context.performed) return;

        pushing = true;
        EnterAction?.Invoke();
    }

    public void Jump(InputAction.CallbackContext context)//�������u�Ԃɐݒ�
    {
        if (!context.performed) return;

        pushing = false;
        ExitAction?.Invoke();
    }
}
