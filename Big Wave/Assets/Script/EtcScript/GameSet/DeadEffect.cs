using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
//�쐬��:���R
//�v���C���[�����񂾂Ƃ��̉��o(�V�[���J�ڂ��܂߂�)
public class DeadEffect : MonoBehaviour
{
    [Header("�g���b�N�̃`���[�W")]
    [SerializeField] ChargeTrickPoint _chargeTrickPoint;
    [Header("�v���C���[��HP")]
    [SerializeField] HP _player_HP;
    [Header("�v���C���[�̎��S���[�V����")]
    [SerializeField] PlayerDeadMotion _playerDeadMotion;
    [Header("�`���[�W�̃G�t�F�N�g")]
    [SerializeField] ChargeTrickEffect_WhileCharge _chargeTrickEffect;
    [Header("����ύX")]
    [SerializeField] PlayerInput _playerInput;
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
    [Header("�炷���ʉ�")]
    [SerializeField]AudioClip _audioClip;
    [Header("�I�[�f�B�I�\�[�X")]
    [SerializeField] AudioSource _source;
    [Header("����ł��牽�b��ɃV�[���J�ڂ��邩")]
    [SerializeField] float _changeSceneTime;//���b��ɃV�[���J�ڂ��邩
    [SerializeField] JudgeGameSet _judgeGameSet;
    float _currentChangeSceneTime = 0;
    bool _startEffect = false;//���o�̊J�n��
    const string _actionMapName = "Defeat";//�v���C���[���S���ɂ��̃A�N�V�����}�b�v�ɕύX����

    public void Trigger()//���o�J�n
    {
        _startEffect = true;
        _player_HP.Fix = true;//�v���C���[��HP���Œ�
        _duringGame_UI.SetActive(false);//�Q�[����UI�̔�\��
        _playerInput.SwitchCurrentActionMap(_actionMapName);//����̕ύX
        _chargeTrickPoint.Switch = false;//�`���[�W���Ȃ��悤�ɂ���
        //���S���̃J�����̈ړ����J�n(�����\��)
        _playerDeadMotion.Trigger();//�v���C���[�̎��S���[�V�����̍Đ�
        _timeLimit.enabled = false;//�������Ԃ��~�߂�
        _algorithmOfEnemy.enabled = false;//�G�̍s�����~�߂�
        _ropeEffect.enabled = false;//�������
        _chargeTrickEffect.Switch = false;//�`���[�W�̃G�t�F�N�g�͏o���Ȃ��悤�ɂ���
        _source.PlayOneShot(_audioClip);
    }

    void Start()
    {
        _judgeGameSet.DeadAction += Trigger;
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
