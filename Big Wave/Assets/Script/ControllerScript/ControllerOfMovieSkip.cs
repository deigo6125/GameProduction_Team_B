using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R����
//���[�r�[���X�L�b�v���鑀��
public class ControllerOfMovieSkip : MonoBehaviour
{
    [SerializeField] MovieCameraEvent _movieCameraEvent;
   
    public void Skip(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        _movieCameraEvent.End();
    }
}
