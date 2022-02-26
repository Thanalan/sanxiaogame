using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 音效视图部分
    /// </summary>
    public class AudioView : MonoBehaviour,IGameAudioListener,IView
    {
        private AudioSource _audioSource;

        public void OnGameAudio(GameEntity entity, string path)
        {
            if (_audioSource == null)
            {
                _audioSource = gameObject.AddComponent<AudioSource>();
            }

            _audioSource.clip = Resources.Load<AudioClip>(ResPath.AudioPath + path);
            _audioSource.Play();
        }

        public void Link(IEntity entity, IContext contex)
        {
            GameEntity gameEntity = entity as GameEntity;
            if(gameEntity != null) gameEntity.AddGameAudioListener(this);
        }
    }

}
