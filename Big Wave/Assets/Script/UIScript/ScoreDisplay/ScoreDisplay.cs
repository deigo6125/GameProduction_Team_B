using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//�쐬��:���R
//�o�^�����X�R�A��\��������
public class ScoreDisplay : MonoBehaviour
{
    [Header("�X�R�A�\�����镶��")]
    [SerializeField] TMP_Text m_scoreText;
    [Header("�\���������X�R�A")]
    [SerializeField] Score_Base[] m_showScores;//�\���������X�R�A

    void Start()
    {
        ShowScore();
    }

    void ShowScore()
    {
        float totalScore = 0;

        for(int i=0;i<m_showScores.Length ;i++)
        {
            totalScore += m_showScores[i].Score;
        }

        m_scoreText.text = totalScore.ToString("0");
    }
}
