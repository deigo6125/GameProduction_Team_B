using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

[System.Serializable]
public class InertialMoveParameter : MonoBehaviour
{
    [Header("���ړ��Ɋւ���ݒ�")]
    [Header("�����x")]
    [SerializeField] float acceleration = 60f;
    [Header("�����x")]
    [SerializeField] float deceleration = 30f;
    [Header("�ō����x")]
    [SerializeField] float targetSpeed = 100f;
    [Header("�ڕW�ʒu�Ɉ����񂹂��")]
    [SerializeField] float targetPullStrength = 10f;
    [Header("�����񂹂�͂̍ő�l")]
    [SerializeField] float maxPullStrength = 100f;
    [Header("�ړ��ɂ����銵�����Ȃ���x���W")]
    [SerializeField] float maxLocalPosition_X = 9f;

    public float Acceleration { get { return acceleration; } }
    public float Deceleration { get { return deceleration; } }
    public float TargetSpeed { get {  return targetSpeed; } }
    public float TargetPullStrength { get {  return targetPullStrength; } }
    public float MaxPullStrength { get { return maxPullStrength; } }
    public float MaxLocalPosition_X { get {  return maxLocalPosition_X; } }
}