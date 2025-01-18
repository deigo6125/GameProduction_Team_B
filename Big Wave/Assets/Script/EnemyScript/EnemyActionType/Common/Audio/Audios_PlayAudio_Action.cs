using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�s�����Ɍ��ʉ����o���R���|�l���g�̉��̐ݒ荀��
[System.Serializable]
public class Audios_PlayAudio_Action
{
    [Header("�x������")]
    [SerializeField] float _delayTime;//�x������
    [Header("���ʉ�")]
    [SerializeField] AudioClip _se;//���ʉ�
    [Header("AudioSource")]
    [SerializeField] AudioSource _audioSource;//AudioSource
    bool _played;//�����o������

    public float DelayTime { get { return _delayTime; } }//�x������

    public void Play()//���ʉ����o��
    {
        _audioSource.PlayOneShot(_se);
    }

    public bool Played//�����o������
    {
        get { return _played; }
        set { _played = value; }
    }
}
