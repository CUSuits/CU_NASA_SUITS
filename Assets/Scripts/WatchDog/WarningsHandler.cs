using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningsHandler : SubMenuBehavior {
	public MenuWarningStatBehavior warningPrefab;

	public void PushWarningStat(MenuStat menuStat) {
		// if already being displayed, just update value
		foreach (MenuStatBehavior menuStatBehav in menuItems) {
			if (menuStatBehav.menuStat == menuStat) {
				Text textObj = menuStatBehav.gameObject.GetComponent<Text>();
				textObj.color = Color.red;
				textObj.fontSize = 20;
				textObj.fontStyle = FontStyle.Bold;
				return;
			} else {
				continue;
			}
		}

		canvas.enabled = true;
		//Create new stat and turn it bold,red,
		MenuStatBehavior createdEmergencyMenuStat = CreateMenuStat(menuStat);
		Text emergencyText = createdEmergencyMenuStat.gameObject.GetComponent<Text>();
		emergencyText.color = Color.red;
		emergencyText.fontSize = 20;
		emergencyText.fontStyle = FontStyle.Bold;

	}

	protected MenuStatBehavior CreateSwitchStat(SwitchStat switchStat) {
		MenuStatBehavior newMenuStat = Instantiate(warningPrefab, MenuStatHolder.transform) as MenuStatBehavior;
		//Move new stat to the top of the menu
		newMenuStat.transform.SetAsFirstSibling(); 
		menuItems.Insert(0, newMenuStat);
		//menuItems.Add(newMenuStat);
		newMenuStat.InitializeMenuStat(switchStat);
		return newMenuStat;
	}

	public void PushWarningSwitch(SwitchStat menuStat)
	{
		foreach (MenuStatBehavior menuStatBehav in menuItems) {
			if (menuStatBehav.menuStat == menuStat as MenuStat) {
				Text textObj = menuStatBehav.gameObject.GetComponent<Text>();
				textObj.color = Color.red;
				textObj.fontSize = 20;
				textObj.fontStyle = FontStyle.Bold;
				return;
			} else {
				continue;
			}
		}

		//Create new warning stat
		canvas.enabled = true;
		MenuStatBehavior createdEmergencyMenuStat = CreateSwitchStat(menuStat);
		Text emegerncyText = createdEmergencyMenuStat.gameObject.GetComponent<Text>();
		emegerncyText.color = Color.red;
		emegerncyText.fontSize = 20;
		emegerncyText.fontStyle = FontStyle.Bold;
		emegerncyText.text = menuStat.warning;
	}




	public void Clear(MenuStat menuStat) {
		foreach (MenuStatBehavior menuStatBehav in menuItems) {
			if (menuStatBehav.menuStat != menuStat) {
				continue;
			} else {
				canvas.enabled = true;
				menuItems.Remove(menuStatBehav);

				// Destroy object.
				Destroy(menuStatBehav.gameObject);
			}
		}

	}


		

}
