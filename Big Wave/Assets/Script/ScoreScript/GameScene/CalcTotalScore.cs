using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�X�R�A�̍��v���v�Z
public class CalcTotalScore : MonoBehaviour
{
    [Header("���Z����X�R�A")]
    [SerializeField] Score_Base[] _addScores;//���Z����X�R�A
    [Header("���v�X�R�A")]
    [SerializeField] Score_Total _score_Total_;//���v�X�R�A
    [Header("�Q�[���I���𔻒f")]
    [SerializeField] JudgeGameSet _judgeGameSet;

    void Start()
    {
        _judgeGameSet.LatedAction += Calc;
    }

    public void Calc()
    {
        //���v���v�Z
        float score = 0;

        for (int i = 0; i < _addScores.Length; i++)
        {
            score += _addScores[i].Score;
        }

        //�����_��؂�̂�
        score = Mathf.Floor(score);

        //���v�X�R�A�ɔ��f
        _score_Total_.ReWrite(score);
    }
}
