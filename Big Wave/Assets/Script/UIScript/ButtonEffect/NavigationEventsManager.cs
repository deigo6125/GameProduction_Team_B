using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//�쐬�ҁF�K��
//�{�^���I����ɕʂ̃{�^����I���ł��Ȃ��悤�ɂ��邽�߂ɂ�����g��
public class NavigationEventsManager : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;

    private void Start()
    {
        ChangeNavigationEvent(true);
    }

    //�ʂ̃{�^����I���ł���悤�ɂ��邩
    public void ChangeNavigationEvent(bool active)
    {
        if(eventSystem!=null)
        {
            eventSystem.sendNavigationEvents=active;
        }
    }
}
