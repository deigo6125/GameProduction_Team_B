using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�`�Ԃ��Ƃ̍s���p�^�[��(��A�̓���)
[System.Serializable]
public class SequenceOfActionPatternPerForm
{
    [Header("�ŏ��̍s�������邩")]
    [SerializeField] bool _actFirst=false;//�ŏ��̍s�������邩
    [Header("�ŏ��̍s�����e")]
    [SerializeField] SequenceOfActionPattern _firstAction;//�ŏ��̍s�����e
    [Header("�ŏ��ȍ~�̍s�����e(�����_���Œ��I)")]
    [SerializeField] ProbabilityGet<SequenceOfActionPattern> _afterAction;//�ŏ��ȍ~�̍s�����e(�����_���Œ��I)

    public bool ActFirst { get { return _actFirst; } }//�ŏ��̍s�������邩
    public SequenceOfActionPattern FirstAction { get { return _firstAction; } }//�ŏ��̍s�����e

    public void CalcSum()//�m�����v���v�Z
    {
        _afterAction.CalcSum();
    }

    public SequenceOfActionPattern SelectAfterAction()//�ŏ��ȍ~�̍s���������_���Œ��I���ĕԂ�
    {
        return _afterAction.Get();
    }
    
}
