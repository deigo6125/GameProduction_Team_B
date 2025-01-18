using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

//�쐬��:���R
//�Q�[���X�^�[�g�̔��f
public class JudgeGameStart : MonoBehaviour
{
    public event Action StartGameAction;//�Q�[���J�n���ɌĂԏ���
    private bool isStarted = false;//�Q�[�����J�n���ꂽ��(�J�E���g�_�E���͏I�������)

    public bool IsStarted { get { return isStarted; } }

    public void GameStartTrigger()//�Q�[���X�^�[�g���������ɂ�����ĂԁA��x�X�^�[�g�����炱����ēx�ĂԂ��Ƃ͏o���Ȃ�
    {
        if (isStarted) return;

        isStarted = true;
        StartGameAction?.Invoke();
    }
}
