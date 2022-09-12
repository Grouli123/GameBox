using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]
    public class PlayerInput : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private Shooter _shooter;

        

        public bool bulletOnTheScene = false;
            
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
                if (bulletOnTheScene == false)
                {
                    _shooter.Shoot(_horizontalDidection);
                    bulletOnTheScene = true;
                }
            }  
            _playerMovement.Move(_horizontalDidection, _isJumpButtonPressed);
        }

    //     private void FireHero()
    //     {
    //         _shooter.Shoot(_horizontalDidection);
    //     }
    
}