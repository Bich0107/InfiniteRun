using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSequence : MonoBehaviour
{
    [SerializeField] List<CustomAnimation> frames;
    [SerializeField] bool isPlaying;
    [SerializeField] bool loop;

    public void Play()
    {
        if (isPlaying) return;
        StartCoroutine(CR_Play());
    }

    IEnumerator CR_Play()
    {
        isPlaying = true;

        do
        {
            foreach (CustomAnimation frame in frames)
            {
                yield return frame.Play();
            }
        } while (loop);

        isPlaying = false;
    }

    public void Stop()
    {
        if (!isPlaying) return;
        StopAllCoroutines();
        isPlaying = false;
    }
}
