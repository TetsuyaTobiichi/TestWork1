using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Take : MonoBehaviour
{
    // Start is called before the first frame update

[SerializeField] private ParticleSystem _takeBillParticle;
private IStuff _stuff;
private ParticleSystem _instantiateTakeBillParticle;

     
     void OnTriggerEnter(){
          _stuff = gameObject.GetComponent<IStuff>();
          
          ThrowParticles();
          TakeBonus();
          Destroy(gameObject);
     }

     private void ThrowParticles(){
          _instantiateTakeBillParticle=Instantiate(_takeBillParticle,transform.position,Quaternion.Euler(-90, 0, 0));
     }

     private void TakeBonus(){
          float temp = PlayerPrefs.GetFloat("Score");
          temp+=_stuff.GetBonus();
          PlayerPrefs.SetFloat("Score",temp);
          Debug.Log(PlayerPrefs.GetFloat("Score"));
     }
}

