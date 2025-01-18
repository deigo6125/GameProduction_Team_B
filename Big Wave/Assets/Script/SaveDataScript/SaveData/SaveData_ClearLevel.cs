using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�N���A���x���֌W�̃Z�[�u�f�[�^
public static partial class SaveData
{
    //�N���A���x���֌W
    const string _saveDataName_ClearLevel = "CLEARLEVEL";//�N���A���x���̃Z�[�u�f�[�^��
    const int _defaultClearLevel = 0;//�N���A���x���̏������

    public static int GetClearLevel()//�N���A���x���̎擾
    {
        return PlayerPrefs.GetInt(_saveDataName_ClearLevel, _defaultClearLevel);
    }

    public static void SaveClearLevel(int saveLevel)//�N���A���x���̃Z�[�u
    {
        PlayerPrefs.SetInt(_saveDataName_ClearLevel, saveLevel);
        PlayerPrefs.Save();
    }
}
