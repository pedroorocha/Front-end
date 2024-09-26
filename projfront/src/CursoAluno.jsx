import HeaderMenu from "./HeaderMenu"
import './Curso.css'
import { Navigate, useNavigate } from "react-router-dom";
import { useEffect } from "react";
function Curso(props){
    const navigate = useNavigate();
    function andamento(){
        navigate('/TelaInscriçãoCurso', {state: {id: id, matricula:matricula}})
    };
    const id = props.id;
    const matricula = props.matricula
    return(
        <div>
            <div id="C">
                <p id="infocurso"><strong>{props.titulo}</strong></p>
                <p id="infocurso">{props.data}</p>
                <p id="infocurso">{props.hora}</p>
                <p id="infocurso">Vagas: {props.vagas}</p>
                <button id="vercurso" value={props.id} onClick={andamento}>Ver curso</button>
                
            </div> 
            </div>
        
    )
}export default Curso