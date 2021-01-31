using CullingSystem;
using Globals;
using Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Player.PlayerLocomotion;

namespace Freecam
{
    public class FreecamManager : MonoBehaviour
    {
		public FreecamManager(IntPtr intPtr) : base(intPtr)
		{
		}

		bool FreecamEnabled = false;
		float speed = 5;
		bool SpacePressedLastFrame = false;
		PlayerLocomotion PlayerLocomotion;
		GameObject player;

		public void Update()
		{
			if (Input.GetKeyDown(KeyCode.F1))
			{
				if (!FreecamEnabled)
                {
					FPSCameraHolder fpsCamHolder = GameObject.FindObjectOfType<FPSCameraHolder>();
					FPSCamera fpsCamera = GameObject.FindObjectOfType<FPSCamera>();
					//fpsCamera.gameObject.transform.GetChild(1)?.gameObject.SetActive(false);

					//UI_Apply ui = GameObject.FindObjectOfType<UI_Apply>();
					//ui.enabled = false;

					//fpsCamHolder.m_flatTrans.gameObject.SetActive(false);

					player = fpsCamHolder.m_owner.gameObject;
					PlayerLocomotion = player.GetComponent<PlayerLocomotion>();
					PlayerLocomotion.enabled = false;
					//Global.EnemyPlayerDetectionEnabled = false;
				} else
                {

					//FPSCameraHolder fpsCam = GameObject.FindObjectOfType<FPSCameraHolder>();
					//fpsCam.m_flatTrans.gameObject.SetActive(true);
					//
					//FPSCamera fpsCamera = GameObject.FindObjectOfType<FPSCamera>();
					//fpsCamera.gameObject.transform.GetChild(1)?.gameObject.SetActive(true);


					PlayerLocomotion.enabled = true;
					//Global.EnemyPlayerDetectionEnabled = true;

					//UI_Apply ui = GameObject.FindObjectOfType<UI_Apply>();
					//ui.enabled = true;
				}
				FreecamEnabled = !FreecamEnabled;
				FreecamMain.log.LogMessage(FreecamEnabled == true ? "Freecam Enabled" : "Freecam Disabled");
			}


			if (FreecamEnabled)
            {
				UpdateMovement();
				PlayerLocomotion.m_owner.m_movingCuller.UpdatePosition(player.transform.position);
				PlayerLocomotion.m_owner.Sync.SendLocomotion(PlayerLocomotion.m_currentStateEnum, player.transform.position, PlayerLocomotion.m_owner.FPSCamera.Forward, 0, 0);
			}
		}

		void UpdateMovement()
        {
			if (Input.mouseScrollDelta.y > 0)
            {
				speed += 0.1f;
            } else if (Input.mouseScrollDelta.y < 0) 
			{
				speed -= 0.1f;
			}

			if (Input.GetKey(KeyCode.Space))
            {
				player.transform.Translate(Vector3.up * speed * Time.deltaTime);
			}

			if (Input.GetKey(KeyCode.LeftShift))
            {
				player.transform.Translate(Vector3.down * speed * Time.deltaTime);
			}

			if (Input.GetKey(KeyCode.W))
            {
				player.transform.Translate(Vector3.forward * speed * Time.deltaTime);
			}

			if (Input.GetKey(KeyCode.S))
            {
				player.transform.Translate(Vector3.back * speed * Time.deltaTime);
            }

			if (Input.GetKey(KeyCode.A))
            {
				player.transform.Translate(Vector3.left * speed * Time.deltaTime);
			}

			if (Input.GetKey(KeyCode.D))
            {
				player.transform.Translate(Vector3.right * speed * Time.deltaTime);
			}
		}
	}
}
