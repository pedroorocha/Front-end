import HeaderMenuVolta from "./HeaderMenuVoltar"
import CursoAluno from "./CursoAluno.jsx"
import './TelaCursos.css'
import axios from "axios";
import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";

function TelaCursos(){

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
        <HeaderMenuVolta/>
        <div>
        <input type="text" placeholder="Pesquisar" id="pesq" />
        <button id="pesquisa">
            <img src="images\lupa.png" height="15px"></img>
            </button>
        </div>
        <ul>
                {eventos.map((evento) => (
                    <div key={evento.id}>
                        <CursoAluno titulo = {evento.nome} data = {evento.data} hora = {evento.hora} vagas = {evento.qtdMaximaParticipantes} id = {evento.id}/>        
                    </div>
                ))}
            </ul>
    </div>
    )
}
export default TelaCursos