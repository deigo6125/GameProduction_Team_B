using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�s�����ɃG�t�F�N�g���o���R���|�l���g�̃G�t�F�N�g�̐ݒ荀��
[System.Serializable]
public class Effects_GenerateEffect_Action
{
    [Header("�x������")]
    [SerializeField] float _delayTime;//�x������
    [Header("�G�t�F�N�g")]
    [SerializeField] GameObject _effect;//�G�t�F�N�g
    [Header("�G�t�F�N�g�����ʒu")]
    [SerializeField] Transform _effectPos;//�G�t�F�N�g�����ʒu
    bool _effected;//�G�t�F�N�g���o������

    public float DelayTime { get { return _delayTime; } }//�x������
    public GameObject Effect { get { return _effect; } }//�G�t�F�N�g
    public Transform EffectPos { get { return _effectPos; } }//�G�t�F�N�g�����ʒu
    public bool Effected//�G�t�F�N�g���o������
    {
        get { return _effected; }
        set { _effected = value; }
    }
}
