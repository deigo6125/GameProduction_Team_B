using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:�K��(��ɐ��R������)
//�Ō�ɐ������ꂽ�����̑傫��(BoxCollider����擾)�ƈʒu���Q�Ƃ��Č����𐶐�����
public class InstantiateBuildings : MonoBehaviour
{
    [Header("����������������(BoxColider�����Ă�����̌���)")]
    [SerializeField] RandomGet<GameObject> randomGetGameObject = new RandomGet<GameObject>();//�o�^�����I�u�W�F�N�g�������_���Ɏ擾����
    [Header("���O�ɐ������ꂽ����(BoxColider�����Ă�����̌���)")]
    [SerializeField] GameObject lastBuilding;//�Ō�ɐ������ꂽ����
    private GameObject newBuilding;//�V�����������錚��
    private Vector3 lastPosition;//�Ō�ɐ������ꂽ�ʒu
    private float minimumNecessaryDistanceToGenerate;//��������̂ɍŒ���K�v�ȋ���

    void Start()
    {
        DecideMinimumNecessaryDistanceToGenerate();//��������̂ɍŒ���K�v�ȋ��������߂�
        lastPosition = lastBuilding.transform.position;//�Ō�ɐ������ꂽ�ʒu���L�^
    }

    void Update()
    {
        InstantiateBuildingsPrefab();//�����̐���
    }

    void InstantiateBuildingsPrefab()//�����̐���
    {
        //���݂̈ʒu�ƍŌ�ɐ������ꂽ�ʒu�Ƃ̋����𑪂�
        Vector3 currentPos = transform.position;
        float distance = Vector3.Distance(currentPos, lastPosition);

        //�����Ɛ�������̂ɍŒ���K�v�ȋ������r���ď\���ɋ���������Ă���Ό����𐶐�
        if (distance > minimumNecessaryDistanceToGenerate)
        {
            lastBuilding = GenerateNewBuilding((currentPos - lastPosition).normalized);//�����̐�������

            lastPosition = lastBuilding.transform.position;

            DecideMinimumNecessaryDistanceToGenerate();//��������̂ɍŒ���K�v�ȋ��������߂�
        }
    }

    //�����̐��������Adirection�͑O�񐶐������ʒu���猻�݂̈ʒu�ւ̕����x�N�g��
    //�Ō�ɐ������ꂽ������Ԃ�(BoxCollider�^��)
    GameObject GenerateNewBuilding(Vector3 direction)
    {
        //�i�s�����ɉ����ĐV���������𐶐�����ʒu���v�Z
        Vector3 newPosition = lastPosition + direction * minimumNecessaryDistanceToGenerate;
        //����
        GameObject newBuildingObject = Instantiate(newBuilding.gameObject, newPosition, transform.rotation);
        //�p�x�𒲐��H(���������Ƃ��ƃ}�W�b�N�i���o�[���g���Ă��ĈӐ}���悭������Ȃ�����by��)
        newBuildingObject.transform.Rotate(0, Random.Range(0, 4) * 90, 0);

        return newBuildingObject;
    }

    //��������̂ɍŒ���K�v�ȋ��������߂�
    void DecideMinimumNecessaryDistanceToGenerate()
    {
        newBuilding = randomGetGameObject.Get();//���ɐ������錚�������߂�

        //�Ō�ɐ������ꂽ�����̑傫���𑪂�
        BoxCollider lastBuildingCollider = lastBuilding.GetComponent<BoxCollider>();
        if (lastBuildingCollider == null) Debug.Log("BoxCollider�����Ă��܂���I");

        Vector3 lastBuildingSize = lastBuildingCollider.size;

        //���ɐ������錚���̑傫���𑪂�
        BoxCollider newBuildingCollider=newBuilding.GetComponent<BoxCollider>();
        if (newBuildingCollider == null) Debug.Log("BoxCollider�����Ă��܂���I");

        Vector3 newBuildingSize = newBuildingCollider.size;

        //�����������������߂�(�Ō�̌����̑傫��/2+���ɐ������錚���̑傫��/2)
        //���̎��傫���͏c(z)�Ɖ�(x)�ő傫����������(����(y)�͑���Ȃ�)
        float last_d2 = Mathf.Max(lastBuildingSize.x, lastBuildingSize.z) / 2;//�Ō�̌����̑傫��/2
        float new_d2 = Mathf.Max(newBuildingSize.x, newBuildingSize.z) / 2;//���ɐ������錚���̑傫��/2
        minimumNecessaryDistanceToGenerate = last_d2 + new_d2;
    }
}
