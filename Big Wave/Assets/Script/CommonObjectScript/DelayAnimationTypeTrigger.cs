using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�A�j���[�V������x�点�čĐ�������
[System.Serializable]
public class DelayAnimationTypeTrigger
{
    [Header("���b��ɍĐ����邩")]
    [SerializeField] float _delayTime;//(���������Ă���)���b��ɍĐ����邩
    [Header("�A�j���[�V�����R���g���[��")]
    [Header("�A�j���[�V�������Đ����������Ȃ����͂�������ɂ��Ă�������")]
    [SerializeField] Animator _anim;//�����������I�u�W�F�N�g�̃A�j���[�V�����R���g���[��
    [Header("�g���K�[��")]
    [SerializeField] string _triggerName;//�g���K�[��
    float _currentTime;//���݂̎���
    const float _defaultTime = 0;//���������̎���
    bool _played;//�Đ�������
   
    public void Start()//����������
    {
        _played = false;
        _currentTime = _defaultTime;
    }

    
    public void Update()//���t���[���s������
    {
        UpdateDelay();
    }

    void UpdateDelay()
    {
        if (_played) return;

        _currentTime +=Time.deltaTime;

        //�܂��Đ����ĂȂ������ԂɂȂ�����A�j���[�V�������Đ��A
        if(_currentTime>=_delayTime&&!_played)
        {
            _played=true;
            if(_anim!=null) _anim.SetTrigger(_triggerName);
        }
    }
}
