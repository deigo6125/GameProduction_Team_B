using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���V�[���ł̎c��HP�X�R�A�̌v���E����
//�N���A����HP�����łȂ��A��{�X�R�A����_���[�W���󂯂��񐔂����X�R�A�����炷�d�l�ɕύX
public class ScoreGameScene_HP : MonoBehaviour
{
    //[Header("�ő�HP�ɑ΂��Ă̎c��HP��1%���Ƃ̃X�R�A��")]
    //[SerializeField] float m_scorePerOnePercent;//�ő�HP�ɑ΂��Ă̎c��HP��1%���Ƃ̃X�R�A��
    [Header("��{�X�R�A(�m�[�_���[�W�������ꍇ�Ɋl���ł���X�R�A)")]
    [SerializeField]float baseScore;
    [Header("�_���[�W���󂯂閈�Ɍ��炷�X�R�A")]
    [SerializeField] float decreaseScore;
    [Header("�v���C���[��HP")]
    [SerializeField] HP player_HP;//�v���C���[��HP
    [Header("�X�R�A���f�Ɏg���R���|�[�l���g")]
    [SerializeField] Score_HP score_HP;//�X�R�A���f
    [Header("�Q�[���I���𔻒f����R���|�[�l���g")]
    [SerializeField] JudgeGameSet judgeGameSet;
   
    private int damageCount;
     public int DamageCount
    {
        get { return damageCount; }
        set { damageCount = value; }
    }
    const float ratioToPercent = 100;//�������灓�ɕϊ�����W��
    const float hpRatio_GameOver = 0;//�Q�[���I�[�o�[���c��̗͂̊����������I��0�Ƃ���

     void Start()
    {
       DamageCount = 0;
        judgeGameSet.GameSetAction += Reflect;
    }

    public void Reflect(bool gameClear)//�X�R�A���f
    {
        float hpScore = gameClear ? baseScore-(damageCount*decreaseScore) : hpRatio_GameOver;//�X�R�A�̌v�Z��

        if(hpScore < 0)
        {
            hpScore = 0;
        }
       // float hpPercent = hpRatio * ratioToPercent;//�������p�[�Z���g�ɒ���������

        //float score= hpPercent * m_scorePerOnePercent;//�X�R�A�̌v�Z��

       // score_HP.Rewrite(score, hpPercent, m_scorePerOnePercent);
       score_HP.Rewrite(hpScore);
    }
  
}
