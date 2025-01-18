using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboCountDisplay : MonoBehaviour
{
    [Header("�\��������e�L�X�g")]
    [SerializeField] TMP_Text comboCount_UI;//�\��������e�L�X�g
    [SerializeField] Count_Trick_Critical countTrickCombo;

    void Update()
    {
        comboCount_UI.text=countTrickCombo.TotalCriticalCount.ToString("0");
    }
}
