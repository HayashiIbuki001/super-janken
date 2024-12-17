using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JankenButton : MonoBehaviour
{
    public Button buttonRock;
    public Button buttonScissors;
    public Button buttonPaper;

    public Text playerChoiceText;  // プレイヤーの選択を表示するText
    public Text enemyChoiceText;     // CPUの選択を表示するText
    public Text resultText;        // 勝敗を表示するText
    void Start()
    {
        // ボタンを押したときの処理
        buttonRock.onClick.AddListener(() => ButtonClicked(1)); // Rock(1)
        buttonScissors.onClick.AddListener(() => ButtonClicked(2)); // Scissors(2)
        buttonPaper.onClick.AddListener(() => ButtonClicked(3)); // Paper(3)
    }

    public void ButtonClicked(int value)
    {
        int playerChoice = value;
        playerChoiceText.text = $"Player: {GetChoiceName(playerChoice)}";

        int enemyChoice = Random.Range(1, 4);
        enemyChoiceText.text = $"Enemy: {GetChoiceName(enemyChoice)}";

        JudgeResult(playerChoice, enemyChoice);
    }

    private void JudgeResult(int player, int enemy)
    {
        // 勝敗判定
        if (player == enemy)  // 引き分け
        {
            resultText.text = "Result: Draw";
        }
        else if ((player == 1 && enemy == 2) || (player == 2 && enemy == 3) || (player == 3 && enemy == 1))  // プレイヤーが勝ち
        {
            resultText.text = "Result: Player Wins!";
        }
        else  // CPUが勝ち
        {
            resultText.text = "Result: Enemy Wins!";
        }
    }


    /// <summary> 値を名前に変更する </summary>
    /// <param name="choice">int 1 = Rock, 2 = Scissors, 3 = paper</param>
    /// <returns></returns>
    private string GetChoiceName(int choice)
    {
        switch (choice)
        {
            case 1: return "Rock";
            case 2: return "Scissors";
            case 3: return "Paper";
            default: return "Unknown";
        }
    }
}
