using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�`���[�W���͂����Əo���G�t�F�N�g
public class ChargeTrickEffect_WhileCharge : MonoBehaviour
{
    [Header("�`���[�W����")]
    [SerializeField] JudgeChargeTrickPointNow _judgeChargeTrickPointNow;
    [Header("�`���[�W�G�t�F�N�g")]
    [SerializeField] GameObject _chargeEffect;
    [Header("�`���[�W�̌��ʉ�")]
    [SerializeField] AudioClip _chargeSE;
    [SerializeField] AudioSource _audioSource;
    bool _switch = true;//���ꂪfalse�̎��̓`���[�W��ԂɂȂ��Ă��G�t�F�N�g���o���Ȃ��Ȃ�

    public bool Switch
    {
        get { return _switch; }
        set { _switch = value; }
    }

    void Start()
    {
        _judgeChargeTrickPointNow.SwitchChargeAction += Effect;
    }

    void Update()
    {
        if(!_switch)
        {
            _chargeEffect.SetActive(false);
        }
    }

    void Effect(bool chargeNow)
    {
        _chargeEffect.SetActive(_switch ? chargeNow:false);//�G�t�F�N�g�̕\���E��\��

        if (!_switch) return;

        if(chargeNow)
        {
            _audioSource.PlayOneShot(_chargeSE);//���ʉ���炷
        }
    }
}
