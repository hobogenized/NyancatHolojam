using UnityEngine;
using System.Collections;

namespace mover{
	public class moveEnvironment : MonoBehaviour {

		public GameObject[] things;
		GameObject[] props;
		public Vector2 bounds;
		public findDirection direction;
		public int amount;
		public float speed = 1;
		public GameObject env;
		public int stillAlive;
		// Use this for initialization
		void Start () {
			stillAlive = amount;
			props = new GameObject[amount];
			setupThings ();

		}
		
		// Update is called once per frame
		void Update () {
			moveThings ();
			rotateEnvironment ();
			checkAlive();
			if (stillAlive <= 0)
				Reset ();
		}

		void setupThings(){

			for (int i = 0, j = -1; i < amount; i++) {
				props [i] = Instantiate( things [++j], new Vector3(0,1000*i,0) , Quaternion.identity) as GameObject;
				if (j >= things.Length-1)
					j = -1;
				props[i].transform.localPosition = new Vector3(Random.Range(-bounds.x,bounds.x),0,Random.Range(-bounds.y,bounds.y));
				props [i].transform.parent = env.transform;
			}
		}

		void moveThings(){
			for (int i = 0; i < amount; i++) {
				props [i].transform.localPosition -=
					Vector3.Scale(direction.direction*speed,new Vector3(1,0,1));

				if (props [i].transform.localPosition.x < -bounds.x)
					props [i].transform.localPosition = setX (props [i].transform.localPosition, bounds.x);
				if (props [i].transform.localPosition.x > bounds.x)
					props [i].transform.localPosition = setX (props [i].transform.localPosition,-bounds.x);

				if (props [i].transform.localPosition.z < -bounds.y)
					props [i].transform.localPosition = setZ (props [i].transform.localPosition, bounds.y);
				if (props [i].transform.localPosition.z > bounds.y)
					props [i].transform.localPosition = setZ (props [i].transform.localPosition,-bounds.y);
			}
		}

		void checkAlive(){
			stillAlive = 0;
			for (int i = 0; i < amount; i++) {
				if (props [i].transform.GetChild (0).GetComponent<MeshRenderer> ().enabled == true) {
					stillAlive++;
				}
			}
		}

		void Reset(){
			for (int i = 0; i < amount; i++) {
				props [i].transform.GetChild(0).GetComponent<MeshRenderer> ().enabled = true;
			}
			stillAlive = amount;
		}

		void rotateEnvironment(){
			Vector3 d = new Vector3 (direction.direction.z*-1, 0, direction.direction.x);
			env.transform.localEulerAngles = d*10;
		}

		Vector3 setX(Vector3 v, float p){
			return new Vector3 (p, v.y, v.z);

		}
		Vector3 setZ(Vector3 v, float p){
			return new Vector3 (v.x, v.y, p);

		}
	}
}
