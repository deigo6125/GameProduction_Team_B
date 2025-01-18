using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//�쐬��:���R
//�g���b�N�|�C���g�����^���ɂȂ������ɏo���G�t�F�N�g
public class ChargeTrickEffect_TrickPointFull : MonoBehaviour
{
    [Header("�g���b�N�|�C���g")]
    [SerializeField] TrickPoint _trickPoint;
    [Header("�S�Ẵg���b�N�Q�[�W�����^�����ɗ������ʉ�")]
    [SerializeField] AudioClip _fullSE;
    [SerializeField] AudioSource _audioSource;

    [Header("�S�Ẵg���b�N�Q�[�W�����^�����ɕ\��������e�L�X�g")]
    [SerializeField] TMP_Text _fulltext;
    [SerializeField]Transform _canvas;
    
    [Header("�e�Q�[�W�����^�����ɏo���G�t�F�N�g")]
    [Tooltip("Element0��1�ڂ̃g���b�N�Q�[�W�����^�����AElement1��2�ڂ̃g���b�N�Q�[�W�����^�����ɏo���G�t�F�N�g")]
    [SerializeField] ParticleSystem[] _chargeEffect;

    void Start()
    {
        _trickPoint.FullEvent += Trigger;
    }

    public void Trigger(int maxCount)
    {
        if(maxCount<=_chargeEffect.Length)
        {
            //�g���b�N�Q�[�W������^���ɂȂ邲�Ƃɂ���ɑΉ������G�t�F�N�g���o��
            ParticleSystem effect = _chargeEffect[maxCount - 1];
            effect.gameObject.SetActive(true);
            effect.Play();
        }

        //�S�Ẵg���b�N�Q�[�W�����^�����Ɍ��ʉ��𗬂�
        if(_trickPoint.TrickGaugeNum==maxCount)
        {
            _audioSource.PlayOneShot(_fullSE);
            Instantiate(_fulltext,_canvas.transform.position,_canvas.rotation,_canvas.transform);
        }
    }
}
