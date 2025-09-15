using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public Graph graph;                        // Dra in ditt Graph-objekt
    public SimulationController simulation;    // Dra in ditt SimulationController
    public TextMeshProUGUI startMenuText;      // Dra in en TMP-text i Canvas som visar instruktioner

    private bool gameStarted = false;

    void Start()
    {
        // Stoppa simuleringen och g�m grafen fr�n b�rjan
        simulation.enabled = false;
        graph.gameObject.SetActive(false);
        startMenuText.gameObject.SetActive(true);
    }

    void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Return)) // Enter = b�rja
        {
            gameStarted = true;
            simulation.enabled = true;
            graph.gameObject.SetActive(true);
            startMenuText.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // Esc = avsluta
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Avsluta i Unity Editor
#endif
        }
    }
}
