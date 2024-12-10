using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] AnimationSequence[] sequences;
    [SerializeField] bool playOnAwake;

    void Awake()
    {
        if (playOnAwake) Play();
    }

    public void Play()
    {
        foreach (AnimationSequence sequence in sequences)
        {
            sequence.Play();
        }
    }

    public void Stop()
    {
        foreach (AnimationSequence sequence in sequences)
        {
            sequence.Stop();
        }
    }
}
