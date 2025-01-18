using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//�쐬��:���R
//�t�B�[�o�[���[�h�̃G�t�F�N�g
public class FeverModeEffect : MonoBehaviour
{
    [Header("�t�B�[�o�[���[�h�J�ڎ��̌��ʉ�")]
    [SerializeField] AudioClip _feverSE;
    [SerializeField] AudioSource _audioSource;
    [Header("�t�B�[�o�[���[�h�̃G�t�F�N�g")]
    [SerializeField] ParticleSystem _feverEffect;
    [Header("�t�B�[�o�[��Ԓ������ƕ\������G�t�F�N�g")]
    [SerializeField] GameObject[] _feverNowEffect;//�t�B�[�o�[��Ԓ������ƕ\������G�t�F�N�g
    [Header("�t�B�[�o�[���[�h�̃R���|�[�l���g")]
    [SerializeField] FeverMode _feverMode;
    
    void Start()
    {
        _feverMode.TransitToFeverAction += Trigger;

        //�t�B�[�o�[��Ԓ������ƕ\������G�t�F�N�g�͏����͔�\���ɂ���
        for (int i = 0; i < _feverNowEffect.Length; i++)
        {
            _feverNowEffect[i].SetActive(false);
        }
    }

    void Update()
    {
        ChangeActiveEffect();
    }

    void ChangeActiveEffect()//�t�B�[�o�[��Ԓ��̓G�t�F�N�g��\���A�����łȂ��ꍇ�͔�\���ɂ���
    {
        for (int i = 0; i < _feverNowEffect.Length; i++)
        {
            _feverNowEffect[i].SetActive(_feverMode.FeverNow);
        }
    }

    public void Trigger()
    {
        _audioSource.PlayOneShot(_feverSE);//���ʉ���炷
        //�G�t�F�N�g���o��
        _feverEffect.gameObject.SetActive(true);
        _feverEffect.Play();
       
    }
}
