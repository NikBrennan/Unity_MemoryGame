using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public GameObject cartoonCharacter;
    public CardMatchManager cardMatchManager;
    public bool canClick;
    // Start is called before the first frame update
    void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
	    
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		canClick = cardMatchManager.canClickCards();
		Debug.Log(canClick);
		if (canClick)
        {
			Debug.Log("Displaying");
			cartoonCharacter.GetComponent<Image>().enabled = true;
			cartoonCharacter.tag = "Selected";
		}
	}
}
