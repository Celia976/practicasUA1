using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characters;
    public ThirdPersonCamera thirdPersonCamera;

    private int selectedCharacter = 0;

    void Start()
    {
        SelectCharacter(selectedCharacter);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) ||
            Input.GetKeyDown(KeyCode.Keypad1))
        {
            SelectCharacter(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) ||
            Input.GetKeyDown(KeyCode.Keypad2))
        {
            SelectCharacter(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) ||
            Input.GetKeyDown(KeyCode.Keypad3))
        {
            SelectCharacter(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) ||
            Input.GetKeyDown(KeyCode.Keypad4))
        {
            SelectCharacter(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) ||
            Input.GetKeyDown(KeyCode.Keypad5))
        {
            SelectCharacter(4);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6) ||
            Input.GetKeyDown(KeyCode.Keypad6))
        {
            SelectCharacter(5);
        }
    }

    void SelectCharacter(int index)
    {
        if (index < 0 || index >= characters.Length)
            return;

        selectedCharacter = index;

        Debug.Log("Personaje seleccionado: " + index);

        for (int i = 0; i < characters.Length; i++)
        {
            PhysicsController physics =
                characters[i].GetComponent<PhysicsController>();

            if (physics != null)
            {
                physics.enabled = (i == selectedCharacter);

                if (i == selectedCharacter && thirdPersonCamera != null)
                {
                    thirdPersonCamera.SetTarget(
                        characters[i].transform,
                        physics
                    );
                }
            }
            else
            {
                Debug.LogError(
                    "No se encontró PhysicsController en " +
                    characters[i].name
                );
            }
        }
    }
}