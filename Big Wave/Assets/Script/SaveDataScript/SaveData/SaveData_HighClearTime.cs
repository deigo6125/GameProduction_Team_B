using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�X�e�[�W���Ƃ̍ő��N���A�^�C���֌W�̃Z�[�u�f�[�^
public static partial class SaveData
{
    //�X�e�[�W���Ƃ̍ő��N���A�^�C���֌W
    const string _saveDataName_HighClearTime = "HIGHCLEARTIME_STAGE";//�ő��N���A�^�C���̃Z�[�u�f�[�^��
    const float _defaultHighClearTime = 0;//�ő��N���A�^�C���̏������(�b)

    public static float GetHighClearTime(int stageID)//�ő��N���A�^�C���̎擾
    {
        string str_stageID = stageID.ToString();
        return PlayerPrefs.GetFloat(_saveDataName_HighClearTime + str_stageID, _defaultHighClearTime);
    }

    public static void SaveHighClearTime(int stageID,float clearTime)//�ő��N���A�^�C���̃Z�[�u
    {
        string str_stageID = stageID.ToString();
        PlayerPrefs.SetFloat(_saveDataName_HighClearTime + str_stageID, clearTime);
        PlayerPrefs.Save();
    }
}
