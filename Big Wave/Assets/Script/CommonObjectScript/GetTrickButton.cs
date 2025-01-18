using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�󂯎����TrickButton(enum�^)�̒l�ɑΉ������I�u�W�F�N�g��Ԃ�
[System.Serializable]
public class GetTrickButton<T>
{
    [Header("��(�E)")]
    [SerializeField] T _east;
    [Header("��(��)")]
    [SerializeField] T _west;
    [Header("��(��)")]
    [SerializeField] T _south;
    [Header("�k(��)")]
    [SerializeField] T _north;

    public GetTrickButton() { }//�f�t�H���g�R���X�g���N�^

    public GetTrickButton(T east,T west,T south,T north)//�R���X�g���N�^
    {
        _east = east;
        _west = west;
        _south = south;
        _north = north;
    }

    public T Get(TrickButton trickButton)//�󂯎����TrickButton(enum�^)�̒l�ɑΉ������I�u�W�F�N�g��Ԃ�
    {
        switch (trickButton)
        {
            case TrickButton.east: return _east;
            case TrickButton.west: return _west;
            case TrickButton.south: return _south;
            case TrickButton.north: return _north;
        }

        //��O
        return default(T);
    }
}
