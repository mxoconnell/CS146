using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool gameHasEnded = false;

	public float restartDelay = 1f;

	public GameObject completeLevelUI;
    public GameObject Explosion;
    public GameObject Bike;

	public void CompleteLevel ()
	{
		completeLevelUI.SetActive(true);
	}

	public void EndGame ()
	{
        ExplodeBike();
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
			Debug.Log("GAME OVER");
			Invoke("Restart", restartDelay);
		}
	}

	void Restart ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    void ExplodeBike() {
        Explosion.SetActive(true);
        for(var childIndex = 0; childIndex < Bike.transform.childCount; childIndex++){
            Bike.transform.GetChild(childIndex).gameObject.AddComponent<Rigidbody>();
            Bike.transform.GetChild(childIndex).gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000, Bike.transform.position, 100);
        }
    }

}
