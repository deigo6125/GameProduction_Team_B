using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplay_Player : MonoBehaviour
{
    [Header("��HP�Q�[�W")]
    [SerializeField] Image hpGauge;//HP�Q�[�W
    [Header("��HP��\���������I�u�W�F�N�g")]
    [SerializeField] HP objectDisplayHp;//HP��\���������I�u�W�F�N�g
    [Header("�ʏ펞�̐F")]
    [SerializeField] Color normalColor;//�ʏ펞�̐F
    [Header("�̗͂����Ȃ����̐F")]
    [SerializeField] Color pinchColor;//�̗͂����Ȃ����̐F
    [Header("�̗̓Q�[�W�̐F���ς�鋫�E�l(����)")]
    [Range(0f, 1f)]
    [SerializeField] float borderRatio;//�̗̓Q�[�W�̐F���ς�鋫�E�l(%)
    [Header("�̗͉񕜂̃R���|�[�l���g")]
    [SerializeField] RecoverHPWhileCharging recoverHPWhileCharging;
    [Header("�_�ł̐ݒ�")]
    [SerializeField] BlinkColor blinkColor = new BlinkColor();
    const float maxHpRatio = 1;//�̗͖��^�����̗̑͂̊���


    void Update()
    {
        HpGauge();
    }

    void HpGauge()//HP�Q�[�W�̏���
    {
        float hpRatio = objectDisplayHp.Hp / objectDisplayHp.HpMax;
        hpGauge.fillAmount = hpRatio;
        //�Q�[�W�̐F�̕ύX
        hpGauge.color = (hpRatio <= borderRatio) ? pinchColor : normalColor;

        //�̗͖��^���łȂ����񕜒��͓_�ł�����
        if(hpRatio!=maxHpRatio&&recoverHPWhileCharging.Healing)
        {
            hpGauge.color=blinkColor.Blinking(hpGauge.color);
        }
    }
}
