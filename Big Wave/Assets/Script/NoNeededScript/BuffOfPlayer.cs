using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Buff//�o�t(��{�I�ɂ�����p�����ăo�t�����)
{
    //[Header("���ʎ���(�b)")]
    //[SerializeField] float buffTime = 5f;//�o�t�̌��ʎ���(�b)
    [Header("�o�t�̍ő�X�g�b�N��")]
    [SerializeField] int buffStockMax = 6;//�o�t�̍ő�X�g�b�N��
    [Header("�o�t�̃G�t�F�N�g")]
    [SerializeField] GameObject effect;//�o�t�̃G�t�F�N�g
    [Header("�o�t�̃G�t�F�N�g��\�����邩")]
    [SerializeField] bool effectShow = true;
    //private float buffRemainingTime = 0f;//�o�t�̎c����ʎ���(�b)�A���ꂪ0�b�ȉ��ɂȂ�����o�t�̌��ʂ��؂��悤�ɂ���
    private int buffStockCount = 0;//�o�t�̎c��X�g�b�N��
    protected bool activateNow = false;//�o�t���ʔ�������

    /*public float BuffTime
    {
        get { return buffTime; }
    }*/

    public int BuffStockMax
    {
        get { return buffStockMax; }
    }

    public GameObject Effect
    {
        get { return effect; }
    }

    /*public float BuffRemainingTime
    {
        get { return buffRemainingTime; }
    }*/

    public int BuffStockCount
    {
        get { return buffStockCount; }
    }

    public bool ActivateNow
    {
        get { return activateNow; }
    }

    public Buff()
    {
        //buffRemainingTime = 0f;
        buffStockCount = 0;
        activateNow = false;
    }

    //�o�t�̎c����ʎ��Ԃ̏����ƃo�t���ʂ̏���
    public void ProcessBuffEffect()
    {
        //BuffEffectTime();
        BuffEffectCount();
        BuffEffect();
    }

    //�o�t�̎c����ʎ��Ԃ̏���
    /*void BuffEffectTime()
    {
        buffRemainingTime-=Time.deltaTime;

        if(buffRemainingTime<=0f)//�o�t���ʐ؂�
        {
            activateNow = false;
        }
    }*/

    void BuffEffectCount()
    {
        if(buffStockCount <= 0)//�X�g�b�N���Ȃ��Ȃ�
        {
            activateNow = false;
        }
    }

    //�o�t���ʂ̏���
    protected virtual void BuffEffect()
    {
        if (activateNow)//������
        {
            //upBuff.CurrentGrowthRate = upBuff.GrowthRate;
            if(effectShow) effect.SetActive(true);
        }
        else//�������Ă��Ȃ���
        {
            //upBuff.CurrentGrowthRate = 1f;
            effect.SetActive(false);
        }
    }


    //�o�t�𔭓�������(�o�t����������)���ɂ�����Ă�
    public void Activate()
    {
        activateNow=true;//�o�t���ʔ������ɂ���
        //buffRemainingTime = buffTime;
    }

    //�o�t������
    public void Deactivate()
    {
        activateNow=false;
        //buffRemainingTime = 0f;
    }

    public void IncreaseBuffStock()
    {
        if(buffStockCount < buffStockMax)//�o�t�X�g�b�N�����ő�l�����Ȃ�
        {
            buffStockCount++;//�o�t�X�g�b�N��1���₷
        }

        else
        {
            return;
        }
    }

    public void DecrementBuffStock()
    {
        if(buffStockCount > 0)//�o�t�X�g�b�N������Ȃ�
        {
            buffStockCount--;//�o�t�X�g�b�N��1���炷
        }

        else
        {
            return;
        }
    }
}

[System.Serializable]
public class UpBuff : Buff//�����n�̃o�t
{
    [Header("������(�{��)")]
    [SerializeField] float growthRate = 1;//������(�{��)
    private float currentGrowthRate = 1f;//���݂̑�����

    public UpBuff()
    {
        currentGrowthRate = 1f;
    }

    protected override void BuffEffect()
    {
        base.BuffEffect();

        if (activateNow)//������
        {
            currentGrowthRate = growthRate;
        }
        else//�������Ă��Ȃ���
        {
            currentGrowthRate = 1f;
        }
    }

    public float GrowthRate
    {
        get { return growthRate; }
    }

    public float CurrentGrowthRate
    {
        get { return currentGrowthRate; }
        set { currentGrowthRate = value; }
    }
}

public class BuffOfPlayer : MonoBehaviour
{
    /*[Header("�U���̓A�b�v�̃o�t")]
    [SerializeField] UpBuff powerUp;//�U���̓A�b�v�̃o�t
    [Header("�`���[�W�g���b�N�����̃o�t")]
    [SerializeField] UpBuff chargeTrick;//�`���[�W�g���b�N�����̃o�t*/
    [Header("�g���b�N�����̃o�t")]
    [SerializeField] UpBuff trickBoost;//�g���b�N�����̃o�t

    /*public UpBuff PowerUp
    {
        get { return powerUp; }
    }

    public UpBuff ChargeTrick
    {
        get { return chargeTrick; }
    }*/

    public UpBuff TrickBoost
    {
        get { return trickBoost; }
    }

    // Start is called before the first frame update
    void Start()
    {
        //powerUp.Effect.SetActive(false);
        //chargeTrick.Effect.SetActive(false);
        trickBoost.Effect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*//�U���̓A�b�v�o�t
        powerUp.ProcessBuffEffect();

        //�`���[�W�g���b�N�ʑ����o�t
        chargeTrick.ProcessBuffEffect();*/

        trickBoost.ProcessBuffEffect();
    }

   
}
