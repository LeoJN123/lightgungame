using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour {

    [System.Serializable]
    public class Cover
    {
        public VerticalMover[] verticalMovers;
    }

    public VerticalMover[] walls;

    public Cover[] covers;

	// Use this for initialization
	IEnumerator Start () {
        //Lasketaan seinät.
        foreach (var Wall in walls)
        {
            Wall.MoveToTargetPos();
        }

        yield return new WaitForSeconds(1f);

        //Kopioidaan kaikki coverit listaan
        List<Cover> availableCovers;
        availableCovers = new List<Cover>(covers);
        //Nostetaan random määrä covereita
        int randomAmount = 1; //Random.Range(0, covers.Length);

        for (int i = 0; i < randomAmount; i++)
        {
            int randomIndex = Random.Range(0, availableCovers.Count);
            Cover c = availableCovers[randomIndex];
            foreach (var mover in c.verticalMovers)
            {
                mover.MoveToTargetPos();
            }
            //Poistetaan nostettu cover listasta jotta sitä ei nosteta uudestaan.
            availableCovers.RemoveAt(randomIndex);
        }
		
	}
}
