using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public int itemID { get; set;}
	public string itemName { get; set;}
	public Sprite sprite;

	public Item(int id, string name, Sprite sprite) {
		this.itemID = id;
		this.itemName = name;
		this.sprite = sprite;
	}
}
