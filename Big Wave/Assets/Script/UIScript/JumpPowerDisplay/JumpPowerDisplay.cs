using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�쐬��:���R
//�W�����v�͂�UI�ŕ\��
public class JumpPowerDisplay : MonoBehaviour
{
    [Header("�W�����v�̓Q�[�W(��`���[�W���ɉB������)")]
    [SerializeField] GameObject main_jumpPowerGauge;//�W�����v�̓Q�[�W(��`���[�W���ɉB������)
    [Header("�W�����v�̓Q�[�W�ϕ���")]
    [SerializeField] Image jumpPowerGauge;//�W�����v�̓Q�[�W�ϕ���
    [Header("�W�����v��")]
    [SerializeField] JumpPower jumpPower;

    void Update()
    {
        Display();
        JumpPowerGauge();
    }

    void JumpPowerGauge()//�W�����v�̓Q�[�W�̏���
    {
        if (!main_jumpPowerGauge.activeSelf) return;//�W�����v�̓Q�[�W����\���̎��͈ȉ��̏��������Ȃ�

        float ratio = jumpPower.Ratio;
        jumpPowerGauge.fillAmount = ratio;
    }

    void Display()//�`���[�W���̂ݕ\��������
    {
        main_jumpPowerGauge.SetActive(jumpPower.ChargeNow);
    }
}
