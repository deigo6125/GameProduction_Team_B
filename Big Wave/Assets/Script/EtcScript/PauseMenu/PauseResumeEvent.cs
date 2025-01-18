using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;

public class PauseResumeEvent : MonoBehaviour
{
    [Header("�|�[�Y�󋵂𔻒f����R���|�\�l���g")]
    [SerializeField] JudgePauseNow _judgePauseNow;
    [Header("�Q�[���̊J�n����������R���|�[�l���g")]
    [SerializeField] GameStartSequence _gameStartSequence;
    [Header("�|�[�Y���j���[���J�������̍ŏ��ɑI�������{�^��")]
    [SerializeField] Button _firstSelectbutton;
    [Header("�|�[�Y���j���[")]
    [SerializeField] GameObject _pauseMenu;
    [Header("�Q�[����UI")]
    [SerializeField] GameObject _duringGameUI;
    [Header("�ĊJ���̌��ʉ�")]
    [SerializeField] AudioClip _resumeSE;
    [Header("�|�[�Y���̌��ʉ�")]
    [SerializeField] AudioClip _pauseSE;
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] AudioSource _audioSource;
    [SerializeField] ControlTime _controlTime;
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] EventSystem _eventSystem;
    [SerializeField] CloseMenuEasily _closeMenuEasily;
    string _actionMapName_Original;//���̑��얼
    const string _actionMapName_Pause = "UI";//�|�[�Y�p�̑��얼

    void Start()
    {
        _judgePauseNow.SwitchPauseAction += Event;
    }

    void Event(bool pause)
    {
        if(pause)//�|�[�Y���̂�
        {
            _eventSystem.SetSelectedGameObject(_firstSelectbutton.gameObject);//�|�[�Y���j���[�̑I���{�^����ݒ�
            _closeMenuEasily.OpenNewMenu(_firstSelectbutton); //���j���[�����R���|�[�l���g�ɂ��̑I���{�^����ݒ�
        }

        //�Q�[����UI�̕\���E��\���؂�ւ�(�X�^�[�g�̃��[�r�[���I�����Ă��Ȃ�������\�����Ȃ�)
        _duringGameUI.SetActive(_gameStartSequence.FinishedStartMovie ? !pause : false);
        _pauseMenu.SetActive(pause);//�|�[�Y���j���[�̕\���E��\���؂�ւ�

        //����̕ύX(�|�[�Y��Ԃɐ؂�ւ���Ȃ�A���̑��얼���o���Ă����A�|�[�Y��ԉ������͌��̑���ɖ߂�)
        if(pause)
        {
            _actionMapName_Original = _playerInput.currentActionMap.name;
            _playerInput.SwitchCurrentActionMap(_actionMapName_Pause);
        }
        else
        {
            _playerInput.SwitchCurrentActionMap(_actionMapName_Original);
        }

        _controlTime.ChangeTimeScale(pause);//���Ԃ̃X�s�[�h�̕ύX
        _audioSource.PlayOneShot(pause ? _pauseSE : _resumeSE);//���ʉ��𗬂�
    }


}
