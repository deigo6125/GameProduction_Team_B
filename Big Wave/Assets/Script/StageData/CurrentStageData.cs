using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���݃v���C���Ă���X�e�[�W�f�[�^
public class CurrentStageData : MonoBehaviour
{
    [Header("�X�e�[�W�f�[�^���X�g")]
    [SerializeField] StageDataList _stageDataList;
    const string _stageID_Name = "STAGE_ID";//�X�e�[�WID��ۑ����Ă���f�[�^��

    public int StageID
    {
        get { return PlayerPrefs.GetInt(_stageID_Name); }
    }

    public int Level
    {
        get { return _stageDataList.GetLevel(StageID); }
    }

    public string StageSceneName
    {
        get { return _stageDataList.GetStageSceneName(StageID); }
    }

    public void Rewrite(int dataID)//���݃v���C���̃X�e�[�W�f�[�^��ID�̏�������
    {
        PlayerPrefs.SetInt(_stageID_Name,dataID);//�X�e�[�WID�̕ۑ�
        PlayerPrefs.Save();
    }
}
