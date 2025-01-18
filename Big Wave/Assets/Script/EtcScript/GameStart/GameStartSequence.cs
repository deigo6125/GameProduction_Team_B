using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//�쐬��:���R
//�Q�[���̃X�^�[�g�̏���
public class GameStartSequence : MonoBehaviour
{
    [Header("�Q�[������UI")]
    [SerializeField] GameObject _duringGameUI;
    [SerializeField] MovieCameraEvent _startMovieEvent;
    [SerializeField] StartSignalEvent _startSignalEvent;
    [SerializeField] JudgeGameStart _judgeGameStart;
    State_GameStartSequence _state;//�Q�[���̊J�n�����̏��

    public bool FinishedStartMovie { get { return _state > State_GameStartSequence.movie; } }//�X�^�[�g���̃��[�r�[���I����Ă��邩

    void Start()
    {
        _startMovieEvent.Trigger();//�ŏ��Ƀ��[�r�[�𗬂�
        if(_duringGameUI!=null) _duringGameUI.SetActive(false);//�Q�[������UI���B��
        _state = State_GameStartSequence.movie;
    }

    void Update()
    {
       UpdateSequebce();
    }

    void UpdateSequebce()
    {
        if (_state == State_GameStartSequence.start) return;//���ɃX�^�[�g���Ă���Ȃ�ȉ��̍X�V���������Ȃ�

        switch(_state)
        {
            case State_GameStartSequence.movie:

                if(_startMovieEvent.State==State_Movie.completed)//���[�r�[�𗬂��I�������X�^�[�g�̍��}���o��
                {
                    _startSignalEvent.Trigger();
                    if (_duringGameUI != null) _duringGameUI.SetActive(true);//�Q�[������UI��\����Ԃɂ���
                    _state = State_GameStartSequence.signal;
                }

                break;

            case State_GameStartSequence.signal:

                if(_startSignalEvent.State==State_GameStartSignal.completed)//�X�^�[�g�̍��}���o���I�������Q�[���X�^�[�g
                {
                    _judgeGameStart.GameStartTrigger();
                    _state = State_GameStartSequence.start;
                }

                break;
        }
    }

    
}
