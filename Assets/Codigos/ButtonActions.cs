using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Nivel_1");
    }
}
