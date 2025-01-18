using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�쐬��:���R
//���N���A������
public class JudgeFirstClear : MonoBehaviour
{
    [Header("�N���A�񐔂��Z�[�u����R���|�[�l���g")]
    [SerializeField] SaveClearCount _saveClearCount;
    public event Action<bool> Action_FirstClear;//���N���A�̔����ɌĂԏ����A���N���A�ł���΁Atrue������
    const int _judgeFirstClear_ClearCount = 0;//���N���A�Ɣ��肷��N���A��(0��ł���΁A���N���A�ƂȂ�)
    bool _isFirstClear = false;

    public bool IsFirstClear { get { return _isFirstClear; } }

    private void Awake()
    {
        _saveClearCount.Action_ClearCount_BeforeUpdate += Judge;
    }

    public void Judge(int clearCount_BeforeUpdate)//�X�V�E�Z�[�u�O�̃N���A�񐔂��擾�A���ꂪ0��ł���Ώ��N���A�Ƃ�������
    {
        _isFirstClear = (clearCount_BeforeUpdate == _judgeFirstClear_ClearCount);

        Action_FirstClear?.Invoke(_isFirstClear);
    }

}
