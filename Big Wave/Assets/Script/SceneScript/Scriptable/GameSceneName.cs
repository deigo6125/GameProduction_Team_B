using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���[�h�V�[�����玟�Ɉڍs����Q�[���V�[���̖��O���Ǘ�����
[CreateAssetMenu(menuName = "ScriptableObjects/Scene/GameSceneName")]
public class GameSceneName : ScriptableObject
{
    string _nextGameScene;

    public string NextGameScene
    {
        get { return _nextGameScene; }
        set { _nextGameScene = value; }
    }
}
