using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rulescopia : MonoBehaviour
{
    private Vector2 input;
    public float height;
    public GameObject whiteToken, blackToken, referenceToken;
    public Board board;
    public GameObject occupiedCellSound; 

    private Status turn;
    private GamePhase phase;
    private GameObject selectedCell, newToken;

    private void Start() //se ejecuta al inicio de la escena
    {
        turn = Status.WHITE; //el primer turno, que es el blanco
        phase = GamePhase.PUT; //primera fase que es colocar piezas
    }
    
    private void Update() //se ejecuta 1 vez por cada frame
    {
        if (Input.GetButtonDown("Fire1")) // get button dar click y fire 1 es click izquierdo
        {
            selectedCell = getCellOnClick(); //getCellOnClick linea 40, es saber a que le damos click, en unity sale un rayo de la camara que va a un punto el cual es el collider del objeto (celda)
            if (selectedCell != null) //si la celda no es nula
            {
                if (phase == GamePhase.PUT) //si se esta en la primera fase 
                {
                    putToken(selectedCell.transform.parent.gameObject); //hace la llamada de colocar pieza
                }
                else if (phase==GamePhase.MOVE) //cuando este en la fase de movimiento
                {

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

    private void updatePhase() //se act la fase cuando se colocan las 18 piezas
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
                Token token = newToken.GetComponent<Token>(); //se saca la componente del script del objeto instanciado, para que la ficha tenga las variables actualizadas
                token.cell = cell; // se act la casilla en la que se encuentra esa pieza
                token.color = Status.WHITE; //se act el color
                turn = Status.BLACK; //se pasa el turno a black
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
            board.totalTokens++; //cuando se llega a 18 se cambia de fase
        }
        else
        {
            Instantiate(occupiedCellSound);
        }
    }


    public void restartBoard() //reiniciar el tablero 
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
