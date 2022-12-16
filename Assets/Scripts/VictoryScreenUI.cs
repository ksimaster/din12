using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreenUI : MonoBehaviour
{
    public void RespawnButton()
    {
        PlayerStatHUD.psh.ResetToGoZen();
        SceneManager.LoadScene("ZenGarden");
    }

    public void TitlescreenButton()
    {
        PlayerStatHUD.psh.ResetToGoZen();
        SceneManager.MoveGameObjectToScene(PlayerStatHUD.psh.gameObject, SceneManager.GetActiveScene());
        SceneManager.LoadScene("StartMenu");
    }

    public void MoveOnButton()
    {
        PlayerStatHUD.psh.ResetToGoZen();
        SceneManager.MoveGameObjectToScene(PlayerStatHUD.psh.gameObject, SceneManager.GetActiveScene());
        SceneManager.LoadScene("Ending");
    }
}