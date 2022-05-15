using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


    public enum SE
    {
        CLICK = 0,
        PRESS1 = 1,
        PRESS2 = 2,
        PRESS3 = 3,
        PRESS4 = 4,
        PRESS6 = 5,
        PRESS7 = 6,
        PRESS8 = 7
    }
    public enum BGM
    {
        INGAME = 0,
        MENU = 1,
        END=2,
        GAMEOVER=3
    }

    public enum BGS
    {
        APPROACH1 = 0,
        APPROACH2 = 1
    }

    public enum ME
    {
        BELL1 = 0,
        BELL2 = 1,
        BELL3 = 2,
        DRILL = 3,
        EFFECT2 = 4,
        EVENT = 5,
        GAMEOVER=6,
        SLICE=7
    }
    public static class SoundController
    {

        public static void playSE(SE sound)
        {

            foreach (var item in SoundAssets.Instance.Au)
            {
                if (item.sound == SoundTypes.SE && !item.source.isPlaying)
                {
                    item.source.PlayOneShot(getSEClip(sound)); break;
                }
            }


        }

   
        public static void playME(ME sound)
        {

            foreach (var item in SoundAssets.Instance.Au)
            {
                if (item.sound == SoundTypes.ME && !item.source.isPlaying)
                {
                    item.source.PlayOneShot(getMEClip(sound)); break;
                }
            }


        }
        public static void playBGM(BGM sound, bool loop)
        {
            SoundAssets.Instance.BGMSource.loop = loop;
            SoundAssets.Instance.setVolume();
            SoundAssets.Instance.BGMSource.clip = getBGMClip(sound);
            SoundAssets.Instance.BGMSource.Play();

        }
        public static void playBGS(BGS sound, bool loop)
        {
            
                SoundAssets.Instance.BGSSource.loop = loop;
                SoundAssets.Instance.setVolume();
                SoundAssets.Instance.BGSSource.clip = getBGSClip(sound);
                SoundAssets.Instance.BGSSource.Play();
            

        }

        public static bool isBGSPlaying() {
            return SoundAssets.Instance.BGSSource.isPlaying;
        }
        public static void stopBGM()
        {
            SoundAssets.Instance.BGMSource.Stop();
        }

        public static void stopBGS() {
            SoundAssets.Instance.BGSSource.Stop();
        }
        public static AudioClip getBGSClip(BGS sound)
        {
            return SoundAssets.Instance.BGSAudioClips[(int)sound].audioClip;
        }

        public static AudioClip getMEClip(ME sound)
        {
            return SoundAssets.Instance.MEAudioClips[(int)sound].audioClip;
        }
        public static AudioClip getSEClip(SE sound)
        {
            return SoundAssets.Instance.SEAudioClips[(int)sound].audioClip;
        }

        public static AudioClip getBGMClip(BGM sound)
        {
            return SoundAssets.Instance.BGMAudioClips[(int)sound].audioClip;
        }
    }
