using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�쐬��:���R
//�n�C�X�R�A���Z�[�u����
public class SaveHighScore : MonoBehaviour
{
    [Header("�X�R�A���v")]
    [SerializeField] Score_Total _score_Total_;
    [Header("�X�e�[�W�f�[�^")]
    [SerializeField] CurrentStageData _currentStageData;
    public event Action<bool> Action_HighScore;//�n�C�X�R�A�X�V�̔����ɌĂԏ����A�n�C�X�R�A�X�V�ł���΁Atrue������
    bool _updated = false;//�n�C�X�R�A���X�V������

    public bool Updated { get { return  _updated; } }

    void Start()
    {
        UpdateHighScore();//�n�C�X�R�A�̍X�V����
    }

    void UpdateHighScore()//�n�C�X�R�A�̍X�V����
    {
        //�V�񂾃X�e�[�W�̃n�C�X�R�A���Z�[�u�f�[�^������o��
        float pastHighScore=SaveData.GetHighScore(_currentStageData.StageID);

        //����̃X�R�A�Ɣ�r
        //��������̃X�R�A�̕���������΃n�C�X�R�A�X�V
        if(_score_Total_.Score>pastHighScore)
        {
            _updated = true;
            SaveData.SaveHighScore(_currentStageData.StageID, _score_Total_.Score);
            Debug.Log("�n�C�X�R�A�X�V�I���݂̃n�C�X�R�A��"+ SaveData.GetHighScore(_currentStageData.StageID) + "�ł��I");
        }

        Action_HighScore?.Invoke(_updated);
    }
}
