using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour {

	public ItemList items;


	public LootTableRow[] row { get; set; }

	public LootTable() {
	}

	public LootTable(LootTableRow[] row) {
		this.row = row;
		//row[0] = new LootTableRow(10, new Item(1, "Gold"), 1);
	}
		
}
