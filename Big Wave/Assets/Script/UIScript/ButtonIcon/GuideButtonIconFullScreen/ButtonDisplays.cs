using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�{�^���\���ݒ�
public partial class GuideButtonIconFullScreen
{
    [System.Serializable]
    struct ButtonDisplays
    {
        [Header("�\���������{�^���̗v�f�ԍ�")]
        [Tooltip("���ݎw�肳��Ă���{�^����\���������Ȃ�0�A��ԖڂɎw�肳��Ă���{�^���Ȃ�1...")]
        [SerializeField] public int buttonNum;//�\���������{�^���̗v�f�ԍ�
        [Header("�\�������{�^��")]
        [SerializeField] public ButtonIconDisplay criticalButtonDisplay;//�\�������{�^��
    }
}
