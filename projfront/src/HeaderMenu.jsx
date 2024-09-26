import Header from "./header";
import InfoUsuarios from "./InfoUsuarios";
import './HeaderMenu.css'
import { Router, useNavigate } from "react-router-dom";
import { useLocation } from "react-router-dom";
function HeaderMenu(props){

    const navigate = useNavigate()

    function handleClick(){
        navigate('/InfoUsuarios',{state:{matricula:matricula}})
    }
    const matricula = props.matricula
    return(
        <div>
            <Header/>
            <div>
                <button id="inicio">Inicio</button>
                <div id="linha-init"></div>
                <button id="cursos">Cursos</button>
                <div id="linha-cu"></div>
                <button id="meusCursos" onClick={handleClick}>Meus Dados</button>
            </div>

            </div>

    )

} 
export default HeaderMenu