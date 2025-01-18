using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//�쐬��:���R
//�w��X�e�[�WID�̃n�C�X�R�A���e�L�X�g�ɏo��
public class HighScore_StageNumDisplay : MonoBehaviour
{
    [Header("�n�C�X�R�A���ɕ\������e�L�X�g")]
    [SerializeField] TMP_Text _highScoreText;
    [Header("�N���A�񐔂�\������e�L�X�g")]
    [SerializeField] TMP_Text _clearCountScoreText;
    [Header("�ő��N���A���Ԃ�\������e�L�X�g")]
    [SerializeField] TMP_Text _highClearTimeText;
    const float _seconds_1minute = 60;//1����b�ɒ������Ƃ��̒l
    const int _displayDigit_BelowPoint = 2;//0.�b�̕\������(�������ʂ���)����

    public void Display(int stageID)
    {
        DisplayHighScore(stageID);
        DisplayClearCount(stageID);
        DisplayHighClearTime(stageID);
    }

    void DisplayHighScore(int stageID)//�n�C�X�R�A�̕\��
    {
        float highScore = SaveData.GetHighScore(stageID);

        _highScoreText.text = highScore.ToString("0");
    }

    void DisplayClearCount(int stageID)//�N���A�񐔂̕\��
    {
        int clearCount=SaveData.GetClearCount(stageID);

        _clearCountScoreText.text = clearCount.ToString("0");
    }

    void DisplayHighClearTime(int stageID)
    {
        float highClearTime=SaveData.GetHighClearTime(stageID);

        int minute = (int)(highClearTime / _seconds_1minute);//��
        int second = (int)(highClearTime % _seconds_1minute);//�b

        string text_minute = minute.ToString("00");//�e�L�X�g�ɏ������̕���
        string text_second = second.ToString("00");//�e�L�X�g�ɏ����b�̕���

        string str_clearTime = highClearTime.ToString("F" + _displayDigit_BelowPoint.ToString());
        string text_pointSecond = str_clearTime.Split('.')[_displayDigit_BelowPoint - 1];//�e�L�X�g�ɏ���0.�b�̕���

        _highClearTimeText.text = text_minute + ":" + text_second + ":" + text_pointSecond;//�e�L�X�g�X�V
    }
}
