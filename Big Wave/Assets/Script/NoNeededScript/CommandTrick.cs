using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:����
//[System.Serializable]
//public class CommandPatterns
//{
//    [SerializeField] string patternName; // �p�^�[���̖��O
//    [SerializeField] List<string> sequence; // �R�}���h�V�[�P���X

//    public string PatternName
//    {
//        get { return patternName; }
//    }
//    public List<string> Sequence
//    {
//        get { return sequence; }
//    }
//}

//public class CommandTrick : MonoBehaviour
//{
//    [SerializeField] List<string> commandBuffer = new List<string>();
//    [SerializeField] float bufferDuration = 1.0f; 
//    [SerializeField] List<CommandPatterns> commandPatterns; // �C���X�y�N�^�[�Őݒ肷��p�^�[���̃��X�g
//    private float countTimer = 0;
//    private Jump jumpControl;
//    // Update is called once per frame

//    private void Start()
//    {
//        jumpControl = GetComponent<Jump>();
//    }
//    void Update()
//    {
//        // ���͂��L�^
//        if (Input.GetButtonDown("Fire1")) AddInput("A");
//        if (Input.GetButtonDown("Fire2")) AddInput("X");
//        if (Input.GetButtonDown("Fire3")) AddInput("Y");
//        if (Input.GetButtonDown("Fire4")) AddInput("B");

//        // �o�b�t�@�̎��Ԃ��X�V
//        countTimer += Time.deltaTime;
//        if (countTimer > bufferDuration)
//        {
//            commandBuffer.Clear();
//            countTimer = 0;
//        }

//        if (jumpControl.JumpNow())
//        {
//            CheckInputPatterns();
//        }
//        else
//        {
//            commandBuffer.Clear();
//        }

                
       
//    }

//    void AddInput(string input)
//    {
//        commandBuffer.Add(input);
//        countTimer = 0; // �V�������͂���������^�C�}�[�����Z�b�g
//        Debug.Log(input);
//    }

//    void CheckInputPatterns()
//    {

//        string inputSequence = string.Join("", commandBuffer.ToArray());

//        foreach (var pattern in commandPatterns)
//        {
//            string patternSequence = string.Join("", pattern.Sequence.ToArray());
//            if (inputSequence.Contains(patternSequence))
//            {
//                ExecutePattern(pattern.PatternName);
//                commandBuffer.Clear();
//                break;
//            }
//        }
//    }

//    void ExecutePattern(string patternName)
//    {
//        switch (patternName)
//        {
//            case "UltimateAttack":
//                PerformAttackCombo();
//                break;
//            case "SpeedUp":
//                PerformDefenseCombo();
//                break;
//            case "PowerCharge":
//                PerformSpecialMove();
//                break;
//            default:
//                Debug.LogWarning("Unknown pattern: " + patternName);
//                break;
//        }
//    }

//    void PerformAttackCombo()
//    {
//        // AttackCombo�̏����������ɋL�q
//        Debug.Log("�Ȃ񂩂��������_���[�W�^�����`");
//    }

//    void PerformDefenseCombo()
//    {
//        // DefenseCombo�̏����������ɋL�q
//        Debug.Log("��莞�ԃX�s�[�g�N�\�����Ȃ��`");
//    }

//    void PerformSpecialMove()
//    {
//        // SpecialMove�̏����������ɋL�q
//        Debug.Log("���̍U���������`");
//    }
//}
