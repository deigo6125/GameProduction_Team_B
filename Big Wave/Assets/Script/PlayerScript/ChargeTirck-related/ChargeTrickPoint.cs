using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�g���b�N�̃`���[�W
public class ChargeTrickPoint : MonoBehaviour
{
    [Header("�t�B�[�o�[��Ԃ̃`���[�W�g���b�N�ʃA�b�v�̑�����")]
    [SerializeField] float chargeTrickGrowthRate_Fever;

    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] ChangeChargeRateTheChargers changeChargeRateTheChargers;
    [SerializeField] FeverMode feverMode;
    [SerializeField] TrickPoint player_TrickPoint;
    [SerializeField] JudgeChargeTrickPointNow judgeChargeTrickPointNow;
    [SerializeField] ChangeChargeRateTheSurfer changeChargeRateTheSurfer;

    const float chargeTrickGrowthRate_Normal = 1;//���{(�`���[�W�g���b�N�ʃA�b�v�̑�����)
    bool _switch = true;//���ꂪfalse���ƃ`���[�W����Ȃ�

    /////private(�ʃN���X�͎g�p�s��)�̃��\�b�h/////

    float ChargeTrickAmount(float chargeAmount)//�`���[�W�����g���b�N��
    {
        float ret = chargeAmount;//�ʏ펞�̃`���[�W�����g���b�N��
        ret *= feverMode.FeverNow ? chargeTrickGrowthRate_Fever : chargeTrickGrowthRate_Normal;//�t�B�[�o�[��Ԃ̃`���[�W�{��
        ret *= changeChargeRateTheChargers.ChargeRate(player_TrickPoint.MaxCount,player_TrickPoint.TrickGaugeNum);//���^���̃g���b�N�Q�[�W�̐��ɂ��`���[�W�{��
        ret *= changeChargeRateTheSurfer.ChargeRate();//�g�ɏ���Ă��鎞�Ԃɂ��`���[�W�{��
        return ret;
    }


    /////public(�ʃN���X���g�p�\)�̃��\�b�h/////
   
    public bool Switch
    {
        get { return _switch; }
        set { _switch = value; }
    }

    public void Charge(float chargeAmount)//�g���b�N�̃`���[�W
    {
        if (!_switch) return;

        player_TrickPoint.Charge(ChargeTrickAmount(chargeAmount));//�g���b�N���`���[�W
        judgeChargeTrickPointNow.ResetSinceLastChargedTime();//�Ō�Ƀ`���[�W����Ă���̎��Ԃ����Z�b�g
    }
}
