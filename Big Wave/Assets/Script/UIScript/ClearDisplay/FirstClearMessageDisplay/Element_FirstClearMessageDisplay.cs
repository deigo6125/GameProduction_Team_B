using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���N���A���ɕ\�����郁�b�Z�[�W�̗v�f
//���ڂ́A�X�e�[�WID�A����ɑΉ�����\������I�u�W�F�N�g
[System.Serializable]
public class Element_FirstClearMessageDisplay
{
    [Header("�X�e�[�WID")]
    [Header("���N���A���ɃX�e�[�WID�ɑΉ������I�u�W�F�N�g��\��������")]
    [SerializeField] int _stageID;//�X�e�[�WID
    [Header("�\��������I�u�W�F�N�g")]
    [SerializeField] GameObject _object;//�\������I�u�W�F�N�g

    public int StageID { get { return _stageID; } }

    public GameObject Object { get { return _object; } }

    Element_FirstClearMessageDisplay() { }//�f�t�H���g�R���X�g���N�^
}
