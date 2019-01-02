using UnityEngine;

public class HitSound : MonoBehaviour
{
    //音楽ファイル
    [SerializeField] AudioClip[] audios;
    //音を鳴らすコンポー
    AudioSource audioSource;
    //外部読み出し用
    public static HitSound main;

    void Start()
    {
        main = this;
        audioSource = GetComponent<AudioSource>();
    }

    //鳴らす
    public void PlaySound(int no)
    {
        audioSource.clip = audios[no];
        audioSource.Play();
    }
}
