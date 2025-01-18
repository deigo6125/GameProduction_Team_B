using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//�쐬��:���R
//�G�̍s���̒��ۃN���X
public abstract class EnemyActionTypeBase : MonoBehaviour
{
    /// <summary>
    /// �s���J�n���ɌĂԏ���
    /// beforeActionType�͑O�̍s���p�^�[���ł����s��
    /// </summary>
    public virtual void OnEnter(EnemyActionTypeBase[] beforeActionType) { }

    /// <summary>
    /// �s�������t���[���Ăԏ���
    /// </summary>
    public virtual void OnUpdate() { }

    /// <summary>
    /// �s���I�����ɌĂԏ���
    /// beforeActionType�͎��̍s���p�^�[���ł���s��
    /// </summary>
    public virtual void OnExit(EnemyActionTypeBase[] nextActionType) { }
}