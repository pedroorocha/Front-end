import './InscriçãoCurso.css'
import HeaderProfessor from "./HeaderProfessor";
import './TelaCursoAndamento.css'
import { useLocation } from 'react-router-dom';
import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import axios from "axios";

function InscriçãoCurso(){
    
    const location = useLocation();
    const { id } = location.state || {};
    const {matricula} = location.state || {};
    

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

        
            const inscreverser = async () => {
                
                try {  
                  const response = await axios.post(`http://localhost:5077/api/cadastro/subscribe?matricula=${matricula}&eventoId=${id}`);
                  console.log("Dados enviados com sucesso:", response.data);
                  alert("inscrição realizada com sucesso!")
                } catch (error) {
                    alert("falhou")
                  console.error("Erro ao enviar os dados:", error);
                }
              };
        

    return(
        
        <div>            
            <div id="inscrição">

            <div> 
                    
                    <h3 id="titulodocurso">{evento.nome}</h3>
                    <p id="informações"><strong>Vagas: {evento.qtdMaximaParticipantes} | Horas complementares: {evento.horasComplementares}</strong></p>
                    <p id="informações">{evento.data} | {evento.hora}</p>
                    <p id="informações">Ministrado por: {evento.palestrantes}</p>
                    <p id="descrição"><strong>Descrição:</strong></p>
                    <p id="texto">{evento.descricao}</p>
                    
                    </div>

                <button id="inscreverse" onClick={inscreverser}>inscrever-se</button>
            </div>
        </div>
        
    )
}
export default InscriçãoCurso