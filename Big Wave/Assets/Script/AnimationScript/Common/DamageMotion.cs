using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�_���[�W���[�V����(bool�ƃg���K�[�����g�����ƂňӐ}���Ȃ����Ƀ_���[�W���[�V�������Đ�����̂�h��)
public class DamageMotion : MonoBehaviour
{
    [Header("�A�j���[�^�[")]
    [SerializeField] Animator _enemy_animator;//�A�j���[�^�[
    [SerializeField] string damageTriggerName;
    [SerializeField] string damageBoolName;
    [Header("���b�o�������e����������")]
    [SerializeField] float cancelDamagedTime;//���b�o�������e����������
    bool damageMotion=false;
    float currentCancelDamagedTime = 0;


    public void DamageTrigger()
    {
        _enemy_animator?.SetTrigger(damageTriggerName);
        currentCancelDamagedTime = 0;
        damageMotion = true;
    }

    void Update()
    {
        UpdateCancelDamage();
    }

    void UpdateCancelDamage()//�_���[�W���[�V�����̍Đ��̃L�����Z����Ԃ̍X�V
    {
        currentCancelDamagedTime += Time.deltaTime;

        if (damageMotion == true && currentCancelDamagedTime >= cancelDamagedTime)
        {
            damageMotion = false;
        }

        _enemy_animator?.SetBool(damageBoolName, damageMotion);
    }

    
}
