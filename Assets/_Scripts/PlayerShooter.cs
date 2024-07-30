using UnityEngine;
using UnityEngine.UI;

public class PlayerShooter : MonoBehaviour
{
    public Shooter Player;
    public Button shootButton;

    void Start()
    {
        // Add a listener to the shoot button
        shootButton.onClick.AddListener(OnShootButtonPressed);
    }

    void OnShootButtonPressed()
    {
        // Call the Fire method of the Shooter class
        Player.Fire();
    }
}
