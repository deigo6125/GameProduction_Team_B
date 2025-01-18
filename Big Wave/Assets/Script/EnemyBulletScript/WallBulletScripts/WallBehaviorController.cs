using UnityEngine;

//�쐬�ҁF�K��

public partial class WallBullet
{
    void DisableWallsPreview()//�U���͈̗͂\���̖���������
    {
        for (int i = 0; i < generationParams.Height; i++)
        {
            for (int j = 0; j < generationParams.Width; j++)
            {
                if (wallsPreview[i, j] != null)
                {
                    wallsPreview[i, j].SetActive(false);//�U���͈̗͂\���v���n�u�𖳌���
                }
            }
        }
    }

    void SetPreviewTransparency(float alpha)//�U���͈̗͂\���̓����x��ݒ�
    {
        for (int i = 0; i < generationParams.Height; i++)
        {
            for (int j = 0; j < generationParams.Width; j++)
            {
                if (wallsPreview[i, j] != null && wallsPreview[i, j].activeSelf)//�U���͈̗͂\���v���n�u�����݂���Ȃ�
                {
                    //�U���͈̗͂\���v���n�u��Renderer���擾
                    Renderer renderer = wallsPreview[i, j].GetComponent<Renderer>();

                    if (renderer != null)//Renderer�����݂���Ȃ�
                    {
                        Color color = renderer.material.color;//���݂̐F���擾
                        color.a = alpha;//�����x��ݒ�
                        renderer.material.color = color;//�F���X�V
                    }
                }
            }
        }
    }

    void AddForceToWalls()//�ǃv���n�u�ɗ͂�������
    {
        if (wallAreaRigidbody != null)
        {
            Vector3 velocity = wallAreaRigidbody.velocity;//�ǂ̐����͈̓v���n�u�̑��x���擾

            for (int i = 0; i < generationParams.Height; i++)
            {
                for (int j = 0; j < generationParams.Width; j++)
                {
                    if (walls[i, j] != null)
                    {
                        //�ǂ�Rigidbody���擾
                        Rigidbody wallRigidbody = walls[i, j].GetComponentInChildren<Rigidbody>();

                        if (wallRigidbody != null)
                            wallRigidbody.velocity = velocity;//���ꂼ��̕ǃv���n�u�ɑ��x��ݒ�
                    }
                }
            }
        }
    }

    void AddForceToWallsOnebyOne()//��莞�Ԍo�߂��ƂɊe�v���n�u����ɗ͂�������
    {
        if (wallAreaRigidbody != null)
        {
            currentDelayShotTime += Time.deltaTime;

            Vector3 velocity = wallAreaRigidbody.velocity;//�ǂ̐����͈̓v���n�u�̑��x���擾

            if (wallShotStack.Count > 0 && currentDelayShotTime > shootingParams.IntervalShotTime)
            {
                GameObject wallToShot = wallShotStack.Pop();

                if (wallToShot != null)
                {
                    Rigidbody wallRigidbody = wallToShot.GetComponentInChildren<Rigidbody>();

                    if (wallRigidbody != null)
                        wallRigidbody.velocity = velocity;//�ǃv���n�u�ɑ��x��ݒ�
                }

                currentDelayShotTime = 0;
            }
        }
    }

    public void ToggleCollider()//�ǂ̃R���C�_�[�𖳌�������
    {
        if (walls != null)
        {
            for (int i = 0; i < walls.GetLength(0); i++)
            {
                for (int j = 0; j < walls.GetLength(1); j++)
                {
                    if (walls[i, j] != null)
                    {
                        //�ǃv���n�u�̃R���C�_�[���擾
                        Collider wallCollider = walls[i, j].GetComponentInChildren<Collider>();

                        if (wallCollider != null)
                        {
                            wallCollider.enabled = false;//�ǃv���n�u�̃R���C�_�[�𖳌���
                        }
                    }
                }
            }
        }
    }
}