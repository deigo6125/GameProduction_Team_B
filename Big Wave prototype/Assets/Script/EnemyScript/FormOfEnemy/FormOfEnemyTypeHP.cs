using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�G��HP���獡���扽�`�Ԃ��𔻒f
public class FormOfEnemyTypeHP : FormOfEnemyTypeBase
{
    [Header("�ǂ̓G��HP���Q�Ƃ��邩")]
    [SerializeField] HP enemy_Hp;//�G��HP
    [Header("�`�Ԃ��Ƃ̓˓�����HP")]
    [Tooltip("�v�f�ԍ�0�����`�ԁA�v�f�ԍ�1�����`��...�v�f�ԍ�n����n-1�`�ԁB���̗͈̑ȉ��̎����̌`�ԓ˓�����")]
    [SerializeField] float[] formHp;//�w��`�ԓ˓������̗�(���̗͈̑ȉ��̎����̌`�ԓ˓�)

    void Start()
    {
        //���`�ԓ˓�����HP���ő�HP�ɐݒ�(�ŏ��͑��`�Ԃ���Ȃ̂�)
        formHp[0] = enemy_Hp.HpMax;
    }

    public override int CurrentForm()//���݂��扽�`�Ԃ��A�Ⴆ�΍������`�ԂȂ�1��Ԃ�
    {
        for (int i = formHp.Length - 1; 0 <= i; i--)//�ŏI�`�Ԃ̏������珇�Ɍ��Ă���
        {
            if (enemy_Hp.Hp <= formHp[i])//���݂̗̑͂����̌`�Ԃ̓˓�����HP�ȉ��Ȃ炻�̌`�Ԃ̔ԍ���Ԃ�
            {
                return i;
            }
        }

        return 0;
    }
}