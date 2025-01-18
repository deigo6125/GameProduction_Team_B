using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�G�Ƀ_���[�W��^���鎞�̃W�����v�̓_���[�W�̌v�Z
public partial class DamageToEnemy
{
    [System.Serializable]
    class JumpPowerDamage
    {
        [Header("�ő�܂ŗ��߂����ɉ��Z�����_���[�W")]
        [Header("�ʏ펞")]
        [SerializeField] float _normalDamageAmount;
        [Header("�N���e�B�J����")]
        [SerializeField] float _criticalDamageAmount;
        [Header("�W�����v�͂��擾���邽�߂̃R���|�[�l���g")]
        [SerializeField] JumpPower _jumpPower;

        public float Damage(bool critical)//�_���[�W�v�Z
        {
            //�N���e�B�J���ƃW�����v��(����)�ɂ���Ēl���ϓ�
            float damage = critical ? _criticalDamageAmount : _normalDamageAmount;
            damage *= _jumpPower.RatioLastJump;

            return damage;
        }

        public float NormalDamageAmount { get { return _normalDamageAmount; } }

        public float CriticalDamageAmount { get { return _criticalDamageAmount; } }

        //�R���X�g���N�^
        public JumpPowerDamage() { }

        public JumpPowerDamage(float damageAffectJumpPower_Normal, float damageAffectJumpPower_Critical, JumpPower jumpPower)
        {
            _normalDamageAmount = damageAffectJumpPower_Normal;
            _normalDamageAmount = damageAffectJumpPower_Critical;
            _jumpPower = jumpPower;
        }
    }
}