using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�Ƀ_���[�W��^����
[System.Serializable]
public class DamageToPlayer
{
    [Header("�_���[�W��")]
    [SerializeField] float damage;//�_���[�W��

    public void Damage(Collider p)//�v���C���[�Ƀ_���[�W��^����
    {
        HP player_Hp;
        player_Hp = p.GetComponentInChildren<HP>();

        if (player_Hp == null)//�擾�o���Ȃ�������HP�����炳���G���[�R�[�h
        {
            Debug.Log("HP���擾�ł��܂���ł���");
            return;
        }

        player_Hp.Hp -= damage;
    }
}
