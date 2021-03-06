//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity gameScoreEntity { get { return GetGroup(GameMatcher.GameScore).GetSingleEntity(); } }
    public Game.Score gameScore { get { return gameScoreEntity.gameScore; } }
    public bool hasGameScore { get { return gameScoreEntity != null; } }

    public GameEntity SetGameScore(int newScore) {
        if (hasGameScore) {
            throw new Entitas.EntitasException("Could not set GameScore!\n" + this + " already has an entity with Game.Score!",
                "You should check if the context already has a gameScoreEntity before setting it or use context.ReplaceGameScore().");
        }
        var entity = CreateEntity();
        entity.AddGameScore(newScore);
        return entity;
    }

    public void ReplaceGameScore(int newScore) {
        var entity = gameScoreEntity;
        if (entity == null) {
            entity = SetGameScore(newScore);
        } else {
            entity.ReplaceGameScore(newScore);
        }
    }

    public void RemoveGameScore() {
        gameScoreEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.Score gameScore { get { return (Game.Score)GetComponent(GameComponentsLookup.GameScore); } }
    public bool hasGameScore { get { return HasComponent(GameComponentsLookup.GameScore); } }

    public void AddGameScore(int newScore) {
        var index = GameComponentsLookup.GameScore;
        var component = (Game.Score)CreateComponent(index, typeof(Game.Score));
        component.score = newScore;
        AddComponent(index, component);
    }

    public void ReplaceGameScore(int newScore) {
        var index = GameComponentsLookup.GameScore;
        var component = (Game.Score)CreateComponent(index, typeof(Game.Score));
        component.score = newScore;
        ReplaceComponent(index, component);
    }

    public void RemoveGameScore() {
        RemoveComponent(GameComponentsLookup.GameScore);
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

    static Entitas.IMatcher<GameEntity> _matcherGameScore;

    public static Entitas.IMatcher<GameEntity> GameScore {
        get {
            if (_matcherGameScore == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameScore);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameScore = matcher;
            }

            return _matcherGameScore;
        }
    }
}
