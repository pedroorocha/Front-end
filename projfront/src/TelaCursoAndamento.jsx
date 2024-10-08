import { Route } from "react-router-dom";
import HeaderProfessor from "./HeaderProfessor";
import './TelaCursoAndamento.css'
import { useLocation } from 'react-router-dom';
import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import axios from "axios";

function TelaCursoAndamento(){
    const navigate = useNavigate();
    const location = useLocation();
    const { id } = location.state || {};

    const [evento, setEvento] = useState([]);
    useEffect(() =>{
            const fetchEventos = async () => {
                try {
                    const response = await axios.get(`http://localhost:5077/api/evento/${id}`);
                    setEvento(response.data);
                
                    
                } catch (error) {
                    console.error("Erro ao buscar eventos:", error);
                    
                }
            };
            fetchEventos();
        }, [])

        const handleClick=()=>{
            navigate("/TelaListaPresença", {state:{id: id}})
        }

    return (

        <div>
            <HeaderProfessor/>
            <button id="lista" onClick={handleClick}>Lista Alunos</button>
            <div id="inscrição">
                    <div> 
                    <h3 id="titulodocurso">{evento.nome}</h3>
                    <p id="informações"><strong>Vagas: {evento.qtdMaximaParticipantes} | Horas complementares: {evento.horasComplementares}</strong></p>
                    <p id="informações">{evento.data} | {evento.hora}</p>
                    <p id="informações">Ministrado por: {evento.palestrantes}</p>
                    <p id="descrição"><strong>Descrição:</strong></p>
                    <p id="texto">{evento.descricao}</p>
                    </div>
                <button id="editar">Editar curso</button>
            </div>
            
        </div>


    )
}
export default TelaCursoAndamento