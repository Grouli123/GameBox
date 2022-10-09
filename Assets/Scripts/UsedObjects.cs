using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsedObjects : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private PlayerSettings settings;
    [SerializeField] private MostActivated mostActivated;
    [SerializeField] private Most2Activation mostActivated2;
    // [SerializeField] private LiftActivated liftActivated;
    [SerializeField] private TextMoveHelp textMoveHelp;

    //[SerializeField] private CallLift _callLift;

    [Header("Objects")]
    private bool activatedMost = false;
    private bool activatedMost2 = false;
    //private bool activatedLift = false;

    private bool _jamesLift = true;

    // private bool _isLiftUp = false;

    private float horizontal;

    private RaycastHit hit;

    [Header("Sounds")]
    [SerializeField] private AudioSource box;
    [SerializeField] private AudioSource artefactSound;
    [SerializeField] private AudioSource coinSound;
    [SerializeField] private AudioSource grandMatherSound;
    [SerializeField] private AudioSource runStone;
    [SerializeField] private AudioSource runMetall;
    [SerializeField] private AudioSource jamesLift;
    [SerializeField] private AudioSource lever;
    //[SerializeField] private AudioSource callLift;
    //[SerializeField] private AudioSource activateMost;
 
    // [SerializeField] private float _timeMoveLift;


    // [SerializeField] private LiftUp _liftUp;
    // [SerializeField] private LiftDown _liftDown;

    private void Start() 
    {
       
    }
    private void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cat1") | collision.gameObject.CompareTag("Cat2") | collision.gameObject.CompareTag("Cat3")
            | collision.gameObject.CompareTag("Cat4") | collision.gameObject.CompareTag("Cat5"))
        {
            grandMatherSound.Play();
        }

        if (collision.gameObject.GetComponent<CoinCollectScript>())
        {
            coinSound.Play();
        }

        if (collision.gameObject.GetComponent<HairGelObject>() | collision.gameObject.GetComponent<CasseteObject>())
        {
            artefactSound.Play();
        }

        if (collision.gameObject.GetComponent<MostActivated>())
        {
            activatedMost = true;
            textMoveHelp.Texting("E - Активировать мост");
            textMoveHelp.FulText(true);
        }

        if (collision.gameObject.GetComponent<Most2Activation>())
        {
            activatedMost2 = true;
            textMoveHelp.Texting("E - Активировать мост");
            textMoveHelp.FulText(true);
        }

        // if (_liftUp.isElevatorUp == false)
        // {
        //     _liftUp.isElevatorUp = true;
        //     textMoveHelp.Texting("E - Вызов лифта");
        //     textMoveHelp.FulText(true);
        // }
        // else
        // {
        //     // _liftUp.isElevatorUp = false;
        // }

        // if (Input.GetKeyDown(KeyCode.E) & _liftUp.isElevatorUp == false)
        // {
        //     _liftUp.isElevatorUp = true;
            
        //     Debug.Log("Лифт едет вниз");
        //     StartCoroutine(LiftPositionDown());
        //     StartCoroutine(JamesSound());
        // }
        // else
        // {
        //     _liftUp.isElevatorUp = false;
        // }

        // if(Input.GetKeyDown(KeyCode.E) & activatedLift == true & liftActivated.LiftPositionDown == true)
        // {
        //     liftActivated.ActivatedLift("Activated", false);
        //     StartCoroutine(LiftPositionUp());
        // }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        // if (collision.gameObject.GetComponent<LiftActivated>())
        // {
        //    // activatedLift = true;
        //     textMoveHelp.Texting("E - Запуск");
        //     textMoveHelp.FulText(true);
        // }
        // else
        // {
        //     //activatedLift = false;
        // }

        // if (collision.gameObject.GetComponent<CallLift>() & Input.GetKeyDown(KeyCode.E) & liftActivated.LiftPositionDown == true)
        // {
        //     lever.Play();
        //     //liftActivated.ActivatedLift("Activated", false);
        //     StartCoroutine(LiftPositionUp());
        //    // callLift.Play();
        // }

        if (Input.GetKeyDown(KeyCode.E) & activatedMost == true)
        {
            lever.Play();
            mostActivated.Activated("Most", true);
           // activateMost.Play();
        }

        if (Input.GetKeyDown(KeyCode.E) & activatedMost2 == true)
        {
            lever.Play();
            mostActivated2.Animation("Activation", true);
            // activateMost.Play();
        }

        // if (Input.GetKeyDown(KeyCode.E) & activatedLift == true & liftActivated.LiftPositionDown == false)
        // {
        //     liftActivated.ActivatedLift("Activated", true);
        //     StartCoroutine(LiftPositionDown());
        //     StartCoroutine(JamesSound());
        // }

        // if(Input.GetKeyDown(KeyCode.E) & activatedLift == true & liftActivated.LiftPositionDown == true)
        // {
        //     liftActivated.ActivatedLift("Activated", false);
        //     StartCoroutine(LiftPositionUp());
        // }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
           if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.35f)
           {
             if (runStone.isPlaying) return;
             runStone.Play();
           }
           else
           {
             runStone.Stop();
           }
        }
        else if(collision.gameObject.CompareTag("Metall"))
        {
           runStone.Stop();
        }
        else
        {
            runStone.Stop();
        }


        if(collision.gameObject.CompareTag("Metall"))
        {
           if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.35f)
           {
             if (runMetall.isPlaying) return;
             runMetall.Play();
           }
           else
           {
             runMetall.Stop();
           }
        }
        else if(collision.gameObject.CompareTag("Ground"))
        {
           runMetall.Stop(); 
        }
        else
        {
            runMetall.Stop();
        }
    }

    // private IEnumerator LiftPositionDown()
    // {
    //     yield return new WaitForSeconds(10);
    //     liftActivated.LiftDown();
    // }

    // private IEnumerator LiftPositionUp()
    // {
    //     yield return new WaitForSeconds(10);
    //     liftActivated.LiftUp();
    // }

    private IEnumerator JamesSound()
    {
        yield return new WaitForSeconds(4);
        if(_jamesLift == true)
        {
            jamesLift.Play();
        }
        else
        {
            jamesLift.Stop();
        }
        yield return new WaitForSeconds(3);
        _jamesLift = false;
    }

    public void AudioStop()
    {
        runMetall.volume = 0f;
        runStone.volume = 0f;
    }

    public void AudioPlay()
    {
        runMetall.volume = 1f;
        runStone.volume = 1f;
    }
}