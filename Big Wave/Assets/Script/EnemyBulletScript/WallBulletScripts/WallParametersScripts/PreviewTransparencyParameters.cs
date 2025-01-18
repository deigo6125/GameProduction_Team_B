using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PreviewTransparencyParameters
{
    [Header("�����x���ω�����T�C�N���̎���")]
    [SerializeField] float transparencyCycleDuration = 0.5f;

    public float TransparencyCycleDuration { get { return transparencyCycleDuration; } }
}