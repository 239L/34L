using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

    public enum SoundTypes {
        BGM,
        ME,
        SE,
        BGS
    }
    public class SoundAssets : MonoBehaviour
    {
        private static SoundAssets instance;
        public AudioMixer am;
        public static SoundAssets Instance {
            get { return instance; }

        }

        [SerializeField] FloatValue bgmVolume;
        [SerializeField] FloatValue seVolume;
        [SerializeField] FloatValue volume;

        private void Awake()
        {
            if (instance == null) { instance = this; }
            else { Destroy(this); }

            DontDestroyOnLoad(gameObject);

            setVolume();
        }
        void Start()
        {

        }

        public void setVolume() {

            am.SetFloat("Vol", Mathf.Log10(volume.value) * 20);
            am.SetFloat("BGMVol", Mathf.Log10(bgmVolume.value) * 20);
            am.SetFloat("SEVol", Mathf.Log10(seVolume.value) * 20);

        }

        // Update is called once per frame
        void Update()
        {

        }

        [SerializeField]
        List<SEAudioClip> seAudioClips;
        [SerializeField]
        List<BGMAudioClip> bgmAudioClips;
        [SerializeField]
        List<BGSAudioClip> bgsAudioClips;
        [SerializeField]
        List<MEAudioClip> meAudioClips;
        public List<SEAudioClip> SEAudioClips {
            get { return seAudioClips; }
        }

        public List<BGMAudioClip> BGMAudioClips
        {
            get { return bgmAudioClips; }
        }

        public List<BGSAudioClip> BGSAudioClips
        {
            get { return bgsAudioClips; }
        }

        public List<MEAudioClip> MEAudioClips
        {
            get { return meAudioClips; }
        }

        [SerializeField]
        List<AudioSourceExtended> au;

        public List<AudioSourceExtended> Au
        {
            get { return au; }
        }
        [SerializeField]
        AudioSource bgmSource;

        public AudioSource BGMSource {
            get { return bgmSource; }
        }
        public AudioSource BGSSource
        {
            get { return bgsSource; }
        }

        [SerializeField]
        AudioSource bgsSource;

        [System.Serializable]
        public class AudioSourceExtended {
            public SoundTypes sound;
            public AudioSource source;
        }

        [System.Serializable]
        public class SEAudioClip {
            public SE sound;
            public AudioClip audioClip;
        }

        [System.Serializable]
        public class BGMAudioClip
        {
            public BGM sound;
            public AudioClip audioClip;
        }

        [System.Serializable]
        public class BGSAudioClip
        {
            public BGS sound;
            public AudioClip audioClip;
        }

        [System.Serializable]
        public class MEAudioClip
        {
            public ME sound;
            public AudioClip audioClip;
        }

    }
