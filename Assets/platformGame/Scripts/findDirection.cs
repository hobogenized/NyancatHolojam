using UnityEngine;
using System.Collections;

namespace mover{
	public class findDirection : MonoBehaviour {

		//public GameObject[] people;
		[SerializeField]
		Holojam.Actor[] people;
		public Vector3 direction = Vector3.zero;
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			direction = findAveragePosition ();
		}

		Vector3 findAveragePosition(){

			Vector3 avg = Vector3.zero;
			for (int i = 0; i < people.Length; i++) {
				Vector3 pos = people [i].transform.position;
				avg = new Vector3 (avg.x + pos.x, avg.y + pos.y, avg.z + pos.z);
			}
			Vector3 returnAvg = new Vector3 (avg.x / people.Length, avg.y / people.Length, avg.z / people.Length);
			return returnAvg;

		}
	}
}
