using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlinkUI : MonoBehaviour
{
    private TMP_Text T_Color;
    [SerializeField] float cycle = 1f; // �_�ł̊Ԋu
    [SerializeField] JumpUI jump; // �O������ݒ肳���JumpUI�N���X

    private float time;

    private void Start()
    {
        // TMP_Text �R���|�[�l���g���擾
        T_Color = this.GetComponent<TMP_Text>();
        T_Color.enabled = true;
    }

    // ���t���[�����s
    void Update()
    {
        Blink_UI();
    }

    // �_�Ń��W�b�N
    void Blink_UI()
    {
        if (jump != null && jump.reached)
        {
            // �_�ł��~���A��ɕ\����Ԃɂ���
            T_Color.enabled = true;
            return;
        }

        // ���Ԃ����Z
        time += Time.deltaTime;

        // cycle���Ƃɓ_�ł�؂�ւ�
        if (time > cycle)
        {
            time = 0f; // ���Ԃ����Z�b�g
            T_Color.enabled = !T_Color.enabled; // �\��/��\����؂�ւ�
        }
    }
}
