import HeaderProfessor from "./HeaderProfessor.jsx";
import './TelaHistoricoCursos.css'
import axios from "axios";
import Curso from "./Curso.jsx";
import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
function TelaHistoricoCursos(){
    
    

    const navigate = useNavigate();


    const [eventos, setEventos] = useState([]);
    useEffect(() =>{
            const fetchEventos = async () => {
                try {
                    const response = await axios.get("http://localhost:5077/api/evento");
                    setEventos(response.data);
                    
                } catch (error) {
                    console.error("Erro ao buscar eventos:", error);
                    
                }
            };
            fetchEventos();
        }, [])
    return(
        <div>
            <HeaderProfessor/>
            <div>
                <h3 id="historiocurso">Gerenciamento de cursos</h3>
                <input type="text" placeholder="Pesquisar" id="pesq-bar" />
        <button id="pesquisa">
            <img src="images\lupa.png" height="15px"></img>
            </button>
        <button id="criar" onClick={() => navigate('/AdicionarCurso')}>Criar Curso</button>
            </div>
            <ul>
                {eventos.map((evento) => (
                    <div key={evento.id}>
                        <Curso titulo = {evento.nome} data = {evento.data} hora = {evento.hora} vagas = {evento.qtdMaximaParticipantes} id = {evento.id}/>        
                    </div>
                ))}
            </ul>
        </div>
        
    )

}
export default TelaHistoricoCursos