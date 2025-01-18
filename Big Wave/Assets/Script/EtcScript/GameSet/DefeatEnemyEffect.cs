using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

//�쐬��:���R
//�G��|�����Ƃ��̉��o(�V�[���J�ڂ��܂߂�)
public class DefeatEnemyEffect : MonoBehaviour
{
    [Header("�N���A���̃J����")]
    [SerializeField] CinemachineBlendListCamera _clearCamera;
    [Header("�g���b�N�̃`���[�W")]
    [SerializeField] ChargeTrickPoint _chargeTrickPoint;
    [Header("�v���C���[��HP")]
    [SerializeField] HP _player_HP;
    [Header("����ύX")]
    [SerializeField] PlayerInput _playerInput;
    [Header("�G�̎��S���[�V����")]
    [SerializeField] EnemyDeadMotion _enemyDeadMotion;
    [Header("�v���C���[�̎��S���[�V����")]
    [SerializeField] PlayerWinMotion _playerWinMotion;
    [Header("�����̔g�̐���")]
    [SerializeField] InstantiateWave inWave;
    [Header("�O���̔g�̐���")]
    [SerializeField] InstantiateWave outWave;
    [Header("���[�v")]
    [SerializeField] RopeEffect _ropeEffect;
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
    [Header("�G��|���Ă��牽�b��ɃV�[���J�ڂ��邩")]
    [SerializeField] float _changeSceneTime;//���b��ɃV�[���J�ڂ��邩
    [SerializeField] JudgeGameSet _judgeGameSet;
    float _currentChangeSceneTime=0;
    bool _startEffect=false;//���o�̊J�n��
    const string _actionMapName = "Win";//�G��|�����Ƃ��ɂ��̃A�N�V�����}�b�v�ɕύX����

    public void Trigger()//���o�J�n
    {
        _startEffect = true;
        _player_HP.Fix = true;//�v���C���[��HP���Œ�
        _duringGame_UI.SetActive(false);//�Q�[����UI�̔�\��
        _playerInput.SwitchCurrentActionMap(_actionMapName);//����̕ύX
        _chargeTrickPoint.Switch = false;//�`���[�W���Ȃ��悤�ɂ���
        _clearCamera.enabled = true;//�N���A���̃J�����̈ړ����J�n(�����\��)
        _enemyDeadMotion.Trigger();//�G�̌��j���[�V�����̍Đ�
        _playerWinMotion.Trigger();//�v���C���[�̏������[�V�����̍Đ�
        _timeLimit.enabled = false;//�������Ԃ��~�߂�
        _algorithmOfEnemy.enabled = false;//�G�̍s�����~�߂�
        _ropeEffect.enabled = false;//�������
        //�g�̐������~�߂�
        inWave.enabled = false;
        outWave.enabled = false;
    }

    void Start()
    {
        _judgeGameSet.GameClearAction += Trigger;
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

        if(_currentChangeSceneTime>=_changeSceneTime)
        {
            _controller.ClearScene();//�N���A�V�[���Ɉڍs����
        }
    }

    void UpdateChangeActive()//�I�u�W�F�N�g�̃A�N�e�B�u��Ԃ�ύX���鎞�Ԃ̍X�V
    {
        if (!_startEffect) return;

        _changeObjects.UpdateActive();
    }
}
