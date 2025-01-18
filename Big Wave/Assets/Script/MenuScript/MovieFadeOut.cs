using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Video;

public class MovieFadeOut : MonoBehaviour
{
    [SerializeField] GameObject fadeInObject;//����Đ���A�N�e�B�u�ɂ���I�u�W�F�N�g
    [SerializeField] GameObject _activeDuringMovieObject;//����Đ����ɂ̂݃A�N�e�B�u�ɂ���I�u�W�F�N�g
    [SerializeField] GameObject fadeInAudio;
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] RawImage videoImage;
    [SerializeField] float fadeOutSpeed;
    [SerializeField] float fadeInAudio_delay;//�I�u�W�F�N�g���t�F�[�h�C�����Ă��特���Đ����鎞�ԍ�
    [SerializeField] AudioClip clip;
    bool Isfade;
    float nowValue;
    float countTime;
    // Start is called before the first frame update
    void Start()
    {
        nowValue = videoImage.color.a;
        fadeInObject.SetActive(false);
        if (_activeDuringMovieObject != null)
        {
            _activeDuringMovieObject.SetActive(true);
        }

        fadeInAudio.SetActive(false);
        videoPlayer.Play();
        videoPlayer.loopPointReached += VideoPlayer_loopPointReached;

    }

    private void VideoPlayer_loopPointReached(VideoPlayer vb)
    {
        fadeInObject.SetActive(true);
        if(_activeDuringMovieObject != null)
        {
            _activeDuringMovieObject.SetActive(false);
        }
      
        Isfade = true;
        AudioSource.PlayClipAtPoint(clip,new(0,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Isfade)
        {
            nowValue-= Time.deltaTime*fadeOutSpeed;
            countTime += Time.deltaTime;
            //GetValue();
            if (countTime>fadeInAudio_delay)
            {
                fadeInAudio.SetActive(true);
            }
        }
    }
    void GetValue()
    {
        Color color = videoImage.color;

        color.a = nowValue;
        videoImage.color = color;
    }
}
