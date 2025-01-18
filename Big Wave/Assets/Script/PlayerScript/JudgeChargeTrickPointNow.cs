using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

//�쐬��:���R
//���݃`���[�W���Ă��邩�̔���
public class JudgeChargeTrickPointNow : MonoBehaviour
{
    [Header("�`���[�W���Ă��Ȃ��E���Ă���̋��E�̎���")]
    [SerializeField] float chargedBorderTime = 0.1f;//�`���[�W���Ă��Ȃ��E���Ă���̋��E�̎���
    public event Action StartChargeAction;//�`���[�W��ԊJ�n�̏u�ԂɌĂ�
    public event Action EndChargeAction;//�`���[�W��ԏI���̏u�ԂɌĂ�
    public event Action<bool> SwitchChargeAction;//�`���[�W��Ԃ̐؂�ւ�莞�ɌĂ�(true�ł���΃`���[�W�J�n�Afalse�ł���΃`���[�W�I��)
    private float sinceLastChargedTime;//�Ō�Ƀ`���[�W����Ă���̎���
    bool chargeNow = false;//���݃`���[�W���Ă��邩
    bool chargeNowBeforeFrame;//�O�̃t���[���̃`���[�W���Ă��邩�̔���

    public bool ChargeNow()//���`���[�W���Ă��邩
    {
        return chargeNow;
    }

    public void ResetSinceLastChargedTime()//�Ō�Ƀ`���[�W����Ă���̎��Ԃ����Z�b�g
    {
        sinceLastChargedTime = 0;
    }

    void Start()
    {
        sinceLastChargedTime = chargedBorderTime;//�����̍Ō�Ƀ`���[�W����Ă���̎��Ԃ��`���[�W�̋��E���Ԃɐݒ�
        chargeNowBeforeFrame = chargeNow;
    }

    void Update()
    {
        UpdateChargeNow();

        CallChargeAction();

        chargeNowBeforeFrame = chargeNow;
    }

    //�`���[�W�󋵂��؂�ւ�����u�Ԃɓo�^���Ă������\�b�h���Ăяo��
    void CallChargeAction()
    {
        if(chargeNow!=chargeNowBeforeFrame)
        {
            //�O�t���[���ƃ`���[�W�󋵂��ς���Ă���A���݂̃t���[���Ń`���[�W���Ă���Ƃ������Ƃ̓`���[�W���J�n���ꂽ�Ƃ�������
            bool startCharge = chargeNow;

            SwitchChargeAction?.Invoke(startCharge);

            if(startCharge)
            {
                StartChargeAction?.Invoke();
            }
            else
            {
                EndChargeAction?.Invoke();
            }
        }
    }

    //�`���[�W�󋵂̍X�V
    void UpdateChargeNow()
    {
        sinceLastChargedTime += Time.deltaTime;

        //�Ō�Ƀ`���[�W���Ă���chargeBorderTime(�b)�����Ȃ獡�`���[�W���Ă锻��
        chargeNow = sinceLastChargedTime < chargedBorderTime;
    }
}
