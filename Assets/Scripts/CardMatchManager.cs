using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardMatchManager : MonoBehaviour
{
    public GameObject[] currentCards;
    public GameObject[] foundCards;
    [SerializeField] public static bool canClick;
    public GameStateController gameStateController;

    // Start is called before the first frame update
    void Start()
    {
        canClick = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Constantly look for selected and found cards
        currentCards = GameObject.FindGameObjectsWithTag("Selected");
		foundCards = GameObject.FindGameObjectsWithTag("Found");

		// Compare cards when 2 cards are selected
		if (currentCards.Length == 2)
        {
            StartCoroutine( compareCards() );
        }

        // End game when all cards are found
        if (foundCards.Length == 16)
        {
            Debug.Log("Game Over");
            GameOver();
        }
    }

    IEnumerator compareCards()
    {
        // Gets the names of the selected cards
        var card1 = currentCards[0].GetComponent<Image>().sprite.name;
        var card2 = currentCards[1].GetComponent<Image>().sprite.name;

        if (card1 != card2)
        {
            canClick = false;
			yield return new WaitForSecondsRealtime(1f);
			foreach (var card in currentCards)
			{
				card.GetComponent<Image>().enabled = false;
				card.tag = "Untagged";
			}
            
			canClick = true;
		}
        else
        {
			foreach (var card in currentCards)
			{
				card.tag = "Found";
			}
			
		}
    }

    public bool canClickCards()
    {
        return canClick;
    }

    void GameOver()
    {
		foreach(var card in foundCards)
		{
			card.tag = "Untagged";
		}
		gameStateController.DisplayOverScene();
    }
}
