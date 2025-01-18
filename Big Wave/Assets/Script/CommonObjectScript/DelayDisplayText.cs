using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//�쐬��:���R
//�x�����ĕ�����\������
[System.Serializable]
public class DelayDisplayText
{
    [Header("�\�����镶��")]
    [SerializeField] TMP_Text _text;
    [Header("�x������")]
    [SerializeField] float _delayTime;
    [Header("�\������")]
    [SerializeField] float _displayTime;
    float _currentDelayTime = 0;
    float _currentDisplayTime = 0;
    bool _displayed = false;
    bool _hided = false;

    public void Update()
    {
        UpdateDisplayTiming();
        UpdateHideTiming();
    }

    void UpdateDisplayTiming()//�\������^�C�~���O�̍X�V
    {
        if (_displayed) return;

        _currentDelayTime += Time.deltaTime;

        if(_currentDelayTime>=_delayTime)
        {
            _displayed = true;
            if (_text != null) _text.enabled = true;
        }
    }

    void UpdateHideTiming()//�\�����Ă��當�����B���^�C�~���O�̍X�V
    {
        if (_hided||!_displayed) return;

        _currentDisplayTime += Time.deltaTime;

        if(_currentDisplayTime>=_displayTime)
        {
            _hided = true;
            if (_text != null) _text.enabled = false;
        }
    }
}
