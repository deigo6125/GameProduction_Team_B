using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�`���[�W��HP���񕜂�����
public class RecoverHPWhileCharging : MonoBehaviour
{
    [Header("1�b���Ƃ̗͉̑񕜗�")]
    [SerializeField] float recoveryAmount;
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] HP hp_Player;
    [SerializeField] JudgeChargeTrickPointNow judgeChargeTrickPointNow;
    bool healing=false;//�񕜒���

    public bool Healing { get { return healing; } }

    void Update()
    {
        RecoverHP();
    }

    void RecoverHP()
    {
        healing = judgeChargeTrickPointNow.ChargeNow();//�񕜂������

        if(healing)
        {
            hp_Player.Hp += recoveryAmount * Time.deltaTime;
        }
    }
}
