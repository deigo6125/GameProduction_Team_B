using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�g�ɏ��قǃ`���[�W�G�t�F�N�g�̑傫�����傫���Ȃ��Ă���
public class ChangeScaleTheSurfer : MonoBehaviour
{
    [Header("�ő�{�����̃`���[�W���̑傫��(�{��)")]
    [SerializeField] float maxScaleRate;//�ő�{�����̃`���[�W���̑傫���̔{���A�����̑傫�����牽�{�̑傫����
    private Vector3 normalScale;//�ʏ펞(����)�̑傫��
    [SerializeField] ChangeChargeRateTheSurfer changeChargeRateTheSurfer;

    void Start()
    {
        normalScale = transform.localScale;//�ʏ펞(����)�̑傫�����L��
    }

    void Update()
    {
        ChangeEffectScale();
    }

    //�傫����ύX
    void ChangeEffectScale()
    {
        if (gameObject.activeSelf)//�A�N�e�B�u��(�\�����Ă���)���ɑ傫����ύX
        {
            //���݂̑傫����ύX
            transform.localScale = normalScale*CurrentScaleRate();
        }
    }

    //���݂̃`���[�W�{��(�g�ɏ��قǑ�������)����
    //�ʏ펞�Ɣ�ׂ����̌��݂̑傫���̔{�����v�Z���ĕԂ�
    //�`���[�W�{�����ő�̎��͍ő�{�����̃`���[�W���̑傫���̔{����Ԃ��悤�ɂ���
    float CurrentScaleRate()
    {
        //0%�������̃`���[�W�{���A100%���ő�̃`���[�W�{���Ƃ����Ƃ���
        //���݂̃`���[�W�{������%�������߂�
        float current = changeChargeRateTheSurfer.ChargeRate() - changeChargeRateTheSurfer.NormalChargeRate;//���݂̃`���[�W�{������ʏ�̃`���[�W�{��(1)������������
        float max = changeChargeRateTheSurfer.ChargeRateMax - changeChargeRateTheSurfer.NormalChargeRate;//�ő�`���[�W�{������ʏ�̃`���[�W�{��(1)������������
        float ratio = current / max;

        const float normalScaleRate = 1;//�ʏ펞�̑傫���̔{���A1�Œ�
        float currentScaleRate=normalScaleRate+(maxScaleRate-normalScaleRate)*ratio;//�ʏ펞�Ɣ�ׂ����̌��݂̑傫���̔{��
        return currentScaleRate;
    }

    
}
