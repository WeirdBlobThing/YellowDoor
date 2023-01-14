using UnityEngine;

[CreateAssetMenu(fileName = "Room", menuName = "SCROBs/Room", order = 1)]
public class RoomSCROB : ScriptableObject
{
    public string Name;
    public string Creator;
    public string SceneName;
    public RoomDifficulty Difficulty;
}