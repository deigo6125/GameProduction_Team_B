using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//�쐬��:���R
//�g���b�N���Ƃ̌���

public class TrickPatternEffect : MonoBehaviour
{
    [Header("�{�^���̎��")]
    [SerializeField] TrickButton button;//�{�^���̎��
    [Header("����g���b�N��")]
    [SerializeField] int trickCost;
    [Header("�g���b�N���̌���(�C�x���g)")]
    [SerializeField] UnityEvent trickEffectEvent;
    
    public TrickButton Button { get { return button; } }
    public int TrickCost { get {  return trickCost; } }
    
    public virtual void TrickEffect()//�g���b�N�̌���
    {
        trickEffectEvent.Invoke();
    }

}
