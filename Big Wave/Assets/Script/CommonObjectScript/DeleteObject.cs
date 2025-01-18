using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//�쐬��:��
//�I�u�W�F�N�g���w�萔�b��ɔj��
public class DeleteObject : MonoBehaviour
{
    [SerializeField] float deleteTime = 4f;
    [SerializeField] UnityEvent deleteEvents;
    private float currentDeleteTime = 0;

    void Update()
    {
        UpdateDeleteTime();
    }

    void UpdateDeleteTime()
    {
        currentDeleteTime += Time.deltaTime;

        if(currentDeleteTime>=deleteTime)
        {
            deleteEvents.Invoke();
            Destroy(gameObject);
        }
    }
}
