using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�s�����e(��A�̓���̐ݒ���\)
[System.Serializable]
public class SequenceOfActionPattern
{
    [Header("�s����")]
    [Tooltip("�s�����͏����ɑS���e���͂���܂���̂ŁA�J���҂ɂ킩��₷���悤�ɍD���ɏ����č\��Ȃ��ł�(�Z���l�����肷��̂͑������`�x�ɂ��Ȃ��邩���...�H)")]
    [SerializeField] string _actionName;//�s�����A�����ɂ͑S���e���͂Ȃ�
    [Header("�s�����e")]
    [Header("�v�f��ǉ�����Έ�A�̓���Ƃ��Đݒ�\")]
    [SerializeField] ActionPattern[] _actionPatterns;//�s�����e(�v�f��ǉ�����Έ�A�̓���Ƃ��Đݒ�\)

    public ActionPattern this[int i] { get { return _actionPatterns[i]; } }//�s�����e���擾
    public int ActionNum { get { return _actionPatterns.Length; } }//�s�����e�̍s����(���̓��삪���邩)

}
