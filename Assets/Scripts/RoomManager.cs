using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public enum RoomDifficulty
{
    Easy,
    Medium,
    Hard,
    Expert
}

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;

    private RoomSCROB[] m_rooms;

    private void Awake()
    {
        Instance = this;
        m_rooms = Resources.LoadAll<RoomSCROB>("Rooms");
    }

    public void LoadNewRoom(RoomDifficulty difficulty)
    {
        var matches = m_rooms.Where(room => room.Difficulty == difficulty).ToList<RoomSCROB>();

        if (matches.Count() == 0)
        {
            Debug.LogErrorFormat("No '{0}' Rooms Found!", difficulty);
            return;
        }

        var match = matches[Random.Range(0, matches.Count())];
        SceneManager.LoadSceneAsync(match.SceneName, LoadSceneMode.Single);
    }
}
