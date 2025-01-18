using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���݂̃g���b�N�ʂɂ��`���[�W�{����ω�������
public class ChangeChargeRateTheChargers : MonoBehaviour
{
    [Header("�`���[�W�{��(�g���b�N�Q�[�W�̌����z���p�ӂ��Ă�������)")]
    [SerializeField] float[] chargeRate;//�`���[�W�{��

    //���^���̃Q�[�W�̐��ɑΉ������`���[�W�{����Ԃ�
    //������maxCount�ɂ̓v���C���[�̖��^���̃g���b�N�Q�[�W�̌��A������trickGaugeNum�ɂ̓v���C���[�̃g���b�N�Q�[�W�̌�������
    public float ChargeRate(int maxCount, int trickGaugeNum)
    {
        maxCount = Mathf.Clamp(maxCount, 0, trickGaugeNum - 1);
        return chargeRate[maxCount];
    }
}
