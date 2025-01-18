using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//�쐬�ҁF�K��
//
public class CustomButtonEventsManager : MonoBehaviour
{
    [SerializeField] MenuEffectController menuEffectController;
    private RectTransform currentSelectedButton;

    //�{�^���I�����̏���
    public void OnButtonSelected(RectTransform buttonRect)
    {
        if (currentSelectedButton != buttonRect)
        {
            menuEffectController.ButtonSelectedProcess(buttonRect);
            currentSelectedButton = buttonRect;
        }
    }

    //�{�^���̑I���������̏���
    public void OnButtonDeselected(RectTransform buttonRect)
    {
        if (currentSelectedButton != null)
        {
            menuEffectController.ButtonDeselectedProcess();
            currentSelectedButton = null;
        }
    }

    //�{�^���̃N���b�N���̏���
    public void OnButtonClicked(RectTransform buttonRect)
    {
        menuEffectController.ButtonClickedProcess(buttonRect);
    }
}