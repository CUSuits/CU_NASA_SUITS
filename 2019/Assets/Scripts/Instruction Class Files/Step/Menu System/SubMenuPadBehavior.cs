using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMenuPadBehavior : SubMenuBehavior {
	public void Push(MenuStat menuStat) {
        //SubMenu subMenu = GetSubMenuFromManager(subMenuName);
        //MenuStat menuStat  = subMenu.subMenuItems.Find(x => x.name == statName);
        foreach(MenuStatBehavior menuStatBehav in menuItems) {
            if(menuStatBehav.menuStat == menuStat) {
                return;
            } else {
                continue;
            }
        }
        canvas.enabled = true;
        CreateMenuStat(menuStat);
    }	


	public void PushEmergencyStat(MenuStat menuStat) {

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
		
    public void ClearAll() {
        int numMenuToClear = menuItems.Count;
        for (int i = 0; i < numMenuToClear; i++) {
                
            MenuStatBehavior menuItemToBeDeleted = menuItems[0];

            menuItems.Remove(menuItemToBeDeleted);

            // Destroy object.
            Destroy(menuItemToBeDeleted.gameObject);
        }
    }



}
