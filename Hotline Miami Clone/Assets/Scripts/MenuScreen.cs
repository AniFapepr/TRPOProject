using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScreen : MonoBehaviour
{
    float originalWidth = 1444.0f;
    float originalHeight = 900.0f;
    Vector3 scale;

    public GUIStyle text, titleText, titleShadow;
    public Texture2D bg;

    bool playSelect = true, exitSelect = false, play = false, menu = true;
    public LevelStore[] levels;
    int levelSelectCount = 0;
    // Update is called once per frame
    void Update()
    {
        inputController();
    }
    void inputController()
    {
        if (menu == true)
        {
            if (Input.GetKeyDown(KeyCode.S) && playSelect == true || Input.GetKeyDown(KeyCode.W) && playSelect == true)
            {
                exitSelect = true;
                playSelect = false;
            }
            else if (Input.GetKeyDown(KeyCode.S) && exitSelect == true || Input.GetKeyDown(KeyCode.W) && exitSelect == true)
            {
                exitSelect = false;
                playSelect = true;
            }
            if (Input.GetKeyDown(KeyCode.Return) && playSelect == true)
            {
                menu = false;
                play = true;
            }
            else if (Input.GetKeyDown(KeyCode.Return) && exitSelect == true)
            {
                Application.Quit();
            }
        }
        else if (play == true)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                play = false;
                menu = true;
            }
            if (Input.GetKeyDown(KeyCode.D) && levelSelectCount < levels.Length - 1)
            {
                levelSelectCount++;
            }
            if (Input.GetKeyDown(KeyCode.A) && levelSelectCount > 0)
            {
                levelSelectCount--;
            }
            if (Input.GetKeyDown(KeyCode.Return) && levels[levelSelectCount].unlocked == true)
            {
                SceneManager.LoadScene(levels[levelSelectCount].sceneManagerName);
            }
        }
    }
    void OnGUI()
    {
        GUI.depth = 0;
        scale.x = Screen.width / originalWidth;
        scale.y = Screen.height / originalHeight;
        scale.z = 1;
        var svMat = GUI.matrix;
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
        Rect titlePos = new Rect(originalWidth / 2 - 400, originalHeight - originalHeight, 800, 300);
        if (menu == true)
        {
            play = false;
            titlePos = new Rect(originalWidth / 2 - 400, originalHeight - originalHeight, 800, 300);
            GUI.Box(titlePos, "Hotline Miami", titleShadow);
            titlePos = new Rect(originalWidth / 2 - 405, originalHeight - originalHeight - 5, 800, 300);
            GUI.Box(titlePos, "Hotline Miami", titleText);
            Rect menuPos = new Rect(originalWidth / 2 - 400, originalHeight - originalHeight + 400, 800, 200);
            if (playSelect == true)
            {
                GUI.DrawTexture(menuPos, bg);
                GUI.Box(menuPos, "Play", text);
            }
            else if (playSelect == false)
            {
                GUI.Box(menuPos, "Play", text);
            }

            Rect exitPos = new Rect(originalWidth / 2 - 400, originalHeight - originalHeight + 700, 800, 200);
            if (exitSelect == true)
            {
                GUI.DrawTexture(exitPos, bg);
                GUI.Box(exitPos, "Exit", text);
            }
            else if (exitSelect == false)
            {
                GUI.Box(exitPos, "Exit", text);
            }
        }
        else if (play == true)
        {
            Rect backToRet = new Rect(originalWidth - originalWidth + 200, originalHeight - 200, 800, 200);
            GUI.DrawTexture(backToRet, bg);
            GUI.Box(backToRet, "Press backspace to return to menu", text);

            titlePos = new Rect(originalWidth / 2 - 400, originalHeight - originalHeight, 800, 300);
            GUI.Box(titlePos, "Hotline Miami", titleShadow);

            titlePos = new Rect(originalWidth / 2 - 405, originalHeight - originalHeight - 5, 800, 300);
            GUI.Box(titlePos, "Hotline Miami", titleText);

            if (levels[levelSelectCount].unlocked == true)
            {
                Rect levelTitlePos = new Rect(originalWidth / 2 - 400, originalHeight - originalHeight + 200, 800, 200);
                GUI.Box(levelTitlePos, levels[levelSelectCount].levelName, text);
                levelTitlePos = new Rect(originalWidth / 2 - 250, originalHeight - originalHeight + 400, 500, 500);
                GUI.DrawTexture(levelTitlePos, levels[levelSelectCount].levelIcon);
            }
            else
            {
                Rect levelTitlePos = new Rect(originalWidth / 2 - 400, originalHeight - originalHeight + 200, 800, 200);
                GUI.Box(levelTitlePos, "Level Locked", text);
                levelTitlePos = new Rect(originalWidth / 2 - 250, originalHeight - originalHeight + 400, 500, 500);
                GUI.DrawTexture(levelTitlePos, bg);
            }
        }
        GUI.matrix = svMat;
    }
}