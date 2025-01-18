using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�N���A���x���̃Z�[�u�E�X�V
public class SaveClearLevel : MonoBehaviour
{
    [Header("�X�e�[�W�f�[�^")]
    [SerializeField] CurrentStageData _currentStageData;

    private void Start()
    {
        UpdateClearLevel();
    }

    void UpdateClearLevel()//�N���A���x���̍X�V
    {
        //���݂̃N���A���x�����Z�[�u�f�[�^������o��
        int pastClearLevel = SaveData.GetClearLevel();
        //�N���A���x���̍X�V
        if (_currentStageData.Level > pastClearLevel)
        {
            SaveData.SaveClearLevel(_currentStageData.Level);
        }
    }
}
