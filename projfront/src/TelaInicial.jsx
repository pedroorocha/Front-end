import Header from "./header";
import './TelaInicial.css'
import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import Login from "./Login";
import { useLocation } from "react-router-dom";
import axios from "axios";
function TelaInicial(){

    const [paginaSelecionada, setPaginaSelecionada] = useState("")
    const navigate = useNavigate();
    const [matricula, setMatricula] = useState("")
      
    const categoriaSelecionada = (event) => {
        const { id } = event.target;
        if (id === "aluno") {
            setPaginaSelecionada("TelaCursos");
        } else if (id === "professor") {
            setPaginaSelecionada("TelaHistoricoCursos");
        }
    };

      const abreCadastro = () =>{
        navigate("/TelaCadastro")
      }
    
      const [dados, setDados] = useState("")
      
      
      const handleButtonClick = () => {
        if (paginaSelecionada) {
          navigate(`/${paginaSelecionada}`, {state:{matricula: matricula}});
          
        } else {
          alert("Por favor, selecione uma opção.");
        }
      };

      
        
    
    return(
        <div>
                <Header/>
                <p id="email">Matricula:</p>
                <input id="imp_email" type="text" onChange={(e) => setMatricula(e.target.value)}/>
                <hr id="line1"/>
                <p id="senha">Senha: </p>
                <input id="imp_senha" type="password" onChange={(e) => setSenha(e.target.value)} />
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
                <button id='cadastrar' type='button' onClick={abreCadastro}>Cadastrar</button>
                
            </div>
    )
}
export default TelaInicial