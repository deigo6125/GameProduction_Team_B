using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�ʏ�e(Rigidbody���g��Ȃ�)�̐ݒ�
[System.Serializable]
public class BulletSettingTypeNoRigid
{
    [Header("���e")]
    [Header("��:�e�ɂ͕K��NoRigidBullet�������I�u�W�F�N�g�����邱��")]
    [SerializeField] GameObject bulletPrefab;//���������e
    [Header("���e�����������ʒu")]
    [SerializeField] Transform shotPos;//�e�����������ʒu
    [Header("���s���J�n���猂�܂ł̒x������")]
    [Header("��:�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�")]
    [SerializeField] float delayTime;//�s���J�n���猂�܂ł̒x�����ԁA�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�
    bool shoted;//�e����������

    //�ȉ���NoRigidBullet�ŗL�̃X�e�[�^�X
    [Header("�ˌ��̎��")]
    [SerializeField] ShotType shotType;
    [Header("�e�̃X�s�[�h")]
    [SerializeField] float speed;

    public GameObject BulletPrefab { get { return bulletPrefab; } }//���������e
    public Transform ShotPos { get { return shotPos; } }//�e�����������ʒu
    public float DelayTime { get { return delayTime; } }//�s���J�n���猂�܂ł̒x������
    public bool Shoted { get { return shoted; } set { shoted = value; } }//�e����������

    //�ȉ���NoRigidBullet�ŗL�̃X�e�[�^�X
    public ShotType ShotType { get { return shotType; } }
    public float Speed { get { return speed; } }
}
