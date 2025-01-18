using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���ʐݒ�̃Z�[�u�f�[�^(�}�X�^�[��BGM��SE)
public static partial class SaveData
{
    //���ʊ֌W
    const string _saveDataName_Audio = "AUDIOVOLUME";//���ʂ̃Z�[�u�f�[�^��

    public static float GetAudioVolume(AudioType audioType, float noSaveVal)//���ʂ̎擾
    {
        string audioVolumeType = audioType.ToString();
        return PlayerPrefs.GetFloat(_saveDataName_Audio + audioVolumeType, noSaveVal);
    }

    public static void SaveAudioVolume(AudioType audioType, float saveVolume)//���ʂ̃Z�[�u
    {
        string audioVolumeType = audioType.ToString();
        PlayerPrefs.SetFloat(_saveDataName_Audio + audioVolumeType, saveVolume);
        PlayerPrefs.Save();
    }
}
