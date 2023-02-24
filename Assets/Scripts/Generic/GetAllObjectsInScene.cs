using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class gets all objects in the scene and stores them in a list
// This is useful for getting all objects in the scene and then doing something with them
// For example, you can get all objects in the scene and then disable them
// Or you can get all objects in the scene and then destroy them
// Or you can get all objects in the scene and then change their color
public class GetAllObjectsInScene : MonoBehaviour
{
    //This method returns all objects in the scene  
    public static List<GameObject> GetAllObjects()
    {
        //Create a list of game objects
        List<GameObject> allObjects = new List<GameObject>();
        //Get all objects in the scene
        GameObject[] allObjectsInScene = FindObjectsOfType<GameObject>();
        //Loop through all objects in the scene
        foreach (GameObject obj in allObjectsInScene)
        {
            //Add the object to the list
            allObjects.Add(obj);
        }
        //Return the list of objects
        return allObjects;
    }
}
