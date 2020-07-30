using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 소리를 내는 기관 : AudioSource
// 소리파일 : AudioClip
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private void Awake()
    {
        Instance = this;
        InitAudio();
    }

    private void InitAudio()
    {
        //// 배경음악
        //bgmPlayer = gameObject.AddComponent<AudioSource>();

        //bgmClipDict = new Dictionary<BGMEnum, AudioClip>();
        //int len = (int)BGMEnum.Length;
        //for (int i = 0; i < len; i++)
        //{
        //    BGMEnum c = (BGMEnum)i;
        //    AudioClip clip_item = Resources.Load<AudioClip>("Sound/" + c.ToString());
        //    bgmClipDict.Add(c, clip_item);
        //}

        // 이펙트 사운드

        effectPlayerList = new List<AudioSource>();
        for (int i = 0; i < effectPlayerCount; i++)
        {
            effectPlayerList.Add(gameObject.AddComponent<AudioSource>());
        }

        effectCilpDict = new Dictionary<EffectClipsEnum, AudioClip>();
        int len = (int)EffectClipsEnum.Length;
        for (int i = 0; i < len; i++)
        {
            //EffectClipsEnum c = (EffectClipsEnum)((int)EffectClipsEnum.arrowFire + i);
            EffectClipsEnum c = (EffectClipsEnum)i;
            // enum 의 이름과 파일의 이름이 같게 해서 바로 Dict에 Add가능
            AudioClip clip_item = Resources.Load<AudioClip>("Audio/" + c.ToString());
            effectCilpDict.Add(c, clip_item);
        }
    }

    public Dictionary<EffectClipsEnum, AudioClip> effectCilpDict;

    public enum EffectClipsEnum
    {
        SFX_BG_FirstRoom,
        SFX_UIPopUp,
        SFX_Typing,
        SFX_DoorOpen,
        SFX_FlowerBlossom,
        SFX_ItemCollision,
        SFX_KeyPopUp,
        SFX_KeyUsing,
        SFX_LadderDown,
        Length,
    }

    //AudioClip bgmClip;

    //AudioSource bgmPlayer;

    //public Dictionary<BGMEnum, AudioClip> bgmClipDict;

    //public enum BGMEnum
    //{
    //    Length
    //}


    List<AudioSource> effectPlayerList;
    int effectPlayerCount = 40;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void StopBGM()
    //{
    //    bgmPlayer.Stop();
    //}
    //public void PlayBGM(BGMEnum bgm)
    //{
    //    bgmPlayer.Stop();
    //    bgmPlayer.clip = bgmClipDict[bgm];
    //    bgmPlayer.loop = true;
    //    bgmPlayer.Play();
    //}
    //public void PlayBGM(BGMEnum bgm, float volume)
    //{
    //    bgmPlayer.Stop();
    //    bgmPlayer.clip = bgmClipDict[bgm];
    //    bgmPlayer.volume = volume;
    //    bgmPlayer.loop = true;
    //    bgmPlayer.Play();
    //}

    public void PlayEffect(EffectClipsEnum clip, float volume, bool isLoop)
    {
        for (int i = 0; i < effectPlayerList.Count; i++)
        {
            if (effectPlayerList[i].isPlaying == false)
            {
                effectPlayerList[i].Stop();
                effectPlayerList[i].clip = effectCilpDict[clip];
                effectPlayerList[i].volume = volume;
                effectPlayerList[i].loop = isLoop;
                effectPlayerList[i].Play();
                return;
            }
        }
    }

    public void PlayEffect(EffectClipsEnum clip, float volume)
    {
        for (int i = 0; i < effectPlayerList.Count; i++)
        {
            if (effectPlayerList[i].isPlaying == false)
            {
                effectPlayerList[i].Stop();
                effectPlayerList[i].clip = effectCilpDict[clip];
                effectPlayerList[i].volume = volume;
                effectPlayerList[i].Play();
                return;
            }
        }
    }

    public void PlayEffect(EffectClipsEnum clip)
    {
        for (int i = 0; i < effectPlayerList.Count; i++)
        {
            if (effectPlayerList[i].isPlaying == false)
            {
                effectPlayerList[i].Stop();
                effectPlayerList[i].clip = effectCilpDict[clip];
                effectPlayerList[i].Play();
                return;
            }
        }
    }


}
