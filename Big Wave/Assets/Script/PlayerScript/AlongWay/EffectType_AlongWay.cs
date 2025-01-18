using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�쐬��:���R
//���[�v��`���G�t�F�N�g�̐ݒ�
[System.Serializable]
public class EffectType_AlongWay
{
    [Header("�`�����̃G�t�F�N�g")]
    [SerializeField] GameObject passEffect;//�`�����̃G�t�F�N�g
    [Header("���e���̃G�t�F�N�g")]
    [SerializeField] GameObject landEffect;//���e���̃G�t�F�N�g
    public event Action LandAction;//���e���ɌĂԃC�x���g
    public event Action PassAction;//�`�����ɌĂԃC�x���g
    
    public EffectType_AlongWay()//�R���X�g���N�^
    {
       
    }

    public GameObject PassEffect()//�`���G�t�F�N�g���o���Ƃ��ɌĂ�
    {
        PassAction?.Invoke();
        return passEffect;
    }

    public GameObject LandEffect()//���e�G�t�F�N�g���o���Ƃ��ɌĂ�
    {
        LandAction?.Invoke();
        return landEffect;
    }
}
