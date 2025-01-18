using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
//�쐬��:���R
//�^�C���A�b�v���̉��o(�V�[���J�ڂ��܂߂�)
public class TimeUpEffect : MonoBehaviour
{
    [Header("�g���b�N�̃`���[�W")]
    [SerializeField] ChargeTrickPoint _chargeTrickPoint;
    [Header("�v���C���[��HP")]
    [SerializeField] HP _player_HP;
    [Header("����ύX")]
    [SerializeField] PlayerInput _playerInput;
    [Header("��������")]
    [SerializeField] TimeLimit _timeLimit;
    [Header("�G�̍s��")]
    [SerializeField] AlgorithmOfEnemy _algorithmOfEnemy;
    [Header("�Q�[������UI")]
    [SerializeField] GameObject _duringGame_UI;
    [Header("�V�[���ڍs�R���|�[�l���g")]
    [SerializeField] SceneController _controller;
    [Header("�\����Ԃ�؂�ւ���I�u�W�F�N�g")]
    [SerializeField] ChangeActiveOfObject _changeObjects;
    [Header("�^�C���A�b�v���Ă��牽�b��ɃV�[���J�ڂ��邩")]
    [SerializeField] float _changeSceneTime;//���b��ɃV�[���J�ڂ��邩
    [SerializeField] JudgeGameSet _judgeGameSet;
    float _currentChangeSceneTime = 0;
    bool _startEffect = false;//���o�̊J�n��
    const string _actionMapName = "Defeat";//�^�C���A�b�v���ɂ��̃A�N�V�����}�b�v�ɕύX����

    public void Trigger()//���o�J�n
    {
        _startEffect = true;
        _player_HP.Fix = true;//�v���C���[��HP���Œ�
        _duringGame_UI.SetActive(false);//�Q�[����UI�̔�\��
        _chargeTrickPoint.Switch = false;//�`���[�W���Ȃ��悤�ɂ���
        _playerInput.SwitchCurrentActionMap(_actionMapName);//����̕ύX
        _timeLimit.enabled = false;//�������Ԃ��~�߂�
        _algorithmOfEnemy.enabled = false;//�G�̍s�����~�߂�
    }

    void Start()
    {
        _judgeGameSet.TimeUpAction += Trigger;
    }

    void Update()
    {
        UpdateChangeScene();
        UpdateChangeActive();
    }

    void UpdateChangeScene()//�V�[���ڍs�̏���
    {
        if (!_startEffect) return;

        _currentChangeSceneTime += Time.deltaTime;

        if (_currentChangeSceneTime >= _changeSceneTime)
        {
            _controller.GameOverScene();//�N���A�V�[���Ɉڍs����
        }
    }

    void UpdateChangeActive()//�I�u�W�F�N�g�̃A�N�e�B�u��Ԃ�ύX���鎞�Ԃ̍X�V
    {
        if (!_startEffect) return;

        _changeObjects.UpdateActive();
    }
}
