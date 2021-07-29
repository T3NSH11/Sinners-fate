using UnityEngine;
using UnityEditor;

public class Path_Creator : EditorWindow
{
    AI_Waypoint_System waypoint_System;

    string pathName;
    int path_ID = 1;
    int node_ID = 0;

    //Vector3 spawnPos = new Vector3(5, 5, 5);    //Used as a default spawn point, for the path. 
    Vector3 mousePos;

    //float spawn_radius = 2.0f;

    public GameObject waypoint_node;
    GameObject pathContainer;

    Color pathRay_Col;

    bool toolActive = false;

    [MenuItem("Tools/Custom Tools/Waypoint Creator")]
    public static void DisplayToolWindow()
    {
        GetWindow(typeof(Path_Creator));        //Used to display the Window that will let us use this tool.
    }

    public void OnEnable()
    {
        SceneView.duringSceneGui += this.OnSceneGUI;
    }

    private void OnGUI()
    {
        GUILayout.Label("Waypoint Path Creator", EditorStyles.boldLabel);

        pathName = EditorGUILayout.TextField("Path Name", pathName);
        path_ID = EditorGUILayout.IntField("Path ID", path_ID);
        node_ID = EditorGUILayout.IntField("Node ID", node_ID);

        //spawn_radius = EditorGUILayout.FloatField("Spawn Radius", spawn_radius); 
        //Rename variable to whatever makes it clear that this is to ensure no waypoints spawn on top of each other.



        waypoint_node = EditorGUILayout.ObjectField("Node Prefab (if any)", waypoint_node, typeof(GameObject), false) as GameObject;

        toolActive = EditorGUILayout.Toggle(toolActive);

        if (GUILayout.Button("Activate Tool"))
        {
            toolActive = !toolActive;

            if (!toolActive)
            {
                node_ID = 0;
            }
        }

        /*
        if (GUILayout.Button("Spawn Node"))
        {
            //Call the waypoint node placement function here.

            SpawnNodeObj();
        }
        */
    }

    public void OnSceneGUI(SceneView current_SceneView)
    {
        Debug.Log(mousePos);


        //Gets the mousePos within the Scene View Window
        mousePos = new Vector3(Event.current.mousePosition.x, Event.current.mousePosition.y);

        //Inverts the mousePos so that up means up, and down means down.
        mousePos.y = SceneView.currentDrawingSceneView.camera.pixelHeight - mousePos.y;

        mousePos.z += 5;

        //Converts the mouse's screen position into scene world coordinates.
        mousePos = SceneView.currentDrawingSceneView.camera.ScreenToWorldPoint(mousePos);

        if (toolActive)
        {
            Event mouseEvent = Event.current;

            if (mouseEvent.isMouse)
            {
                if (mouseEvent.type == EventType.MouseDown)
                {
                    if (/*mouseEvent.alt &&*/ mouseEvent.button == 0)
                    {
                        Debug.Log("Shift + Control + Left Click");
                        Debug.Log(mousePos);

                        if (node_ID == 0)
                            SpawnPathObj();

                        else if (node_ID > 0)
                            SpawnNodeObj();
                    }
                }

                /*For changing the Z value of something.
                 * if (mouseEvent.isScrollWheel)
                    mousePos.z++;*/
            }
        }

    }


    public void SpawnPathObj()
    {
        pathContainer = new GameObject(pathName + path_ID);
        pathContainer.transform.position = mousePos;
        pathContainer.AddComponent<AI_Waypoint_System>();
        path_ID++;

        //Creates the Starting Node for the Path.
        GameObject newNode = Instantiate(waypoint_node, mousePos, Quaternion.identity, pathContainer.transform);
        newNode.name = pathName + "Node" + node_ID;
        node_ID++;
    }

    public void SpawnNodeObj()
    {
        GameObject newNode = Instantiate(waypoint_node, mousePos, Quaternion.identity, pathContainer.transform);
        newNode.name = pathName + "Node" + node_ID;
        node_ID++;
    }
}
