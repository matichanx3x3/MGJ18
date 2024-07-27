using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
        [SerializeField] private AudioMixer[] mixerFase;
        [SerializeField] private Sound[] sounds;

        public static SoundManager Instance;
        private Sound instanceSound;

        private int currentFase;
        private bool increment;
        private float volumeMusic;
        private string nameMixer;

        private bool stop;
        private string currentSound;

        private bool decrease;
        private bool decrease2;
        private float volumeMixer1;

        void Awake() {
            if (Instance != null) {
				Destroy(gameObject);
			}
			else {
				Instance = this;
				DontDestroyOnLoad(gameObject);
			}

            foreach (Sound s in sounds) {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.loop = s.loop;

                s.source.outputAudioMixerGroup = s.mixerGroup;
            }
        }

        void Update() {
            if (stop) {
                instanceSound.source.volume -= Time.deltaTime;

                if (instanceSound.source.volume == 0f) {
					instanceSound.source.Stop();
					stop = false;
				}
            }

            if (increment) {
                volumeMusic += Time.deltaTime * 90;
                mixerFase[currentFase].SetFloat(nameMixer, volumeMusic);

                if (volumeMusic >= 0f) {
                    volumeMusic = 0;
                    increment = false;
                }
            }

            if(decrease) {
                volumeMixer1 -= Time.deltaTime * 20;
                mixerFase[0].SetFloat("Master1Volume", volumeMixer1);

                if(volumeMixer1 <= -80) {
                    decrease = false;
                }
            }

            if (decrease2) {
                volumeMixer1 -= Time.deltaTime * 20;
                mixerFase[1].SetFloat("Master2Volume", volumeMixer1);

                if (volumeMixer1 <= -80) {
                    decrease2 = false;
                }
            }
        }

        public void PlayMusic(string sound) {
            Sound s = Array.Find(sounds, item => item.name == sound);
            if (s == null) {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }

            if (currentSound == sound) return;

            //s.source.playOnAwake = false;

            s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
            s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

            s.source.Play();
            currentSound = sound;
        }

        public void PlaySFX(string sound) {
            Sound s = Array.Find(sounds, item => item.name == sound);
            if (s == null) {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }

            //if (currentSound == sound) return;

            s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
            s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

            s.source.Play();
            currentSound = sound;
        }

        public void Stop(string sound) {
            Sound s = Array.Find(sounds, item => item.name == sound);
            if (s == null) {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }

            instanceSound = s;
            stop = true;
        }

        public void InstantStop(string sound)
        {
            Sound s = Array.Find(sounds, item => item.name == sound);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }

            s.source.Stop();
        }

        public void IncrementSound(string mixer) {
            volumeMusic = -80;
            nameMixer = mixer;
            //increment = true;
            mixerFase[currentFase].SetFloat(nameMixer, 0);
        }

        public void SetFaseMixer(int value) {
            currentFase = value;
        }

        public void StopMixer1() {
            decrease = true;
            //mixerFase[0].SetFloat("Master1Volume", -80f);
        }

        public void StopMixer2() {
            decrease2 = true;
            volumeMixer1 = 0f;
        }
    

}
