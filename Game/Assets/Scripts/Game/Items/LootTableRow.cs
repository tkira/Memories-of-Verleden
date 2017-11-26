using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTableRow : MonoBehaviour {

	public int weight { get; set;}
	public Item item { get; set; }
	public int amount { get; set; }

	public LootTableRow(int weight, Item item, int amount) {
		this.weight = weight;
		this.item = item;
		this.amount = amount;
	}

}
