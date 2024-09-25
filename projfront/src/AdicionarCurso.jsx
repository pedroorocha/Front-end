import React, { useState } from "react";
import HeaderProfessor from "./HeaderProfessor.jsx";
import './AdicionarCurso.css'
import axios from "axios";



function AdicionarCurso(){

    const[titulo, setTitulo] = useState("");
    const[categoria, setCategoria] = useState("");
    const[tema, setTema] = useState("")
    const[descrição, setDescriçao] = useState("")
    //const[tipo, setTipo] = useState("")
    //const[modalidade, setModalidade] = useState("")
    const[vagas, setVagas] = useState("")
    const[horas, setHoras] = useState("")
    const[data, setData] = useState("")
    const[ano, mes, dia] = data.split('-');
    const dataFormatada = `${dia}/${mes}/${ano}`;
    const[palestrantes, setPalestrantes] = useState("")
    const[horaCompl, setHorasCompl] = useState("")
    

    const handleClick = async () => {
        const dados = {
          id: 0,
          nome: titulo,
          categoria: categoria,
          tema: tema,
          data: dataFormatada,
          hora: horas,
          horasComplementares: horaCompl,
          qtdMaximaParticipantes: vagas,
          palestrantes: palestrantes,
          descricao: descrição,
        };
    
        try {
          
          const response = await axios.post("http://localhost:5077/api/evento", dados);
          console.log("Dados enviados com sucesso:", response.data);
          alert("Trabalho realizado com sucesso!")
        } catch (error) {
          console.error("Erro ao enviar os dados:", error);
        }
      };

    return (
        <div>
            <HeaderProfessor/>
            <div>
                
                <h3 id="Add">Adicionar Novo Curso/Editar Curso</h3>  
                <input id="titulo" placeholder="Titulo" type="text" onChange={(e) => setTitulo(e.target.value)} ></input>

                <input id="titulo" placeholder="Categoria" type="text" onChange={(e) => setCategoria(e.target.value)} ></input>
                <input id="titulo" placeholder="Tema" type="text" onChange={(e) => setTema(e.target.value)}></input>
                <br></br>
                <textarea type="text" id="desc" placeholder="Descrição do Curso" onChange={(e) => setDescriçao(e.target.value)} />
                <br></br>
                <input type="date" id="data" onChange={(e) => setData(e.target.value)}></input>
                <input type="time" id="qtd" placeholder='horarios' onChange={(e) => setHoras(e.target.value)}/>
                <input type="number" id="qtd" placeholder="Qntd.de Vagas" onChange={(e) => setVagas(e.target.value)} />
                <input type="text" id="qtd" placeholder="Horas Complementares" onChange={(e) => setHorasCompl(e.target.value)} />
                <input type="text" id="qtd" placeholder="palestrantes" onChange={(e) => setPalestrantes(e.target.value)}/>
                <br></br>
                <br></br>
                <br></br>
                <button id="confimar" onClick={handleClick}>Confirmar e voltar</button>
                
            </div>   
        </div>
        
    )
}
export default AdicionarCurso