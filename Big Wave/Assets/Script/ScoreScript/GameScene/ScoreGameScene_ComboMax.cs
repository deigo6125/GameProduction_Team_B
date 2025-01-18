using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

//�쐬��:���R
//�Q�[���V�[���ł̍ő�R���{�񐔃X�R�A�̌v���E����
//�g���b�N�����񐬌����������̃X�R�A�ɕύX
public class ScoreGameScene_ComboMax : MonoBehaviour
{
    [Header("�R���{1�񂲂Ƃ̃X�R�A")]
    [SerializeField] float m_scorePerCombo;//�R���{1�񂲂Ƃ̃X�R�A
    [Header("�X�R�A���f�Ɏg���R���|�[�l���g")]
    [SerializeField] Score_ComboMax score_ComboMax;//�X�R�A���f
    [Header("�R���{�񐔂𐔂���R���|�[�l���g")]
    [SerializeField] Count_Trick_Critical countTrickCombo;
    [Header("�Q�[���I���𔻒f����R���|�[�l���g")]
    [SerializeField] JudgeGameSet judgeGameSet;

    private void Start()
    {
        judgeGameSet.GameSetCommonAction += Reflect;
    }


    public void Reflect()//�X�R�A���f
    {
        float score = countTrickCombo.TotalCriticalCount * m_scorePerCombo;//�X�R�A�̌v�Z��

        score_ComboMax.Rewrite(score, countTrickCombo.TotalCriticalCount, m_scorePerCombo);
    }
}
