using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance = null;
    public static AudioManager instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject audioObject = new GameObject("AudioManager(Singleton)");
                DontDestroyOnLoad(audioObject);

                _instance = audioObject.AddComponent<AudioManager>();
                audioObject.AddComponent<AudioSource>();
            }
            return _instance;
        }
    }

    private float lastJumpEffectTime = -1f;
    private float lastDeathEffectTime = -1f;

    private AudioClip jumpClip;
    private AudioClip deathClip;

    public void JumpSound()
    {
        if (Time.time > lastJumpEffectTime + 0.5f)
        {
            if (jumpClip == null)
            {
                jumpClip = (AudioClip)Resources.Load("SFX/jump");
            }
            GetComponent<AudioSource>().PlayOneShot(jumpClip);
            lastJumpEffectTime = Time.time;
        }
    }

    public void DeathSound()
    {
        if (Time.time > lastDeathEffectTime + 1f)
        {
            if (deathClip == null)
            {
                deathClip = (AudioClip)Resources.Load("SFX/death");
            }
            GetComponent<AudioSource>().PlayOneShot(deathClip);
            lastDeathEffectTime = Time.time;
        }
    }

    public void MachineStartAndStop(float duration)
    {
        StartCoroutine(MachineStartAndStop_C(duration));
    }

    private IEnumerator MachineStartAndStop_C(float duration)
    {
        AudioSource startSource = createSoundSource();
        startSource.clip = (AudioClip)Resources.Load("SFX/machine_start");
        startSource.volume = 1f;
        startSource.Play();

        AudioSource loopSource = createSoundSource();
        loopSource.clip = (AudioClip)Resources.Load("SFX/machine_loop");
        loopSource.loop = true;
        loopSource.volume = 1f;

        AudioSource endSource = createSoundSource();
        endSource.clip = (AudioClip)Resources.Load("SFX/machine_stop");

        yield return new WaitForSeconds(startSource.clip.length);
        loopSource.Play();
        Destroy(startSource.gameObject);

        float stopTime = duration - endSource.clip.length;

        yield return new WaitForSeconds(stopTime - startSource.clip.length);

        endSource.Play();

        LeanTween.value(gameObject, (vol) => endSource.volume = vol, 0f, 1f, 0.25f);
        LeanTween.value(gameObject, (vol) => loopSource.volume = vol, 1f, 0f, 0.25f);

        yield return new WaitForSeconds(endSource.clip.length);

        Destroy(loopSource.gameObject);
        Destroy(endSource.gameObject);
    }

    private AudioSource createSoundSource()
    {
        //create a new child object with a audio source component
        GameObject newMusicObj = new GameObject("Sound Source");
        newMusicObj.transform.SetParent(transform, false);

        AudioSource musicSource = newMusicObj.AddComponent<AudioSource>();
        musicSource.volume = 0.0f;
        musicSource.playOnAwake = false;

        return musicSource;
    }
}
