using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�ʏ�e(NoRigidBullet)������
public class ShotTypeNoRigidBullet : ShotTypeBase
{
    [Header("��GamePos")]
    [SerializeField] Transform gamePos;//GamePos�A�e������̎q�I�u�W�F�N�g�Ƃ��Ĕz�u����
    [Header("��:�e�ɂ͕K��NoRigidBullet�������I�u�W�F�N�g�����邱��")]
    [SerializeField] BulletSettingTypeNoRigid[] bullets;//�e�̐ݒ�
    VectorOfShotType vectorOfShotType;
    float currentDelayTime;//���݂̒x�����ԁA���ꂪdelayTime�ɒB�������e���������

    void Start()
    {
        vectorOfShotType = GameObject.FindWithTag("VectorOfShot").GetComponent<VectorOfShotType>();
    }

    public override void InitShotTiming()//���^�C�~���O�̏�����
    {
        currentDelayTime = 0;

        for (int i = 0; i < bullets.Length; i++)//����������̏�����
        {
            bullets[i].Shoted = false;
        }
    }

    public override void UpdateShotTiming()//���^�C�~���O�̍X�V
    {
        currentDelayTime += Time.deltaTime;

        for (int i = 0; i < bullets.Length; i++)
        {
            BulletSettingTypeNoRigid bullet = bullets[i];

            if (currentDelayTime >= bullet.DelayTime && !bullet.Shoted)
            {
                Shot(bullet);
            }
        }
    }

    void Shot(BulletSettingTypeNoRigid bullet)
    {
        bullet.Shoted = true;//����������ɂ���

        //�U�������������ʒu�Ɗp�x���擾
        Vector3 shotPos = bullet.ShotPos.transform.position;//�ʒu
        Quaternion shotRot = bullet.ShotPos.transform.rotation;//�p�x

        GameObject bulletObject = Instantiate(bullet.BulletPrefab, shotPos, shotRot, gamePos);//�e�̐���

        NoRigidBullet noRigidBullet=bulletObject.GetComponentInChildren<NoRigidBullet>();//NoRigidBullet���擾

        if (noRigidBullet==null)//�擾�Ɏ��s�����ꍇ�G���[���b�Z�[�W���o��
        {
            Debug.Log(name + "NoRigidBullet���A�^�b�`���ꂽ�e���Z�b�g���Ă�������");
            return;
        }

        Vector3 shotVec = vectorOfShotType.ShotVec(bullet.ShotType, bullet.ShotPos);//�����������߂�

        noRigidBullet.SetBullet(bullet.Speed, shotVec);//�e�̐ݒ������
    }
}
