using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class InstantiateRope : MonoBehaviour
//{
//    //���K���N��������
//    HP enemy_Hp;
//    HP player_Hp;

//    [SerializeField] GameObject ropePrefab;//���[�v�̃v���n�u
//    private GameObject ropeInstance;

//    // Start is called before the first frame update
//    void Start()
//    {
//        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
//        player_Hp = GameObject.FindWithTag("Player").GetComponent<HP>();

//        ropeInstance = Instantiate(ropePrefab);//���[�v����
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (enemy_Hp.Hp <= 0 || player_Hp.Hp <= 0)//�G���v���C���[��hp��0�ȉ��ɂȂ�����
//        {
//            Destroy(ropeInstance);//���[�v����
//        }
//    }
//}
