using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�X�e�[�W���Ƃ̍ő��N���A�^�C���̃Z�[�u�E�X�V
public class SaveHighClearTime : MonoBehaviour
{
    [Header("���N���A�ł��邱�Ƃ𔻒肷��R���|�[�l���g")]//���N���A�ł��邱�Ƃ𔻒肷��R���|�[�l���g
    [SerializeField] JudgeFirstClear _judgeFirstClear;
    [Header("�X�e�[�W�f�[�^")]
    [SerializeField] CurrentStageData _currentStageData;
    [Header("�N���A�^�C�����擾���邽�߂̃R���|�[�l���g")]
    [SerializeField] Score_TimeLimit _score_timelimit;
    public event Action<bool> Action_NewRecord;//�ő��N���A�^�C���X�V�̔����ɌĂԏ����A�ő��N���A�^�C���X�V�ł���΁Atrue������
    bool _updated = false;//�ő��N���A�^�C�����X�V������

    public bool Updated { get { return  _updated; } }

    private void Awake()
    {
        _judgeFirstClear.Action_FirstClear += UpdateHighClearTime;
    }

    void UpdateHighClearTime(bool isFirstClear)//�ő��N���A�^�C���̍X�V
    {
        float currentHighClearTime = SaveData.GetHighClearTime(_currentStageData.StageID);//���݂̍ő��N���A�^�C�����擾
        float thisClearTime = _score_timelimit.ClearTime;//���݂̃N���A�^�C�����擾

        bool fasterThis = currentHighClearTime > thisClearTime;//����̕���������

        //�ő��N���A�^�C���̍X�V(���N���A�ł���Ίm��ōX�V�A�܂��N���A�^�C��������̕����͂₯��΍X�V)
        if (isFirstClear || fasterThis)
        {
            SaveData.SaveHighClearTime(_currentStageData.StageID, thisClearTime);
            _updated = true;
        }

        Action_NewRecord?.Invoke(_updated);
    }
}
