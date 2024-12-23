using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//作成者：桑原
//
public class CustomButtonEventsManager : MonoBehaviour
{
    [SerializeField] MenuEffectController menuEffectController;
    private RectTransform currentSelectedButton;

    //ボタン選択時の処理
    public void OnButtonSelected(RectTransform buttonRect)
    {
        if (currentSelectedButton != buttonRect)
        {
            menuEffectController.ButtonSelectedProcess(buttonRect);
            currentSelectedButton = buttonRect;
        }
    }

    //ボタンの選択解除時の処理
    public void OnButtonDeselected(RectTransform buttonRect)
    {
        if (currentSelectedButton != null)
        {
            menuEffectController.ButtonDeselectedProcess();
            currentSelectedButton = null;
        }
    }

    //ボタンのクリック時の処理
    public void OnButtonClicked(RectTransform buttonRect)
    {
        menuEffectController.ButtonClickedProcess(buttonRect);
    }
}