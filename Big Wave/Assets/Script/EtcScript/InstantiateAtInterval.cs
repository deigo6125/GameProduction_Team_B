using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAtInterval : MonoBehaviour
{
    //���쐬��:�K��
    [Header("�������������I�u�W�F�N�g�����Ă�������")]
    [SerializeField] RandomGet<GameObject> randomGetGameObject = new RandomGet<GameObject>();//�o�^�����I�u�W�F�N�g�������_���Ɏ擾����
    [SerializeField] float instantiateIntervalTime = 1.5f;//�����o���Ԋu
    private float instantiateCurrentTime = 0f;//�o���Ԋu���Ǘ����鎞��
    // Start is called before the first frame update
    void Start()
    {
        instantiateCurrentTime = instantiateIntervalTime;
    }

    // Update is called once per frame
    void Update()
    {
        InstantiatePrefab();//����
    }

    void InstantiatePrefab()
    {
        instantiateCurrentTime += Time.deltaTime;//�o�ߎ��Ԃ̌v��

        if (instantiateCurrentTime > instantiateIntervalTime)//�o�ߎ��Ԃ����̎��Ԃ𒴂�����
        {
            instantiateCurrentTime = 0f;//�o�ߎ��Ԃ����Z�b�g
            Instantiate(randomGetGameObject.Get(), transform.position, transform.rotation); //����
        }
    }
}
