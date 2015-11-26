using UnityEngine;
using System.Collection

public class AISearchEnemy : AI {

  IEnumerator SearchEnemy(){

    
    while(true){
        List<GameObject> enemys = GameObject.FindGameObjectsWithTag("Team" + team == 0 ? 1:2);
        
        GameObject nearestEnemy = null;
        float distance = 0f;
        
        foreach(GameObject enemy in enemys){
          
          
          yield return new WaitForSeconds(0.5f);
        
        }
    }
  
  }



}
