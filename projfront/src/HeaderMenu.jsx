import Header from "./header";
import './HeaderMenu.css'

function HeaderMenu(){

    return(
        <body>
            <Header/>
            <div>
                <button id="inicio">Inicio</button>
                <div id="linha-init"></div>
                <button id="cursos">Cursos</button>
                <div id="linha-cu"></div>
                <button id="meusCursos">Meus Cursos</button>
            </div>

        </body>

    )

} 
export default HeaderMenu