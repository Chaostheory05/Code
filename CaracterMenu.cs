using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaracterMenu : MonoBehaviour
{
	//Text fields
	public Text LevelText, hitpointText, pesosText, upgradeCostText, xpText;

	//logic


	public Image weaponSprite;
	public RectTransform xpBar;


	//Character Selection but i cant implement it rn


//Weapon Upgrade
	public void OnUpgradeClick()
	{
		if (GameManager.instance.TryUpgradeWeapon ())
			UpdateMenu ();
	}

	//Update the character Info
	public void UpdateMenu()
	{
		//Weapon
		weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.weapon.weaponLevel];
		if (GameManager.instance.weapon.weaponLevel == GameManager.instance.weaponPrices.Count)
			upgradeCostText.text = "MAX";
		else
			upgradeCostText.text = GameManager.instance.weaponPrices [GameManager.instance.weapon.weaponLevel].ToString ();

		//Meta
		LevelText.text = GameManager.instance.GetCurrentLevel().ToString();
		hitpointText.text = GameManager.instance.player.hitpoint.ToString();
		pesosText.text = GameManager.instance.pesos.ToString ();

		//xp BAR
		int currLevel = GameManager.instance.GetCurrentLevel();
		if (currLevel == GameManager.instance.xpTable.Count) {

			xpText.text = GameManager.instance.experience.ToString () + "total experience points";  //display total xṕ
			xpBar.localScale = Vector3.one;
		} else 
		{
			int prevLevelXp = GameManager.instance.GetXpToLevel (currLevel-1);
			int currLevelXp = GameManager.instance.GetXpToLevel (currLevel);

			int diff = currLevelXp - prevLevelXp;
			int currXpIntoLevel = GameManager.instance.experience - prevLevelXp;

			float completionRatio = (float)currXpIntoLevel / (float)diff;
			xpBar.localScale = new Vector3 (completionRatio, 1, 1);
			xpText.text = currXpIntoLevel.ToString () + "/" + diff; 
		}
			
	}
}
