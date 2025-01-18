using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���J�n���ɌĂԏ����������ňꊇ�œo�^����
public class GameStartEvent : MonoBehaviour
{
    [Header("�X�^�[�g���̕����ƌ��ʉ��̉��o")]
    [SerializeField] DelayDisplayTextSoundComp _startEffect;
    [Header("�Q�[���̊J�n�𔻒f����R���|�[�l���g")]
    [SerializeField] JudgeGameStart _judgeGameStart;
    [Header("�����̔g�̐���")]
    [SerializeField] InstantiateWave _inWave;
    [Header("�O���̔g�̐���")]
    [SerializeField] InstantiateWave _outWave;
    [Header("�G�̍s��")]
    [SerializeField] AlgorithmOfEnemy _algorithmOfEnemy;
    [Header("��������")]
    [SerializeField] TimeLimit _timeLimit;
    [Header("BGM")]
    [SerializeField] AudioSource _bgm;
    void Start()
    {
        _judgeGameStart.StartGameAction += Event;
    }

    public void Event()
    {
        //�X�^�[�g���̕����̕\���ƌ��ʉ��̍Đ�
        _startEffect.DisplayTrigger();
        //�g�𐶐����n�߂�
        _inWave.enabled = true;
        _outWave.enabled = true;
        //�G���s�����n�߂�
        _algorithmOfEnemy.enabled = true;
        //���Ԑ���������n�߂�
        _timeLimit.enabled = true;
        //BGM�𗬂��n�߂�
        _bgm.Play();
    }
}
