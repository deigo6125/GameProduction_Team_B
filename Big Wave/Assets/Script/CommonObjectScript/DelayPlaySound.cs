using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�x�����ĉ����o��
[System.Serializable]
public class DelayPlaySound
{
    [Header("�x������")]
    [SerializeField] float _delayTime;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _sound;
    float _currentTime=0;
    bool _played = false;

    public void Update()
    {
       UpdatePlayTiming();
    }

    void UpdatePlayTiming()//�����o���^�C�~���O�̍X�V
    {
        if (_played) return;

        _currentTime += Time.deltaTime;

        if (_currentTime >= _delayTime)
        {
            if(_audioSource!=null&&_sound!=null) _audioSource.PlayOneShot(_sound);
            _played = true;
        }
    }
}
