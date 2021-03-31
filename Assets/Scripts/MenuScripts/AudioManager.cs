using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] List<AudioSource> back;
    [SerializeField] List<AudioSource> other;

    [SerializeField] Slider sliderBack;
    [SerializeField] Slider sliderOther;

    private float backBase = 0.5f;
    private float otherBase = 1f;

    void Start()
    {
        sliderBack.value = backBase;
        sliderOther.value = otherBase;
    }

    // Update is called once per frame
    void Update()
    {
        if(sliderBack.value != backBase)
        {
            backBase = sliderBack.value;
            ReVolume(back, sliderBack);
        }

        if(sliderOther.value != otherBase)
        {
            otherBase = sliderOther.value;
            ReVolume(other, sliderOther);
        }

    }
    
    private void ReVolume(List<AudioSource> changing, Slider chan)
    {
        foreach (AudioSource t in changing)
            t.volume = chan.value;
    }       
}   
