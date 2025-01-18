using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���w�n�̃��\�b�h���g����������
public static class MathfExtend 
{
    const float cosWidth = 2f;//cos�̕�(-1�`1)
    const float sinWidth = 2f;//sin�̕�(-1�`1)

    public static float Cos01(float f)//cos�̒l��0�`1�ŕԂ��悤�ɂ���(������0 or 2�΂̎���1�A��/2 or 3��/2�̎���0.5�A�΂̎���0)
    {
        const float gap = 0.5f;//�ڕW�̒l��cos�̕��Ŋ�����cos�̒l�̍�(cos�̕��Ŋ��������Acos��-0.5�`0.5�̒l���Ƃ�̂ł����ڕW�l��0�`1�ɂ��邽�߂̒l)

        float ret = Mathf.Cos(f) / cosWidth + gap;

        return ret;
    }

    public static float Sin01(float f)//sin�̒l��0�`1�ŕԂ��悤�ɂ���(������0 or �� or 2�΂̎���0.5�A��/2�̎���1�A 3��/2�̎���0)
    {
        const float gap = 0.5f;//�ڕW�̒l��cos�̕��Ŋ�����cos�̒l�̍�(cos�̕��Ŋ��������Acos��-0.5�`0.5�̒l���Ƃ�̂ł����ڕW�l��0�`1�ɂ��邽�߂̒l)

        float ret= Mathf.Sin(f) / sinWidth + gap;

        return ret;
    }
}
