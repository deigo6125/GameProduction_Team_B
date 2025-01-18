using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�ɓ����������ɒe������
public class DestroyBullet : MonoBehaviour
{
    [Header("�v���C���[�ɓ����������ɒe��������")]
    [SerializeField] bool ifHitDestroy = true;//�v���C���[�ɓ����������ɒe��������
    [Header("�󂷃I�u�W�F�N�g")]
    [SerializeField] GameObject destroyObject;

    public void Destroy()
    {
        //�v���C���[��������Βe������
        if (ifHitDestroy && destroyObject != null)
        {
            Destroy(destroyObject);
        }
    }
}
