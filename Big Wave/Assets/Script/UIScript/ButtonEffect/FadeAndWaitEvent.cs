using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//�쐬��:���R
//�t�F�[�h�A�E�g�����Đ��b�҂�����C�x���g���N����
public class FadeAndWaitEvent : MonoBehaviour
{
    [Header("�t�F�[�h�A�E�g")]
    [Header("�t�F�[�h�A�E�g���Ȃ��ꍇ�͋�̂܂܂ɂ��Ă�������")]
    [SerializeField] FadeOut _fadeOut;//�t�F�[�h�A�E�g
    [Header("���b�҂��Ă���C�x���g���N������")]
    [Header("�t�F�[�h�A�E�g����ꍇ�̓t�F�[�h�A�E�g���������Ă��炱�̎��ԕ��҂��܂�")]
    [SerializeField] float _waitTime;//�x������
    [Header("�C�x���g")]
    [SerializeField] UnityEvent _event;//�N���������C�x���g
    [Header("�A�ł��Ă��C�x���g���N�����܂ł͔������Ȃ��悤�ɂ��邩")]
    [SerializeField] bool _preventMash;//�A�ł��Ă��C�x���g���N�����܂ł͔������Ȃ��悤�ɂ��邩
    bool _switch = false;

    public void Trigger()
    {
        if (_preventMash && _switch) return;

        _switch = true;

        if (_fadeOut!=null)//�t�F�[�h�A�E�g����ꍇ
        {
            _fadeOut.StartTrigger();
        }
        else//���Ȃ��ꍇ
        {
            StartCoroutine(DelayEventCoroutine());
        }
    }

    void Update()
    {
        CheckFade();
    }

    void CheckFade()
    {
        if (_fadeOut == null) return;

        //�t�F�[�h�A�E�g��������x�����ăC�x���g���N����
        if(_fadeOut.FadeState==State_Fade.completed&&_switch)
        {
            StartCoroutine(DelayEventCoroutine());
            _fadeOut.ReturnDefault();
        }
    }

    IEnumerator DelayEventCoroutine()
    {
        yield return new WaitForSecondsRealtime(_waitTime);
        //���ԕ��҂�����ɃC�x���g���N����

        _switch = false;
        _event.Invoke();
      
    }
}
