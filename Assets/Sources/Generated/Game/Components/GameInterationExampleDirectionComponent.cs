//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public InterationExample.DirectionComponent interationExampleDirection { get { return (InterationExample.DirectionComponent)GetComponent(GameComponentsLookup.InterationExampleDirection); } }
    public bool hasInterationExampleDirection { get { return HasComponent(GameComponentsLookup.InterationExampleDirection); } }

    public void AddInterationExampleDirection(float newDirection) {
        var index = GameComponentsLookup.InterationExampleDirection;
        var component = (InterationExample.DirectionComponent)CreateComponent(index, typeof(InterationExample.DirectionComponent));
        component.direction = newDirection;
        AddComponent(index, component);
    }

    public void ReplaceInterationExampleDirection(float newDirection) {
        var index = GameComponentsLookup.InterationExampleDirection;
        var component = (InterationExample.DirectionComponent)CreateComponent(index, typeof(InterationExample.DirectionComponent));
        component.direction = newDirection;
        ReplaceComponent(index, component);
    }

    public void RemoveInterationExampleDirection() {
        RemoveComponent(GameComponentsLookup.InterationExampleDirection);
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

    static Entitas.IMatcher<GameEntity> _matcherInterationExampleDirection;

    public static Entitas.IMatcher<GameEntity> InterationExampleDirection {
        get {
            if (_matcherInterationExampleDirection == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InterationExampleDirection);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInterationExampleDirection = matcher;
            }

            return _matcherInterationExampleDirection;
        }
    }
}
