using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

//�쐬�ҁF�K��
//[System.Serializable]
//class Borderline
//{
//    [Header("��_���[�W�]����")]
//    [SerializeField] int borderCount = 0;//��_���]�����
//    [Header("���̕]�����̃X�R�A��")]
//    [SerializeField] int addScore = 100;//�]�����Ɋl���ł���X�R�A��

//    public int BorderCount
//    {
//        get { return borderCount; }
//        set { borderCount = value; }
//    }

//    public int AddScore
//    {
//        get { return addScore; }
//        set { addScore = value; }
//    }
//}

//public class ManagementOfScore : MonoBehaviour
//{
//    [Header("�`���Ԃ̃X�R�A�ݒ�`")]
//    [Header("�c�莞�Ԃ̃X�R�A�{���i�b���j")]
//    [SerializeField] float timeScore_ratio = 10;//�c�莞�ԕ]���{��

//    [Header("�`�g���b�N�Q�[�W�c�ʂ̃X�R�A�ݒ�`")]
//    [Header("�g���b�N�Q�[�W�c�ʂ̃X�R�A�{��")]
//    [SerializeField] float trickScore_ratio = 1;//�g���b�N�Q�[�W�c�ʂ̃X�R�A�{��

//    [Header("�`�g���b�N�̃X�R�A�ݒ�`")]
//    [Header("�g���b�N�������̃X�R�A��")]
//    [SerializeField] int trickScore = 10;//�g���b�N�������̃X�R�A

//    [Header("�`��_���]���̃X�R�A�ݒ�`")]
//    [Header("�_���[�W���󂯂��񐔂�")]
//    [Header("�eborderCount�̒l�i�񐔁j�𒴂���ƁA")]
//    [Header("�]�����P���̒i�K�ɉ�����܂��B")]

//    [Header("��_���[�W�]�����C���i�ō��j")]
//    [SerializeField] Borderline bestRank;

//    [Header("��_���[�W�]�����C���i���j")]
//    [SerializeField] Borderline goodRank;

//    [Header("��_���[�W�]�����C���i���ԁj")]
//    [SerializeField] Borderline normalRank;

//    [Header("��_���[�W�]�����C���i��j")]
//    [SerializeField] Borderline badRank;

//    [Header("�Œ�]�����̃X�R�A��")]
//    [SerializeField] int lowestRank_AddScore = 0;

//    private static int totalScore;//���v�X�R�A
//    private static int nowScore;//�Q�[���i�s���̃X�R�A
//    private static int damageCount;//�_���[�W���󂯂���
//    private int remainingTime;//�N���A���̎c�莞��(�b���j
//    //private float oldPlayerHp;//�_���[�W���󂯂�O�̃v���C���[��HP�B�_���[�W���󂯂���̔�r�p

//    //HP player_Hp;
//    TrickPoint player_TrickPoint;
//    //HP enemy_Hp;

//    public static int TotalScore
//    {
//        get { return totalScore; }
//        private set { totalScore = value; }
//    }
//    // Start is called before the first frame update
//    void Start()
//    {
//        //player_Hp = GameObject.FindWithTag("Player").GetComponent<HP>();
//        player_TrickPoint = GameObject.FindWithTag("Player").GetComponent<TrickPoint>();
//        //enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();

//        totalScore = 0;
//        nowScore = 0;
//        damageCount = 0;
//        remainingTime = 0;
//        //oldPlayerHp = player_Hp.Hp;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//    }

//    public void CalculateScore()//�X�R�A�Z�o(�G���S���ɌĂяo��)
//    {
//        CalculateTimeScore();
//        CalculateTrickGageScore();
//        CalculateDamageScore();

//        totalScore += nowScore;//���v�X�R�A�Ƀv���C���̃X�R�A�����_
//    }

//    public void AddDamageCount()//��e���Ƀ_���[�W���󂯂��񐔂𑝂₷
//    {
//        damageCount++;
//        //if (player_Hp.Hp < oldPlayerHp)//�v���C���[��HP������������
//        //{
//        //    damageCount++;
//        //}

//        //if (player_Hp.Hp != oldPlayerHp)//�v���C���[��HP������������
//        //{
//        //    oldPlayerHp = player_Hp.Hp;//���݂�HP���L�^

//        //    if (oldPlayerHp >= player_Hp.HpMax)
//        //    {
//        //        oldPlayerHp = player_Hp.HpMax;
//        //    }
//        //}
//    }

//    public void AddTrickScore()//�g���b�N�������ɃX�R�A�����_
//    {
//        nowScore += trickScore;
//    }


//    // �X�R�A�Z�o�̃��\�b�h

//    void CalculateTimeScore()//�c�莞�Ԃ̃X�R�A�v�Z
//    {
//        remainingTime = (int)(TimeDisplay.Minutes * 60 + TimeDisplay.Seconds);
//        totalScore += (int)(remainingTime * timeScore_ratio);//�c�莞�Ԃɉ������X�R�A�����_
//    }

//    void CalculateTrickGageScore()//�g���b�N�Q�[�W�c�ʂ̃X�R�A�v�Z
//    {
//        for (int i = 0; i < player_TrickPoint.TrickPoint_.Length; i++)
//        {
//            totalScore += (int)(player_TrickPoint.TrickPoint_[i] * trickScore_ratio);//�g���b�N�Q�[�W�̎c�ʂɉ������X�R�A�����_
//        }
//    }

//    void CalculateDamageScore()//�_���[�W�]���̃X�R�A�v�Z
//    {
//        switch (damageCount)//�_���[�W���󂯂��񐔂̕]��
//        {
//            case int n when (n <= bestRank.BorderCount)://�_���[�W���󂯂��񐔂�bestRank.BoderCount��ȉ��̎�
//                totalScore += bestRank.AddScore;//���v�X�R�A�ɍō��]�����̃X�R�A�����_
//                break;

//            case int n when (bestRank.BorderCount < n && n <= goodRank.BorderCount):
//                //�_���[�W���󂯂��񐔂�bestRank.BorderCount��𒴂��A����goodRank.BorderCount��ȉ��ł��鎞
//                totalScore += goodRank.AddScore;//���v�X�R�A�ɍ��]�����̃X�R�A�����_
//                break;

//            case int n when (goodRank.BorderCount < n && n <= normalRank.BorderCount):
//                //�_���[�W���󂯂��񐔂�goodRank.borderCount��𒴂��A����normalRank.BoarderCount��ȉ��ł��鎞
//                totalScore += normalRank.AddScore;//���v�X�R�A�ɕ��ʕ]�����̃X�R�A�����_
//                break;

//            case int n when (normalRank.BorderCount < n && n <= badRank.BorderCount):
//                //�_���[�W���󂯂��񐔂�normalRank.BorderCount��𒴂��A����badRank.BorderCount��ȉ��ł��鎞
//                totalScore += badRank.AddScore;//���v�X�R�A�ɒ�]�����̃X�R�A�����_
//                break;

//            case int n when (badRank.BorderCount < n):
//                //�_���[�W���󂯂��񐔂�badRank.BorderCount��𒴂�����
//                totalScore += lowestRank_AddScore;//���v�X�R�A�ɍŒ�]�����̃X�R�A�����_
//                break;
//        }
//    }
//}
