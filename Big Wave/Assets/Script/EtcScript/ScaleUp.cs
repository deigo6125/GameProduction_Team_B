using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//���X�ɃI�u�W�F�N�g��傫������X�N���v�g�Bdelay��������ƒx�����C�ɃX�s�[�h���グ�Ĕ��˂����悤�ɂȂ�B
public class ScaleUp : MonoBehaviour
{

    [SerializeField] float scaleSpeed; 
    [SerializeField] float delayScale;
    float countTime;

    
    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if(countTime > delayScale)
        {
            
            transform.localScale +=new Vector3(scaleSpeed*Time.deltaTime,scaleSpeed*Time.deltaTime,scaleSpeed*Time.deltaTime);
        }
    }
}
