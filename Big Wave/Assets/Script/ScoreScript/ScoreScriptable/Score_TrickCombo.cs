using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�g���b�N�̃X�R�A
[CreateAssetMenu(menuName = "ScriptableObjects/Score/TrickCombo")]
public class Score_TrickCombo : Score_Base
{
    public void Rewrite(float score)//�X�R�A�̏�������
    {
        m_score = score;
    }
}
