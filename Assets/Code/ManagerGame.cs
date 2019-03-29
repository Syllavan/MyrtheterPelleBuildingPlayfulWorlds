using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerGame : MonoBehaviour
{
    bool gameHasEnded = false;

    public int currentSouls;

    public float restartDelay = 1f;
    public Text soulText;

    public void EndGame ()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddSoul(int soulsToAdd)
    {
        currentSouls += soulsToAdd;
        soulText.text = "Souls " + currentSouls;
    }
}
