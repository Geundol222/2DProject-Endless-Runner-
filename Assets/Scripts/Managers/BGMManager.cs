using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BGMManager : MonoBehaviour
{
    private AudioSource bgm;

    public AudioSource Bgm
    {
        get { return bgm; }
        set { bgm = value; }
    }

    private void Awake()
    {
        bgm = gameObject.AddComponent<AudioSource>();
    }
}
