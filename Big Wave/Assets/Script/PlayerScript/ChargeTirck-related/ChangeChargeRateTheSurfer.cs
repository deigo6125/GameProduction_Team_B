using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�g�ɏ��قǃ`���[�W�{�����オ���Ă���
public class ChangeChargeRateTheSurfer : MonoBehaviour
{
    [Header("�ő�܂ł��܂�₷���Ȃ������̔{��(�ő�{��)")]
    [SerializeField] float chargeRateMax = 3;//�ő�{��
    [Header("�ő�{���ɂȂ�܂łɂ����鎞��")]
    [SerializeField] float byMaxRateTime = 10;//�ő�{���ɂȂ�܂łɂ����鎞��
    [Header("�{�������鑬�x(�{���������鎞�̑��x��1�Ƃ���)")]
    [SerializeField] float minusChargeRateSpeed;//�g�ɐG��ĂȂ����W�����v���Ă��Ȃ����ɔ{�������鑬�x
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] JudgeJumpNow judgeJumpNow;
    [SerializeField] JudgeTouchWave judgeTouchWave;

    private const float normalChargeRate = 1;//���{
    private float currentChargeRate = normalChargeRate;//���݂̔{��

    public float ChargeRateMax//�ő�`���[�W�{��
    {
        get { return chargeRateMax; }
    }

    public float NormalChargeRate//���{(�������)�̃`���[�W�{��
    {
        get { return normalChargeRate; }
    }

    public float ChargeRate()//���݂̃`���[�W�{����Ԃ�
    {
        return currentChargeRate;
    }

    void Update()
    {
        ChangeChargeRate();
    }

    //�`���[�W�{����ω�������
    void ChangeChargeRate()
    {
        float changeRatePerSecond = (chargeRateMax - normalChargeRate) / byMaxRateTime;//1�b���Ƃɑ�����{����

        //�g�ɐG��Ă��邩�W�����v���Ă��鎞�AbyRateMaxTime�����Ă��񂾂�{����1�{����chargeRateMax�{�܂ŕω�����
        if (ChangeChargeRateNow())
        {
            currentChargeRate += changeRatePerSecond * Time.deltaTime;//1�t���[�����Ƃɑ�����{����
        }
        //�����łȂ����A�{�������Ԃ��ƂɌ����Ă���
        else
        {
            currentChargeRate -= minusChargeRateSpeed * changeRatePerSecond * Time.deltaTime;//1�t���[�����ƂɌ���{����
        }

        currentChargeRate = Mathf.Clamp(currentChargeRate, 1, chargeRateMax);
    }

    bool ChangeChargeRateNow()//���݃`���[�W�{�����ω����Ă��邩
    {
        //���݃W�����v���Ă���������͔g�ɐG��Ă���Ƃ��A�`���[�W�{�����ω�����
        bool chargeRateNow = (judgeJumpNow.JumpNow() || judgeTouchWave.TouchWaveNow);
        return chargeRateNow;
    }
}
