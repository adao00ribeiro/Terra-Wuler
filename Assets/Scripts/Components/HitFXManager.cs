using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
namespace ApocalipseZ
{
    public class HitFXManager : MonoBehaviour
    {
        /*
        [SerializeField] private DataManager DataManager;
        private ParticleSystem objconcreteHitFX;
        private ParticleSystem objwoodHitFX;
        private ParticleSystem objdirtHitFX;
        private ParticleSystem objmetalHitFX;
        private ParticleSystem objbloodHitFX;
        [Header("Melee sounds")]
        public AudioClip impactSound;
        [Header("Ricochet sounds")]
        [SerializeField] private AudioSource ricochetSource;
        public AudioClip[] ricochetSounds;
        void Start()
        {
            DataManager = GameController.Instance.GetComponentManager<DataManager>();
            ricochetSource = GetComponent<AudioSource>();
        }
        public void RicochetSFX()
        {
            ricochetSource.Stop();
            ricochetSource.PlayOneShot(ricochetSounds[Random.Range(0, ricochetSounds.Length)]);
        }
        public void HitParticlesFXManager(RaycastHit hit)
        {
            if (hit.collider.CompareTag("Wood"))
            {
                objWoodHitFX.Stop();
                objWoodHitFX.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                transform.position =  new Vector3(hit.point.x, hit.point.y, hit.point.z);
                objWoodHitFX.transform.LookAt(Camera.main.transform.position);
                objWoodHitFX.Play(true);
            }
            else if (hit.collider.CompareTag("Concrete"))
            {
                objConcreteHitFX.Stop();
                objConcreteHitFX.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                 transform.position =  new Vector3(hit.point.x, hit.point.y, hit.point.z);
                objConcreteHitFX.transform.LookAt(Camera.main.transform.position);
                objConcreteHitFX.Play(true);
            }
            else if (hit.collider.tag == "Dirt")
            {
                objDirtHitFX.Stop();
                objDirtHitFX.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                 transform.position =  new Vector3(hit.point.x, hit.point.y, hit.point.z);
                objDirtHitFX.transform.LookAt(Camera.main.transform.position);
                objDirtHitFX.Play(true);
            }
            else if (hit.collider.tag == "Metal")
            {
                objMetalHitFX.Stop();
                objMetalHitFX.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                 transform.position =  new Vector3(hit.point.x, hit.point.y, hit.point.z);
                objMetalHitFX.transform.LookAt(Camera.main.transform.position);
                objMetalHitFX.Play(true);
            }
            else if (hit.collider.CompareTag("Flesh") || hit.collider.CompareTag("Player"))
            {
                objBloodHitFX.Stop();
                objBloodHitFX.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                 transform.position =  new Vector3(hit.point.x, hit.point.y, hit.point.z);
                objBloodHitFX.transform.LookAt(Camera.main.transform.position);
                objBloodHitFX.Play(true);
            }
            else
            {
                objConcreteHitFX.Stop();
                objConcreteHitFX.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                 transform.position =  new Vector3(hit.point.x, hit.point.y, hit.point.z);
                objConcreteHitFX.transform.LookAt(Camera.main.transform.position);
                objConcreteHitFX.Play(true);
            }
        }
        internal void ApplyFX(RaycastHit hit)
        {
            RicochetSFX();
            HitParticlesFXManager(hit);
        }
        public ParticleSystem objConcreteHitFX
        {
            get
            {
                if (objconcreteHitFX == null)
                {
                    objconcreteHitFX = Instantiate(DataManager.GetDataParticles("Concrete").Particles);
                }
                return objconcreteHitFX;
            }
        }
        public ParticleSystem objWoodHitFX
        {
            get
            {
                if (objwoodHitFX == null)
                {
                    objwoodHitFX = Instantiate(DataManager.GetDataParticles("Wood").Particles);
                }
                return objwoodHitFX;
            }
        }
        public ParticleSystem objDirtHitFX
        {
            get
            {
                if (objdirtHitFX == null)
                {
                    objdirtHitFX = Instantiate(DataManager.GetDataParticles("Dirt").Particles);
                }
                return objdirtHitFX;
            }
        }
        public ParticleSystem objMetalHitFX
        {
            get
            {
                if (objmetalHitFX == null)
                {
                    objmetalHitFX = Instantiate(DataManager.GetDataParticles("Metal").Particles);
                }
                return objmetalHitFX;
            }
        }
        public ParticleSystem objBloodHitFX
        {
            get
            {
                if (objbloodHitFX == null)
                {
                    objbloodHitFX = Instantiate(DataManager.GetDataParticles("Blood").Particles);
                }
                return objbloodHitFX;
            }
        }
         */
    }
   
}