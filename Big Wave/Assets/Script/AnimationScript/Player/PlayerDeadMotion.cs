using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadMotion : MonoBehaviour
{
    [SerializeField] Animator _player_animator;
    [SerializeField] string _deadTriggerName;
    [SerializeField] WaterSplashEffect_Player _waterSplashEffect_Player;//�v���C���[�̐����Ԃ�
    [Header("�\����Ԃ�؂�ւ���I�u�W�F�N�g")]
    [SerializeField] ChangeActiveOfObject _changeObjects;
    bool _startMotion = false;

    public void Trigger()
    {
        _player_animator.SetTrigger(_deadTriggerName);
        _waterSplashEffect_Player.enabled = false;
        _startMotion = true;
    }

    void Update()
    {
        UpdateChangeActive();
    }

    void UpdateChangeActive()
    {
        if (!_startMotion) return;

        _changeObjects.UpdateActive();
    }
}
