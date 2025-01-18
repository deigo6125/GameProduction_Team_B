using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�ʏ�e(Rigidbody���g��)�̐ݒ�
[System.Serializable]
public class BulletSettingTypeRigid
{
    [Header("���e")]
    [Header("��:�e�ɂ͕K��Rigidbody�������I�u�W�F�N�g�����邱��")]
    [SerializeField] GameObject bulletPrefab;//���������e
    [Header("���e�����������ʒu")]
    [SerializeField] Transform shotPos;//�e�����������ʒu
    [Header("���s���J�n���猂�܂ł̒x������")]
    [Header("��:�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�")]
    [SerializeField] float delayTime;//�s���J�n���猂�܂ł̒x�����ԁA�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�
    bool shoted;//�e����������

    //�ȉ���Rigidbody�ŗL�̃X�e�[�^�X
    [Header("�ˌ��̎��")]
    [SerializeField] ShotType shotType;
    [Header("������")]
    [SerializeField] float shotPower;//����

    public GameObject BulletPrefab { get { return bulletPrefab; } }//���������e
    public Transform ShotPos { get { return shotPos; } }//�e�����������ʒu
    public float DelayTime { get { return delayTime; } }//�s���J�n���猂�܂ł̒x������
    public bool Shoted { get { return shoted; } set { shoted = value; } }//�e����������

    //�ȉ���Rigidbody�ŗL�̃X�e�[�^�X
    public ShotType ShotType { get { return shotType; } }
    public float ShotPower { get { return shotPower; } }
}
