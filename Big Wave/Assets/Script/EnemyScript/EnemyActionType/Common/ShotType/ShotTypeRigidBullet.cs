using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�ʏ�e(Rigidbody)������
public class ShotTypeRigidBullet : ShotTypeBase
{
    [Header("��GamePos")]
    [SerializeField] Transform gamePos;//GamePos�A�e������̎q�I�u�W�F�N�g�Ƃ��Ĕz�u����
    [Header("��:�e�ɂ͕K��Rigidbody�������I�u�W�F�N�g�����邱��")]
    [SerializeField] BulletSettingTypeRigid[] bullets;//�e�̐ݒ�
    VectorOfShotType vectorOfShotType;
    float currentDelayTime;//���݂̒x�����ԁA���ꂪdelayTime�ɒB�������e���������
   [SerializeField] float torquePower;//��]����́B
    void Start()
    {
        vectorOfShotType=GameObject.FindWithTag("VectorOfShot").GetComponent<VectorOfShotType>();
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
            BulletSettingTypeRigid bullet = bullets[i];

            if (currentDelayTime >= bullet.DelayTime && !bullet.Shoted)
            {
                Shot(bullet);
            }
        }
    }

    void Shot(BulletSettingTypeRigid bullet)
    {
        bullet.Shoted = true;//����������ɂ���

        //�U�������������ʒu�Ɗp�x���擾
        Vector3 shotPos = bullet.ShotPos.transform.position;//�ʒu
        Quaternion shotRot = bullet.ShotPos.transform.rotation;//�p�x

        GameObject bulletObject = Instantiate(bullet.BulletPrefab, shotPos, shotRot, gamePos);//�e�̐���

        Rigidbody rb = bulletObject.GetComponentInChildren<Rigidbody>();//RigidBody���擾

        if(rb==null)//�擾�Ɏ��s�����ꍇ�G���[���b�Z�[�W���o��
        {
            Debug.Log(name + "Rigidbody���A�^�b�`���ꂽ�e���Z�b�g���Ă�������");
            return;
        }

        Vector3 shotVec=vectorOfShotType.ShotVec(bullet.ShotType,bullet.ShotPos);//�����������߂�

        bulletObject.transform.rotation = Quaternion.LookRotation(shotVec, Vector3.up);//�U���̌������������ɕύX

        rb.AddForce(shotVec * bullet.ShotPower, ForceMode.Impulse);//�e����������
        rb.AddTorque(-transform.right*torquePower, ForceMode.Impulse);
    }
}
