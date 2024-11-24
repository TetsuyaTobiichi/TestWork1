using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private UnityEngine.UI.Image _scoreImage;
    public GameObject player;
    private Rigidbody _playerBody;
    public Camera playerCamera;
    void Start()
    {
        PlayerPrefs.SetFloat("Score",0);
        _playerBody = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        float mouseX = Input.GetAxis("Mouse X");
        _playerBody.transform.Rotate(0, mouseX * 200f *Time.deltaTime, 0);
       //вот этот бред подчистить
        Vector3 temp = _playerBody.transform.position;
        temp.y=2;
        temp.z-=2;
        playerCamera.transform.position=temp;  
        //
        _scoreImage.fillAmount=PlayerPrefs.GetFloat("Score");
        switch(PlayerPrefs.GetFloat("Score")){
            case <0:
                Debug.Log("проиграл");
                break;
        }
    }
    void FixedUpdate()
    {
        _playerBody.velocity=_playerBody.transform.forward;
    }
}
