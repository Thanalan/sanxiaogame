//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public InterationExample.PositionComponent interationExamplePosition { get { return (InterationExample.PositionComponent)GetComponent(GameComponentsLookup.InterationExamplePosition); } }
    public bool hasInterationExamplePosition { get { return HasComponent(GameComponentsLookup.InterationExamplePosition); } }

    public void AddInterationExamplePosition(UnityEngine.Vector2 newPostion) {
        var index = GameComponentsLookup.InterationExamplePosition;
        var component = (InterationExample.PositionComponent)CreateComponent(index, typeof(InterationExample.PositionComponent));
        component.postion = newPostion;
        AddComponent(index, component);
    }

    public void ReplaceInterationExamplePosition(UnityEngine.Vector2 newPostion) {
        var index = GameComponentsLookup.InterationExamplePosition;
        var component = (InterationExample.PositionComponent)CreateComponent(index, typeof(InterationExample.PositionComponent));
        component.postion = newPostion;
        ReplaceComponent(index, component);
    }

    public void RemoveInterationExamplePosition() {
        RemoveComponent(GameComponentsLookup.InterationExamplePosition);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherInterationExamplePosition;

    public static Entitas.IMatcher<GameEntity> InterationExamplePosition {
        get {
            if (_matcherInterationExamplePosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InterationExamplePosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInterationExamplePosition = matcher;
            }

            return _matcherInterationExamplePosition;
        }
    }
}
