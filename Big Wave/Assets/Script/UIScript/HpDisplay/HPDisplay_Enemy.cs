using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplay_Enemy : MonoBehaviour
{
    [Header("��HP�Q�[�W")]
    [SerializeField] Image hpGauge;//HP�Q�[�W
    [Header("��HP��\���������I�u�W�F�N�g")]
    [SerializeField] HP objectDisplayHp;//HP��\���������I�u�W�F�N�g
    private Slant slant = new Slant();

    void Update()
    {
        HPGauge();
    }

    void HPGauge()
    {
        float hpRatio = objectDisplayHp.Hp / objectDisplayHp.HpMax;
        RectTransform rectTransform = hpGauge.GetComponent<RectTransform>();

        slant.MakeSlant(rectTransform, hpRatio);
    }
}
