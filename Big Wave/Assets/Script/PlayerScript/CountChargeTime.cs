using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�g���b�N�|�C���g�̃`���[�W���Ԃ��v������
public class CountChargeTime : MonoBehaviour
{
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] JudgeChargeTrickPointNow judge;
    private float m_chargeTime = 0;

    public float ChargeTime { get { return m_chargeTime; }  }

    // Update is called once per frame
    void Update()
    {
        Count();
    }

    void Count()
    {
        if(judge.ChargeNow())//�`���[�W���Ԃ��v��
        {
            m_chargeTime += Time.deltaTime;
        }
    }
}
