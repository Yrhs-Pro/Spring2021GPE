using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
	public GameObject mainMenu;
	public GameObject optionMenu;

	public Slider musicSlider;
	public Slider sfxSlider;
	public Dropdown mapDropdown;

	public enum MenuState { mainmenu, optionsMenu };
	public MenuState currentMenuState = MenuState.mainmenu;

	public void onQuitClicked()
	{
		Application.Quit();// quits application
	}

	public void onNewGameClicked()
	{
		SceneManager.LoadScene(2);
	}

	public void onOptionsClicked()
	{
		mainMenu.SetActive(false);
		optionMenu.SetActive(true);
		changeState(MenuState.optionsMenu);
	}

	public void changeState(MenuState nextState)
	{
		currentMenuState = nextState;
	}

	public void onSaveChangesClicked()
	{
		//  Save Options 
		GameManager.Instance.SavePrefrences();
		//go back to main menu 
		GoToMainMenuFromOptions();
	}

	private void GoToMainMenuFromOptions()
	{
		optionMenu.SetActive(false);
		mainMenu.SetActive(true);
		changeState(MenuState.mainmenu);
	}

	public void onClickedBackInOptions()
	{
		//  Revert Options
		GameManager.Instance.LoadPrefrences();
		// Go Back to main menu 
		GoToMainMenuFromOptions();
	}

	public void OnChangeMusicVolume()
	{
		GameManager.Instance.musicVolume = musicSlider.value;
	}

	public void OnChangeSfxVolume()
	{
		GameManager.Instance.sfxVolume = sfxSlider.value;
	}

	public void OnChangeMapType()
	{
		GameManager.Instance.mapType = (GameManager.MapGenerationtype)mapDropdown.value; // expicity convert from the integer to the enum
		
	}
}
