using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�\���E��\����Ԃ����Ԃ����炵�ĕύX����
[System.Serializable]
public class ChangeActiveOfObject
{
    [Header("�\����Ԃ�؂�ւ������I�u�W�F�N�g�̐ݒ�")]
    [SerializeField] Element_ChangeActionOfObject[] _objects;
    const float _defaultCurrentChangeTime = 0;
    float _currentchangeTime;

    public ChangeActiveOfObject()//�f�t�H���g�R���X�g���N�^
    {
        _currentchangeTime = _defaultCurrentChangeTime;
    }

    public void Init()//�����������A(������x���������������ɌĂ�)
    {
        for(int i=0; i<_objects.Length;i++)
        {
            _objects[i].Changed = false;
        }

        _currentchangeTime=_defaultCurrentChangeTime;
    }

    public void UpdateActive()//�X�V����
    {
        _currentchangeTime += Time.deltaTime;

        for (int i = 0; i<_objects.Length; i++)
        {
            Element_ChangeActionOfObject _obj = _objects[i];

            bool changeActive = !_obj.Changed && _currentchangeTime >= _obj.ChangeTime;//�܂��؂�ւ��ĂȂ� ���� ���̃I�u�W�F�N�g�̒x�����ԂɒB�������̂ݐ؂�ւ�

            if (changeActive)
            {
                //�؂�ւ�����
                _obj.Object.SetActive(_obj.Active);
                _obj.Changed = true;
            }
        }
    }
}
