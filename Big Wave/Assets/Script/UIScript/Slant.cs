using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�摜���΂߂Ɍ��炵���肷��
public class Slant
{
    const float maxRatio = 1;//�����̍ő�l
    const float minRatio = 0;//�����̍ŏ��l

    public Slant()//�R���X�g���N�^
    {

    }

    public void MakeSlant(RectTransform gauge,float ratio)
    {
        ratio = Mathf.Clamp(ratio,0,1);

        float xPosition = Mathf.Lerp(0, -387, 1 - ratio);
        gauge.anchoredPosition = new Vector2(xPosition, gauge.anchoredPosition.y);
    }
}
