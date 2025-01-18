using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

//�쐬��:���R
//�t�B�[�o�[��Ԃ̌���
public class FeverMode : MonoBehaviour
{
    [Header("�t�B�[�o�[��Ԃ̌��ʎ���")]
    [SerializeField] float feverTime=20f;//�t�B�[�o�[��Ԃ̌��ʎ���
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] FeverPoint player_FeverPoint;
    public event Action TransitToFeverAction;//�t�B�[�o�[��ԑJ�ڎ��ɌĂԃC�x���g
    public event Action CancelFeverAction;//�t�B�[�o�[��ԉ������ɌĂԃC�x���g
    private bool feverNow=false;//���t�B�[�o�[��Ԃ�
    private float remainingFeverTime = 0f;//�t�B�[�o�[��Ԃ̎c����ʎ���

    public bool FeverNow
    {
        get { return feverNow; }
    }

    void Start()
    {
       
        remainingFeverTime = 0f;
        feverNow = false;
    }

   

    void Update()
    {
        ChangeFeverMode();//�t�B�[�o�[��ԂɈڍs

        UpdateFeverTime();//�t�B�[�o�[��Ԃ̎c�莞�Ԃ��Ǘ�

        FeverModeEffect();//�t�B�[�o�[��Ԃ̌��ʂ̏���
    }

    //�܂��t�B�[�o�[��ԂɂȂ��Ă��Ȃ����t�B�[�o�[�|�C���g�����^���ɂȂ�����t�B�[�o�[��ԂɈڍs
    void ChangeFeverMode()
    {
        if (feverNow == false && player_FeverPoint.FeverPoint_ >= player_FeverPoint.FeverPointMax)
        {
            feverNow = true;
            remainingFeverTime = feverTime;
            TransitToFeverAction?.Invoke();
        }
    }

    //�t�B�[�o�[��Ԃ̎c�莞�Ԃ��X�V
    void UpdateFeverTime()
    {
        if (!feverNow) return;

        remainingFeverTime -= Time.deltaTime;

        if(remainingFeverTime<=0f)//�t�B�[�o�[��Ԃ̎c�莞�Ԃ�0�ɂȂ�����t�B�[�o�[��Ԃ�����
        {
            CancelFeverAction?.Invoke();
            remainingFeverTime=0f;
            feverNow = false;
        }
    }

    //�t�B�[�o�[��Ԃ̌��ʂ̏���
    void FeverModeEffect()
    {
        //�t�B�[�o�[��Ԓ���...
        //�G�t�F�N�g���t��
        //�t�B�[�o�[�|�C���g�����Ԃ��ƂɌ����Ă���(�t�B�[�o�[��Ԃ̎c�莞�Ԃ�\���Ă���)
        if (feverNow)
        {
            float ratio = remainingFeverTime / feverTime;
            player_FeverPoint.FeverPoint_ = player_FeverPoint.FeverPointMax * ratio;
        }
    }
}
