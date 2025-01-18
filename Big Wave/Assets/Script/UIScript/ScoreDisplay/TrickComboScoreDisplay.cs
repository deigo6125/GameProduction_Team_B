using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

//�쐬��:���R
//�Q�[�����ɃX�R�A(�g���b�N�R���{�ƃ`���[�W����)��\��������
public class TrickComboScoreDisplay : MonoBehaviour
{
    [Header("�X�R�A�\�����镶��")]
    [SerializeField] TMP_Text m_scoreText;
    [Header("�g���b�N�R���{�̃X�R�A���v������R���|�[�l���g")]
    [SerializeField] ScoreGameScene_TrickCombo score_TrickCombo;
    [Header("�`���[�W���Ԃ̃X�R�A���v������R���|�[�l���g")]
    [SerializeField] ScoreGameScene_ChargeTime score_ChargeTime;
    [Header("�\�����镶���̑�����X�s�[�h")]
    [SerializeField] float m_riseSpeed;
    private float displayScore=0;//�\���p�̃X�R�A(������ہA�u�ԓI�ɐ�����؂�ւ���̂ł͂Ȃ��i���o�[�J�E���^�[�̂悤�ɑ��₷���o�����̂���)
    const float defaultScore=0;//�X�R�A�����l

    void Update()
    {
        Display();
    }

    void Display()//�\������
    {
        //���݂̃X�R�A
        float score = score_TrickCombo.Score+score_ChargeTime.Score;

        //���݂̃X�R�A�ɂȂ�܂ő���������
        displayScore += Time.deltaTime*m_riseSpeed;
        displayScore = Mathf.Clamp(displayScore, defaultScore, score);

        m_scoreText.text = displayScore.ToString("0");
    }
}
