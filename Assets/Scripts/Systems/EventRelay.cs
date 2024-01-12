using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EventRelay : Singleton
{
    public static SpawnEventClass Spawner { get; private set; }
    public static MovementEventClass Movement { get; private set; }
    public static InputEventClass Input { get; private set; }
    private void Awake()
    {
        Spawner = new();
        Movement = new();
        Input = new();
    }

}

public class SpawnEventClass
{
    public UnityEvent Spawn = new();
}

public class MovementEventClass
{
    public UnityEvent Move = new();
    public UnityEvent Jump = new();
}

public class InputEventClass
{
    public UnityEvent PointerDown = new();
    public UnityEvent PointerUp = new();
}
