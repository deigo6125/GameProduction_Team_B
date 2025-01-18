using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

//�쐬��:���R�A�K�����ꕔ�C��
//�������̃v���C���[�̃��[�V����
public class PlayerWinMotion : MonoBehaviour
{
    [SerializeField] Animator _player_animator;
    [SerializeField] string _deadTriggerName;
    [Header("���b��ɏ������[�V�������Đ����邩")]
    [SerializeField] float _startMotionTime;
    [SerializeField] AudioClip _clearSound;
    [SerializeField] AudioSource _audio;
    float _currentStartMotionTime = 0;
    bool _startMotion = false;

    public void Trigger()
    {
        _startMotion = true;
    }

    void Update()
    {
        UpdatePlayAnimation();
    }

    void UpdatePlayAnimation()
    {
        if (!_startMotion) return;

        _currentStartMotionTime += Time.deltaTime;

        if (_currentStartMotionTime > _startMotionTime )
        {
            _audio.PlayOneShot(_clearSound);
            _player_animator.SetTrigger(_deadTriggerName);
            _startMotion = false;
        }
    }
}
