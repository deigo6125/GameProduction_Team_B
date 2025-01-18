using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�G�Ƀ_���[�W��^����
//�d�l�̕ύX(�N���e�B�J���łȂ��Ă��_���[�W��^�����Ă����̂��N���e�B�J���łȂ��ƃ_���[�W��^�����Ȃ��悤�ɂ��܂���)
public partial class DamageToEnemy : MonoBehaviour
{
    [Header("��{�_���[�W�̐ݒ�")]
    [SerializeField] BaseDamage _baseDamage;
    [Header("�t�B�[�o�[���[�h���̃_���[�W�̐ݒ�")]
    [SerializeField] FeverDamage _feverDamage;
    [Header("�W�����v�͈ˑ��̃_���[�W�̐ݒ�")]
    [SerializeField] JumpPowerDamage _jumpPowerDamage;

    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] Critical _critical;
    [SerializeField] Generate_AlongWay _generate_AlongWay;

    HP enemy_Hp;//�G��HP
    Queue<float> damageQueue = new Queue<float>();

    void Start()
    {
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponentInChildren<HP>();
        _generate_AlongWay.CriticalTrickEffect.LandAction += CauseDamage;
        _generate_AlongWay.NormalTrickEffect.LandAction += CauseDamage;
        _generate_AlongWay.CriticalFeverTrickEffect.LandAction += CauseDamage;
    }

    public void AccumulateDamage()//�_���[�W���L���[�ɒ~��
    {
        float damage = CalcDamage();//�_���[�W�v�Z
        
        damageQueue.Enqueue(damage);//�L���[�Ƀ_���[�W��o�^
    }

    float CalcDamage()//�_���[�W�v�Z
    {
        bool critical = _critical.CriticalNow;

        float damage = 0;

        damage += _baseDamage.Damage(critical);//��{�_���[�W�ʉ��Z

        damage *= _feverDamage.DamageRate();//�t�B�[�o�[���[�h�̃_���[�W�{����

        damage += _jumpPowerDamage.Damage(critical);//�W�����v��(����)�ɉ������_���[�W���Z

        return damage;
    }

    public void CauseDamage()//�G�Ƀ_���[�W��^����
    {
        enemy_Hp.Hp -= damageQueue.Dequeue();
    }
}
