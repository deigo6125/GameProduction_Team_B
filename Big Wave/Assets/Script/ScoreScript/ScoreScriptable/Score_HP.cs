using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//HP�̃X�R�A
[CreateAssetMenu(menuName = "ScriptableObjects/Score/Hp")]
public class Score_HP : Score_Base
{
    //float m_remainingHpPercent;//�c��HP����
    //float m_scorePerOnePercent;//�ő�HP�ɑ΂��Ă̎c��HP��1%���Ƃ̃X�R�A��

    //public float RemainingHPPercent { get { return m_remainingHpPercent; }  }
   // public float ScorePerOnePercent { get {  return m_scorePerOnePercent; } }

    public void Rewrite(float score)//�X�R�A�̏�������
    {
        m_score=score;
        //m_remainingHpPercent=remainingHpPercent;
        //m_scorePerOnePercent=scorePerOnePercent;
    }
}
