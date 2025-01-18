using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

//�쐬��:���R
//�ȒP�Ƀ��j���[�E�T�u���j���[�������悤�ɂ���
//�g����
//���j���[�E�T�u���j���[���J������OpenNewMenu���Ă�(�����ɂ͊J�����j���[���̕���{�^��������
//����{�^���������Ƃ���CloseMenu_ButtonOnScreen���Ăяo���悤�ɂ���
//�R���g���[���̃{�^�����炷�������悤�ɂ���ɂ͔C�ӂ�Action(InputSystem��)��CloseMenu_InputAction������
public class CloseMenuEasily : MonoBehaviour
{
    Stack<Button> _quitButton=new Stack<Button>();

    public void OpenNewMenu(Button quitButton)//�V�����J�������j���[�̕���{�^����o�^����Anull������΃{�^���������Ȃ��ƕ���Ȃ��悤�ɂ��邱�Ƃ��o����
    {
        _quitButton.Push(quitButton);
    }
    
    public void CloseMenu_InputAction(InputAction.CallbackContext context)//����(B�{�^���Ȃ�)�̎��ɌĂ�
    {
        if (!context.performed) return;
        if (_quitButton.Count == 0) return;//���������ĂȂ��Ȃ疳��
        if (_quitButton.Peek() == null) return;//null�������Ă��ꍇ������

        //����{�^���̃N���b�N������Ă�
        Button quitButton = _quitButton.Peek();
        quitButton.onClick.Invoke();
    }

    public void CloseMenu_ButtonOnScreen()//��ʏ�̃{�^���������Ƃ��ɌĂ�
    {
        if (_quitButton.Count == 0) return;//���������ĂȂ��Ȃ疳��

        //����{�^�������o��
        Button quitButton = _quitButton.Pop();
    }
}
