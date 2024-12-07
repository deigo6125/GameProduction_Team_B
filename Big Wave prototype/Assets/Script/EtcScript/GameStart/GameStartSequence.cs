using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//作成者:杉山
//ゲームのスタートの処理
public class GameStartSequence : MonoBehaviour
{
    [SerializeField] MovieCameraEvent _startMovieEvent;
    [SerializeField] StartSignalEvent _startSignalEvent;
    [SerializeField] JudgeGameStart _judgeGameStart;
    State_GameStartSequence _state;//ゲームの開始処理の状態

    void Start()
    {
        _startMovieEvent.Trigger();//最初にムービーを流す
        _state = State_GameStartSequence.movie;
    }

    // Update is called once per frame
    void Update()
    {
       UpdateSequebce();
    }

    void UpdateSequebce()
    {
        if (_state == State_GameStartSequence.start) return;//既にスタートしているなら以下の更新処理をしない

        switch(_state)
        {
            case State_GameStartSequence.movie:

                if(_startMovieEvent.State==State_Movie.off)//ムービーを流し終わったらスタートの合図を出す
                {
                    _startSignalEvent.Trigger();
                    _state = State_GameStartSequence.signal;
                }

                break;

            case State_GameStartSequence.signal:

                if(_startSignalEvent.State==State_GameStartSignal.completed)//スタートの合図を出し終わったらゲームスタート
                {
                    _judgeGameStart.GameStartTrigger();
                    _state = State_GameStartSequence.start;
                }

                break;
        }
    }

    
}
