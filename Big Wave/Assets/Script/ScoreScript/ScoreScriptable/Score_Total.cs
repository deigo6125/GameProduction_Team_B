using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���v�X�R�A
[CreateAssetMenu(menuName = "ScriptableObjects/Score/Total")]
public class Score_Total : Score_Base
{
    public void ReWrite(float totalScore)
    {
        m_score = totalScore;
    }

}
