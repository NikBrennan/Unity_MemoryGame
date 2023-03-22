using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSpawner : MonoBehaviour
{
    public GameObject cardPrefab;
    public int totalCards = 16;

	// Keep track of cards that are on the board
	public Dictionary<string, int> cards = new Dictionary<string, int>()
    {
		{"bean",0},
	    {"doraemon",0},
	    {"minion",0},
	    {"mouse",0},
	    {"noddy",0},
	    {"popeye",0},
	    {"scooby",0},
	    {"shinchan",0},
    };

	// Start is called before the first frame update
	void Start()
    {
        List<string> characters = new List<string>()
		{ 
			"bean",
			"doraemon",
			"minion",
			"mouse",
			"noddy",
			"popeye",
			"scooby",
			"shinchan"
		};

        for(int i = 0; i < totalCards; i++)
        {
            
			
			// Choose a random character from the characters array
			int randomCharacter = Random.Range(0, characters.Count);
			string charName = characters[randomCharacter];
			
			Sprite sprite = Resources.Load<Sprite>("Sprites/" + charName);
			cardPrefab.transform.GetChild(1).GetComponent<Image>().sprite = sprite;
			
			cards[charName] += 1;
			
			// Remove character from list if it is on the board 2 times already
			if (cards[charName] == 2)
			{
				characters.RemoveAt(randomCharacter);
			}

			// Load cards as child of Grid element
			Instantiate(cardPrefab, transform.position, transform.rotation, transform);

		}

		foreach(string charName in cards.Keys)
		{
			Debug.Log($"{charName} : {cards[charName]}");
		}
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
