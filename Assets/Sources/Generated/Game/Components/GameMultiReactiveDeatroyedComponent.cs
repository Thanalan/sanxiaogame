//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly MultiReactive.DeatroyedComponent multiReactiveDeatroyedComponent = new MultiReactive.DeatroyedComponent();

    public bool isMultiReactiveDeatroyed {
        get { return HasComponent(GameComponentsLookup.MultiReactiveDeatroyed); }
        set {
            if (value != isMultiReactiveDeatroyed) {
                var index = GameComponentsLookup.MultiReactiveDeatroyed;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : multiReactiveDeatroyedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity : IMultiReactiveDeatroyedEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMultiReactiveDeatroyed;

    public static Entitas.IMatcher<GameEntity> MultiReactiveDeatroyed {
        get {
            if (_matcherMultiReactiveDeatroyed == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MultiReactiveDeatroyed);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMultiReactiveDeatroyed = matcher;
            }

            return _matcherMultiReactiveDeatroyed;
        }
    }
}
