using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�g���b�N�E�N���e�B�J���E�A���N���e�B�J���̉񐔂𐔂���
public partial class Count_Trick_Critical : MonoBehaviour
{
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] Critical critical;
    CountContinuanceCritical _continuanceCritical=new CountContinuanceCritical();//�A���N���e�B�J���󋵂��v������C���X�^���X
    private int _totalCriticalCount = 0;//���v�N���e�B�J����
    private int _totalTrickCount = 0;//���v�g���b�N��

    public int TotalCriticalCount{ get { return _totalCriticalCount; } }//���v�N���e�B�J����

    public int TotalTrickCount { get { return _totalTrickCount; } }//���v�g���b�N��

    public float CriticalRate//�N���e�B�J���̐�����
    {
        get
        {
            const float retDividedByZero = 0;//0�ɂ�鏜�Z���ɕԂ��l
            if (_totalTrickCount == 0) return retDividedByZero;//0�ɂ�鏜�Z���N����ꍇ��0��Ԃ�

            return (float)(_totalCriticalCount / _totalTrickCount); 
        } 
    }

    public int ContinuanceCriticalCount { get { return _continuanceCritical.ContinuanceCriticalCount; } }//�A���N���e�B�J����

    public bool ContinueCritical{ get { return _continuanceCritical.ContinueCritical; } }//�N���e�B�J���������Ă��邩


    public void Count()//�N���e�B�J���񐔂��v��
    {
        _totalTrickCount++;//���v�g���b�N�񐔂����Z

        if(critical.CriticalNow)//�N���e�B�J����������
        {
            _totalCriticalCount++;//���v�N���e�B�J���񐔂����Z

            _continuanceCritical.Add();//�A���N���e�B�J���̉��Z����
        }

        else//�N���e�B�J������Ȃ�������
        {
            _continuanceCritical.Reset();//�A���N���e�B�J���̃��Z�b�g����
        }
    }
}
