using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//�쐬��:���R
//�ő��N���A�^�C�����o���牉�o���o��(���݂͕������o������)
public class HighClearTimeEffect : MonoBehaviour
{
    [SerializeField] SaveHighClearTime _saveHighClearTime;
    [Header("�ő��N���A�^�C���X�V���ɕ\������e�L�X�g")]
    [SerializeField] TMP_Text _highClearTimeText;

    private void Awake()
    {
        _saveHighClearTime.Action_NewRecord += Display;
    }

    public void Display(bool updated)
    {
        _highClearTimeText.enabled = updated;
    }
}
