using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�s�����e
[System.Serializable]
public class ActionPattern//�s���Ƃ��̍s���̎��ɍs�����n�߂�܂ł̎���
{
    [Header("�s����")]
    [Tooltip("�s�����͏����ɑS���e���͂���܂���̂ŁA�J���҂ɂ킩��₷���悤�ɍD���ɏ����č\��Ȃ��ł�(�Z���l�����肷��̂͑������`�x�ɂ��Ȃ��邩���...�H)")]
    [SerializeField] string _actionName;//�s�����A�����ɂ͑S���e���͂Ȃ�
    [Header("���s��")]
    [SerializeField] EnemyActionTypeBase[] action;//�s��
    [Header("���s������")]
    [SerializeField] float actionTime;//�s������

    public EnemyActionTypeBase[] Action
    {
        get { return action; }
    }

    public float ActionTime
    {
        get { return actionTime; }
    }
}
