using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//��������LineInstantiate���擾���A���̃I�u�W�F�N�g�������鎞��LineInstantiate�����������
public class LineWave : MonoBehaviour
{
    private LineInstantiate m_lineInstantiate;

    //�������ɌĂяo��
    public void GetLineInstantiate(LineInstantiate lineInstantiate)
    {
        m_lineInstantiate = lineInstantiate;
    }

    //
    public void Remove()
    {
        m_lineInstantiate.Remove();
    }
}
