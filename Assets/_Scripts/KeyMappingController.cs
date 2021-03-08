using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyMappingController : MonoBehaviour
{
    public MovementOptionSO currentMovementOptions;
    public MovementOptionSO defaultMovementOptions;

    public Dropdown upButtonDropdownOtions;
    public Dropdown downButtonDropdownOtions;
    public Dropdown rightButtonDropdownOtions;
    public Dropdown leftButtonDropdownOtions;

    public PlayerBehaviour player;


    // Start is called before the first frame update
    void Start()
    {
        LoadCurrentMovementOptions();
    }

    public void LoadCurrentMovementOptions()
    {
        upButtonDropdownOtions.options[currentMovementOptions.upKey.value].text = currentMovementOptions.upKey.name;
        upButtonDropdownOtions.value = currentMovementOptions.upKey.value;

        downButtonDropdownOtions.options[currentMovementOptions.downKey.value].text = currentMovementOptions.downKey.name;
        downButtonDropdownOtions.value = currentMovementOptions.downKey.value;

        rightButtonDropdownOtions.options[currentMovementOptions.rightKey.value].text = currentMovementOptions.rightKey.name;
        rightButtonDropdownOtions.value = currentMovementOptions.rightKey.value;

        leftButtonDropdownOtions.options[currentMovementOptions.leftkey.value].text = currentMovementOptions.leftkey.name;
        leftButtonDropdownOtions.value = currentMovementOptions.leftkey.value;

    }

    public void OnUpKeyValueChanged()
    {
        int selectedIndex = upButtonDropdownOtions.value;
        currentMovementOptions.upKey.name = upButtonDropdownOtions.options[selectedIndex].text;
        currentMovementOptions.upKey.value = selectedIndex;
        player.loadCurrentMovementOptions();

    }

    public void OnDownKeyValueChanged()
    {
        int selectedIndex = downButtonDropdownOtions.value;
        currentMovementOptions.downKey.name = downButtonDropdownOtions.options[selectedIndex].text;
        currentMovementOptions.downKey.value = selectedIndex;
        player.loadCurrentMovementOptions();
    }

    public void OnRightKeyValueChanged()
    {
        int selectedIndex = rightButtonDropdownOtions.value;
        currentMovementOptions.rightKey.name = rightButtonDropdownOtions.options[selectedIndex].text;
        currentMovementOptions.rightKey.value = selectedIndex;
        player.loadCurrentMovementOptions();
    }

    public void OnLeftKeyValueChanged()
    {
        int selectedIndex = leftButtonDropdownOtions.value;
        currentMovementOptions.leftkey.name = leftButtonDropdownOtions.options[selectedIndex].text;
        currentMovementOptions.leftkey.value = selectedIndex;
        player.loadCurrentMovementOptions();
    }

    public void OnResetButtonClicked()
    {
        currentMovementOptions.rightKey.name = defaultMovementOptions.rightKey.name;
        currentMovementOptions.rightKey.value = defaultMovementOptions.rightKey.value;
        rightButtonDropdownOtions.value = (int)KeyType.KEY;

        currentMovementOptions.downKey.name = defaultMovementOptions.downKey.name;
        currentMovementOptions.downKey.value = defaultMovementOptions.downKey.value;
        downButtonDropdownOtions.value = (int)KeyType.KEY;

        currentMovementOptions.leftkey.name = defaultMovementOptions.leftkey.name;
        currentMovementOptions.leftkey.value = defaultMovementOptions.leftkey.value;
        leftButtonDropdownOtions.value = (int)KeyType.KEY;

        currentMovementOptions.upKey.name = defaultMovementOptions.upKey.name;
        currentMovementOptions.upKey.value = defaultMovementOptions.upKey.value;
        upButtonDropdownOtions.value = (int)KeyType.KEY;
        player.loadCurrentMovementOptions();
    }
}