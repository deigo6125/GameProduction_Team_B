using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���݂��扽�`�Ԃ���Ԃ�
public abstract class FormOfEnemyTypeBase : MonoBehaviour
{
    public abstract int DefaultForm();//�ŏ��̌`�Ԃ͂ǂ̌`�Ԕԍ�����Ԃ�
    public abstract int CurrentForm();//���ݑ扽�`�Ԃ���Ԃ��A���������`�ԂȂ�0�A���`�ԂȂ�1...��n�`�ԂȂ�n-1��Ԃ��悤�ɂ���
}
