using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���V�[���ł̃g���b�N�X�R�A�̌v���E����
//�����ł����R���{�Ƃ͘A���N���e�B�J���񐔂̂���
//�g���b�N�̐������Ōv������d�l�ɕύX
public class ScoreGameScene_TrickCombo : MonoBehaviour
{
    [Header("��{�X�R�A")]
    [SerializeField] float m_defaultScore;//��{�X�R�A
    [Header("������100%�������ꍇ�ɒǉ������X�R�A")]
    [SerializeField] float m_perfectScore;
    [Header("�R���{�ǉ��X�R�A")]
    [SerializeField] float m_addComboScore;//�R���{�ǉ��X�R�A
    [Header("�X�R�A�����ő�R���{��")]
    [SerializeField] int m_maxAddComboCount;//�X�R�A�����ő�R���{��
    [Header("�X�R�A���f�Ɏg���R���|�[�l���g")]
    [SerializeField] Score_TrickCombo score_TrickCombo;//�X�R�A���f
    [Header("�R���{�񐔂𐔂���R���|�[�l���g")]
    [SerializeField] Count_Trick_Critical countTrickCombo;
    [Header("�Q�[���I���𔻒f����R���|�[�l���g")]
    [SerializeField] JudgeGameSet judgeGameSet;
    private float m_score=0;//�X�R�A���v

    public float Score { get { return m_score; }  }

    private void Start()
    {
        judgeGameSet.GameSetCommonAction += Reflect;
    }

    public void AddScore()//�X�R�A���Z(�g���b�N���ɌĂ�)
    {
        //�R���{�񐔂��擾(�ő�R���{�񐔂𒴂��Ă�����ő�R���{�񐔂̒l�ɂ���)
        int comboCount = Mathf.Min(countTrickCombo.ContinuanceCriticalCount, m_maxAddComboCount);

        m_score += m_defaultScore + m_addComboScore * comboCount;//�A���R���{�񐔂ɉ����ăX�R�A�����Z
    }

    float AddCriticalSuccessRateScore()//�N���e�B�J���̐������ɂ����Z�����X�R�A�̎Z�o
    {
        return m_perfectScore * countTrickCombo.CriticalRate;
    }

    public void Reflect()//�X�R�A���f
    {
        m_score += AddCriticalSuccessRateScore();
       
        score_TrickCombo.Rewrite(m_score);
    }
}
