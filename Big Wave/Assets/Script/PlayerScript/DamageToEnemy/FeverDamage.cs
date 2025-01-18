using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�쐬��:���R
//�G�Ƀ_���[�W��^���鎞�̃t�B�[�o�[��Ԏ��̃_���[�W�̌v�Z
public partial class DamageToEnemy
{
    [System.Serializable]
    class FeverDamage
    {
        [Header("�_���[�W�̑�����")]
        [Header("�ʏ펞")]
        [SerializeField] float _normalDamageGrowthRate;//�ʏ펞�̃_���[�W�̑�����
        [Header("�t�B�[�o�[���[�h��")]
        [SerializeField] float _feverDamageGrowthRate;//�t�B�[�o�[���[�h���̃_���[�W������
        [Header("�t�B�[�o�[���[�h�����擾���邽�߂̃R���|�[�l���g")]
        [SerializeField] FeverMode _feverMode;

        public float DamageRate()//�_���[�W�{���v�Z
        {
            return _feverMode.FeverNow ? _feverDamageGrowthRate : _normalDamageGrowthRate;
        }

        public float NormalDamageGrowthRate { get { return _normalDamageGrowthRate; } }

        public float FeverDamageGrowthRate { get { return _feverDamageGrowthRate; } }

        //�R���X�g���N�^
        public FeverDamage() { }

        public FeverDamage(float normalDamageGrowthRate, float feverDamageGrowthRate, FeverMode feverMode)
        {
            _normalDamageGrowthRate = normalDamageGrowthRate;
            _feverDamageGrowthRate = feverDamageGrowthRate;
            _feverMode = feverMode;
        }
    }
}
