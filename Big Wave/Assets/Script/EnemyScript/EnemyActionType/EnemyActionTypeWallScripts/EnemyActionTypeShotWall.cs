using UnityEngine;

//�쐬�ҁF�K��

public partial class EnemyActionTypeShotWall : EnemyActionTypeBase
{
    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        Debug.Log("Wall");

        currentDelayTime = 0;

        _animTrigger.Start();//���[�V�����̍Đ������̏�����

        if (_generateEffect != null) _generateEffect.OnEnter();//�G�t�F�N�g�̏���������

        if (_playAudio != null) _playAudio.OnEnter();//���ʉ��̏���������

        if (_wallCamera!=null) _wallCamera.enabled = true;//�ǍU���̃J�������N��
    }

    public override void OnUpdate()
    {
        if (!shoted)
        {
            if (wallAreaInstance == null)
                GenerateWallArea();

            else
                Shot();
        }

        if (_playAudio != null) _playAudio.OnUpdate();//���ʉ��̍X�V����

        if (_generateEffect != null) _generateEffect.OnUpdate();//�G�t�F�N�g�̍X�V����

        _animTrigger.Update();//���[�V�����̍Đ������̍X�V
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {
        shoted = false;

        wallAreaInstance = null;

        if (_wallCamera != null) _wallCamera.enabled = false;//�ǍU���̃J�������I��
    }

    void GenerateWallArea()
    {
        if (wallAreaInstance == null)
        {
            //�U�������������ʒu���擾
            Vector3 shotPos = shotPosObject.transform.position;
            Quaternion shotRot = shotPosObject.transform.rotation;

            wallAreaInstance = Instantiate(wallAreaPrefab, shotPos, shotRot, gamePos.transform);

            WallBullet wallBulletScript = wallAreaInstance.AddComponent<WallBullet>();

            //ToggleColliderOfWallBullet��wallBullet�̎Q�Ƃ�ݒ�
            wallBulletScript.SetWallBullet(this);

            //�e��Rigidbody���擾
            bulletRb = wallAreaInstance.GetComponent<Rigidbody>();
        }
    }

    void Shot() //�e������
    {
        currentDelayTime += Time.deltaTime;

        if (currentDelayTime > _shootingParameters.DelayTime)
        {
            //�e����������
            bulletRb.AddForce(-transform.forward * _shootingParameters.ShotPower, ForceMode.Impulse);

            shoted = true;
        }
    }
}
