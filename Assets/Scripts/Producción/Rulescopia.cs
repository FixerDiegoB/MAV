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
    [HideInInspector]
    public Status turn;
    public GamePhase phase;
    private GameObject selectedCell, newToken;

    private void Start() //se ejecuta al inicio de la escena
    {
        turn = Status.WHITE; //el primer turno, que es el blanco
        phase = GamePhase.PUT; //primera fase que es colocar piezas
    }
    
    private void Update() //se ejecuta 1 vez por cada frame, depende de cada computadora
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
                //seria u flujo con dos estados, un flujo es cuando doy click y el otro cuando aun no le doy click a nada, dos estados, cuandos e da click se verifica que se vaya a hacer un mov y dsp de hacer el mov termina la 
                //etapa de mov, dentro de la func de mov zetear que el estado no ha acabado el mov
 /*               else if (phase == GamePhase.MOVE)//si esta en la fase de movimiento
                {
                    Token token = selectedCell.GetComponent<Token>();
                    if (Cell.token != null)
                    {
                        moveToken(selectedCell.transform.parent.gameObject);
                    }

                }*/
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
