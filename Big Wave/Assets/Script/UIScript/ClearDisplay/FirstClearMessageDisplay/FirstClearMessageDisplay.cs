using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���N���A���ɕ\�����郁�b�Z�[�W
public class FirstClearMessageDisplay : MonoBehaviour
{
    [Header("���N���A���ɕ\������I�u�W�F�N�g�Ƃ��̃X�e�[�W��ID")]
    [SerializeField] Element_FirstClearMessageDisplay[] elements;//���N���A���ɕ\������I�u�W�F�N�g�Ƃ��̃X�e�[�W��ID
    [Header("���N���A���𔻒肷��R���|�[�l���g")]
    [SerializeField] JudgeFirstClear _judgeFirstClear;//���N���A���𔻒肷��R���|�[�l���g
    [Header("�X�e�[�W�f�[�^")]
    [SerializeField] CurrentStageData _currentStageData;//�X�e�[�W�f�[�^

    private void Awake()
    {
        _judgeFirstClear.Action_FirstClear += Display;
    }

    public void Display(bool firstClear)//��قǗV�񂾃X�e�[�W��ID�ƈ�v������̂�\������
    {
        if (!firstClear) return;

        int currentStageID = _currentStageData.StageID;//��قǗV�񂾃X�e�[�W��ID

        for(int i=0; i<elements.Length ;i++)
        {
            if (elements[i].StageID==currentStageID)
            {
                elements[i].Object.SetActive(true);
            }
        }
    }

}
