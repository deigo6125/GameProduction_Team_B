using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

//�쐬��:���R
//���[�r�[�̃J�����̏���
public class MovieCameraEvent : MonoBehaviour
{
    [Header("BGM")]
    [SerializeField] AudioSource _bgm;
    [Header("���[�r�[����UI")]
    [SerializeField] GameObject _movieUI;
    [Header("����")]
    [SerializeField] PlayerInput _playerInput;
    [Header("���[�r�[�̃J����")]
    [Tooltip("�J�����̗D��x�̓Q�[�����̃J�������������ݒ肵�Ēu���Ă�������")]
    [SerializeField] CinemachineBlendListCamera _movieCamera;
    [Header("���[�r�[�̎���")]
    [Tooltip("���̎��ԕ��o������t�F�[�h�A�E�g���n�܂�܂�")]
    [SerializeField] float _movieTime;
    [Header("�t�F�[�h�C���̐ݒ�")]
    [SerializeField] FadeIn _fadeIn;
    [Header("�t�F�[�h�A�E�g�̐ݒ�")]
    [SerializeField] FadeOut _fadeOut;
    float _currentMovieTime;//���[�r�[�̌��݂̎���
    const string _actionMapName_Movie = "Movie";//���[�r�[�p�̑��얼
    string _actionMapName_Original;//���̑��얼
    const float _defaultCurrentMovieTime= 0;
    State_Movie _state = State_Movie.off;//���[�r�[�̍Đ��󋵁A������Ԃ̓��[�r�[�𓮂����Ă��Ȃ����

    public State_Movie State { get { return _state; } }

    public void Trigger()//���[�r�[�̊J�n
    {
        //���[�r�[�������Ă��Ȃ�(����)��ԂłȂ���Ζ���
        if (_state!=State_Movie.off) return;

        _currentMovieTime = _defaultCurrentMovieTime;
        _state = State_Movie.playing;//�Đ����Ă����Ԃɂ���
        _fadeIn.StartTrigger();//�t�F�[�h�C�����J�n
        if(_movieUI!=null) _movieUI.SetActive(true);//���[�r�[����UI��\��
        if (_bgm != null) _bgm.Play();//BGM���Đ��J�n
        //��������[�r�[�p�ɕύX(���̑��얼���o���Ă���)
        _actionMapName_Original = _playerInput.currentActionMap.name;
        _playerInput.SwitchCurrentActionMap(_actionMapName_Movie);
        _movieCamera.enabled = true;//�J���������[�r�[�p�̂��̂ɐ؂�ւ���
    }

    public void End()//���[�r�[�̏I����������(���[�r�[�X�L�b�v���ɂ�����Ă�)
    {
        //���[�r�[�Đ����łȂ���Ζ���
        if (_state != State_Movie.playing) return;

        if (_movieUI != null) _movieUI.SetActive(false);//���[�r�[����UI���\��
        _state = State_Movie.ending;//�I�����Ă����Ԃɂ���
        _fadeIn.CancelTrigger();//�t�F�[�h�C���𒆒f��
        _fadeIn.ReturnDefault();
        _fadeOut.StartTrigger();//�t�F�[�h�A�E�g���J�n(�t�F�[�h�A�E�g�����S�ɏI������烀�[�r�[�������Ă��Ȃ���Ԃɂ���)
    }

    void Update()
    {
       UpdateState();
    }

    void UpdateState()//���[�r�[�̍Đ��󋵂̍X�V
    {
        if (_state == State_Movie.off|| _state == State_Movie.completed) return;//���[�r�[�������Ă��Ȃ��܂��͊������͓��ɍX�V�͂��Ȃ�

        switch(_state)
        {
            case State_Movie.playing://�Đ���

                //���[�r�[�̎��Ԃ̍X�V(���ԂɂȂ�����I����Ԃɓ���)
                _currentMovieTime += Time.deltaTime;

                if(_currentMovieTime>=_movieTime)
                {
                    End();
                }

                break;


            case State_Movie.ending://�I����

                //�t�F�[�h�A�E�g���I������烀�[�r�[������ԂɑJ��
                if (_fadeOut.FadeState == State_Fade.completed)
                {
                    _fadeOut.ReturnDefault();
                    _movieCamera.enabled = false;//���[�r�[�̃J�������I�t�ɂ���
                    _playerInput.SwitchCurrentActionMap(_actionMapName_Original);//��������̑���ɕύX
                    if (_bgm != null) _bgm.Stop();//BGM���~�߂�
                    _state = State_Movie.completed;
                }

                break;
        }
    }
}
