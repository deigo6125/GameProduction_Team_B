using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChargeTrick : MonoBehaviour
{
    [Header("最大までたまりやすくなった時の倍率(最大倍率)")]
    [SerializeField] float chargeRateMax=1;//最大倍率
    [Header("最大倍率になるまでにかかる時間")]
    [SerializeField] float byRateMaxTime=10;//最大倍率になるまでにかかる時間
    [Header("倍率が減る速度(倍率が増える時の速度を1として)")]
    [SerializeField] float minusChargeRateSpeed;//波に触れてないかつジャンプしていない時に倍率が減る速度
    private float curremtChangeChargeRateTime=0;//倍率が変化している時間
    private const float normalChargeRate = 1;//等倍
    private float currentChargeRate = normalChargeRate;//現在の倍率

    JumpControl jumpControl;
    JudgeTouchWave judgeTouchWave;
    ChangeChargeTrickEffect changeChargeTrickEffect;

    public float CurrentChargeRate
    {
        get { return currentChargeRate; }
    }

    public float ChargeRateMax
    {
        get { return chargeRateMax; }
    }

    // Start is called before the first frame update
    void Start()
    {
        jumpControl = GetComponent<JumpControl>();
        judgeTouchWave = GetComponent<JudgeTouchWave>();
        changeChargeTrickEffect = GetComponent<ChangeChargeTrickEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeChargeRate();
        Debug.Log(currentChargeRate);
    }

    bool ChangeChargeRateNow()//波に触れているかジャンプしている時に倍率が変化するようにする
    {
        if(jumpControl.JumpNow||judgeTouchWave.TouchWaveNow)
        {
            return true; 
        }
       
        return false;
    }

    void ChangeChargeRate()
    {
        //波に触れているかジャンプしている時、byRateMaxTimeかけてだんだん倍率が1倍からchargeRateMax倍まで変化する
        if (ChangeChargeRateNow())
        {
            curremtChangeChargeRateTime += Time.deltaTime;
            curremtChangeChargeRateTime = Mathf.Clamp(curremtChangeChargeRateTime, 0, byRateMaxTime);
        }
        //そうでない時、倍率が時間ごとに減っていく
        else
        {
            curremtChangeChargeRateTime -= minusChargeRateSpeed*Time.deltaTime;
            curremtChangeChargeRateTime = Mathf.Clamp(curremtChangeChargeRateTime, 0, byRateMaxTime);
        }

        currentChargeRate = normalChargeRate + (chargeRateMax - normalChargeRate) * RatioOfChargeRate();
        currentChargeRate = Mathf.Clamp(currentChargeRate, 1, chargeRateMax);

        changeChargeTrickEffect.ChangeEffectScale();
    }

    public float RatioOfChargeRate()
    {
        return curremtChangeChargeRateTime / byRateMaxTime;
    }
}
