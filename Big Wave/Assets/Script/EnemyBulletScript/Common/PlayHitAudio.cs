using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�ɓ����������ɉ��𗬂�
[System.Serializable]
public class PlayHitAudio
{
    [Header("�����������̌��ʉ�")]
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;

    public void Play()//���ʉ��𗬂�
    {
        if (audioClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
