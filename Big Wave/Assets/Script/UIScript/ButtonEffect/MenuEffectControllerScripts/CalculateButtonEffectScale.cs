using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

public class CalculateButtonEffectScale
{
    public float CalculateScaledWidth(RectTransform rectTransform)//�G�t�F�N�g�̉����̒����p
    {
        float width = rectTransform.rect.width;
        float scaleX = rectTransform.localScale.x;
        return width * scaleX;
    }

    public float CalculateScaledHeight(RectTransform rectTransform)//�G�t�F�N�g�̏c���̒����p
    {
        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;
        float scaleY = rectTransform.localScale.y;
        float aspectHeight = height < width ? width / height : height / width;

        return height * aspectHeight * scaleY;
    }
}
