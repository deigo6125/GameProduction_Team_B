using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

public class ToggleColliderOfWallBullet : MonoBehaviour
{
    WallBullet wallBullet;

    bool colliderToggled = false;//�R���C�_�[�̐؂�ւ��̊Ǘ��p

    public void SetWallBullet(WallBullet wallBullet)
    {
        this.wallBullet = wallBullet;
    }

    void OnTriggerEnter(Collider other)
    {
        if (wallBullet != null && other.CompareTag("Player") && wallBullet.Generated && !colliderToggled)
        {
            wallBullet.ToggleCollider();
            colliderToggled = true;
        }
    }
}