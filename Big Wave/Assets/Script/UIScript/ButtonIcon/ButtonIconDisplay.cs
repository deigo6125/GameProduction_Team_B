using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�{�^���A�C�R���̕\���̐؂�ւ�
public class ButtonIconDisplay : MonoBehaviour
{
    [Header("�{�^���̃A�C�R��")]
    [SerializeField] GetTrickButton<GameObject> icon_Button;//�{�^���̃A�C�R��

    public void DisplayButton(TrickButton buttonDisplayed)//�{�^���\���A����(�F��)�{�^����\�����邩�������ɓ����
    {
        //�w�肳��Ă���{�^����\��
        for (int i = 0; i < Enum.GetNames(typeof(TrickButton)).Length; i++)
        {
            bool display = (TrickButton)i == buttonDisplayed;//�{�^����\�����邩

            GameObject icon = icon_Button.Get((TrickButton)i);//�\���̐؂�ւ�������{�^���̃A�C�R��

            icon.SetActive(display);
        }
    }

    public void HideButton()//�{�^����S�ĉB��
    {
        //�S�Ẵ{�^�����\��
        for (int i = 0; i < Enum.GetNames(typeof(TrickButton)).Length; i++)
        {
            GameObject icon = icon_Button.Get((TrickButton)i);//�\���̐؂�ւ�������{�^���̃A�C�R��

            icon.SetActive(false);
        }
    }
}
