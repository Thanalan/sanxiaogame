//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.ItemEffectState gameItemEffectState { get { return (Game.ItemEffectState)GetComponent(GameComponentsLookup.GameItemEffectState); } }
    public bool hasGameItemEffectState { get { return HasComponent(GameComponentsLookup.GameItemEffectState); } }

    public void AddGameItemEffectState(Game.ItemEffectName newState) {
        var index = GameComponentsLookup.GameItemEffectState;
        var component = (Game.ItemEffectState)CreateComponent(index, typeof(Game.ItemEffectState));
        component.state = newState;
        AddComponent(index, component);
    }

    public void ReplaceGameItemEffectState(Game.ItemEffectName newState) {
        var index = GameComponentsLookup.GameItemEffectState;
        var component = (Game.ItemEffectState)CreateComponent(index, typeof(Game.ItemEffectState));
        component.state = newState;
        ReplaceComponent(index, component);
    }

    public void RemoveGameItemEffectState() {
        RemoveComponent(GameComponentsLookup.GameItemEffectState);
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

    static Entitas.IMatcher<GameEntity> _matcherGameItemEffectState;

    public static Entitas.IMatcher<GameEntity> GameItemEffectState {
        get {
            if (_matcherGameItemEffectState == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameItemEffectState);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameItemEffectState = matcher;
            }

            return _matcherGameItemEffectState;
        }
    }
}
