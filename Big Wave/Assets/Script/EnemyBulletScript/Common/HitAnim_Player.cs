using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�ɔ�e���[�V����������
[System.Serializable]
public class HitAnim_Player
{
    public void DamageMotionTrigger(Collider p)//�v���C���[�̃_���[�W���[�V�������Đ�
    {
        DamageMotion damageMotion_Player;
        damageMotion_Player=p.GetComponentInChildren<DamageMotion>();
        damageMotion_Player.DamageTrigger();
    }
}
