import HeaderProfessor from "./HeaderProfessor";
import './TelaListaPresença.css'
import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import axios from "axios";
function TelaListaPresença(){
    const [listaAlunos, setListaALunos] = useState([ ])
    const location = useLocation();
    const [listaPresença, setListaPresença] = useState ([ ])
    const { id } = location.state || {};

    const Checked = (event) => {
        if (event.target.checked) {
            // Adiciona a matrícula se o checkbox estiver marcado
            setListaPresença([...listaPresença, event.target.value]);
        } else {
            // Remove a matrícula se o checkbox for desmarcado
            setListaPresença(listaPresença.filter(matricula => matricula !== event.target.value));
        }
    };



    useEffect(() =>{
        const fetchAlunos = async () => {
            try {
                const response = await axios.get(`http://localhost:5077/api/aluno/evento/${id}`);
                setListaALunos(response.data);
                
            } catch (error) {
                console.error("Erro ao buscar eventos:", error);
                
            }
        };
        fetchAlunos();
    }, [])


    const fetchPresença = async () => {
        try {
            const response = await axios.post(`http://localhost:5077/api/presenca/checkout?eventoId=${id}`, listaPresença);
            alert('Presenças comfimadas!')
        } catch (error) {
            console.error("Erro:", error);
            
        }
    };

    return(
        <div>
            <HeaderProfessor/>
            <div id="listapre">
                <h3 id="titulo">Lista dos Alunos para receber o certificado:</h3>
                <br></br>
                
            <button id="presença" onClick={fetchPresença}>Confirmar presença</button>
                <br></br>
            </div>
            
                {listaAlunos.map((aluno) =>(
                    <div id="nomes">
                        <input type="checkbox" id="check" value={aluno.matricula} onChange={Checked} />
                        <p >{aluno.nome}</p>
                        
                        <br></br>

                    </div>
                ))}
                  
                
        </div>
        
    )

}
export default TelaListaPresença