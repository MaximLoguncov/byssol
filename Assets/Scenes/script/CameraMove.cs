/// <summary>
/// Camera move.
/// Create by Sky Games
/// </summary>
using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	
	public GameObject player;
	public float speedCam = 15;
	public float speedScroll = 15;
	public float minDistance;
	public float maxDistance;
	
	private bool _isActive = false;
	private float _distance;
	private float _x;
	private float _y;
	
	void LateUpdate () {
		
		// Получение значения сдвига мыши
		_x = Input.GetAxis("Mouse X")*speedCam*10;
		_y = Input.GetAxis("Mouse Y")*-speedCam*10;
		
		// Зажатие правой кнопки мыши
		if(Input.GetMouseButtonDown(1))
		{
			_isActive = true;	
		}
		
		if(Input.GetMouseButtonUp(1))
		{
			_isActive = false;
		}
		
		// Вращение
		if(_isActive)
		{
			transform.RotateAround(player.transform.position, transform.up, _x*Time.deltaTime);
			transform.RotateAround(player.transform.position, transform.right, _y*Time.deltaTime);
			
			transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
		}
		
		// Приближение/удаление
		if(Input.GetAxis("Mouse ScrollWheel") != 0)
		{
			_distance = Vector3.Distance(transform.position, player.transform.position);
			if(Input.GetAxis("Mouse ScrollWheel") > 0 && _distance > minDistance)
			{
				transform.Translate(Vector3.forward * Time.deltaTime * speedScroll);
			}
			
			if(Input.GetAxis("Mouse ScrollWheel") < 0 && _distance < maxDistance)
			{
				transform.Translate(Vector3.forward * Time.deltaTime * -speedScroll);	
			}
		}
	}
}
