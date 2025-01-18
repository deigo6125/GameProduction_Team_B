using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�s�����Ɍ��ʉ����o��
public class PlayAudio_Action : MonoBehaviour
{
    [Header("���ʉ��̐ݒ�")]
    [SerializeField] Audios_PlayAudio_Action[] _audios;//���ʉ��̐ݒ�
    float _currentDelayTime;//���݂̒x������

    public void OnEnter()//�s���J�n���ɌĂ�(����������)
    {
        _currentDelayTime = 0;//���݂̒x�����Ԃ����Z�b�g

        for (int i = 0; i < _audios.Length; i++)
        {
            _audios[i].Played = false;//�S�ẴG�t�F�N�g�̐ݒ���G�t�F�N�g���o���ĂȂ���Ԃɂ���
        }
    }

    public void OnUpdate()//�s�������t���[���Ă�(�X�V����)
    {
        _currentDelayTime += Time.deltaTime;

        for (int i = 0; i < _audios.Length; i++)//�S�ẴG�t�F�N�g�̐ݒ肩�獡�G�t�F�N�g�𐶐����邩���f
        {
            Audios_PlayAudio_Action audio = _audios[i];

            if (_currentDelayTime >= audio.DelayTime && !audio.Played)
            {
                PlayAudio(audio);
            }
        }
    }

    void PlayAudio(Audios_PlayAudio_Action audio)//���ʉ����o��
    {
        audio.Played = true;
        audio.Play();
    }
}
