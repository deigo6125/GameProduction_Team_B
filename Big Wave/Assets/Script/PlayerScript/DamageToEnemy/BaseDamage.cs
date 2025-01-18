using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

//�쐬��:���R
//�G�Ƀ_���[�W��^���鎞�̊�{�_���[�W�̌v�Z
public partial class DamageToEnemy
{
    [System.Serializable]
    class BaseDamage
    {
        [Header("�_���[�W��")]
        [Header("�ʏ펞")]
        [SerializeField] float _normalDamageAmount;//�ʏ�_���[�W��
        [Header("�N���e�B�J����")]
        [SerializeField] float _criticalDamageAmount;//�N���e�B�J���_���[�W��

        public float Damage(bool critical)//�_���[�W�v�Z
        {
            return critical ? _criticalDamageAmount : _normalDamageAmount;
        }

        public float NormalDamageAmount { get { return _normalDamageAmount; } }

        public float CriticalDamageAmount { get { return _criticalDamageAmount; } }

        //�R���X�g���N�^
        public BaseDamage() { }

        public BaseDamage(float normalDamageAmount, float criticalDamageAmount)
        {
            _normalDamageAmount = normalDamageAmount;
            _criticalDamageAmount = criticalDamageAmount;
        }
    }
}
