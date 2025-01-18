using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�쐬��:���R
//�v���C���[�̃N���A���x��(�ǂ̃X�e�[�W�܂ŃN���A������)�ɉ����ă{�^���̑I��
public class ChangeInteractable_ClearLevel : MonoBehaviour
{
    [Header("�K�v�N���A���x��")]
    [SerializeField] int _requiredLevel;
    [Header("�Ώۂ̃{�^��")]
    [SerializeField] Button _targetButton;//�Ώۂ̃{�^��

    void Start()
    {
        ChangeInteractable();
    }

    void ChangeInteractable()
    {
        //�v���C���[�̃N���A���x�����擾
        int clearLevel=SaveData.GetClearLevel();

        //����\�����f
        bool challengable = clearLevel >= _requiredLevel;

        //����s�\�Ȃ�{�^���I�����ł��Ȃ��悤�ɂ���
        _targetButton.interactable = challengable;
    }
}
