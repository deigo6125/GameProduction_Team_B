using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;

//�쐬��:���R
//�Q�[���I���̔��f
public class JudgeGameSet : MonoBehaviour
{
    public event Action<bool> GameSetAction;//true�Ȃ�Q�[���N���A�Afalse�Ȃ�Q�[���I�[�o�[
    public event Action GameSetCommonAction;//�Q�[���I�����N���A�ł��Q�[���I�[�o�[�ł��ǂ���ł���鋤�ʃC�x���g
    public event Action GameClearAction;//�Q�[���N���A���ɌĂ�
    public event Action DeadAction;//���S���ɌĂ�
    public event Action TimeUpAction;//�^�C���A�b�v���ɌĂ�
    public event Action LatedAction;//�x��ČĂ�

    [Header("�v���C���[��HP")]
    [SerializeField] HP player_Hp;//�v���C���[��HP
    [Header("�G��HP")]
    [SerializeField] HP enemy_Hp;//�G��HP
    [Header("����")]
    [SerializeField] TimeLimit timeLimit;
    bool gameSet = false;

    public bool GameSet { get { return gameSet; } }

    void Update()
    {
        JudgeClear();
        JudgeDead();
        JudgeTimeUp();
    }

    void JudgeClear()//�N���A���f
    {
        if (enemy_Hp.Hp <= 0&&!gameSet)//�G��|������
        {
            GameSetProcess(true);
            GameClearAction?.Invoke();
            LatedAction?.Invoke();
        }
    }

    void JudgeDead()//�v���C���[���S���f
    {
        bool dead = player_Hp.Hp <= 0;//�v���C���[������

        if (dead&& !gameSet)//�v���C���[�����񂾂�
        {
            GameSetProcess(false);
            DeadAction?.Invoke();
            LatedAction?.Invoke();
        }
    }

    void JudgeTimeUp()//���Ԑ؂ꔻ�f
    {
        if(timeLimit.TimeUp&& !gameSet)//���Ԑ؂ꎞ
        {
            GameSetProcess(false);
            TimeUpAction?.Invoke();
            LatedAction?.Invoke();
        }
    }

    void GameSetProcess(bool gameClear)//�Q�[���I�����V�[���Ɉڍs���钼�O�ɍs������
    {
        gameSet = true;
        GameSetCommonAction?.Invoke();
        GameSetAction?.Invoke(gameClear);
    }
}
