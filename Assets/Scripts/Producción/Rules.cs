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
    public Status turn;
    [HideInInspector]
    public GamePhase phase;
    private GameObject selectedObject, selectedCell, selectedToken, newToken;

    private void Start() //se ejecuta al inicio de la escena
    {
        turn = Status.WHITE; //el primer turno, que es el blanco
        phase = GamePhase.PUT; //primera fase que es colocar piezas
    }

    private void Update() //se ejecuta 1 vez por cada frame, depende de cada computadora
    {
        if (Input.GetButtonDown("Fire1")) // get button dar click y fire 1 es click izquierdo
        {
            selectedObject = getObjectOnClick(); //getCellOnClick linea 40, es saber a que le damos click, en unity sale un rayo de la camara que va a un punto el cual es el collider del objeto (celda)
            if (selectedObject != null) //si la celda no es nula
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
                        if (Input.GetButtonDown("Fire1")) //si damos click izquierdo
                        {
                            selectedCell = getObjectOnClick();
                            if (selectedCell = null) //si la celda es nula
                            {
                                moveToken(selectedCell.transform.parent.gameObject); //hace la llamada a mover la pieza
                            }

                        }
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

    private void updatePhase() //se act la fase cuando se colocan las 18 piezas
    {
        if (board.totalTokens == 18)
        {
            phase = GamePhase.MOVE;
        }
    }

    private void moveToken(GameObject selectedCell)
    {
        
    }
    private void putToken(GameObject selectedCell) //para poner una ficha
    {
        Cell cell = selectedCell.GetComponent<Cell>();
        if (cell.status == Status.EMPTY)  //si la celda está vacia 
        {
            Vector3 position = selectedCell.transform.position;
            position = new Vector3(position.x, height, position.z);
            if (turn == Status.WHITE) //si el turno es del jugador blanco
            {
                cell.status = Status.WHITE;
                newToken = Instantiate(whiteToken, position, Quaternion.identity);
                newToken.transform.parent = referenceToken.transform;
                Token token = newToken.GetComponent<Token>(); //se saca la componente del script del objeto instanciado, para que la ficha tenga las variables actualizadas
                // token.rules = this;
                cell.token = token;
                token.cell = cell; // se actualiza la casilla en la que se encuentra esa pieza
                token.color = Status.WHITE; //se actualiza el color
                turn = Status.BLACK; //se pasa el turno a black
            }
            else if (turn == Status.BLACK) //si el turno es del jugador negro
            {
                cell.status = Status.BLACK;
                newToken = Instantiate(blackToken, position, Quaternion.identity);
                newToken.transform.parent = referenceToken.transform;
                Token token = newToken.GetComponent<Token>(); //se saca la componente del script del objeto instanciado, para que la ficha tenga las variables actualizadas
                cell.token = token;
                token.cell = cell; //se actualiza la casilla en la que se encuentra esa pieza
                token.color = Status.BLACK; //se actualiza el color
                turn = Status.WHITE; //se cambia el turno a white
            }
            board.totalTokens++; //cuando se llega a 18 que son el total de fichas a colocar, se cambia de fase, a la fase de movimiento
        }
        else
        {
            Instantiate(occupiedCellSound); //si la celda no esta vacia entonces se instancia el sonido de error
        }
    }

    private bool verifyMill(GameObject selectedCell)
    {
        Cell cell = selectedCell.GetComponent<Cell>();

        foreach (Mill mill in cell.mills)
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
