using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���J�n�O�̏����i�K�ŌĂԃC�x���g��o�^
public class StartReadyEvent : MonoBehaviour
{
    [SerializeField] StartSignalEvent _startSignalEvent;
    [SerializeField] DelayDisplayTextSoundComp _readyEffect;//Ready�H�̕����ƌ��ʉ����o��
    [SerializeField] GameObject _readyText;

    void Start()
    {
        _startSignalEvent.CompleteFadeInAction += CompleteFadeInEvent;
    }

    public void CompleteFadeInEvent()//�t�F�[�h�C�����I��������ɌĂԃC�x���g
    {
        _readyEffect.DisplayTrigger();
        _readyText.SetActive(true);
    }
}
