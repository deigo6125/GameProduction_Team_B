using Cinemachine;
using UnityEngine;

public partial class EnemyActionTypeShotWall : EnemyActionTypeBase
{
    [Header("�A�j���[�V�����̐ݒ�")]
    [SerializeField] DelayAnimationTypeTrigger _animTrigger;

    [Header("�ǍU�����̃J����")]
    [SerializeField] CinemachineVirtualCamera _wallCamera;

    [Header("�s�����̃G�t�F�N�g")]
    [SerializeField] GenerateEffect_Action _generateEffect;
    [Header("�s�����̌��ʉ�")]
    [SerializeField] PlayAudio_Action _playAudio;

    [Header("���e�p�����[�^")]
    [Header("�ǂ̐����Ɋւ���p�����[�^")]
    [SerializeField] WallGenerationParameters _generationParameters;
    [Header("�ǂ̔��˂Ɋւ���p�����[�^")]
    [SerializeField] WallShootingParameters _shootingParameters;
    [Header("�U���\���̓����x����Ɋւ���p�����[�^")]
    [SerializeField] PreviewTransparencyParameters _previewTransparencyParameters;

    [Header("���˂����")]
    [SerializeField] GameObject wallPrefab;
    [Header("�ǂ̐����͈�")]
    [SerializeField] GameObject wallAreaPrefab;
    [Header("�U���͈̗͂\���\��")]
    [SerializeField] GameObject wallPreviewPrefab;
    [Header("�U���\���\���𐶐�����ʒu")]
    [SerializeField] protected Transform spawnPosOfWallPreview;
    [Header("�e�����������ʒu")]
    [SerializeField] protected Transform shotPosObject;
    [Header("GamePos")]
    [SerializeField] protected GameObject gamePos;

    GameObject wallAreaInstance;
    Rigidbody bulletRb;

    private float currentDelayTime;//���݂̒x�����ԁA���ꂪdelayTime�ɒB�������e���������
    bool shoted;//�e����������

    public GameObject WallPrefab { get { return wallPrefab; } }
    public GameObject WallAreaPrefab { get { return wallAreaPrefab; } }
    public GameObject WallPreviewPrefab { get { return wallPreviewPrefab; } }
    public GameObject WallAreaInstance { get { return wallAreaInstance; } }
    public Transform SpawnPosOfWallPreview { get { return spawnPosOfWallPreview; } }
    public Transform ShotPosObject { get { return shotPosObject; } }
    public WallGenerationParameters GenerationParameters { get { return _generationParameters; } }
    public WallShootingParameters ShootingParameters { get { return _shootingParameters; } }
    public PreviewTransparencyParameters TransparencyParameters { get { return _previewTransparencyParameters; } }

    public bool Shoted { get { return shoted; } }
}