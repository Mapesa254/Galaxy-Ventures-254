using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public Shooter weapon;
    public int maxLife = 10;
    public int maxWeaponLevel = 5;
    public float speed = 1;
    public Rect movementLimits = new Rect(-7, 0, 14, 10);

    [Header("Sounds:")]
    public AudioClip fireSnd;
    public AudioClip pickupSnd;

    [HideInInspector]
    public UI_Basic UI;
    int weaponLevel;
    int life;
    Vector3 oldPosition;
    Vector3 initialPosition;
    Quaternion initialRotation;

    public GameObject projectilePrefab;
    public Transform shootPoint;
    public Button shootButton;

    public GameObject prefabToInstantiate; // Add this public variable to assign the prefab in the Inspector
  

    void Start()
    {
        // Add a listener to the shoot button
        shootButton.onClick.AddListener(OnShootButtonPressed);

        life = maxLife;
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Check if there is at least one touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Calculate the movement offset
            Vector3 touchDelta = new Vector3(touch.deltaPosition.x, touch.deltaPosition.y, 0) * speed * Time.deltaTime;

            // Save the old position
            oldPosition = transform.position;

            // Apply the movement offset
            transform.Translate(touchDelta.x, 0, touchDelta.y);

            // Check if the new position is within the limits
            if (!movementLimits.Contains(transform.position))
            {
                // Revert to the old position if out of bounds
                transform.position = oldPosition;
            }
            else
            {
                // Rotate around the z-axis
                transform.RotateAround(Vector3.zero, Vector3.forward, touchDelta.x * 1.5f);
            }
        }
    }

    void OnShootButtonPressed()
    {
        // Call the Fire method of the Shooter class
        if (weapon.Fire())
        {
            // Play fire sound if available
            if (fireSnd != null)
            {
                UI.soundManager.PlaySoundOnce(fireSnd);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // Decrease life if collided with Enemy
        if (other.collider.CompareTag("Enemy"))
        {
            ApplyDamage(1);
        }

        if (other.collider.CompareTag("Bonus"))
        {
            other.gameObject.GetComponent<Bonus>().ActivateBonus(this);
        }
    }

    public void ApplyDamage(int _value)
    {
        if (life >= _value)
            life -= _value;

        if (weaponLevel >= _value)
            weaponLevel -= _value;

        weapon.SetUpgradeLevel(weaponLevel);
    }

    public int GetCurrentLifes()
    {
        return life;
    }

    public void ReplenishLife(int _value)
    {
        if (life <= (maxLife - _value))
        {
            life += _value;
            UI.soundManager.PlaySoundOnce(pickupSnd);
        }
    }

    public void UpgradeWeapon(int _value)
    {
        if (weaponLevel <= (maxWeaponLevel - _value))
        {
            weaponLevel += _value;
            weapon.SetUpgradeLevel(weaponLevel);
            UI.soundManager.PlaySoundOnce(pickupSnd);
        }
    }

    public int GetWeaponLevel()
    {
        return weaponLevel;
    }

    public void ResetTransform()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }

    public float RemainingLifePercent()
    {
        return (float)life / (float)maxLife;
    }
}
