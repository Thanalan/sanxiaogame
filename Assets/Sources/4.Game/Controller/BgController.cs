using System.Collections;
using System.Collections.Generic;
using Entitas.Unity;
using UnityEngine;

namespace Game
{
    public class BgController : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            var entity = Contexts.sharedInstance.game.CreateEntity();
            IView audio = gameObject.AddComponent<AudioView>();

            gameObject.Link(entity, Contexts.sharedInstance.game);
            audio.Link(entity, Contexts.sharedInstance.game);

            entity.ReplaceGameAudio(AudioName.Bg.ToString());
        }
    }
}

