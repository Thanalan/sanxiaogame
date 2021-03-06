//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MultiReactiveNameListenerComponent multiReactiveNameListener { get { return (MultiReactiveNameListenerComponent)GetComponent(GameComponentsLookup.MultiReactiveNameListener); } }
    public bool hasMultiReactiveNameListener { get { return HasComponent(GameComponentsLookup.MultiReactiveNameListener); } }

    public void AddMultiReactiveNameListener(System.Collections.Generic.List<IMultiReactiveNameListener> newValue) {
        var index = GameComponentsLookup.MultiReactiveNameListener;
        var component = (MultiReactiveNameListenerComponent)CreateComponent(index, typeof(MultiReactiveNameListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMultiReactiveNameListener(System.Collections.Generic.List<IMultiReactiveNameListener> newValue) {
        var index = GameComponentsLookup.MultiReactiveNameListener;
        var component = (MultiReactiveNameListenerComponent)CreateComponent(index, typeof(MultiReactiveNameListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMultiReactiveNameListener() {
        RemoveComponent(GameComponentsLookup.MultiReactiveNameListener);
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

    static Entitas.IMatcher<GameEntity> _matcherMultiReactiveNameListener;

    public static Entitas.IMatcher<GameEntity> MultiReactiveNameListener {
        get {
            if (_matcherMultiReactiveNameListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MultiReactiveNameListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMultiReactiveNameListener = matcher;
            }

            return _matcherMultiReactiveNameListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddMultiReactiveNameListener(IMultiReactiveNameListener value) {
        var listeners = hasMultiReactiveNameListener
            ? multiReactiveNameListener.value
            : new System.Collections.Generic.List<IMultiReactiveNameListener>();
        listeners.Add(value);
        ReplaceMultiReactiveNameListener(listeners);
    }

    public void RemoveMultiReactiveNameListener(IMultiReactiveNameListener value, bool removeComponentWhenEmpty = true) {
        var listeners = multiReactiveNameListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveMultiReactiveNameListener();
        } else {
            ReplaceMultiReactiveNameListener(listeners);
        }
    }
}
