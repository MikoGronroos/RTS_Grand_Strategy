using System;
using System.Collections.Generic;
using UnityEngine;

public class StatesDictionary : MonoBehaviour
{

    [SerializeField] private List<State> states = new List<State>();

    private static Dictionary<int, State> statesDictionary = new Dictionary<int, State>();

    private static Action<State> OnStateAdded;

    private void OnEnable()
    {
        OnStateAdded += AddStateToList;
    }

    private void OnDisable()
    {
        OnStateAdded -= AddStateToList;
    }

    private void AddStateToList(State state)
    {
        states.Add(state);
    }

    public static void AddToDictionary(State state)
    {
        statesDictionary.Add(state.StateID, state);
        OnStateAdded?.Invoke(state);
    }

    public static State GetStateFromDictionary(int id)
    {
        return statesDictionary[id];
    }


}
