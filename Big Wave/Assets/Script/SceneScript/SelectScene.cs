using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�쐬��:���R
//�I�񂾃V�[���Ɉڍs����
[System.Serializable]
class SelectScene
{
    [SerializeField] Scene _scene;
    [SerializeField] int _gameSceneStageID;
    [SerializeField] SceneController _sceneController;

    //�f�t�H���g�R���X�g���N�^
    public SelectScene() { }

    //�R���X�g���N�^
    public SelectScene(Scene scene)
    {
        _scene = scene;
    }

    public void ChangeScene()
    {
        switch(_scene)
        {
            case Scene.gameover: _sceneController.GameOverScene(); break;//�Q�[���I�[�o�[�V�[���Ɉڍs
            case Scene.clear: _sceneController.ClearScene(); break;//�N���A�V�[���Ɉڍs
            case Scene.menu: _sceneController.MenuScene(); break;//���j���[�V�[���Ɉڍs
            case Scene.game: _sceneController.GameScene(_gameSceneStageID); break;//�Q�[���V�[���Ɉڍs
            case Scene.end: _sceneController.EndGame(); break;//�Q�[���I��
        }
    }
}
