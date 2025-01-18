using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���N���A�̃X�R�A
[CreateAssetMenu(menuName = "ScriptableObjects/Score/GameClear")]

public class Score_GameClear : Score_Base
{
    bool m_gameCleared=false;//�Q�[�����N���A������

    public bool GameCleared { get { return m_gameCleared; } }

    public void Rewrite(float score,bool gameCleared)//�X�R�A�̏�������
    {
        m_score = score;
        m_gameCleared = gameCleared;
    }
}
