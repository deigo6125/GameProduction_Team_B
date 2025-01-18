using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

//�쐬��:���R
//���Ԃ��Ƃɔ�������l(0�`1�̊Ԃœ���)
//�����ɐݒ肳�ꂽ���Ԃ��Ƃ�0->1->0�ƂȂ��Ă���
[System.Serializable]
public class RepetitiveValue_Sin
{
    [Header("����")]
    [SerializeField] float _cycle;//����
    [Range(_timeResetMin,_timeResetMax)]
    [Header("���Z�b�g���̎�������")]
    [Tooltip("0�܂���1�ɐݒ肷��ƒl��0����̃X�^�[�g�A0.5�ɐݒ肷��Βl��1����̃X�^�[�g")]
    [SerializeField] float _timeReset;//���Z�b�g���̎��ԁA0�܂���1�ɐݒ肷��ƒl��0����̃X�^�[�g�A0.5�ɐݒ肷��Βl��1����̃X�^�[�g
    float _time;//���݂̎���
    const float _correctedValue=3*Mathf.PI/2;//�␳�l�A�l�ɂ���𑫂����Ƃ�0.5->1->0->0.5�ɂȂ�̂�h���A0->1->0�ɂ��邱�Ƃ��o����
    const float _timeResetMin = 0f;
    const float _timeResetMax = 1f;

    public float Value//�l�̎擾
    {
        get { return MathfExtend.Sin01((2 * Mathf.PI * _time / _cycle) + _correctedValue); }
    }

    public float Cycle//�����̎擾�A�ύX
    {
        get { return _cycle; }
        set { _cycle = value; }
    }

    public float TimeReset//���Z�b�g���̒l�̎擾�A�ύX
    {
        get { return _timeReset; }
        set { _timeReset =Mathf.Clamp(value,_timeResetMin,_timeResetMax); }//�ύX����0�`1�̒l����́A0�܂���1�ɐݒ肷��ƒl��0����̃X�^�[�g�A0.5�ɐݒ肷��Βl��1����̃X�^�[�g
    }

    //�f�t�H���g�R���X�g���N�^
    public RepetitiveValue_Sin()
    {
        _time = 0;
        _cycle = 0f;
        _timeReset = 0f;
    }
    //�R���X�g���N�^
    public RepetitiveValue_Sin(float time,float cycle,float timeReset)
    {
        _time = time;
        _cycle = cycle;
        _timeReset = Mathf.Clamp(timeReset, _timeResetMin, _timeResetMax);
    }

    public void ResetCycle()//������������������
    {
        _time = _timeReset*_cycle;
    }

    public void UpdateValue()//�l�̍X�V
    {
        _time += Time.deltaTime;
    }
}
