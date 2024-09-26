import Header from "./header";
import './TelaCadastro.css'
import axios from "axios";
import React, { useState } from "react";

function TelaCadastro(){

    const[matricula, setMatricula] = useState("")
    const[senha, setSenha] = useState("")
    const[email, setEmail] = useState("")
    const[nome, setNome] = useState("")
    const[cpf, setCpf] = useState("")
    const[curso, setCurso] = useState("")
    const[date, setData] = useState("")
    const[ano, mes, dia] = date.split('-');
    const dataFormatada = `${dia}/${mes}/${ano}`;
    const[telefone, setTelefone] = useState("")
    const[senhaRep, setSenhaRep] = useState("")
    const senhaString = senha.toString()
    function vericaSenha(){
        if(setSenha == setSenhaRep){
            return true
        }else{
            return false
        }
    }

    const handleClick = async () => {
        const dados = {
            matricula: matricula, 
            email: email, 
            senha: senhaString,
            nome: nome,
            cpf: cpf,
            curso: curso,
            dataDeNascimento: dataFormatada,
            telefone: telefone
        }
        if(vericaSenha){
            try {
                const response = await axios.post("http://localhost:5077/api/aluno", dados);
                console.log("Dados enviados com sucesso:", response.data);
                alert("Cadastro realizado com sucesso!")
              } catch (error) {
                alert("erro!")
                console.error("Erro ao enviar os dados:", error);
              }
        }else{
            alert("As senhas estão diferentes!")
        }
    }

    return(
        <div>
            <Header/>
            <div>
                <h1 id="cad">CADASTRAR</h1>
                <label id="dados" >Matricula:</label>
                <input id="matr" type="text" placeholder="matricula" onChange={(e)=> setMatricula(e.target.value)} required></input>
                <br/>
                <label id="dados">E-mail:</label>
                <input id="e-mail" type="text" placeholder="E-mail" onChange={(e)=> setEmail(e.target.value)} required></input>
                <br/>
                <label id="dados">Senha:</label>
                <input id="pass" type="password" placeholder="Senha" onChange={(e)=> setSenha(e.target.value)} required></input>
                <br/>
                <label id="dados">Confirmar senha:</label>
                <input id="csenha" type="password" placeholder="Confirme a senha" onChange={(e)=> setSenhaRep(e.target.value)} required></input>
                <br/>
                <label id="dados">Nome:</label>
                <input id="nome" type="text" placeholder="Nome" onChange={(e)=> setNome(e.target.value)} required></input>
                <br/>
                <label id="dados">CPF:</label>
                <input id="cpf" type="text" placeholder="CPF" onChange={(e)=> setCpf(e.target.value)} required></input>
                <br/>
                <label id="dados">Curso:</label>
                <input id="curso" type="text" placeholder="Curso" onChange={(e)=> setCurso(e.target.value)} required></input>
                <br/>
                <label id="dados">Data de nascimento:</label>
                <input id="date" type="date" placeholder="Data de nascimento" onChange={(e)=> setData(e.target.value)} required></input>
                <br/>
                <label id="dados">Número:</label>
                <input id="tel" type="tel" placeholder="(XX) XXXXX-XXXX" pattern="\(\d{2}\) \d{5}-\d{4}" onChange={(e)=> setTelefone(e.target.value)} required></input>
                
            </div>
            <button id="cada" onClick={handleClick}>Cadastrar-se</button>
        </div>
        
    )
}
export default TelaCadastro