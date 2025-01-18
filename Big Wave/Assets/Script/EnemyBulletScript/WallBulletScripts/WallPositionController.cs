using UnityEngine;

//�쐬�ҁF�K��

public partial class WallBullet
{
    private void PositioningWallArea()//�ǂ̐����͈̓v���n�u�̈ʒu�̐ݒ�
    {
        if (generationParams.MatchCameraSize)//�J�����̕`�ʔ͈͂ɍ��킹��ꍇ
        {
            Vector3 screenSize = CalculateCameraSize();//�J�����̕`�ʔ͈͂̌v�Z

            //�ǂ̐����͈̓v���n�u�̃X�P�[���ݒ�
            _enemyShotWall.WallAreaInstance.transform.localScale = new Vector3(
                screenSize.x, screenSize.y, _enemyShotWall.WallAreaInstance.transform.localScale.z);
        }

        AlignWallAreaToBulletSpawn();//�ǂ̐����͈̓v���n�u�̒�ӂ��AwallArea�̐����n�_�I�u�W�F�N�g�̍����ɍ��킹��
    }

    private void PositioningWalls()//�ǃv���n�u�̈ʒu�𒲐�
    {
        Vector3 size_WallArea = _enemyShotWall.WallAreaInstance.GetComponent<MeshFilter>().sharedMesh.bounds.size;//�ǂ̐����͈̓v���n�u�̑傫�����擾
        Vector3 size_Wall = walls[0, 0].GetComponentInChildren<MeshFilter>().sharedMesh.bounds.size;

        Vector3 scaleFactor = CalculateScaleFactor(size_WallArea, size_Wall);//�ǃv���n�u�̃X�P�[�����v�Z
        PositionAndScaleWalls(scaleFactor);//�ǃv���n�u�̃X�P�[���ƈʒu��ݒ�
    }

    private void PositioningWallsPreview()//�U���͈̗͂\���v���n�u�̈ʒu�𒲐�
    {
        //SpawnPosOfWallPreview�̃��[���h���W���擾
        Vector3 spawnPosWorld = _enemyShotWall.SpawnPosOfWallPreview.transform.position;

        //wallAreaInstance�̃��[�J�����W�n�ɕϊ�
        Vector3 spawnPosLocal = _enemyShotWall.WallAreaInstance.transform.InverseTransformPoint(spawnPosWorld);

        for (int i = 0; i < generationParams.Height; i++)
        {
            for (int j = 0; j < generationParams.Width; j++)
            {
                if (wallsPreview[i, j] != null && wallsPreview[i, j].activeSelf)//�U���͈̗͂\���v���n�u�����݂���Ȃ�
                {
                    wallsPreview[i, j].transform.localScale = walls[i, j].transform.localScale;

                    Vector3 wallsPreviewPos = walls[i, j].transform.localPosition;

                    //�U���͈̗͂\���v���n�u�̈ʒu��ݒ�
                    wallsPreview[i, j].transform.localPosition = new Vector3(
                        wallsPreviewPos.x, wallsPreviewPos.y, spawnPosLocal.z);
                }
            }
        }
    }

    private void AlignWallAreaToBulletSpawn()//�ǂ̐����͈͂̒�ӂ��AwallArea�̐����n�_�I�u�W�F�N�g�̍����ɍ��킹��
    {
        float wallAreaHeight = _enemyShotWall.WallAreaInstance.GetComponent<Renderer>().bounds.size.y;
        Vector3 wallAreaPos = _enemyShotWall.WallAreaInstance.transform.position;
        wallAreaPos.y = shotPosY + wallAreaHeight / 2;
        _enemyShotWall.WallAreaInstance.transform.position = wallAreaPos;
    }

    private void PositionAndScaleWalls(Vector3 scaleFactor)//�ǃv���n�u�̃X�P�[���ƈʒu��ݒ�
    {
        for (int i = 0; i < generationParams.Height; i++)
        {
            for (int j = 0; j < generationParams.Width; j++)
            {
                if (walls[i, j] != null)
                {
                    //�ǃv���n�u�̃X�P�[�������ƂɁA�ʒu�𒲐�
                    walls[i, j].transform.localScale = scaleFactor;
                    walls[i, j].transform.localPosition = new Vector3(
                        (j - (generationParams.Width / 2f) + 0.5f) * scaleFactor.x,
                        (i - (generationParams.Height / 2f) + 0.5f) * scaleFactor.y,
                        0);
                }
            }
        }
    }
}