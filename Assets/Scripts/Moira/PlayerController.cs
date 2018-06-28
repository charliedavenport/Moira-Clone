using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    private Animator anim;
    private Rigidbody rb;
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private Transform playerModelPivot;
    [SerializeField] private ParticleSystem healingParticles;
    [SerializeField] private ParticleSystem succ;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float MouseSensitivity = 150f;

    private float rotX, rotY;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rotX = transform.rotation.eulerAngles.x;
        rotY = transform.rotation.eulerAngles.y;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Heal Start");
        }

        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetTrigger("Heal End");
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            anim.SetTrigger("Damage Start");
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            anim.SetTrigger("Damage End");
        }

    }

    private void FixedUpdate()
    {
        Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        Vector3 deltaPos = new Vector3(movementInput.x, 0, movementInput.y) * moveSpeed * Time.deltaTime;
        transform.Translate(deltaPos);

        rotX += mouseY * MouseSensitivity * Time.deltaTime;
        rotY += mouseX * MouseSensitivity * Time.deltaTime;
        rotX = Mathf.Clamp(rotX, -80f, 80f); // no flippy flips

        Quaternion localRot = Quaternion.Euler(0f, rotY, 0f); // rotate player object about y axis only
        transform.rotation = localRot;

        Quaternion cameraRot = Quaternion.Euler(rotX, rotY, 0f); // rotate camera on x and y axes
        cameraPivot.rotation = cameraRot;
        // give player model same rotation as camera
        playerModelPivot.RotateAround(cameraPivot.position, cameraPivot.right, mouseY * MouseSensitivity * Time.deltaTime);
        //playerModelPivot.rotation = cameraRot;
    }

    public void BeginHealing()
    {
        //if (!healingParticles.isPlaying) healingParticles.Play();
        healingParticles.Play();
        Debug.Log("Begin Healing");
    }

    public void EndHealing()
    {
        //if (healingParticles.isPlaying) healingParticles.Stop();
        healingParticles.Stop();
        Debug.Log("End Healing");
    }

    public void BeginSucc()
    {
        //if (!succ.isPlaying) succ.Play();
        succ.Play();
        Debug.Log("Begin Succ");
    }
    
    public void EndSucc()
    {
        //if (succ.isPlaying) succ.Stop();
        succ.Stop();
        Debug.Log("End Succ");
    }

    



}
