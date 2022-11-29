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

    private bool isWaitingForClick, canRemoveToken;
    private LayerMask layerToken, layerCell;
    private GameObject selectedObject, selectedCell, selectedToken, newToken;

    private void Start() //se ejecuta al inicio de la escena
    {
        turn = Status.WHITE; //el primer turno, que es el blanco
        phase = GamePhase.PUT; //primera fase que es colocar piezas
        isWaitingForClick = false;
        layerToken = LayerMask.NameToLayer("Tokens");
        layerCell = LayerMask.NameToLayer("Cells");
    }

    private void Update() //se ejecuta 1 vez por cada frame, depende de cada computadora
    {
        if (Input.GetButtonDown("Fire1") && !isWaitingForClick) // get button dar click y fire 1 es click izquierdo
        {
            selectedObject = getObjectOnClick(); //getObjectOnClick es saber a que le damos click, en unity sale un rayo de la camara que va a un punto el cual es el collider del objeto (celda)
            if (selectedObject != null) //si el objeto no es nulo
            {
                if (selectedObject.layer == layerCell) // Si se selecciona el collider de una casilla
                {
                    selectedCell = selectedObject.transform.parent.gameObject;

                    if (phase == GamePhase.PUT)
                    {
                        putToken(selectedCell);
                        canRemoveToken = verifyMill(selectedCell); //si se ha creado un molino
                        updateTurn();
                    }
                    else if (phase == GamePhase.MOVE)
                    {
                        Instantiate(occupiedCellSound);
                    }

                    if (canRemoveToken)
                    {
                        isWaitingForClick = true; //espera que se de click
                        StartCoroutine(removeToken()); //una corutina que remueve la ficha 
                    }
                }
                else if (selectedObject.layer == layerToken) // Si se selecciona el collider de una ficha
                {
                    selectedToken = selectedObject;
                    Token token = selectedToken.GetComponent<Token>();
                    if (phase == GamePhase.PUT)
                    {
                        Instantiate(occupiedCellSound);
                    }
                    else if (phase == GamePhase.MOVE)
                    {
                        if (token.color == turn)
                        {
                            isWaitingForClick = true;
                            StartCoroutine(moveToken(selectedToken));
                        }
                        else
                        {
                            Instantiate(occupiedCellSound);
                        }
                    }
                }
                updatePhase();
            }
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

    private void updatePhase() //se actualiza la fase cuando se colocan las 18 piezas
    {
        if (board.totalTokens == 18) //si se colocan las 18 fichas
        {
            phase = GamePhase.MOVE; //pasa a la fase de mover fichas
        }
        
        if (phase == GamePhase.MOVE)
        {
            endGame();
        }
    }

    private void updateTurn() //se actualiza el turno
    {
        if (turn == Status.WHITE)
            turn = Status.BLACK;
        else if (turn == Status.BLACK)
            turn = Status.WHITE;
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
                board.whiteTokens.Add(token);
                cell.token = token;
                token.cell = cell; // se actualiza la casilla en la que se encuentra esa pieza
                token.color = Status.WHITE; //se actualiza el color
                board.numWhiteTokens++;
            }
            else if (turn == Status.BLACK) //si el turno es del jugador negro
            {
                cell.status = Status.BLACK;
                newToken = Instantiate(blackToken, position, Quaternion.identity);
                newToken.transform.parent = referenceToken.transform;
                Token token = newToken.GetComponent<Token>(); //se saca la componente del script del objeto instanciado, para que la ficha tenga las variables actualizadas
                board.blackTokens.Add(token);
                cell.token = token;
                token.cell = cell; //se actualiza la casilla en la que se encuentra esa pieza
                token.color = Status.BLACK; //se actualiza el color
                board.numBlackTokens++;
            }
            board.totalTokens++; //cuando se llega a 18 que son el total de fichas a colocar, se cambia de fase, a la fase de movimiento
        }
        else
        {
            Instantiate(occupiedCellSound); //si la celda no esta vacia entonces se instancia el sonido de error
        }
    }

    private IEnumerator moveToken(GameObject selectedToken)
    {
        Cell cell2 = selectedCell.GetComponent<Cell>();
        Token token = selectedToken.GetComponent<Token>();
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            if (Input.GetButtonDown("Fire1")) //cuando se da click
            {
                selectedObject = getObjectOnClick(); //selecciona el objeto
                if (selectedObject != null && selectedObject.layer == layerCell) //si es diferente de null y la capa pertenece a la capa cells, o sea si es una celda
                {
                    if (token.cell.neighbors.Contains(cell2))
                    {
                        if (cell2.status == Status.EMPTY)
                        {
                            selectedToken.transform.position = cell2.transform.position;
                            yield break;
                        }
                    }
                }
            }
            yield return null;
        }
    }

    private IEnumerator removeToken() //remover ficha
    {
        List<Token> listTokens = turn == Status.WHITE ? board.blackTokens : board.whiteTokens;
        List<Token> candidateTokens = new List<Token>();
        foreach (Token token in listTokens)
        {
            if (!token.isPartOfMill())
                candidateTokens.Add(token);
        }
        if (candidateTokens.Count == 0)
            candidateTokens = listTokens;

        yield return new WaitForSeconds(0.5f); //espera 0.5 seg para recien realizar y evitar que detecte el mismo click
        while (true)
        {
            if (Input.GetButtonDown("Fire1")) //cuando se da click
            {
                selectedObject = getObjectOnClick(); //selecciona el objeto
                if (selectedObject != null && selectedObject.layer == layerToken) //si es diferente de null y la capa pertenece a la capa ficha, o sea si es una ficha (ya que se tienen 2 colliders, celda y ficha)
                {
                    Token token = selectedObject.GetComponent<Token>(); //obtiene el token
                    Cell cell = token.cell; //obtiene el cell
                    if (candidateTokens.Contains(token)) //si el color de la ficha seleccionada es diferente a la del turno
                    {
                        cell.status = Status.EMPTY;
                        cell.token = null;
                        verifyMill(cell.gameObject);
                        if (turn == Status.WHITE)
                        {
                            board.blackTokens.Remove(token);
                            board.numBlackTokens--;
                        }

                        else if (turn == Status.BLACK)
                        {
                            board.whiteTokens.Remove(token);
                            board.numWhiteTokens--;
                        }
                        Destroy(selectedObject);
                        isWaitingForClick = false;
                        updateTurn();
                        yield break;
                    }
                }
            }

            yield return null;
        }
    }

    private void endGame()
    {
        if (board.numWhiteTokens == 2)
            Debug.Log("El ganador es el negro.");
        else if (board.numBlackTokens == 2)
            Debug.Log("El ganador es el blanco.");
    }

    private bool verifyMill(GameObject selectedCell) //verifica molino
    {
        Cell cell = selectedCell.GetComponent<Cell>();
        bool millCreated = false;

        foreach (Mill mill in cell.mills)
        {
            Status status = mill.isComplete();
            if (status != Status.EMPTY)
            {
                millCreated = true;
            }
        }

        return millCreated;
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

        foreach (Mill mill in board.mills)
        {
            mill.isComplete();
        }

        board.totalTokens = 0;
        turn = Status.WHITE;
    }


}
