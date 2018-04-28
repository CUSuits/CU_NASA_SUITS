using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        for (int i = 0; i <= menuItems.Count; i++) {
            MenuStatBehavior menuItemToBeDeleted = menuItems[0];
            menuItems.Remove(menuItemToBeDeleted);

            // Destroy object.
            Destroy(menuItemToBeDeleted.gameObject);
        }
    }
}
