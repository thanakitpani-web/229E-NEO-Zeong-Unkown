using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // ออกจาก Play Mode
#else
        Application.Quit(); // ออกจากเกมจริง
#endif
    }
}
/* UnityEngine;

public class UIManager : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }
}
*/