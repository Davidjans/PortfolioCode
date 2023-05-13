using UnityEngine;

public class ModeManager : MonoBehaviour
{
    private static ModeManager instance; // singleton instance of the manager

    public static ModeManager Instance // property for accessing the singleton instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ModeManager>();
                if (instance != null)
                    return instance;
                // If there is no existing instance, create a new GameObject with the ModeManager component
                GameObject go = new GameObject("ModeManager");
                instance = go.AddComponent<ModeManager>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }

    public enum Mode // the available modes
    {
        VRMode,
        FlatScreenMode
    }
    public Mode currentMode = Mode.FlatScreenMode; // the current mode
}