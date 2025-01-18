using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�z�[�~���O�e�̐ݒ�
[System.Serializable]
public class BulletSettingTypeHoming
{
    [Header("���e")]
    [Header("��:�e�ɂ͕K��HomingBullet�������I�u�W�F�N�g�����邱��")]
    [SerializeField] GameObject bulletPrefab;//���������e
    [Header("���e�����������ʒu")]
    [SerializeField] Transform shotPos;//�e�����������ʒu
    [Header("���s���J�n���猂�܂ł̒x������")]
    [Header("��:�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�")]
    [SerializeField] float delayTime;//�s���J�n���猂�܂ł̒x�����ԁA�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�
    bool shoted;//�e����������

    //�ȉ���HomingBullet�ŗL�̃X�e�[�^�X
    [Header("���˂���ĉ��b�ォ��z�[�~���O���n�߂邩")]
    [SerializeField] float startHomingTime;//���˂���ĉ��b�ォ��z�[�~���O���n�߂邩
    [Header("���b�ԃz�[�~���O���邩")]
    [SerializeField] float homingTime;//���b�ԃz�[�~���O���邩
    [Header("�W�I�Ɍ������x")]
    [Tooltip("1�b�Ԃ�homingSpeed�x�̑��x�Ō����܂�")]
    [SerializeField] float homingSpeed;//�W�I�Ɍ������x
    [Header("�e�̈ړ����x")]
    [SerializeField] float speed;//�e�̈ړ����x
    

    public GameObject BulletPrefab { get { return bulletPrefab; } }//���������e
    public Transform ShotPos { get { return shotPos; } }//�e�����������ʒu
    public float DelayTime { get { return delayTime; } }//�s���J�n���猂�܂ł̒x������
    public bool Shoted { get { return shoted; } set { shoted = value; } }//�e����������

    //�ȉ���HomingBullet�ŗL�̃X�e�[�^�X
    public float StartHomingTime { get { return startHomingTime; } }//���˂���ĉ��b�ォ��z�[�~���O���n�߂邩
    public float HomingTime { get { return homingTime; } }//���b�ԃz�[�~���O���邩
    public float HomingSpeed { get { return homingSpeed; } }//�W�I�Ɍ������x
    public float Speed { get { return speed; } }//�e�̈ړ����x
}
