using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�C���v�b�g�V�X�e���w�K�p���\�b�h
public class TestInput : MonoBehaviour
{
    bool isPressed=false;

    public void InputNothingContext()
    {
        Debug.Log("���ɂ��ݒ肳��Ă��Ȃ�");
    }
    public void InputNothing(InputAction.CallbackContext context)
    {
        Debug.Log(context.phase+"�Ă΂�Ă��");
    }

    public void InputMoment(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log(context.phase + "�Ă΂�Ă��");
        }
    }

    public void InputEveryFrame(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        isPressed = !isPressed;
    }

    void Update()
    {
        if(isPressed) Debug.Log("���t���[���Ă�ł܂�");
    }
}
