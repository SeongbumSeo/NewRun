using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Nematode : MonoBehaviour {
    public float moveSpeed = 1f;
	public Vector2[] Destination;

	public int moveIndex = 0;
	Vector3 initialPosition;

    void Start() {
		PolygonCollider2D originalCollider = GetComponent<PolygonCollider2D>();

		// 캐릭터와의 충돌 무시
		Physics2D.IgnoreCollision(originalCollider, GameObject.Find("Character").GetComponent<BoxCollider2D>());
		// 초기 좌표 기억
		initialPosition = transform.position;
		// 생성 타이머
        Invoke("Create", 30f);
		// 플립 타이머
		InvokeRepeating("Flip", .1f, Random.Range(.05f, .1f));
    }

    void Update() {
		Vector2 destination = Destination[moveIndex];	// 이동 목적지
        Vector3 current = transform.position;			// 현재 좌표
        Vector2 speed = new Vector2(0f, 0f);			// X, Y 속도

		if(transform.localScale != new Vector3()
			&& (destination.x + .25f > current.x && destination.x - .25f < current.x || destination.x == 256f)
			&& (destination.y + .25f > current.y && destination.y - .25f < current.y || destination.y == 256f)) {
			if(Destination.Length - 1 > moveIndex) {
				moveIndex++;
			} else {
				SceneManager.LoadScene("Scenes/GameOver");
			}
		} else {
			float differX = Mathf.Abs(destination.x - current.x);
			float differY = Mathf.Abs(destination.y - current.y);
			float ratioX = differX < differY ? differX / differY : 1f;
			float ratioY = differY < differX ? differY / differX : 1f;

			if(destination.x == 256f) {             // X좌표로 이동하지 않는 경우

			} else if(destination.x > current.x) {  // 목적지가 오른쪽인 경우
				speed.x = moveSpeed * ratioX;
			} else if(destination.x < current.x) {  // 목적지가 왼쪽인 경우
				speed.x = -moveSpeed * ratioX;
			}

			if(destination.y == 256f) {             // Y좌표로 이동하지 않는 경우

			} else if(destination.y > current.y) {  // 목적지가 윗쪽인 경우
				speed.y = moveSpeed * ratioY;
			} else if(destination.y < current.y) {  // 목적지가 아랫쪽인 경우
				speed.y = -moveSpeed * ratioY;
			}

			// 정지 해제
			GetComponent<Rigidbody2D>().isKinematic = false;
			// 속도 처리
			GetComponent<Rigidbody2D>().velocity = new Vector3(speed.x, speed.y, 0f);
		}
    }

    void Create() {
        if(transform.localScale != new Vector3()) {

        } else if(Random.Range(0, GameObject.Find("EventSystem").GetComponent<Vessel>().enemyAppearProbability) == 0) {
			// 체력 설정
			GetComponent<Enemy>().initialHealth = GetComponent<Enemy>().Health = GameObject.Find("EventSystem").GetComponent<Vessel>().nematodeInitialHealth;
			// 초기 좌표로 이동
			transform.position = initialPosition;
			moveIndex = 0;
			// 생성
			transform.localScale = new Vector3(1f, 1f, 1f);
        } else {
            Invoke("Create", 20f);
        }
    }

	void Flip() {
		PolygonCollider2D col = GetComponent<PolygonCollider2D>();
		Vector2[] points = col.points;
		
		GetComponent<SpriteRenderer>().flipY = !GetComponent<SpriteRenderer>().flipY;
		for(int i = 0; i < points.Length; i++)
			points[i].Set(points[i].x, -points[i].y);
		col.points = points;
	}
}
