using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:����
//�o���A�̔j��G�t�F�N�g��u��������DeleteObject�ɓ���Ă����̂ł������Ɉړ����Ă����܂���by���R
public class DestroyBarrierEffect : MonoBehaviour
{
    [SerializeField] GameObject _destroyBarrierEffect;

    public void Generate()
    {
        if (_destroyBarrierEffect != null)
        {
            Instantiate(_destroyBarrierEffect, gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
        }
    }
}
