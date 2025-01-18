using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//�쐬��:���R
//�g���b�N�|�C���g
public class TrickPoint : MonoBehaviour
{
    [Header("1�Q�[�W�ɓ���ő�g���b�N�|�C���g�̗�")]
    [SerializeField] float trickPointMax = 50;//1�Q�[�W�ɓ���ő�g���b�N�|�C���g(�S�Q�[�W�����e��)
    [Header("�g���b�N�Q�[�W�̖{��")]
    [SerializeField] int _trickGaugeNum;
    public event Action<int> FullEvent;//�Q�[�W�����^���ɂȂ������ɌĂԃC�x���g�A�����ɂ͖��^���̃Q�[�W�̐�������
    private int maxCount = 0;//���^���̃g���b�N�Q�[�W�̐�
    private float[] _trickPoint;//�g���b�N�|�C���g(�e��trickGaugeMax�̃Q�[�W��trickGaugeNum����)

    public float this[int index]
    {
        get { return _trickPoint[index]; }
    }

    public float TrickPointMax//�g���b�N�Q�[�W1�{�ɓ���g���b�N�̗e��
    {
        get { return trickPointMax; }
    }

    public int TrickGaugeNum//�g���b�N�Q�[�W�̖{��
    {
        get { return _trickGaugeNum; }
    }

    public int MaxCount//���^���̃g���b�N�Q�[�W�̖{��
    {
        get { return maxCount; }
    }

    public bool Full//�S�ẴQ�[�W�����^����
    {
        get { return maxCount == _trickGaugeNum; }
    }

    public void Charge(float charge)//�g���b�N�|�C���g�̃`���[�W
    {
        if (maxCount == _trickPoint.Length)//�S�Q�[�W�����^���̎��͏������Ȃ�
        {
            return;
        }

        for (int i = maxCount; i < _trickPoint.Length; i++)
        {
            _trickPoint[i] += charge;

            if (_trickPoint[i] >= trickPointMax)//���`���[�W���Ă���Q�[�W�����^���ɂȂ�����
            {
                charge = _trickPoint[i] - trickPointMax;//���̃Q�[�W�Ƀ`���[�W���镪
                _trickPoint[i] = trickPointMax;//�g���b�N�|�C���g�����E�˔j���Ȃ��悤��
                maxCount++;//���^���̃g���b�N�Q�[�W�̐��𑝂₷
                FullEvent?.Invoke(maxCount);
            }
            else//���`���[�W���Ă���Q�[�W�����^���ɂȂ�Ȃ�������`���[�W�������I����
            {
                break;
            }
        }
    }

    public bool Consume(int cost)//�g���b�N�|�C���g�̏���(�g���Q�[�W�ʂ������ɓ����A�g�p�Q�[�W������Ȃ���false��Ԃ����̂ł���Ńg���b�N�|�C���g�̑��E�s���𔻒f)
    {
        if (maxCount < cost)//�g���Q�[�W�ʂ�����Ȃ����
        {
            return false;
        }

        else//������
        {
            //�g���Q�[�W�̒��g��0�ɂ���
            for (int i = 0; i < cost; i++)
            {
                _trickPoint[maxCount - 1 - i] = 0;
            }


            if (!Full)
            {
                _trickPoint[maxCount - cost] = _trickPoint[maxCount];
                _trickPoint[maxCount] = 0;
            }

            //���^���̃Q�[�W�̐����g���������炷
            maxCount -= cost;

            return true;
        }
    }

    void Start()
    {
        //�g���b�N�Q�[�W�̖{�����̃g���b�N�Q�[�W���m��
        _trickPoint = new float[_trickGaugeNum];

        for (int i = 0; i < _trickPoint.Length; i++)
        {
            _trickPoint[i] = new float();
        }
    }
}
