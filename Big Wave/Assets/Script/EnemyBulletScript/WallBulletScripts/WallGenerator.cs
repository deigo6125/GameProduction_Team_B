using UnityEngine;
using System.Collections.Generic;

//�����m���̍����x��

//�쐬�ҁF�K��

public partial class WallBullet
{
    private Stack<GameObject> wallActivationStack;
    private Stack<GameObject> wallShotStack;

    private float adjustProbability;

    void GenerateWalls()//�ǂ̐���
    {
        wallActivationStack = new Stack<GameObject>();
        wallShotStack = new Stack<GameObject>();

        int maxStackCount = generationParams.GenerateWallsNum;//�ő�X�^�b�N��

        for (int i = 0; i < generationParams.Height; i++)
        {
            wallsCount = 0;

            for (int j = 0; j < generationParams.Width; j++)
            {
                if (walls[i, j] != null) return;

                //�ǂ̃v���n�u�𐶐����A�ǂ̐����͈̓v���n�u�̎q�I�u�W�F�N�g�ɐݒ�
                GameObject wallInstance = Instantiate(_enemyShotWall.WallPrefab, _enemyShotWall.WallAreaInstance.transform);

                if (wallInstance != null)
                {
                    walls[i, j] = wallInstance;//�������ꂽ�ǂ̃v���n�u��z��Ɋi�[
                    walls[i, j].SetActive(false);

                    adjustProbability = Mathf.Clamp(
                        generationParams.GenerationProbability * (1f - (wallActivationStack.Count / (float)maxStackCount)),
                        0.1f,
                        generationParams.GenerationProbability
                        );

                    if (wallActivationStack.Count < maxStackCount && Random.value < adjustProbability /*&& wallsCount < generationParams.Width - 1*/)
                    {
                        wallActivationStack.Push(walls[i, j]);
                        wallShotStack.Push(walls[i, j]);
                        wallsCount++;
                    }
                }
            }
        }
    }

    void ActiveWall()
    {
        currentDelayActiveTime += Time.deltaTime;

        if (currentDelayActiveTime > generationParams.IntervalActiveTime)
        {
            GameObject wallToActive = wallActivationStack.Pop();

            if (wallToActive != null)
                wallToActive.SetActive(true);

            currentDelayActiveTime = 0f;
        }
    }

    void GenerateWallsPreview()//�U���͈̗͂\���\���̐���
    {
        for (int i = 0; i < generationParams.Height; i++)
        {
            for (int j = 0; j < generationParams.Width; j++)
            {
                if (wallsPreview[i, j] != null) return;

                if (walls[i, j] != null && walls[i, j].activeSelf)
                    wallsPreview[i, j] = Instantiate(_enemyShotWall.WallPreviewPrefab, _enemyShotWall.WallAreaInstance.transform);
            }
        }
    }
}