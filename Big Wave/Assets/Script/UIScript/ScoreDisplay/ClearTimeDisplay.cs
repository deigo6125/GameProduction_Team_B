using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//�쐬��:���R
//�N���A�^�C���̕\��
public class ClearTimeDisplay : MonoBehaviour
{
    [Header("00:00:00(��:�b:0.�b)�̌`���ŕ\��")]
    [Header("�N���A�^�C����\������e�L�X�g")]
    [SerializeField] TMP_Text _clearTimeText;//�N���A�^�C����\������e�L�X�g
    [SerializeField] Score_TimeLimit _score_timeLimit;//�N���A�^�C�����擾���邽�߂̃R���|�[�l���g
    const float _seconds_1minute=60;//1����b�ɒ������Ƃ��̒l
    const int _displayDigit_BelowPoint = 2;//0.�b�̕\������(�������ʂ���)����

    void Update()
    {
        Display();
    }

    void Display()
    {
        float clearTime = _score_timeLimit.ClearTime;//�N���A�^�C�����擾

        int minute = (int)(clearTime / _seconds_1minute);//��
        int second = (int)(clearTime % _seconds_1minute);//�b

        string text_minute = minute.ToString("00");//�e�L�X�g�ɏ������̕���
        string text_second = second.ToString("00");//�e�L�X�g�ɏ����b�̕���

        string str_clearTime = clearTime.ToString("F" + _displayDigit_BelowPoint.ToString());
        string text_pointSecond = str_clearTime.Split('.')[_displayDigit_BelowPoint - 1];//�e�L�X�g�ɏ���0.�b�̕���

        _clearTimeText.text = text_minute + ":" + text_second + ":" + text_pointSecond;//�e�L�X�g�X�V
    }
}
