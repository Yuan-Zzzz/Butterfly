using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("音量设置")]
    public float maxVolume = 1.0f;
    public float fadeDuration = 1.0f;

    private AudioSource audioSource;

    private void Awake()
    {
        // 单例
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.volume = 0;
    }

    /// <summary>
    /// 播放音乐（带渐入）
    /// </summary>
    public void PlayMusic(AudioClip clip)
    {
        StartCoroutine(FadeInMusic(clip));
    }

    /// <summary>
    /// 停止音乐（带渐出）
    /// </summary>
    public void StopMusic()
    {
        StartCoroutine(FadeOutMusic());
    }
    /// <summary>
    /// 音量先淡出，等待 duration 后再淡入
    /// </summary>
    public void MuteTransition(float fadeDuration, float waitDuration)
    {
        StartCoroutine(MuteAndUnmuteRoutine(fadeDuration, waitDuration));
    }

    private IEnumerator MuteAndUnmuteRoutine(float fadeDuration, float waitDuration)
    {
        float startVolume = audioSource.volume;

        // 淡出音量
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, t / fadeDuration);
            yield return null;
        }
        audioSource.volume = 0f;

        // 等待设定时长（例如转场时间）
        yield return new WaitForSeconds(waitDuration);

        // 淡入音量
        t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0f, startVolume, t / fadeDuration);
            yield return null;
        }
        audioSource.volume = startVolume;
    }


    private IEnumerator FadeInMusic(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();

        float timer = 0f;
        while (timer < fadeDuration)
        {
            audioSource.volume = Mathf.Lerp(0, maxVolume, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }
        audioSource.volume = maxVolume;
    }

    private IEnumerator FadeOutMusic()
    {
        float startVolume = audioSource.volume;
        float timer = 0f;
        while (timer < fadeDuration)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = 0;
    }

    /// <summary>
    /// 切换音乐（带交叉渐变）
    /// </summary>
    public void CrossFade(AudioClip newClip)
    {
        StartCoroutine(CrossFadeRoutine(newClip));
    }

    private IEnumerator CrossFadeRoutine(AudioClip newClip)
    {
        yield return FadeOutMusic();
        PlayMusic(newClip);
    }
}

public class Bootstrap : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        // 如果还没加载音频场景，加载它（Additive 模式）
        if (!SceneManager.GetSceneByName("AudioScene").isLoaded)
        {
            SceneManager.LoadSceneAsync("AudioScene", LoadSceneMode.Additive);
        }
    }
}
