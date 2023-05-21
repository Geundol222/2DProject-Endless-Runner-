using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TitleController : MonoBehaviour
{
    public UnityEvent isPress;

    [SerializeField] private AudioClip clip;

    private void Awake()
    {
        GameManager.BGM.Bgm.clip = clip;
    }

    private void Start()
    {
        GameManager.BGM.Bgm.Play();
    }

    private void OnStart(InputValue value)
    {
        if (value.isPressed)
            isPress?.Invoke();
    }
}
