using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
public class Move : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private CharacterController _characterController;

    public FixedJoystick _joystick;

    float x;
    float z;

    private void Update()
    {
        if (YandexGame.EnvironmentData.isDesktop)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }

        if (YandexGame.EnvironmentData.isMobile)
        {
            x = _joystick.Horizontal;
            z = _joystick.Vertical;
        }

        var direction = transform.right * x + transform.forward * z;

        _characterController.Move(direction * _speed * Time.deltaTime);
    }
}
