using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMenuBehavior : MonoBehaviour {
    [SerializeField]
    public SubMenuManager subMenuManager;
    public SubMenu _subMenu;
    public List<MenuStatBehavior> menuItems;
    public MenuStatBehavior menuPrefab;

       
    public Canvas canvas;
    public Text titleTextField;
    public GameObject MenuStatHolder;

	// Use this for initialization
	void Start () {
        canvas = GetComponent<Canvas>();
	}

    public void Show(string subMenuName) {
        SubMenu subMenu = GetSubMenuFromManager(subMenuName);
        if(subMenu == _subMenu && !canvas.enabled ) {
            canvas.enabled = true;
        } else if (subMenu != _subMenu) {
            InitializeSubMenu(subMenu);
            canvas.enabled = true;
        }

    }

    public void Hide(string subMenuName) {
        SubMenu subMenu = GetSubMenuFromManager(subMenuName);
        if (subMenu == _subMenu && canvas.enabled) {
            canvas.enabled = false;
        }
    }

    private SubMenu GetSubMenuFromManager(string subMenuName) {
        SubMenu subMenuFromManager = subMenuManager.subMenuDictionary[subMenuName];
        return subMenuFromManager;
    }


    public void InitializeSubMenu(SubMenu subMenu) {
        _subMenu = subMenu;
        
        UpdateTitle(subMenu.subMenuTitle);

        int numMenuStats = subMenu.subMenuItems.Count;
        int numMenuItems = menuItems.Count;
       
        if(numMenuStats < numMenuItems) {
            //Delete extra MenuItems
            for (int i = 0; i < (numMenuItems - numMenuStats); i++) {
                MenuStatBehavior menuItemToBeDeleted = menuItems[0];
                menuItems.Remove(menuItemToBeDeleted);

                // Destroy object.
                Destroy(menuItemToBeDeleted.gameObject);
            }      
        }
        else if (numMenuItems == numMenuStats) {
            //Just update the  MenuItems with MenuStats
        } else {
            //Create extra MenuItems
            for (int i = 0; i < (numMenuStats - numMenuItems); i++) {
                CreateMenuStat();
            }
        }
        //Update MenuItems with Menu Stats   
        UpdateMenuStats();
    }

    void UpdateMenuStats() {
        if(menuItems.Count == _subMenu.subMenuItems.Count) {
            for(int i = 0; i < menuItems.Count; i++) {
                menuItems[i].InitializeMenuStat(_subMenu.subMenuItems[i]);
            }
        } else {
            Debug.Log("number of menuItems not equal to number of submenu items ");
        }
    }

    void UpdateMenuStat(MenuStat menuStat, MenuStatBehavior menuStatBehavior) {
        menuStatBehavior.InitializeMenuStat(menuStat);
    } 

    void CreateMenuStat() {
        MenuStatBehavior newMenuStat = Instantiate(menuPrefab, MenuStatHolder.transform);
        menuItems.Add(newMenuStat);
    }
    
    public void Create() {
        InitializeSubMenu(_subMenu);
    }

    void UpdateTitle(string newTitle) {
        titleTextField.text = newTitle;
    }

    void Show() {
        canvas.enabled = true;
    }

    void Hide() {
        canvas.enabled = false;
    }

}
