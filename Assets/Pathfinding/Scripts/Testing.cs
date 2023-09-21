using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class Testing : MonoBehaviour {
    [SerializeField] private PathfindingDebugStepVisual pathfindingDebugStepVisual;
    [SerializeField] private PathfindingVisual pathfindingVisual;
    [SerializeField] private CharacterMove characterPathfinding;
    private Pathfinding pathfinding;
    public Pathfinding Pathfinding { get { return pathfinding; } }
    Vector3 endPoint;
    List<PathNode> path;
    bool isDraw = true;

    //Vector3 mouseWorldPosition;

    private void Start() {
        pathfinding = new Pathfinding(20, 10);
        //pathfindingDebugStepVisual.Setup(pathfinding.GetGrid());
        //pathfindingVisual.SetGrid(pathfinding.GetGrid());
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (Time.timeScale < 0.1f) return;
            endPoint = UtilsClass.GetMouseWorldPosition();
            drawLineEndPoint();
            characterPathfinding.SetTargetPosition(endPoint);
        }

        //if (Input.GetMouseButtonDown(1)) {
        //    mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
        //    closedPosWall(mouseWorldPosition);
        //    drawLineEndPoint();
        //    characterPathfinding.SetTargetPosition(endPoint);
        //}

        if(Input.GetKeyDown(KeyCode.C))
        {
            isDraw = !isDraw;
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            pathfinding.ReDiagonally();
        }
    }
    public void closedPosWall(Vector3 pos)
    {
        pathfinding.GetGrid().GetXY(pos, out int x, out int y);
        pathfinding.GetNode(x, y).SetIsWalkable(!pathfinding.GetNode(x, y).isWalkable);
    }
    void drawLineEndPoint()
    {
        if (!isDraw) return;
        Vector3 posCharacterDraw = characterPathfinding.GetPositionCharacter() / pathfinding.GetGrid().GetCellSize();
        Vector3 endPointDraw = endPoint / pathfinding.GetGrid().GetCellSize();
        path = pathfinding.FindPath((int)posCharacterDraw.x, (int)posCharacterDraw.y, (int)endPointDraw.x, (int)endPointDraw.y);

        if (path != null)
        {
            for (int i = 0; i < path.Count - 1; i++)
            {
                Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.green, 0.75f);
            }
        }
    }

}
