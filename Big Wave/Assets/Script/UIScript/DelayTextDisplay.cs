using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DelayTextDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [SerializeField] float _delay;
    [SerializeField] AudioSource _audio;
    [SerializeField] AudioClip _clip;
    private string _delayText;
    // Start is called before the first frame update
    void Start()
    {
        _delayText = _text.text;
        _text.text = "";
        StartCoroutine(DelayDisplay());
    }

   IEnumerator DelayDisplay()
    {

        bool isInsideTag = false; // �^�O�������X�L�b�v���邽�߂̃t���O
        string currentText = "";

        foreach (char c in _delayText)
        {

            if (c == '<') // �^�O�̊J�n
            {
                isInsideTag = true;
                currentText += c; // �^�O���ꏏ�ɒ~��
            }
            else if (c == '>') // �^�O�̏I��
            {
                isInsideTag = false;
                currentText += c; // �^�O������������
            }
            else if (isInsideTag)
            {
                currentText += c; // �^�O���̕��������̂܂ܒ~��
            }
            else
            {
                currentText += c; // �ʏ�̕�����ǉ�
                _text.text = currentText; // �\�����X�V

                yield return new WaitForSeconds(_delay);
                if (c != ' ' && c != '!')
                {
                    if (_audio != null)
                    {
                        _audio.PlayOneShot(_clip);
                    }

                }

            }
        }
    }
   
}
