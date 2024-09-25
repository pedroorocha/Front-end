import HeaderProfessor from "./HeaderProfessor";
import './TelaListaPresença.css'

function TelaListaPresença(){

    return(
        <div>
            <HeaderProfessor/>
            <div>
                <h3 id="titulo">Lista dos Alunos para receber o certificado:</h3>
                <br></br>
                <input id="nomealuno" type="text" placeholder="Nome Do Aluno" />
                <button id="presença">Confirmar presença</button>
                <br></br>
                <form action="#">
                    <input type="checkbox" id="opção" name="aluno1"></input>
                    <label For="opção1" id="opção">Aluno1</label><br></br>
                    <input type="checkbox" id="opção" name="aluno1"></input>
                    <label For="opção1" id="opção">Aluno2</label><br></br>
                    <input type="checkbox" id="opção" name="aluno1"></input>
                    <label For="opção1" id="opção">Aluno3</label><br></br>
                    <input type="checkbox" id="opção" name="aluno1"></input>
                    <label For="opção1" id="opção">Aluno4</label><br></br>
                </form>
            </div>
        </div>
        
    )

}
export default TelaListaPresença