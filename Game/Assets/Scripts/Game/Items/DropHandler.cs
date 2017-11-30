using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHandler : MonoBehaviour {

	public ItemList items;
	public LootTable table1 = new LootTable(new LootTableRow[2]);

	public DropHandler() {
		fillLootTables();

	}

	public void fillLootTables() {
		items = new ItemList();
		table1.row[0] = new LootTableRow (15, items.gold, 1);
		table1.row[1] = new LootTableRow (2, items.gem, 1);
	}

	public void calcDrop(Vector3 pos) {
		int total = 0;
		for(int i = 0; i < table1.row.Length; i++) {
			total += table1.row[i].weight;
		}
		System.Random rand = new System.Random();
		int roll = rand.Next (0, total);

		int top = 0;
		for (int i = 0; i < table1.row.Length; i++) {
			top += table1.row [i].weight;
			if(roll < top) {
				dropItem (pos, i);
			}
		}
	}

	public void dropItem(Vector3 pos, int num) {

		Debug.Log(table1.row[num].item.itemName);


		GameObject drop = new GameObject ("Drop");
		drop.transform.position = pos;
		//drop.transform.position = new Vector3 (-5, 15, 0);
		BoxCollider2D collider = drop.AddComponent<BoxCollider2D>();
		collider.isTrigger = true;
		DroppedItem dropped = drop.AddComponent<DroppedItem> ();
		SpriteRenderer dropRender = drop.AddComponent<SpriteRenderer>();
		dropRender.sprite = table1.row [num].item.sprite;
		dropRender.sortingLayerName = "Player";


	}
		
}
