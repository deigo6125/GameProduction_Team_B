using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�e������(���ۃN���X)
public abstract class ShotTypeBase : MonoBehaviour
{
    public abstract void InitShotTiming();//���^�C�~���O�̏�����

    public abstract void UpdateShotTiming();//���^�C�~���O�̍X�V
}
