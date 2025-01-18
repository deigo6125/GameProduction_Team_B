using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�ɐG���ꂽ��g���b�N�|�C���g���`���[�W������
public class Wave : MonoBehaviour
{
    private bool isTouched=false;//�v���C���[�ɐG���ꂽ��
    [Header("�g��肵�����ɗ��܂�g���b�N��")]
    [SerializeField] float chargeTrickAmount = 1;//�g��肵�����ɗ��܂�g���b�N��

    void OnTriggerEnter(Collider other)
    {
        if(!isTouched&&other.CompareTag("Player"))//�܂��G����ĂȂ������������̂��v���C���[�Ȃ�
        {
            ChargeTrickPoint chargeTrick = other.GetComponentInChildren<ChargeTrickPoint>();//�v���C���[�̃g���b�N�`���[�W�̃R���|�[�l���g���擾
            chargeTrick.Charge(chargeTrickAmount);//�g���b�N���`���[�W
            isTouched = true;//�G���ꂽ
        }
    }
}
