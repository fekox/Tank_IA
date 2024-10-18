using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Directions
{
    Wait,
    Walk,
    Gather,
    Eat,
    WaitFood,
    WaitGold,
    Deliver,
    Alarm
}

public enum Flags
{
    OnReachTarget,
    OnReachMine,
    OnReachHome,
    OnWait,
    OnGather,
    OnGoldFull,
    OnHunger,
    OnNoFoodOnMine,
    OnNoGoldOnMine,
    OnFoodFull,
    OnFoodEmpty,
    OnGoToTarget,
    OnGoToNewTarget,
    OnAlarmActive,
    OnAlarmDesactiveOnHome,
    OnAlarmDesactiveAutHome,
}

public class GameManager : MonoBehaviour
{

}