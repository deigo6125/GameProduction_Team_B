using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

//Ş˘˝

class Enemy : MonoBehaviour
{
    [Header("ĽGĚHP")]
    private float hp = 4000f;//GĚHP
    [Header("ĽGĚĹĺHP")]
    [SerializeField] float hpMax = 4000f;//GĚĹĺHP
    SceneControlManager sceneControlManager;
    Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;
        sceneControlManager= GameObject.FindWithTag("SceneManager").GetComponent<SceneControlManager>();
        controller = GameObject.FindWithTag("Player").GetComponent<Controller>();
    }

    public float Hp
    {
        get { return  hp; }
        set { hp = value; }
    }

    public float HpMax
    {
        get { return hpMax; }
        set { hpMax = value; }
    }

    // Update is called once per frame
    void Update()
    {
        Dead();//GSNAV[ÉÚs
    }

    void Dead()//GSNAV[ÉÚs
    {
        if (hp <= 0)
        {
            controller.StopVibe_Trick();//}u
            sceneControlManager.ChangeClearScene();
        }
    }
    

    

    
}
