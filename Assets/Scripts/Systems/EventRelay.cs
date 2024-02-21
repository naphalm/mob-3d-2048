using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EventRelay : Singleton
{
    public static SpawnEventClass Spawner { get; private set; }
    public static ShooterEventClass Shooter { get; private set; }
    public static InputEventClass Input { get; private set; }
    public static DiceEventClass Dice { get; private set; }
    public static GameManagerEvents GameManager { get; private set; }
    public static BoardEventClass Board { get; private set; }
    public static ScreenEventClass Screen { get; private set; }
    private void Awake()
    {
        Spawner = new();
        Shooter = new();
        Input = new();
        Dice = new();
        GameManager = new();
        Board = new();
        Screen = new();
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
    public UnityEvent<int, DiceController> Combination = new();
    public UnityEvent<int> DiceValueChanged = new();
}

public class BoardEventClass
{
    public UnityEvent<int> QueueIncrease = new();
    public UnityEvent<int> BiggestDice = new();
    public UnityEvent<int> Bonus = new();
    public UnityEvent ResetBonus = new();

}
public class GameManagerEvents
{
    public UnityEvent Replay = new();
    public UnityEvent Death = new();
    public UnityEvent RewardedContinue = new();
    public UnityEvent ContinueEnded = new();

}

public class ScreenEventClass
{
    public UnityEvent LandscapeMode = new();
    public UnityEvent PortraitMode = new();
}