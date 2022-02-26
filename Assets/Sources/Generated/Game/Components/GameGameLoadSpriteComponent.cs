//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.LoadSprite gameLoadSprite { get { return (Game.LoadSprite)GetComponent(GameComponentsLookup.GameLoadSprite); } }
    public bool hasGameLoadSprite { get { return HasComponent(GameComponentsLookup.GameLoadSprite); } }

    public void AddGameLoadSprite(string newName) {
        var index = GameComponentsLookup.GameLoadSprite;
        var component = (Game.LoadSprite)CreateComponent(index, typeof(Game.LoadSprite));
        component.name = newName;
        AddComponent(index, component);
    }

    public void ReplaceGameLoadSprite(string newName) {
        var index = GameComponentsLookup.GameLoadSprite;
        var component = (Game.LoadSprite)CreateComponent(index, typeof(Game.LoadSprite));
        component.name = newName;
        ReplaceComponent(index, component);
    }

    public void RemoveGameLoadSprite() {
        RemoveComponent(GameComponentsLookup.GameLoadSprite);
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

    static Entitas.IMatcher<GameEntity> _matcherGameLoadSprite;

    public static Entitas.IMatcher<GameEntity> GameLoadSprite {
        get {
            if (_matcherGameLoadSprite == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameLoadSprite);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameLoadSprite = matcher;
            }

            return _matcherGameLoadSprite;
        }
    }
}