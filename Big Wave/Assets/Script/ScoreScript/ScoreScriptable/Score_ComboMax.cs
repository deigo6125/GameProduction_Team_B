using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�ő�R���{�񐔂̃X�R�A
[CreateAssetMenu(menuName = "ScriptableObjects/Score/ComboMax")]
public class Score_ComboMax : Score_Base
{
    int m_comboMax;//�ő�R���{��
    float m_scorePerCombo;//1�񂲂Ƃ̃X�R�A

    public int ComboMax { get { return m_comboMax; }  } 
    public float ScorePerCombo { get {  return m_scorePerCombo; } }

    public void Rewrite(float score,int comboMax,float scorePerCombo)//�X�R�A�̏�������
    {
        m_score=score;
        m_comboMax=comboMax;
        m_scorePerCombo=scorePerCombo;
    }
}
