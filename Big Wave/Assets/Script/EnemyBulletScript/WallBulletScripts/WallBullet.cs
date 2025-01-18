using System.Runtime.CompilerServices;
using UnityEngine;

//�쐬�ҁF�K��

public partial class WallBullet : MonoBehaviour
{
    EnemyActionTypeShotWall _enemyShotWall;
    WallGenerationParameters generationParams;
    WallShootingParameters shootingParams;
    PreviewTransparencyParameters transparencyParams;

    GameObject[,] walls;//���������ǂ̃v���n�u���Ǘ�����z��
    GameObject[,] wallsPreview;//�U���͈͗\���v���n�u���Ǘ�����z��

    Rigidbody wallAreaRigidbody;//�ǂ̐����͈̓v���n�u�̑��x�Ǘ��p�̕ϐ�

    Camera mainCamera;

    private float shotPosY;//wallArea�̐����n�_�I�u�W�F�N�g��Y���W

    private int wallsCount = 0;//�ǂ̖����Ǘ��p�̕ϐ�

    private float currentDelayTime = 0f;//�o�ߎ��Ԃ̌v���i�U���͈̓v���n�u�̓����x�ύX�p�j
    private float currentDelayActiveTime = 0f;//�o�ߎ��Ԃ̌v���i�ǃv���n�u�̗L�����p�j
    private float currentDelayShotTime = 0f;//�o�ߎ��Ԃ̌v���i�ǂ�ł��o���Ԋu�̌v���p�j    

    private bool generated = false;//�ǂ��������ꂽ���ǂ���
    public bool Generated { get { return generated; } }

    public void SetWallBullet(EnemyActionTypeShotWall enemyShotWall)
    {
        this._enemyShotWall = enemyShotWall;
    }

    void Start()
    {
        generationParams = _enemyShotWall.GenerationParameters;
        shootingParams = _enemyShotWall.ShootingParameters;
        transparencyParams = _enemyShotWall.TransparencyParameters;

        if (_enemyShotWall.WallAreaInstance != null)
        {
            walls = new GameObject[generationParams.Height, generationParams.Width];//�ǂ̃v���n�u���Ǘ�����z���������
            wallsPreview = new GameObject[generationParams.Height, generationParams.Width];//�U���͈̗͂\���\���p�v���n�u���Ǘ�����z���������

            mainCamera = Camera.main;

            wallAreaRigidbody = _enemyShotWall.WallAreaInstance.GetComponent<Rigidbody>();

            shotPosY = _enemyShotWall.ShotPosObject.GetComponent<Transform>().transform.localPosition.y;//�e�̔��˒n�_��Y���W���擾

            PositioningWallArea();//�ǂ̐����͈͂̈ʒu��ݒ�

            GenerateWalls();//�ǂ𐶐�
            PositioningWalls();//�������ꂽ�ǂ̈ʒu�𒲐�

            generated = true;
        }
    }

    void Update()
    {
        if (wallActivationStack.Count > 0)
        {
            ActiveWall();//�L���ȕǂ�\��

            GenerateWallsPreview();//�U���͈͗\���̐���
            PositioningWallsPreview();//�U���͈͗\���̈ʒu�𒲐��@�v�C��
        }       

        if (!_enemyShotWall.Shoted)//�e���܂����˂���Ă��Ȃ��Ȃ�
        {
            currentDelayTime += Time.deltaTime;
            float alpha = Mathf.PingPong(currentDelayTime / transparencyParams.TransparencyCycleDuration * 255f, 255f);
            SetPreviewTransparency(alpha / 255f);//�U���͈͗\���̓����x��ݒ肷��
        }

        else//�e�����˂��ꂽ��
        {
            DisableWallsPreview();//�U���͈̗͂\���̖���������

            if (shootingParams.IsShotAllAtOnce)
                AddForceToWalls();//�ǂɗ͂�������

            else
                AddForceToWallsOnebyOne();//�ǃv���n�u���ꖇ���Ԋu�������ė͂�������
        }
    }
}