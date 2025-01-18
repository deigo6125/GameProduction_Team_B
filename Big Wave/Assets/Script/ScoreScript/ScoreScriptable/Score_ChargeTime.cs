using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�`���[�W�̃X�R�A
[CreateAssetMenu(menuName = "ScriptableObjects/Score/ChargeTime")]
public class Score_ChargeTime : Score_Base
{
    float m_chargeTime;//�`���[�W�b��
    float m_scorePerSecond;//1�b������̃X�R�A

    public float ChargeTime { get { return m_chargeTime; } }
    public float ScorePerSecond { get { return  m_scorePerSecond; } }

    public void Rewrite(float score,float chargeTime,float scorePerSecond)//�X�R�A�̏�������
    {
        m_score=score;
        m_chargeTime=chargeTime;
        m_scorePerSecond=scorePerSecond;
    }
}
