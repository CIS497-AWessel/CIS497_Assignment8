/* Anthony Wessel
 * Assignment 8 Prototype 5
 * 
 * Starts the game with a specific difficulty
 */

using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    GameManager gameManager;

    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);

        gameManager = FindObjectOfType<GameManager>();
    }

    void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
