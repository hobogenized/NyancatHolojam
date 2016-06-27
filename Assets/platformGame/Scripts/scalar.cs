using UnityEngine;
using System.Collections;

namespace mover{
	public class scalar : MonoBehaviour {

		public float worldScale;
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			float dist = this.transform.localPosition.magnitude;
			float remap = map (dist, 0, worldScale, 1, 0);
			this.transform.GetChild (0).transform.localScale = new Vector3 (remap, remap, remap);
		}

		float map(float s, float a1, float a2, float b1, float b2)
		{
			return b1 + (s-a1)*(b2-b1)/(a2-a1);
		}
	}
}