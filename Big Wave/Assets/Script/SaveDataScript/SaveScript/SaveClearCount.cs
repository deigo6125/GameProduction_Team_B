using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�쐬��:���R
//�X�e�[�W���Ƃ̃N���A�񐔂̃Z�[�u�E�X�V
public class SaveClearCount : MonoBehaviour
{
    [Header("�X�e�[�W�f�[�^")]
    [SerializeField] CurrentStageData _currentStageData;
    public event Action Action_BeforeUpdate;//�N���A�񐔂̍X�V�̑O�ɌĂт�������
    public event Action<int> Action_ClearCount_BeforeUpdate;//�N���A�񐔂̍X�V�̑O�ɌĂт�������(�X�V�O�̃N���A�񐔂�����)

    private void Start()
    {
        UpdateClearCount();
    }

    void UpdateClearCount()//�N���A�񐔂̍X�V
    {
        int beforeUpdatedClearCount = SaveData.GetClearCount(_currentStageData.StageID);//�X�V�O�̃N���A��

        //�C�x���g���Ăяo��
        Action_BeforeUpdate?.Invoke();
        Action_ClearCount_BeforeUpdate?.Invoke(beforeUpdatedClearCount);

        //���݂̃X�e�[�W�̃N���A�񐔂𑝂₷
        SaveData.AddClearCount(_currentStageData.StageID);
    }
}
