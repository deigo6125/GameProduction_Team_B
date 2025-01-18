using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�쐬��:���R
//���e���̌��ʉ��ƓG�̔�_�����[�V�����̃Z�b�g�̏������ꎞ�I�ɔ����Ă܂�
public class Land : MonoBehaviour
{
    [SerializeField] DamageMotion damageMotion_Enemy;
    [Header("�ʏ펞")]
    [SerializeField] AudioSource _sourceNormal;
    [SerializeField] AudioClip _seNormal;
    [Header("�N���e�B�J����")]
    [SerializeField] AudioSource _sourceCritical;
    [SerializeField] AudioClip _seCritical;
    [Header("�N���e�B�J���t�B�[�o�[��")]
    [SerializeField] AudioSource _sourceCriticalFever;
    [SerializeField] AudioClip _seCriticalFever;
    [SerializeField] Generate_AlongWay generate_AlongWay;

    void Start()
    {
        generate_AlongWay.NormalTrickEffect.LandAction += LandEffect_Normal;
        generate_AlongWay.CriticalTrickEffect.LandAction += LandEffect;
        generate_AlongWay.CriticalFeverTrickEffect.LandAction += LandEffect_Fever;
    }

     public void LandEffect_Normal()//�ʏ펞
    {
        _sourceNormal.PlayOneShot(_seNormal);
    }
    public void LandEffect()//�N���e�B�J����
    {
        damageMotion_Enemy.DamageTrigger();
        _sourceCritical.PlayOneShot(_seCritical);
    }
    public void LandEffect_Fever()//�N���e�B�J�����t�B�[�o�[��
    {
        damageMotion_Enemy.DamageTrigger();
        _sourceCriticalFever.PlayOneShot(_seCriticalFever);
    }
   
}
