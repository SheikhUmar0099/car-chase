using UnityEngine;
using UnityEngine.UI;

public class scoreUpdate : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    public int scoreMultiplier = 1; // Initial score multiplier

    public int score = 0;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "" + score;
        // No need to find the Text component if it's attached in the Unity Editor
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            score += 1 * scoreMultiplier;
            scoreText.text = "" + score;
            timer = 0;
        }
        // Increase the score based on deltaTime and scoreMultiplier

        // Update the scoreText to display the updated score


    }
}
