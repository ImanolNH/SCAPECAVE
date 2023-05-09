using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class RandomMusic : MonoBehaviour
{
    public bool playOnStart;
    public bool randomiseStartPosition;

    public AudioSource bed;
    public AudioSource melody;
    public AudioSource perc;
    public AudioSource fx;

    public AudioMixer mixer;
    public string exposedParamName = "CaveMasterVol";

    public float fadeInDuration = 3f;
    public float fadeOutDuration = 3f;

    public AudioClip[] melodyArray;
    public AudioClip[] percArray;
    public AudioClip[] fxArray;

    public int bpm = 95;
    public int beatsPerBar = 4;
    public int barsPerTrigger = 2;

    public int melodyChance = 60;
    public int percChance = 40;
    public int fxChance = 20;

    public float panVariation;

    float timer;
    float triggerTime;
    bool musicPlaying;

    void Start()
    {
        triggerTime = 60f / bpm * beatsPerBar * barsPerTrigger;
        if (playOnStart == true)
            StartMusic();
    }

    void Update()
    {
        if (musicPlaying == true)
        {
            timer += Time.deltaTime;
            if (timer > triggerTime)
            {
                PlayClips();
            }
        }
    }

    public void StartMusic()
    {
        if (musicPlaying == false)
        {
            StopAllCoroutines();
            timer = 0f;
            mixer.SetFloat(exposedParamName, - 80);
            StartCoroutine(FadeMasterGroup(fadeInDuration, 1));
            if (randomiseStartPosition)
            {
                bed.time = Random.Range(0, bed.clip.length);
            }
            bed.Play();
            musicPlaying = true;
        }
        else { Debug.Log("Cannot start music, it's still playing."); }
    }

    public void StopMusic()
    {
        StartCoroutine(FadeAndStopMusic());
    }

    void PlayClips()
    {
        timer = 0f;
        int melodyRoll = Random.Range(0, 100);
        int percRoll = Random.Range(0, 100);
        int fxRoll = Random.Range(0, 100);

        if (melodyChance > melodyRoll && !melody.isPlaying)
        {
            int melodyIndex = Random.Range(0, melodyArray.Length);
            melody.panStereo = RandomPan();
            melody.clip = melodyArray[melodyIndex];
            melody.Play();
        }

        if (percChance > percRoll && !perc.isPlaying)
        {
            int percIndex = Random.Range(0, percArray.Length);
            perc.panStereo = RandomPan();
            perc.clip = percArray[percIndex];
            perc.Play();
        }

        if (fxChance > fxRoll && !fx.isPlaying)
        {
            int fxIndex = Random.Range(0, fxArray.Length);
            fx.panStereo = RandomPan();
            fx.clip = fxArray[fxIndex];
            fx.Play();
        }
    }

    float RandomPan()
    {
        float panValue = panVariation;

        if (panVariation != 0)
        {
            panValue = Random.Range(-panVariation, panVariation);
        }
       
        return panValue;
    }

    IEnumerator FadeAndStopMusic()
    {
        yield return StartCoroutine(FadeMasterGroup(fadeOutDuration, 0));
        bed.Stop();
        melody.Stop();
        perc.Stop();
        fx.Stop();
        musicPlaying = false;
        StopAllCoroutines();
    }

    IEnumerator FadeMasterGroup(float duration, float targetVolume)
    {
        float currentTime = 0;
        float currentVol;
        mixer.GetFloat(exposedParamName, out currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);
        float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1);

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            mixer.SetFloat(exposedParamName, Mathf.Log10(newVol) * 20);
            yield return null;
        }
        mixer.SetFloat(exposedParamName, Mathf.Log10(targetValue) * 20);
        yield break;
    }
}
