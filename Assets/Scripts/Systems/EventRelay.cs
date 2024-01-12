using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EventRelay : Singleton
{
    public static SpawnEventClass Spawner { get; private set; }
    public static ShooterEventClass Shooter { get; private set; }
    public static InputEventClass Input { get; private set; }
    public static DiceEventClass Dice { get; private set; }
    private void Awake()
    {
        Spawner = new();
        Shooter = new();
        Input = new();
        Dice = new();
    }

}

public class SpawnEventClass
{
    public UnityEvent Spawn = new();
}

public class ShooterEventClass
{
    public UnityEvent DiceShot = new();
    public UnityEvent EmptyShooter = new();
}

public class InputEventClass
{
    public UnityEvent PointerDown = new();
    public UnityEvent PointerUp = new();
}

public class DiceEventClass
{
    public UnityEvent<int, Transform> Combination;
}