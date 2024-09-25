import Header from "./header";
import './TelaInicial.css'
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Login from "./Login";
function TelaInicial(){

    const [paginaSelecionada, setPaginaSelecionada] = useState("")
    const navigate = useNavigate();
    
    const categoriaSelecionada = (event) => {
        const { id } = event.target;
        if (id === "aluno") {
            setPaginaSelecionada("TelaCursos");
        } else if (id === "professor") {
            setPaginaSelecionada("TelaHistoricoCursos");
        }
    };

      const handleButtonClick = () => {
        if (paginaSelecionada) {
          navigate(`/${paginaSelecionada}`);
        } else {
          alert("Por favor, selecione uma opção.");
        }
      };

    return(
        <div>
                <Header/>
                <p id="email">E-mail: </p>
                <input id="imp_email" type="text" />
                <hr id="line1"/>
                <p id="senha">Senha: </p>
                <input id="imp_senha" type="password" />
                <hr id="line2"/>
                <a id='esqu' href='exemplo.com'>Esqueceu sua senha?</a>
                <br></br>
                <h1><strong>BEM-VINDO!</strong></h1>
                <br></br>
                <hr id="line2"/>
                <br></br>
                <label>Aluno:</label>
                <input
                type="checkbox"
                id="aluno"
                onChange={categoriaSelecionada}
                checked={paginaSelecionada === "TelaCursos"}
            />
                <label>Professor:</label>
                <input
                type="checkbox"
                id="professor"
                onChange={categoriaSelecionada}
                checked={paginaSelecionada === "TelaHistoricoCursos"}
            />
                <button id='entrar' type='button' onClick={handleButtonClick}>Entrar</button>
                <button id='cadastrar' type='button'>Cadastrar</button>
                
            </div>
    )
}
export default TelaInicial