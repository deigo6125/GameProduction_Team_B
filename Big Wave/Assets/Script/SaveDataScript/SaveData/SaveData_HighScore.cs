using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�X�e�[�W���Ƃ̃n�C�X�R�A�֌W�̃Z�[�u�f�[�^
public static partial class SaveData
{
    //�X�e�[�W���Ƃ̃n�C�X�R�A�֌W
    const string _saveDataName_HighScore = "HIGHSCORE_STAGE";//�n�C�X�R�A�̃Z�[�u�f�[�^��
    const float _defaultHighScore = 0;//�n�C�X�R�A�̏������

    public static float GetHighScore(int stageID)//�n�C�X�R�A�̎擾
    {
        string str_stageID = stageID.ToString();
        return PlayerPrefs.GetFloat(_saveDataName_HighScore + str_stageID, _defaultHighScore);
    }

    public static void SaveHighScore(int stageID, float saveScore)//�n�C�X�R�A�̃Z�[�u
    {
        string str_stageID = stageID.ToString();
        PlayerPrefs.SetFloat(_saveDataName_HighScore + str_stageID, saveScore);
        PlayerPrefs.Save();
    }
}
