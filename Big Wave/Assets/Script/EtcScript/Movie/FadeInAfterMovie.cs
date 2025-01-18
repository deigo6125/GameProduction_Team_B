using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Video;

public class FadeInAfterMovie : MonoBehaviour
{
    [Header("����Đ���A�N�e�B�u�ɂ���(�Đ����͔�A�N�e�B�u)�I�u�W�F�N�g")]
    [SerializeField] GameObject[] _activeAfterMovieEndObjects;//����Đ���A�N�e�B�u�ɂ���(�Đ����͔�A�N�e�B�u)�I�u�W�F�N�g
    [Header("����Đ����ɂ̂݃A�N�e�B�u�ɂ���I�u�W�F�N�g")]
    [SerializeField] GameObject[] _activeDuringMovieObjects;//����Đ����ɂ̂݃A�N�e�B�u�ɂ���I�u�W�F�N�g
    [Header("����Đ����ɂ̂݃A�N�e�B�u�����A�X�L�b�v���ꂽ�u�Ԕ�A�N�e�B�u�ɂȂ�I�u�W�F�N�g")]
    [SerializeField] GameObject[] _activeDuringMovie_SkippedDeactiveObjects;
    [SerializeField] FadeIn_RawImage _fadeIn;
    [SerializeField] VideoPlayer videoPlayer;
    [Header("���֌W")]
    [Header("�ǂ��炩����ɂ���΍Đ��I�����ɉ�����Ȃ��悤�ɂȂ�")]
    [SerializeField] AudioClip _se;
    [SerializeField] AudioSource _audioSource;
    [Header("����֌W")]
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] string _actionMapNameAfterMovie;
    [Header("�X�L�b�v���ɓ���I���̉��b�O�܂Ŕ�΂���")]
    [Header("0�ɂ��Ă��܂��Ɠ��悪�Ō�܂ōĐ�����Ȃ����Ƃ�����܂�")]
    [SerializeField] double _skipTimeBeforeEnd;

    double SkipTime { get { return videoPlayer.length - _skipTimeBeforeEnd; } }//�X�L�b�v�łǂ̎��Ԃ܂Ŕ�΂���

    bool Skipable { get { return videoPlayer.time < SkipTime; } }//�X�L�b�v�\��(���݂̍Đ��ӏ����X�L�b�v����ӏ��̑O�ł���΃X�L�b�v�\)

    public void Skip()
    {
        if (!Skipable) return;//���[�r�[�o���Ȃ��Ȃ疳��

        //�Đ����A�N�e�B�u(�X�L�b�v���ꂽ�u�Ԕ�A�N�e�B�u)�ɂ���I�u�W�F�N�g���B��
        SwitchActiveObject(_activeDuringMovie_SkippedDeactiveObjects, false);

        //������X�L�b�v������
        videoPlayer.time = SkipTime;
    }

    private void Awake()
    {
        videoPlayer.Stop();
        videoPlayer.frame = 0;
        videoPlayer.loopPointReached += MovieEndEvent;
    }
    void Start()
    {
        Trigger();
    }

    void Trigger()//���[�r�[�J�n�̃g���K�[
    {
        //�Đ���A�N�e�B�u�ɂ���I�u�W�F�N�g����U�B��
        SwitchActiveObject(_activeAfterMovieEndObjects, false);

        //�Đ����A�N�e�B�u�ɂ���I�u�W�F�N�g��\��
        SwitchActiveObject(_activeDuringMovieObjects, true);

        //�Đ����A�N�e�B�u(�X�L�b�v���ꂽ�u�Ԕ�A�N�e�B�u)�ɂ���I�u�W�F�N�g��\��
        SwitchActiveObject(_activeDuringMovie_SkippedDeactiveObjects, true);
        
        //���[�r�[�𗬂��n�߂�
        videoPlayer.Play();
    }

    void MovieEndEvent(VideoPlayer vb)//���[�r�[������I��������ɋN�����C�x���g
    {
        //�Đ���A�N�e�B�u�ɂ���I�u�W�F�N�g��\��
        SwitchActiveObject(_activeAfterMovieEndObjects, true);

        //�Đ����A�N�e�B�u�ɂ���I�u�W�F�N�g���B��
        SwitchActiveObject(_activeDuringMovieObjects, false);

        //�Đ����A�N�e�B�u(�X�L�b�v���ꂽ�u�Ԕ�A�N�e�B�u)�ɂ���I�u�W�F�N�g���B��
        SwitchActiveObject(_activeDuringMovie_SkippedDeactiveObjects, false);

        //�t�F�[�h�C���J�n
        _fadeIn.StartTrigger();

        //��������[�r�[�̂��̂���UI�ɂ���
        _playerInput.SwitchCurrentActionMap(_actionMapNameAfterMovie);

        //�����o��
        if(_audioSource!=null&&_se!=null)
        {
            _audioSource.PlayOneShot(_se);
        }
    }

    void SwitchActiveObject(GameObject[] gameObjects,bool active)
    {
        for(int i=0; i<gameObjects.Length ;i++)
        {
            gameObjects[i].SetActive(active);
        }
    }
}
