import React from 'react';
import Header from "./header";
import './headerProfessor.css';

function HeaderProfessor() {
    return (
        <div>
            <Header />
            <div>
                <button id="inicio">Inicio</button>
                <div id="linha-init"></div>
                <button id="cursos">Cursos</button>
                <div id="linha-cu"></div>
                <button id="editarCursos">Editar Cursos</button>
                
            </div>
        </div>
    );
}

export default HeaderProfessor;
