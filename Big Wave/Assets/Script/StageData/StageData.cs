using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//
[System.Serializable]
public class StageData
{
    [Header("�X�e�[�WID(��ӂɂ��Ă�������)")]
    [SerializeField] int _stageID;//�X�e�[�W��ID
    [Header("���x��")]
    [SerializeField] int _level;//�X�e�[�W�̃��x��
    [Header("�X�e�[�W�V�[����")]
    [SerializeField] string _stageSceneName;//�X�e�[�W�V�[����

    public int StageID { get { return _stageID; } }//�X�e�[�W��ID
    public int Level { get { return _level; } }//�X�e�[�W�̃��x��
    public string StageSceneName { get { return _stageSceneName; } }//�X�e�[�W�V�[����

    public StageData() { }//�f�t�H���g�R���X�g���N�^

    public StageData(int stageID,int level,string stageSceneName)//�R���X�g���N�^
    {
        _stageID = stageID;
        _level = level;
        _stageSceneName = stageSceneName;
    }
}
