using UnityEngine;
namespace Move.Inputs{
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]
    public class PlayerInput : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private Shooter _shooter;
            
        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _shooter = GetComponent<Shooter>();
        }

        private void Update()
        {
            float _horizontalDidection = Input.GetAxis(GlobalStringVars.HorizontalAxis);
            bool _isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.Jump);
                
            if(Input.GetButtonDown(GlobalStringVars.Fire_1))
            {
                
                _shooter.Shoot(_horizontalDidection);
            }                
            _playerMovement.Move(_horizontalDidection, _isJumpButtonPressed);
        }
    }
}