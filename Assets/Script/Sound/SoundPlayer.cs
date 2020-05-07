using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public float pitchVariation;

    private AudioSource[] audios;
    private float[] pitches;

    /// ===========================================
    void Awake()
    {
        this.audios = GetComponentsInChildren<AudioSource>();

        this.pitches = new float[this.audios.Length];

        for (int i = 0; i < this.audios.Length; i++)
        {
            this.pitches[i] = this.audios[i].pitch;
        }
    }

    /// ===========================================
    public void Play()
    {
        if (Storage.mutedSound)
        {
            return;
        }

        int index = Random.Range(0, this.audios.Length);

        AudioSource audio = this.audios[index];
        float basePitch = this.pitches[index];

        float pitchVariation = Random.Range(-this.pitchVariation, this.pitchVariation);

        audio.pitch = basePitch + pitchVariation;
        audio.Play();
    }
}
