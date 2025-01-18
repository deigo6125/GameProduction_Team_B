using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WallGenerationParameters
{
    [Header("��������ǂ̉��̕�����")]
    [SerializeField] int width = 3;
    [Header("��������ǂ̏c�̕�����")]
    [SerializeField] int height = 3;
    [Header("�ǂ̍ő吶������")]
    [SerializeField] int generateWallsNum = 6;
    [Header("���ꂼ��̕ǂ����������m��")]
    [SerializeField] float generationProbability = 1f;
    [Header("�ǈꖇ���Ƃ̏o���Ԋu")]
    [SerializeField] float intervalActiveTime = 0.2f;
    [Header("�����͈͂��Q�[����ʂɍ��킹�邩�ǂ���")]
    [SerializeField] bool matchCameraSize = true;

    public int Width { get { return width; } }
    public int Height { get { return height; } }
    public int GenerateWallsNum { get { return generateWallsNum; } }
    public float GenerationProbability { get { return generationProbability; } }
    public float IntervalActiveTime { get { return intervalActiveTime; } }
    public bool MatchCameraSize { get { return matchCameraSize; } }
}