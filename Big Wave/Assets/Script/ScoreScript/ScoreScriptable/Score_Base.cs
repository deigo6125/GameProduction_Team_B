using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�X�R�A�̒l(�V�[�����܂����ŕۑ��ł���)
public abstract class Score_Base : ScriptableObject
{
    protected float m_score;//�X�R�A��

    public float Score { get { return m_score; } }
}
