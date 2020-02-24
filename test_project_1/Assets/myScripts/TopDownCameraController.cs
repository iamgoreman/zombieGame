
using UnityEngine;

public class TopDownCameraController : MonoBehaviour {

	public Vector3 offSet;
	public Camera mainCam;
	public Player player;

	void start(){

	}

	void Update(){

		Ray camRay = mainCam.ScreenPointToRay (Input.mousePosition);
		Plane ground = new Plane (Vector3.up,Vector3.zero);

		float rayLength;

		if (ground.Raycast (camRay, out rayLength)) {

			Vector3 pointToLook = camRay.GetPoint (rayLength);
			Debug.DrawLine (camRay.origin, pointToLook,Color.blue);

			player.transform.LookAt (new Vector3(pointToLook.x,player.transform.position.y,pointToLook.z));
		}
	}
		

	void LateUpdate(){

		transform.position = player.transform.position + offSet;
	}


}
