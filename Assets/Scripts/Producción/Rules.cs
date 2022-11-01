using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    public float height;
    public GameObject whiteToken, blackToken, referenceToken;
    public Board board;
    public GameObject occupiedCellSound;
    [HideInInspector]
    public GamePhase phase;
    [HideInInspector]
    public Status turn;
    private GameObject selectedObject, selectedCell, selectedToken, newToken;

    private void Start()
    {
        turn = Status.WHITE;
        phase = GamePhase.PUT;
    }
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            selectedObject = getObjectOnClick();
        
            if (selectedObject != null)
            {
                if (selectedObject.transform.parent.gameObject.GetComponent<Cell>() != null) // Si se selecciona el collider de una casilla
                {
                    selectedCell = selectedObject.transform.parent.gameObject;
                    if (phase == GamePhase.PUT)
                    {
                        putToken(selectedCell);
                        verifyMill(selectedCell);
                    }
                    else if (phase == GamePhase.MOVE)
                    {

                    }
                }
                else // Si se selecciona el collider de una ficha
                {
                    selectedToken = selectedObject;
                    if (phase == GamePhase.PUT)
                    {
                        Instantiate(occupiedCellSound);
                    }
                }
                
            }

            updatePhase();
        }
    }

    private GameObject getObjectOnClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Debug.Log(hitInfo.collider.gameObject.name);
            return hitInfo.collider.gameObject;
        }
        return null;
    }

    private void updatePhase()
    {
        if (board.totalTokens == 18)
        {
            phase = GamePhase.MOVE;
        }
    }

    public void putToken(GameObject selectedCell)
    {
        Cell cell = selectedCell.GetComponent<Cell>();
        if (cell.status == Status.EMPTY)
        {
            Vector3 position = selectedCell.transform.position;
            position = new Vector3(position.x, height, position.z);
            if (turn == Status.WHITE)
            {
                cell.status = Status.WHITE;
                newToken = Instantiate(whiteToken, position, Quaternion.identity);
                newToken.transform.parent = referenceToken.transform;
                Token token = newToken.GetComponent<Token>();
                token.cell = cell;
                token.color = Status.WHITE;
                turn = Status.BLACK;
            }
            else if (turn == Status.BLACK)
            {
                cell.status = Status.BLACK;
                newToken = Instantiate(blackToken, position, Quaternion.identity);
                newToken.transform.parent = referenceToken.transform;
                Token token = newToken.GetComponent<Token>();
                token.cell = cell;
                token.color = Status.BLACK;
                turn = Status.WHITE;
            }
            board.totalTokens++;
        }
    }

    private bool verifyMill(GameObject selectedCell)
    {
        Cell cell = selectedCell.GetComponent<Cell>();

        foreach(Mill mill in cell.mills)
        {
            Status status = mill.isComplete();
            if (status != Status.EMPTY)
            {
                Debug.Log("Mill created");
                return true;
            }
        }

        return false;
    }
    public void restartBoard()
    {
        foreach (Transform child in referenceToken.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Cell cell in board.cells)
        {
            cell.status = Status.EMPTY;
        }

        foreach (Mill mill in board.mills)
        {
            mill.isComplete();
        }

        board.totalTokens = 0;
        turn = Status.WHITE;
    }
}
