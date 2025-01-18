using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�X�e�[�W���Ƃ̃N���A�񐔊֌W�̃Z�[�u�f�[�^
public static partial class SaveData
{
    //�X�e�[�W���Ƃ̃N���A�񐔊֌W
    const string _saveDataName_ClearCount = "CLEARCOUNT_STAGE";//�N���A�񐔂̃Z�[�u�f�[�^��
    const int _defaultClearCount = 0;//�N���A�񐔂̏������
    const int _maxClearCount = 9999;//�N���A�񐔂̏��

    public static int GetClearCount(int stageID)//�N���A�񐔂̎擾
    {
        string str_stageID = stageID.ToString();
        return PlayerPrefs.GetInt(_saveDataName_ClearCount + str_stageID, _defaultClearCount);
    }

    public static void AddClearCount(int stageID)//�N���A�񐔂���񑝂₷
    {
        string str_stageID = stageID.ToString();

        //�N���A�񐔂��擾���Ĉ�񑝂₵�Ă���A�Z�[�u
        int currentClearCount = GetClearCount(stageID);
        currentClearCount++;
        if (currentClearCount > _maxClearCount) currentClearCount = _maxClearCount;//�����˔j���Ȃ��悤�ɂ��邽�߂̏���

        PlayerPrefs.SetInt(_saveDataName_ClearCount + str_stageID, currentClearCount);
        PlayerPrefs.Save();
    }
}
