using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

[System.Serializable]
public class InertialRotateParameter : MonoBehaviour
{
    [Header("����]�Ɋւ���ݒ�")]
    [Header("��]�̋���")]
    [SerializeField] float rotationStrength = 10f;
    [Header("�ő��]�p�x")]
    [SerializeField] float maxRotationAngle = 45f;
    [Header("��]�����Ƃɖ߂�����")]
    [SerializeField] float rotationReturnSpeed = 10f;

    public float RotationStrength { get { return rotationStrength; } }
    public float MaxRotationAngle { get { return maxRotationAngle; } }
    public float RotationReturnSpeed { get {  return rotationReturnSpeed; } }
}