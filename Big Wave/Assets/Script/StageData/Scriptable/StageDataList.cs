using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�X�e�[�W�f�[�^�̃��X�g
[CreateAssetMenu(menuName = "ScriptableObjects/StageData/StageDataList")]
public class StageDataList : ScriptableObject
{
    [Header("�X�e�[�W���Ƃ̃f�[�^")]
    [Header("�v�f�ԍ��ƃX�e�[�W��ID�͍��킹�Ă����Ă�������(ID�̈�Ӑ���ۂ���)")]
    [SerializeField] StageData[] _stageDatas;//�X�e�[�W���Ƃ̃f�[�^

    public StageData GetStageData(int dataID)//�w��ID�̃X�e�[�W�f�[�^�܂邲�Ǝ擾
    {
        //�͈͊O�̎w��ID�����m�F
        if(!CheckError(dataID)) return null;

        //���ɕs����������΃f�[�^��n��
        return _stageDatas[dataID];
    }

    public int GetLevel(int dataID)//�w��ID�̃X�e�[�W�̃��x���̂ݎ擾(�͈͊O��ID��������Ă��ꍇ-1��Ԃ�)
    {
        //�͈͊O�̎w��ID�����m�F
        if (!CheckError(dataID)) return -1;

        //���ɕs����������΃f�[�^��n��
        return _stageDatas[dataID].Level;
    }

    public string GetStageSceneName(int dataID)//�w��ID�̃X�e�[�W�̃V�[�����̂ݎ擾(�͈͊O��ID��������Ă��ꍇnull��Ԃ�)
    {
        //�͈͊O�̎w��ID�����m�F
        if (!CheckError(dataID)) return null;

        //���ɕs����������΃f�[�^��n��
        return _stageDatas[dataID].StageSceneName;
    }

    public bool ExistStageData(int dataID)//�w�肳�ꂽID�̃X�e�[�W�f�[�^�͑��݂��邩
    {
        return 0 <= dataID && dataID < _stageDatas.Length;
    }

    bool CheckError(int dataID)//�G���[�R�[�h(�͈͊O��ID�ɑ΂��Čx������)
    {
        //�w�肳�ꂽID�̃X�e�[�W�f�[�^�͑��݂��邩���m�F
        //�����ꍇ�͂��̃f�[�^���Ȃ��|��`����
        if (!ExistStageData(dataID)) 
        {
            Debug.Log(dataID+"�Ƃ���ID�̃f�[�^�̓��X�g�ɂ���܂���");
            return false;
        }

        //�v�f�ԍ���ID�������ĂȂ������ꍇ�f�o�b�O���O�Ƀ��X�g�ɕs��������|��`����
        if (dataID != _stageDatas[dataID].StageID)
        {
            Debug.Log("�v�f�ԍ���ID�����v���܂���I���X�g�ɕs��������܂��I");
            return false;
        }

        return true;
    }
}
