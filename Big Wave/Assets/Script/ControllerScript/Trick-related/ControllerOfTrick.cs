using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�g���b�N�̑���
public class ControllerOfTrick : MonoBehaviour
{
    Trick trick;

    void Start()
    {
        trick = GameObject.FindWithTag("Player").GetComponentInChildren<Trick>();
    }

    public void Trick_North(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        trick.TrickTrigger(TrickButton.north);//�g���b�N
    }

    public void Trick_West(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        trick.TrickTrigger(TrickButton.west);//�g���b�N
    }

    public void Trick_East(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        trick.TrickTrigger(TrickButton.east);//�g���b�N
    }

    public void Trick_South(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        trick.TrickTrigger(TrickButton.south);//�g���b�N
    }
}
