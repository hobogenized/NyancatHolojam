using UnityEngine;
using System.Collections;

namespace mover{
	public class collide : MonoBehaviour {

		public GameObject explosionObject;

		void OnTriggerEnter(Collider other) {
			if (this.gameObject.GetComponent<MeshRenderer> ().enabled == true) {
				Instantiate (explosionObject, this.transform.position, Quaternion.identity);
				this.gameObject.GetComponent<AudioSource> ().Play ();
			}
			this.gameObject.GetComponent<MeshRenderer> ().enabled = false;

		}
	}
}