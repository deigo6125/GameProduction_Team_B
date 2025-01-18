using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class LimitVector
{
    [Header("�ړ��������邩")]
    [SerializeField] bool limit=false;//�ړ��������邩
    [Header("�ړ��\�͈�")]
    [SerializeField] float range;//�ړ��\�͈�

    public float Limit(float position)
    {
        if (!limit) return position;

        //�ړ������̏���(���Ȃ��Ȃ炱��̑O�̕��ŏ����͏I���)
        position = Mathf.Clamp(position, -range, range);
        return position;
    }
}

[System.Serializable]
class LimitMoveObject
{
    [Header("�ړ��\�̃p�����[�^")]
    [SerializeField] LimitVector x;//x��
    [SerializeField] LimitVector y;//y��
    [SerializeField] LimitVector z;//z��
    [Header("�ړ�����������I�u�W�F�N�g")]
    [SerializeField] GameObject limitObjects;

    //�����̐���
    //�ړ��\�͈͊O�ɏo�Ȃ��悤�ɂ���
    public void Limit()
    {
        Vector3 currentPos = limitObjects.transform.localPosition;
        currentPos.x = x.Limit(currentPos.x);//x���̐���
        currentPos.y = y.Limit(currentPos.y);//y���̐���
        currentPos.z = z.Limit(currentPos.z);//z���̐���
        limitObjects.transform.localPosition = currentPos;
    }
}

public class LimitMove : MonoBehaviour
{
    [Header("�ړ��������������I�u�W�F�N�g�Ɛ����͈�")]
    [SerializeField] LimitMoveObject[] limitMoveObjects;//�ړ��������������I�u�W�F�N�g�Ɛ����͈�
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i< limitMoveObjects.Length;i++)
        {
            limitMoveObjects[i].Limit();
        }
    }
}
