using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;


    public class SoundManager : MonoBehaviour
    {


        public const string BACKGROUND_MUSIC = "Background_Music";
        public const string RIGHT_SWIPE = "Right_Swipe";
        public const string PLAYER_LOST = "Player_Lost";
        public const string WRONG_SWIPE = "Wrong_Swipe";
      

        public Sound[] sounds;
        public Sprite[] volumeSprite;
        public Dictionary<string, Sound> soundLookUp = new Dictionary<string, Sound>();
        public static SoundManager instance;
        public bool isMute = false;

        void Awake()
        {
            instance = this;

            for (int i = 0; i < sounds.Length; i++)
            {
                Sound currentSound = sounds[i];
                currentSound.audioSource = gameObject.AddComponent<AudioSource>();
                currentSound.audioSource.clip = currentSound.clip;
                currentSound.audioSource.volume = currentSound.volume;
                currentSound.audioSource.pitch = currentSound.pitch;

                if (currentSound.name.Equals(BACKGROUND_MUSIC))
                    currentSound.audioSource.loop = true;

                soundLookUp.Add(currentSound.name, currentSound);
            }

        }

        

        public void Play(string soundName)
        {

            if (soundLookUp.ContainsKey(soundName))
            {
                soundLookUp[soundName].audioSource.Play();
                soundLookUp[soundName].isPlaying = true;
            }

        }

        public void Pause(string soundName)
        {
            if (soundLookUp.ContainsKey(soundName))
            {
                soundLookUp[soundName].audioSource.Stop();
                soundLookUp[soundName].isPlaying = false;
            }

        }

        public void MuteGame()
        {

            for (int i = 0; i < sounds.Length; i++)
            {
                sounds[i].audioSource.volume=0f;
            }
            isMute = true;

        }
        public void UnMuteGame()
        {

            for (int i = 0; i < sounds.Length; i++)
            {
                if (sounds[i].isPlaying)
                    sounds[i].audioSource.volume = sounds[i].volume;
            }
            isMute = false;
        }

        public void OnVolume(Button volume)
        {

            if (!SoundManager.instance.isMute)
            {
                volume.image.sprite = SoundManager.instance.volumeSprite[0];
                SoundManager.instance.MuteGame();
            }
            else
            {
                volume.image.sprite = SoundManager.instance.volumeSprite[1];
                SoundManager.instance.UnMuteGame();
            }

        }

        public void OnVolume(Text text)
        {

            if (!SoundManager.instance.isMute)
            {
                text.text = "Un-Mute";
                SoundManager.instance.MuteGame();
            }
            else
            {
                text.text = "Mute";
                SoundManager.instance.UnMuteGame();
            }

        }

        public void CheckMuteStatus(Button volume)
        {
      

            if (SoundManager.instance.isMute)
            {
                volume.image.sprite = SoundManager.instance.volumeSprite[0];
            }
            else
            {
                volume.image.sprite = SoundManager.instance.volumeSprite[1];
            }

        }

        public void CheckMuteStatus(Text text) {

            if (SoundManager.instance.isMute)
            {
                text.text = "Un-Mute";
            }
            else
            {
                text.text = "Mute";
            }
         
        }

    }

