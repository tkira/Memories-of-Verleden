using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour {

	public Item gold;
	public Item gem;
	public Sprite[] itemSprite = new Sprite[2]; 

	public ItemList() {
		itemSprite[0] = Resources.Load<Sprite>("goldtest");
		itemSprite[1] = Resources.Load<Sprite>("gemtest");
		gold = new Item(1, "Gold", itemSprite[0]);
		gem = new Item(2, "Gem", itemSprite[1]);
	}
}
