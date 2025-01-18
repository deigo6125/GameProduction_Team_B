using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�s�����ɃG�t�F�N�g���o��
public class GenerateEffect_Action : MonoBehaviour
{
    [Header("�G�t�F�N�g�̐ݒ�")]
    [SerializeField] Effects_GenerateEffect_Action[] _effects;//�G�t�F�N�g�̐ݒ�
    float _currentDelayTime;//���݂̒x������

    public void OnEnter()//�s���J�n���ɌĂ�(����������)
    {
        _currentDelayTime = 0;//���݂̒x�����Ԃ����Z�b�g

        for(int i=0; i<_effects.Length;i++)
        {
            _effects[i].Effected = false;//�S�ẴG�t�F�N�g�̐ݒ���G�t�F�N�g���o���ĂȂ���Ԃɂ���
        }
    }

    public void OnUpdate()//�s�������t���[���Ă�(�X�V����)
    {
        _currentDelayTime += Time.deltaTime;

        for(int i=0; i<_effects.Length;i++)//�S�ẴG�t�F�N�g�̐ݒ肩�獡�G�t�F�N�g�𐶐����邩���f
        {
            Effects_GenerateEffect_Action effect = _effects[i];

            if(_currentDelayTime >= effect.DelayTime && !effect.Effected)
            {
                GenerateEffect(effect);
            }
        }
    }

    void GenerateEffect(Effects_GenerateEffect_Action effect)
    {
        effect.Effected = true;

        //�G�t�F�N�g�𐶐�����ʒu�Ɗp�x���擾
        Vector3 effectPos = effect.EffectPos.transform.position;//�ʒu
        Quaternion effectRot = effect.EffectPos.transform.rotation;//�p�x

        Instantiate(effect.Effect, effectPos, effectRot, effect.EffectPos);//�G�t�F�N�g�̐���
    }

}
