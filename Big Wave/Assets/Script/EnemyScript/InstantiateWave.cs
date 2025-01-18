using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�g�̐���
public class InstantiateWave : MonoBehaviour
{
    [Header("�g�̐����ʒu")]
    [SerializeField] GameObject instantiateWavePos;//�g�̐����ʒu
    [Header("�g�̃v���n�u")]
    [SerializeField] LineWave wavePrefab;//�g�̃v���n�u
    [Header("�g�̏o���Ԋu")]
    [SerializeField] float waveInterval;//�����ȍ~�̔g�̏o���Ԋu
    [Header("GamePos")]
    [SerializeField] GameObject gamePos;//GamePos
    [Header("LineInstantiate")]
    [SerializeField] LineInstantiate m_lineInstantiate;
    private float m_waveTime=0;//�g�̏o���Ԋu���Ǘ����鎞��(�������l)

    void Update()
    {
        InstantiateWavePrefab();//�g�̐���
    }

    //�g�̐����AwaveIntervalTime�̎��Ԃ��Ƃɔg�𐶐�����
    void InstantiateWavePrefab()
    {
        m_waveTime += Time.deltaTime;//�g�̏o���Ԋu���Ǘ����鎞�Ԃ��X�V
        
        if (m_waveTime > waveInterval)
        {
            m_waveTime = 0f;//�g�̏o���Ԋu���Ǘ����鎞�Ԃ����Z�b�g
            LineWave lineWave = Instantiate(wavePrefab, instantiateWavePos.transform.position, transform.rotation, gamePos.transform);//�g�𐶐�
            lineWave.transform.localRotation = Quaternion.Euler(0, 180, 0);//�g��������(�v���C���[����)�ɂ���
            m_lineInstantiate.Add(lineWave.transform);
            lineWave.GetLineInstantiate(m_lineInstantiate);
        }
    }
}
