using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�F��_�ł�����
[System.Serializable]
public class BlinkColor 
{
    [Header("�_�Ŏ���")]
    [SerializeField] float cycle;//�_�Ŏ���
    [Header("�ł��_�ł��Ă��鎞�̍ʓx�̒l")]
    [Range(0f, 100f)]
    [SerializeField] float s_maxValue;//�ł��_�ł��Ă��鎞�̍ʓx�̒l
    private float _time = 0;

    public BlinkColor()//�R���X�g���N�^
    {
        _time = 0;
    }

    public Color Blinking(Color color)//�_�ł�����(�_�Ŏ��̐F��Ԃ�)
    {
        _time += Time.deltaTime;

        float h;//�F��
        float s;//�ʓx
        float v;//���x

        //���̐F����hsv���擾
        UnityEngine.Color.RGBToHSV(color,out h,out s,out v);

        //s(�ʓx)��ύX
        float ratio = MathfExtend.Cos01(2*Mathf.PI*_time/cycle);
        
        s = ratio * (s-s_maxValue)+s_maxValue;

        //���̐F�ɓK�p
        color = UnityEngine.Color.HSVToRGB(h, s, v);

        return color;
    }

}
