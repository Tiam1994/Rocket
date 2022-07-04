using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioSource;
    [SerializeField] float rotSpeed = 100f;
    [SerializeField] float flySpeed = 100f;
    [SerializeField] AudioClip flySound;
    [SerializeField] AudioClip loseSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] ParticleSystem fireParticle;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] ParticleSystem finishParticle;
    enum State { Playing, Dead, NextLevel };
    State state = State.Playing;
    bool collisionOff = false;


    void Start()
    {
        State state = State.Playing;
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (state == State.Playing)
        {
            RocketLaunch();
            RocketRotation();
        }
        if(Debug.isDebugBuild)
            DebugKeys();
    }

    void RocketLaunch()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            fireParticle.Play();
            rigidBody.AddRelativeForce(Vector3.up * flySpeed * Time.deltaTime);
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(flySound);
        }
        else
        {
            fireParticle.Stop();
            audioSource.Pause();
        }
    }

    void RocketRotation()
    {
        float rotationSpeed = rotSpeed * Time.deltaTime;

        rigidBody.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }
        rigidBody.freezeRotation = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (state == State.Dead || state != State.Playing || collisionOff)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                Finish();
                break;
            case "Battery":
                break;
            default:
                Lose();
                break;
        }
    }

    void LoadNextLevel()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = levelIndex+1;

        if (nextLevelIndex == SceneManager.sceneCountInBuildSettings)
            nextLevelIndex = 1;

        SceneManager.LoadScene(nextLevelIndex);
    }

    void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    void Finish()
    {
        state = State.NextLevel;
        fireParticle.Stop();
        audioSource.Stop();
        audioSource.PlayOneShot(winSound);
        finishParticle.Play();
        Invoke("LoadNextLevel", 2f);
    }

    void Lose()
    {
        state = State.Dead;
        fireParticle.Stop();
        audioSource.Stop();
        audioSource.PlayOneShot(loseSound);
        deathParticle.Play();
        Invoke("LoadFirstLevel", 2f);
    }

    void DebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
            LoadNextLevel();
        else if (Input.GetKeyDown(KeyCode.C))
            collisionOff = !collisionOff;
    }
}
