using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

//�쐬��:�K��
//�{�^���̃C�x���g
public class CustomButtonEvent : MonoBehaviour
{
    [Header("���t�F�[�h�A�E�g���邩�ǂ���")]
    [SerializeField] bool isFadeOut;
    [Header("�{�^���̉��o���I���������ɋN�����C�x���g")]
    [SerializeField] UnityEvent _clickEvents;
    [SerializeField] MenuEffectController menuEffectController;
    [SerializeField] FadeOut fadeOut;

    private bool isButtonClicked = false;

    private void Update()
    {
        if (!isButtonClicked) return;

        ButtonAction();
    }

    public void ButtonClicked()
    {
        isButtonClicked = true;
    }

    private void ButtonAction()
    {

        if (menuEffectController!=null && !menuEffectController.EffectColorChanged) return;//�{�^���̐F���ς��؂��Ă���

        if (isFadeOut && fadeOut.FadeState == State_Fade.off) fadeOut.StartTrigger();//�t�F�[�h�A�E�g����ꍇ�̓t�F�[�h�A�E�g������
        if (isFadeOut && fadeOut.FadeState != State_Fade.completed) return;//�܂��A�t�F�[�h�A�E�g���I���̂�҂��Ă���V�[���ڍs������(�t�F�[�h�A�E�g���Ȃ��ꍇ�͂��̂܂܃V�[���ڍs)

        fadeOut.ReturnDefault();//�ė��p�\�ɂ���
        _clickEvents.Invoke();
    }
}
