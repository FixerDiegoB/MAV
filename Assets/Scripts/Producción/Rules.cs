using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    public float height;
    public GameObject whiteToken, blackToken, referenceToken;
    public Board board;
    public GameObject occupiedCellSound; 

    private Status turn;
    private GamePhase phase;
    private GameObject selectedCell, newToken;

    private void Start()
    {
        turn = Status.WHITE;
        phase = GamePhase.PUT;
    }
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            selectedCell = getCellOnClick();
            if (selectedCell != null)
            {
                if (phase == GamePhase.PUT)
                {
                    putToken(selectedCell.transform.parent.gameObject);
                }
            }

            updatePhase();
        }
    }

    private GameObject getCellOnClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
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

    private void putToken(GameObject selectedCell)
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
        else
        {
            Instantiate(occupiedCellSound);
        }
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

        board.totalTokens = 0;
        turn = Status.WHITE;
    }
}
