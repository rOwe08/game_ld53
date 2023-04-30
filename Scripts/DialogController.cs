using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public GameObject dialogPopup;
    public Text dialogText;
    public Button closeButton;
    public bool isClosed = false;
    private string firstMessage = "\r\nWelcome to the first level of \"MindWave: Unraveling Memories,\" an immersive puzzle-adventure game that invites you to embark on a captivating journey to recover Luna's lost memories. As you begin this level, you will encounter a series of intriguing challenges set within a mysterious, futuristic room. With each puzzle you solve, Luna will gradually regain fragments of her past, eventually piecing together her life story. Guided by the enigmatic voice of her long-lost friend, Max, your journey will uncover secrets, friendship, and self-discovery. So, let's dive into the adventure and help Luna unravel the mysteries hidden within her mind!";
    private string secondMessage = "To navigate through the puzzles in \"MindWave: Unraveling Memories,\" simply use the point-and-click control system. Click on the free tiles directly to Luna's left, right, up, or down to move her. Remember, you can only interact with adjacent free tiles. Good luck, and enjoy the game!";
    void Start()
    {
        closeButton.onClick.AddListener(CloseDialog);
        dialogPopup.SetActive(false);
        ShowDialog(firstMessage);
    }

    public void ShowDialog(string message)
    {
        dialogText.text = message;
        dialogPopup.SetActive(true);
    }

    public void CloseDialog()
    {
        dialogPopup.SetActive(false);
        isClosed = true;
    }
}

