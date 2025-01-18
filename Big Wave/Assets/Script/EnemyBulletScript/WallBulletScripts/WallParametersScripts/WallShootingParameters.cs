using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WallShootingParameters
{
    [Header("����")]
    [SerializeField] protected float shotPower = 90f;
    [Header("�ǂ𐶐����Ă��猂�܂ł̒x������")]
    [Header("��:�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�")]
    [SerializeField] float delayTime = 2.0f;
    [Header("���������ǂ���x�ɂ��ׂĔ��˂��邩�ǂ���")]
    [SerializeField] bool isShotAllAtOnce = false;
    [Header("�ǂ��ꖇ�����˂���ꍇ�̊Ԋu")]
    [SerializeField] float intervalShotTime = 0.25f;

    public float ShotPower { get { return shotPower; } }
    public float DelayTime { get { return delayTime; } }
    public bool IsShotAllAtOnce { get { return isShotAllAtOnce; } }
    public float IntervalShotTime { get { return intervalShotTime; } }
}