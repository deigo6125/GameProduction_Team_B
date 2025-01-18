using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�z�[�~���O�e������
public class ShotTypeHomingBullet : ShotTypeBase
{
    [Header("��GamePos")]
    [SerializeField] Transform gamePos;//GamePos�A�e������̎q�I�u�W�F�N�g�Ƃ��Ĕz�u����
    [Header("��:�e�ɂ͕K��HomingBullet�������I�u�W�F�N�g�����邱��")]
    [SerializeField] BulletSettingTypeHoming[] bullets;//�e�̐ݒ�
    float currentDelayTime;//���݂̒x�����ԁA���ꂪdelayTime�ɒB�������e���������

    public override void InitShotTiming()//���^�C�~���O�̏�����
    {
        currentDelayTime = 0;

        for(int i=0;i<bullets.Length ;i++)//����������̏�����
        {
            bullets[i].Shoted = false;
        }
    }

    public override void UpdateShotTiming()//���^�C�~���O�̍X�V
    {
        currentDelayTime += Time.deltaTime;

        for (int i=0; i<bullets.Length;i++)
        {
            BulletSettingTypeHoming bullet = bullets[i];

            if (currentDelayTime >= bullet.DelayTime && !bullet.Shoted)
            {
                Shot(bullet);
            }
        }
    }

    void Shot(BulletSettingTypeHoming bullet)
    {
        bullet.Shoted = true;//����������ɂ���

        //�U�������������ʒu�Ɗp�x���擾
        Vector3 shotPos = bullet.ShotPos.transform.position;//�ʒu
        Quaternion shotRot = bullet.ShotPos.transform.rotation;//�p�x

        GameObject homingBulletObject=Instantiate(bullet.BulletPrefab,shotPos,shotRot, gamePos);//�e�̐���

        HomingBullet homing = homingBulletObject.GetComponentInChildren<HomingBullet>();//HomingBullet���擾

        if(homing==null)//�擾�Ɏ��s�����ꍇ�G���[���b�Z�[�W���o��
        {
            Debug.Log(name+"HomingBullet���A�^�b�`���ꂽ�e���Z�b�g���Ă�������");
            return;
        }

        homing.SetBullet(bullet.StartHomingTime, bullet.HomingTime, bullet.HomingSpeed, bullet.Speed);//�e�̐ݒ������
    }
}
