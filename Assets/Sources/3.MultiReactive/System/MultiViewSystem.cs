using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using MultiReactive;
using UnityEngine;

namespace MultiReactive
{
    public class MultiViewSystem : MultiReactiveSystem<IViewSystem, Contexts>
    {
        private Dictionary<string, Transform> _parentDic;
        private Contexts _contexts;

        public MultiViewSystem(Contexts contexts) : base(contexts)
        {
            _contexts = contexts;
            _parentDic = new Dictionary<string, Transform>();
            foreach (var context in contexts.allContexts)
            {
                string name = context.contextInfo.name;
                _parentDic[name] = new GameObject(name + "ViewParent").transform;
            }
        }

        protected override ICollector[] GetTrigger(Contexts contexts)
        {
            return new ICollector[]
            {
                contexts.game.CreateCollector(GameMatcher.MultiReactiveView),
                contexts.input.CreateCollector(InputMatcher.MultiReactiveView),
                contexts.ui.CreateCollector(UiMatcher.MultiReactiveView)
            };
        }

        protected override bool Filter(IViewSystem entity)
        {
            return !entity.hasMultiReactiveView;
        }

        protected override void Execute(List<IViewSystem> entities)
        {
            foreach (IViewSystem entity in entities)
            {
                string name = entity.contextInfo.name;
                var go = new GameObject(name + "View");
                go.transform.SetParent(_parentDic[name]);
                entity.AddMultiReactiveView(go.transform);
                go.Link(entity, _contexts.GetContextByName(name));
            }
        }
    }
    public interface IViewSystem : IEntity, IMultiReactiveViewEntity { }

    public static class ContextExtention
    {
        private static readonly Dictionary<string, IContext> _contextsDic = new Dictionary<string, IContext>();

        public static IContext GetContextByName(this Contexts contexts, string name)
        {
            InitDic(contexts);
            return _contextsDic[name];
        }

        private static void InitDic(Contexts contexts)
        {
            foreach (IContext context in contexts.allContexts)
            {
                _contextsDic[context.contextInfo.name] = context;
            }
        }
    }
}

public partial class GameEntity : IViewSystem { }
public partial class InputEntity : IViewSystem { }
public partial class UiEntity : IViewSystem { }
