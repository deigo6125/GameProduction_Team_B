using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�\���E��\����Ԃ����Ԃ����炵�ĕύX����R���|�[�l���g�̗v�f
[System.Serializable]
public class Element_ChangeActionOfObject
{
    [Header("�\����Ԃ�؂�ւ���I�u�W�F�N�g")]
    [SerializeField] GameObject _object;
    [Header("�\�����")]
    [SerializeField] bool _active;
    [Header("���b��ɕ\����Ԃ�؂�ւ��邩")]
    [SerializeField] float _changeTime;
    bool _changed = false;//�ύX������

    public GameObject Object { get { return _object; } }

    public bool Active { get { return _active; } }

    public float ChangeTime { get { return _changeTime; } }

    public bool Changed
    { 
        get { return _changed; }
        set { _changed = value; }
    }
}
