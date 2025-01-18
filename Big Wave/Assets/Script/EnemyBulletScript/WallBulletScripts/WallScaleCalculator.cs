using UnityEngine;

//�쐬�ҁF�K��

public partial class WallBullet
{
    private Vector3 CalculateCameraSize()//�J�����̕`�ʔ͈͂��v�Z
    {
        float screenHeight = 2f * mainCamera.orthographicSize;
        float screenWidth = screenHeight * mainCamera.aspect;

        return new Vector3(screenWidth, screenHeight, 0);
    }

    private Vector3 CalculateScaleFactor(Vector3 size_WallArea, Vector3 size_Wall)//�ǃv���n�u�̃X�P�[�����v�Z
    {
        return new Vector3(
            size_WallArea.x / (generationParams.Width * size_Wall.x),
            size_WallArea.y / (generationParams.Height * size_Wall.y),
            size_Wall.z);
    }
}
